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
    public class DocumentsController : ApiController
    {
        private ApplicationDbContext _context;

        public DocumentsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/documents
        public IHttpActionResult GetDocuments()
        {
            var documentDto = _context.Documents
                .Include(p => p.Client)
                //.Include(a => a.ArticleList)
                .ToList()
                .Select(Mapper.Map<Document, DocumentDto>);

            return Ok(documentDto);
        }

        //GET /api/documents/1
        public IHttpActionResult GetDocument(int id)
        {
            var document = _context.Documents.SingleOrDefault(p => p.DocumentId == id);

            if (document == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Document, DocumentDto>(document));
        }

        //POST /api/documents
        //[Authorize(Roles = RoleName.CanManageInvoices)]
        [HttpPost]
        public IHttpActionResult CreateDocument(DocumentDto documentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var document = Mapper.Map<DocumentDto, Document>(documentDto);
            _context.Documents.Add(document);
            _context.SaveChanges();

            documentDto.DocumentId = document.DocumentId;

            return Created(new Uri(Request.RequestUri + "/" + document.DocumentId), documentDto);
        }
        /* dodajanje
             {
        "clientId": 8,
        "offerDate": "2019-07-30T00:00:00",
        "offerValidityDays": 2,
        "offerDateOfOrder": null,
        "invoiceDate": null,
        "invoiceServiceFrom": null,
        "invoiceServiceUntil": null,
        "invoiceDateOfMaturity": null,
        "invoiceDateOfOrder": null,
        "deliveryNoteDate": null,
        "totalExcludingVAT": null,
        "discountPercent": 5,
        "discountAmount": null,
        "amountExcludingVAT": null,
        "amountIncludingVAT": null,
        "paidAmount": null
    }
         */

        //update document
        //PUT /api/documents/1
        //[Authorize(Roles = RoleName.CanManageInvoices)]
        [HttpPut]
        public void UpdateDocument(int id, DocumentDto documentDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var documentInDb = _context.Documents.SingleOrDefault(p => p.DocumentId == id);

            if (documentInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map<DocumentDto, Document>(documentDto, documentInDb);

            _context.SaveChanges();
        }
        /*update
         *     {
      "documentId": 11,
        "clientId": 8,
        "offerDate": "2019-07-25T00:00:00",
        "offerValidityDays": 2,
        "offerDateOfOrder": null,
        "invoiceDate": null,
        "invoiceServiceFrom": null,
        "invoiceServiceUntil": null,
        "invoiceDateOfMaturity": null,
        "invoiceDateOfOrder": null,
        "deliveryNoteDate": null,
        "totalExcludingVAT": null,
        "discountPercent": 10,
        "discountAmount": 500,
        "amountExcludingVAT": null,
        "amountIncludingVAT": null,
        "paidAmount": null
    }
         */

        //DELETE /api/documents/1
        //[Authorize(Roles = RoleName.CanManageInvoices)]
        [HttpDelete]
        public void DeleteDocuments(int id)
        {
            var documentInDb = _context.Documents.SingleOrDefault(p => p.DocumentId == id);
            var articles = _context.Articles.Where(p => p.DocumentId == id).ToList();

            if (documentInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            foreach(var article in articles)
            {
                _context.Articles.Remove(article);
            }

            _context.Documents.Remove(documentInDb);
            _context.SaveChanges();
        }
    }
}