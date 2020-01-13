using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using vodenje_racunov.Models;
using vodenje_racunov.ViewModels;

namespace vodenje_racunov.Controllers
{
    public class ManufacturersController : Controller
    {
        // GET: Manufacturers
        private ApplicationDbContext _context;

        public ManufacturersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public List<Manufacturer> GetManufacturers()
        {
            var manufacturers = new List<Manufacturer>();
            foreach (var manufacturer in _context.Manufacturers.Include(c => c.Country))
            {
                manufacturers.Add(manufacturer);
            }
            return manufacturers;
        }

        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageInvoices))
            {
                return View("Index", GetManufacturers());
            }
            return View("ReadOnlyIndex", GetManufacturers());
        }

        public ActionResult Details(int id)
        {
            var manufacturer = GetManufacturers().SingleOrDefault(p => p.ManufacturerId == id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }

            return View(manufacturer);
        }

        [Authorize(Roles = RoleName.CanManageInvoices)]
        public ActionResult Edit(int id)
        {
            var manufacturer = _context.Manufacturers.SingleOrDefault(p => p.ManufacturerId == id);

            if (manufacturer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ManufacturerFormViewModel()
            {
                Manufacturer = manufacturer,
                CountriesList = _context.Countries
            };

            return View("ManufacturerForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageInvoices)]
        public ActionResult New()
        {
            var countries = _context.Countries.ToList();
            var newManufacturer = new ManufacturerFormViewModel()
            {
                CountriesList = countries
            };

            return View("ManufacturerForm", newManufacturer);
        }

        [Authorize(Roles = RoleName.CanManageInvoices)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ManufacturerFormViewModel manufacturerForm)
        {
            if (manufacturerForm.Manufacturer.ManufacturerId == 0)
            {
                _context.Manufacturers.Add(manufacturerForm.Manufacturer);
            }
            else
            {
                var manufacturerInDb = _context.Manufacturers.Single(p => p.ManufacturerId == manufacturerForm.Manufacturer.ManufacturerId);

                manufacturerInDb.ManufacturerName = manufacturerForm.Manufacturer.ManufacturerName;
                manufacturerInDb.ManufacturerEmail = manufacturerForm.Manufacturer.ManufacturerEmail;
                manufacturerInDb.ManufacturerPhoneNumber = manufacturerForm.Manufacturer.ManufacturerPhoneNumber;
                manufacturerInDb.ManufacturerStreetName = manufacturerForm.Manufacturer.ManufacturerStreetName;
                manufacturerInDb.ManufacturerStreetNumber = manufacturerForm.Manufacturer.ManufacturerStreetNumber;
                manufacturerInDb.ManufacturerPostNumber = manufacturerForm.Manufacturer.ManufacturerPostNumber;
                manufacturerInDb.ManufacturerCity = manufacturerForm.Manufacturer.ManufacturerCity;
                manufacturerInDb.CountryId = manufacturerForm.Manufacturer.CountryId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Manufacturers");
        }
    }
}