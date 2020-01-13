using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vodenje_racunov.Models;
using vodenje_racunov.ViewModels;

namespace vodenje_racunov.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _context;

        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public List<Category> GetCategories()
        {
            var categoriesList = new List<Category>();
            foreach (var category in _context.Categories)
            {
                categoriesList.Add(category);
            }
            return categoriesList;
        }


        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageInvoices))
            {
                return View("Index", GetCategories());
            }
            return View("ReadOnlyIndex", GetCategories());
        }

        public ActionResult Details(int id)
        {
            var category = GetCategories().SingleOrDefault(p => p.CategoryId == id);
            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }


        [Authorize(Roles = RoleName.CanManageInvoices)]
        public ActionResult Edit(int id)
        {
            var category = _context.Categories.SingleOrDefault(p => p.CategoryId == id);

            if (category == null)
            {
                return HttpNotFound();
            }

            //var viewModel = new CategoryFormViewModel()
            //{
            //    Category = category,
            //};

            return View("CategoryForm", category);
        }

        [Authorize(Roles = RoleName.CanManageInvoices)]
        public ActionResult New()
        {

            return View("CategoryForm");
        }


        [Authorize(Roles = RoleName.CanManageInvoices)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Category category)
        {
            if (category.CategoryId == 0)
            {
                _context.Categories.Add(category);
            }
            else
            {
                var categoryInDb = _context.Categories.Single(p => p.CategoryId == category.CategoryId);

                categoryInDb.CategoryName = category.CategoryName;
                categoryInDb.CategoryDescription = category.CategoryDescription;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Categories");
        }
    }
}