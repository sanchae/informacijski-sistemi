using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vodenje_racunov.Models;

namespace vodenje_racunov.Controllers
{
    public class CountryController : Controller
    {
        private ApplicationDbContext _context;

        public CountryController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public List<Country> GetCountries()
        {
            var countriesList = new List<Country>();
            foreach (var country in _context.Countries)
            {
                countriesList.Add(country);
            }
            return countriesList;
        }

        // GET: Countries
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageInvoices))
            {
                return View("Index", GetCountries());
            }
            return View("ReadOnlyIndex", GetCountries());
        }


        public ActionResult Details(int id)
        {
            var country = GetCountries().SingleOrDefault(p => p.CountryId == id);
            if (country == null)
            {
                return HttpNotFound();
            }

            return View(country);
        }

        [Authorize(Roles = RoleName.CanManageInvoices)]
        public ActionResult Edit(int id)
        {
            var country = _context.Countries.SingleOrDefault(p => p.CountryId == id);

            if (country == null)
            {
                return HttpNotFound();
            }

            return View("CountryForm", country);
        }

        [Authorize(Roles = RoleName.CanManageInvoices)]
        public ActionResult New()
        {
            return View("CountryForm");
        }

        [Authorize(Roles = RoleName.CanManageInvoices)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Country country)
        {
            if (country.CountryId == 0)
            {
                _context.Countries.Add(country);
            }
            else
            {
                var categoryInDb = _context.Countries.Single(p => p.CountryId == country.CountryId);

                categoryInDb.CountryName = country.CountryName;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Country");
        }
    }
}