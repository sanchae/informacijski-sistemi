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
    public class ManufacturersController : ApiController
    {
        private ApplicationDbContext _context;

        public ManufacturersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/manufacturers
        public IHttpActionResult GetManufacturers()
        {
            var manufacturersDto = _context.Manufacturers
                .Include(p => p.Country)
                .ToList()
                .Select(Mapper.Map<Manufacturer, ManufacturerDto>);

            return Ok(manufacturersDto);
        }

        //GET /api/manufacturers/1
        public IHttpActionResult GetMenufacturer(int id)
        {
            var manufacturer = _context.Manufacturers.SingleOrDefault(p => p.ManufacturerId == id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Manufacturer, ManufacturerDto>(manufacturer));
        }

        //POST /api/manufacturers
        //[Authorize(Roles = RoleName.CanManageInvoices)]
        [HttpPost]
        public IHttpActionResult CreateManufacturer(ManufacturerDto manufacturerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var manufacturer = Mapper.Map<ManufacturerDto, Manufacturer>(manufacturerDto);
            _context.Manufacturers.Add(manufacturer);
            _context.SaveChanges();

            manufacturerDto.ManufacturerId = manufacturer.ManufacturerId;

            return Created(new Uri(Request.RequestUri + "/" + manufacturer.ManufacturerId), manufacturerDto); 
        }


        //update product
        //PUT /api/manufacturers/1
        //[Authorize(Roles = RoleName.CanManageInvoices)]
        [HttpPut]
        public void UpdateManufacturer(int id, ManufacturerDto manufacturerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var manufactureresInDb = _context.Manufacturers.SingleOrDefault(p => p.ManufacturerId == id);

            if (manufactureresInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map<ManufacturerDto, Manufacturer>(manufacturerDto, manufactureresInDb);

            _context.SaveChanges();
        }

        //DELETE /api/manufacturers/1
        //[Authorize(Roles = RoleName.CanManageInvoices)]
        [HttpDelete]
        public void DeleteManufacturer(int id)
        {
            var manufacturerInDb = _context.Manufacturers.SingleOrDefault(p => p.ManufacturerId == id);

            if (manufacturerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Manufacturers.Remove(manufacturerInDb);
            _context.SaveChanges();
        }
    }
}
