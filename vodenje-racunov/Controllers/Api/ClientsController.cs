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
    public class ClientsController : ApiController
    {
        private ApplicationDbContext _context;

        public ClientsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/clients
        public IHttpActionResult GetClients()
        {
            var clientsDto = _context.Clients
                .Include(p => p.Country)
                .ToList()
                .Select(Mapper.Map<Client, ClientDto>);

            return Ok(clientsDto);
        }

        //GET /api/clients/1
        public IHttpActionResult GetClient(int id)
        {
            var client = _context.Clients.SingleOrDefault(p => p.Id == id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Client, ClientDto>(client));
        }

        //POST /api/clients
        //[Authorize(Roles = RoleName.CanManageInvoices)]
        [HttpPost]
        public IHttpActionResult CreateClient(ClientDto clientDto)
        {   
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var client = Mapper.Map<ClientDto, Client>(clientDto);
            _context.Clients.Add(client);
            _context.SaveChanges();

            clientDto.Id = client.Id;

            return Created(new Uri(Request.RequestUri + "/" + client.Id), clientDto);
        }


        //update product
        //PUT /api/clients/1
        //[Authorize(Roles = RoleName.CanManageInvoices)]
        [HttpPut]
        public void UpdateClient(int id, ClientDto clientDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var clientInDb = _context.Clients.SingleOrDefault(p => p.Id == id);

            if (clientInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map<ClientDto, Client>(clientDto, clientInDb);

            _context.SaveChanges();
        }


        //DELETE /api/clients/1
        //[Authorize(Roles = RoleName.CanManageInvoices)]
        [HttpDelete]
        public void DeleteClient(int id)
        {
            var clientInDb = _context.Clients.SingleOrDefault(p => p.Id == id);

            if (clientInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Clients.Remove(clientInDb);
            _context.SaveChanges();
        }
    }
}