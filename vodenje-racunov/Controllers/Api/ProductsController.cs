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
    public class ProductsController : ApiController
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/products
        public IHttpActionResult GetProducts()
        {
            //var productDtos = _context.Products
            //    .Include(p => p.Category)
            //    .Include(p => p.Manufacturer)
            //    .ToList()
            //    .Select(Mapper.Map<Product, ProductDto>);

            //return Ok(productDtos);

                var productDtos = _context.Products
                    .Include(p => p.Category)
                    .Include(p => p.Manufacturer)
                    .ToList()
                    .Select(Mapper.Map<Product, ProductDto>);

                return Ok(productDtos);
        }

        //GET /api/products/1
        public IHttpActionResult GetProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Product, ProductDto>(product));
        }

        //POST /api/products
        //[Authorize(Roles = RoleName.CanManageInvoices)]
        [HttpPost]
        public IHttpActionResult CreateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var product = Mapper.Map<ProductDto, Product>(productDto);
            _context.Products.Add(product);
            _context.SaveChanges();

            productDto.ProductId = product.ProductId;

            return Created(new Uri(Request.RequestUri + "/" + product.ProductId), productDto); 
        }


        //update product
        //PUT /api/products/1
        //[Authorize(Roles = RoleName.CanManageInvoices)]
        [HttpPut]
        public void UpdateProduct(int id, ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var productInDb = _context.Products.SingleOrDefault(p => p.ProductId == id);

            if (productInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map<ProductDto, Product>(productDto, productInDb);
            //productInDb.Name = productDto.Name;
            //productInDb.ShortName = productDto.ShortName;
            //productInDb.PurchasePrice = productDto.PurchasePrice;
            //productInDb.SellingPrice = productDto.SellingPrice;
            //productInDb.WarrantyInMonths = productDto.WarrantyInMonths;
            //productInDb.ManufacturerId = productDto.ManufacturerId;
            //productInDb.CategoryId = productDto.CategoryId;

            _context.SaveChanges();
        }

        //DELETE /api/product/1
        //[Authorize(Roles = RoleName.CanManageInvoices)]
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var productInDb = _context.Products.SingleOrDefault(p => p.ProductId == id);

            if (productInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Products.Remove(productInDb);
            _context.SaveChanges();
        }
    }
}
