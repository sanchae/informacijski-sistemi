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
    public class ProductsController : Controller
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public List<Product> GetProducts()
        {
            var products = new List<Product>();
            foreach (var product in _context.Products.Include(c => c.Category).Include(m => m.Manufacturer))
            {
                products.Add(product);
            }
            return products;
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
            var product = GetProducts().SingleOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }


        [Authorize(Roles = RoleName.CanManageInvoices)]
        public ActionResult Edit(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ProductFormViewModel()
            {
                Product = product,
                ManufacturersList = _context.Manufacturers,
                CategoriesList = _context.Categories
            };

            return View("ProductForm", viewModel);
        }


        [Authorize(Roles = RoleName.CanManageInvoices)]
        public ActionResult New()
        {
            var manufacturers = _context.Manufacturers.ToList();
            var categories = _context.Categories.ToList();
            var newProduct = new ProductFormViewModel()
            {
                CategoriesList = categories,
                ManufacturersList = manufacturers
            };

            return View("ProductForm", newProduct);
        }


        [Authorize(Roles = RoleName.CanManageInvoices)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ProductFormViewModel productForm)
        {
            if (productForm.Product.ProductId == 0)
            {
                _context.Products.Add(productForm.Product);
            }
            else
            {
                var productInDb = _context.Products.Single(p => p.ProductId == productForm.Product.ProductId);

                productInDb.Name = productForm.Product.Name;
                productInDb.ShortName = productForm.Product.ShortName;
                productInDb.PurchasePrice = productForm.Product.PurchasePrice;
                productInDb.SellingPrice = productForm.Product.SellingPrice;
                productInDb.WarrantyInMonths = productForm.Product.WarrantyInMonths;
                productInDb.ManufacturerId = productForm.Product.ManufacturerId;
                productInDb.CategoryId = productForm.Product.CategoryId;
                productInDb.Description = productForm.Product.Description;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
    }
}