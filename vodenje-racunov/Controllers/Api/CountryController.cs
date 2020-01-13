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
    public class CountryController : ApiController
    {
        private ApplicationDbContext _context;

        public CountryController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/country
        public IHttpActionResult GetCountries()
        {
            var productDtos = _context.Countries
                .ToList()
                .Select(Mapper.Map<Country, CountryDto>);

            return Ok(productDtos);
        }


        //GET /api/country/1
        public IHttpActionResult GetCountries(int id)
        {

            var country = _context.Countries.SingleOrDefault(p => p.CountryId == id);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Country, CountryDto>(country));
        }

        //POST /api/country
        //[Authorize(Roles = RoleName.CanManageInvoices)]
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateCountry(CountryDto countryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var country = Mapper.Map<CountryDto, Country>(countryDto);
            _context.Countries.Add(country);
            _context.SaveChanges();

            countryDto.CountryId = country.CountryId;

            return Created(new Uri(Request.RequestUri + "/" + country.CountryId), countryDto);
        }


        //update product
        //PUT /api/categories/1
        //[Authorize(Roles = RoleName.CanManageInvoices)]
        [HttpPut]
        public void UpdateCategory(int id, CountryDto countryDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var countryInDb = _context.Countries.SingleOrDefault(p => p.CountryId == id);

            if (countryInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map<CountryDto, Country>(countryDto, countryInDb);

            _context.SaveChanges();
        }

        //DELETE /api/categories/1
        //[Authorize(Roles = RoleName.CanManageInvoices)]
        [HttpDelete]
        public void DeleteCountry(int id)
        {
            var countryInDb = _context.Countries.SingleOrDefault(p => p.CountryId == id);

            if (countryInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Countries.Remove(countryInDb);
            _context.SaveChanges();
        }
    }
}