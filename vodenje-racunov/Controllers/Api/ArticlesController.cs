using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using AutoMapper;
using System.Data.Entity;
using vodenje_racunov.Dtos;
using vodenje_racunov.Models;

namespace vodenje_racunov.Controllers.Api
{
    public class ArticlesController : ApiController
    {

        private ApplicationDbContext _context;

        public ArticlesController()
        {
            _context = new ApplicationDbContext();
        }


        //GET /api/articles
        public IHttpActionResult GetArticles()
        {
            var articleDto = _context.Articles
                //.Include(p => p.Document)
                .Include(r => r.Product)
                .ToList()
                .Select(Mapper.Map<Article, ArticleDto>);

            return Ok(articleDto);
        }

        //GET /api/articles/1
        public IHttpActionResult GetArticle(int id) //id je product id - dobi vse postavke za določen productId
        {
            var articles = _context.Articles
                .Include(p => p.Product)
                .Where(p => p.DocumentId == id)
                .ToList();

            if (articles.Count == 0)
            {
                return NotFound();
            }

            return Ok(articles);
        }

        [HttpPost]
        public void CreateArticle(List<ArticleDto> articleDtos)
        {
            List<ArticleDto> createdDtos = new List<ArticleDto>();
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            foreach(var articleDto in articleDtos)
            {
                var article = Mapper.Map<ArticleDto, Article>(articleDto);
                _context.Articles.Add(article);
                _context.SaveChanges();

                articleDto.ArticleId = article.ArticleId;
                createdDtos.Add(articleDto);
            }
        }
        //Uspešen post
        ////{
        //"documentId": 7,
        //"productId": 4,
        //"quantity":15,
        //"price": 500,
        //"discount": 0,
        //"taxRate": 9.5,
        //"assemblyPrice": 380
        //}


        //update article
        //PUT /api/articles/1
        //[Authorize(Roles = RoleName.CanManageInvoices)]
        [HttpPut]
        public void UpdateArticle(int id, ArticleDto articleDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var articleInDb = _context.Articles.SingleOrDefault(p => p.ArticleId == id);

            if (articleInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map<ArticleDto, Article>(articleDto, articleInDb);

            _context.SaveChanges();
        }
        /*uspešen put
         *     {
        "articleId": 12,
        "documentId": 7,
        "productId": 4,
        "quantity": 23,
        "price": 500,
        "discount": 0,
        "taxRate": 9.5,
        "assemblyPrice": 380
    }
         */


        //DELETE /api/articles/1
        //[Authorize(Roles = RoleName.CanManageInvoices)]
        [HttpDelete]
        public IHttpActionResult DeleteArticle(int id) //documentId - izbriše vse postavke tega dokumenta
        {
            var articlesInDb = _context.Articles
                .Include(p => p.Product)
                .Where(p => p.DocumentId == id)
                .ToList();

            if (articlesInDb.Count == 0)
            {
                return NotFound();
            }

            foreach (var article in articlesInDb)
            {
                _context.Articles.Remove(article);
            }

            //_context.Articles.Remove(articleInDb);
            _context.SaveChanges();

            return Ok();

        }
    }
}