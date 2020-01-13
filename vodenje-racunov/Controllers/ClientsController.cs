using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vodenje_racunov.Models;
using vodenje_racunov.ViewModels;

namespace vodenje_racunov.Controllers
{
    public class ClientsController : Controller
    {
        private ApplicationDbContext _context;

        public ClientsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public List<Client> GetClients()
        {
            var clients = new List<Client>();
            foreach (var client in _context.Clients.Include(c => c.Country))
            {
                clients.Add(client);
            }
            return clients;
        }

        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageInvoices))
            {
                return View("Index");
            }
            return View("ReadOnlyIndex");
        }

        public ActionResult Details(int id)
        {
            var client = GetClients().SingleOrDefault(p => p.Id == id);
            if (client == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }

        [Authorize(Roles = RoleName.CanManageInvoices)]
        public ActionResult Edit(int id)
        {
            var client = _context.Clients.SingleOrDefault(p => p.Id == id);

            if (client == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ClientFormViewModel()
            {
                Client = client,
                CountriesList = _context.Countries
            };

            return View("ClientForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageInvoices)]
        public ActionResult New()
        {
            var countries = _context.Countries.ToList();

            var newClient = new ClientFormViewModel()
            {
                CountriesList = countries
            };

            return View("ClientForm", newClient);
        }

        [Authorize(Roles = RoleName.CanManageInvoices)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ClientFormViewModel clientForm)
        {
            if (clientForm.Client.Id == 0)
            {
                _context.Clients.Add(clientForm.Client);
            }
            else
            {
                var clientInDb = _context.Clients.Single(p => p.Id == clientForm.Client.Id);

                clientInDb.Name = clientForm.Client.Name;
                clientInDb.Type = clientForm.Client.Type;
                clientInDb.RegistrationNumber = clientForm.Client.RegistrationNumber;
                clientInDb.Email = clientForm.Client.Email;
                clientInDb.PhoneNumber = clientForm.Client.PhoneNumber;
                clientInDb.taxNumber = clientForm.Client.taxNumber;
                clientInDb.taxPayer = clientForm.Client.taxPayer;
                clientInDb.StreetName = clientForm.Client.StreetName;
                clientInDb.StreetNumber = clientForm.Client.StreetNumber;
                clientInDb.PostNumber = clientForm.Client.PostNumber;
                clientInDb.City = clientForm.Client.City;
                clientInDb.CountryId = clientForm.Client.CountryId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Clients");
        }
    }
}