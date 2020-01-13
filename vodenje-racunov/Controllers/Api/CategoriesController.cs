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
    public class CategoriesController : ApiController
    {
        private ApplicationDbContext _context;

        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/categories
        public IHttpActionResult GetProducts()
        {
            var productDtos = _context.Categories
                .ToList()
                .Select(Mapper.Map<Category, CategoryDto>);

            return Ok(productDtos);
        }

        //GET /api/categories/1
        public IHttpActionResult GetCategory(int id)
        {

            var category = _context.Categories.SingleOrDefault(p => p.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Category, CategoryDto>(category));
        }

        //POST /api/categories
        //[Authorize(Roles = RoleName.CanManageInvoices)]
        [HttpPost]
        public IHttpActionResult CreateCategroy(CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var category = Mapper.Map<CategoryDto, Category>(categoryDto);
            _context.Categories.Add(category);
            _context.SaveChanges();

            categoryDto.CategoryId = category.CategoryId;

            return Created(new Uri(Request.RequestUri + "/" + category.CategoryId), categoryDto); 
        }


        //update product
        //PUT /api/categories/1
        //[Authorize(Roles = RoleName.CanManageInvoices)]
        [HttpPut]
        public void UpdateCategory(int id, CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var categoryinDb = _context.Categories.SingleOrDefault(p => p.CategoryId == id);

            if (categoryinDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map<CategoryDto, Category>(categoryDto, categoryinDb);

            _context.SaveChanges();
        }

        //DELETE /api/categories/1
        //[Authorize(Roles = RoleName.CanManageInvoices)]
        [HttpDelete]
        public void DeleteCategory(int id)
        {
            var categoryInDb = _context.Categories.SingleOrDefault(p => p.CategoryId == id);

            if (categoryInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Categories.Remove(categoryInDb);
            _context.SaveChanges();
        }
    }
}
