using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Rotativa;
using vodenje_racunov.Models;
using vodenje_racunov.ViewModels;

namespace vodenje_racunov.Controllers
{
    public class DocumentsController : Controller
    {
        // GET: Manufacturers
        private ApplicationDbContext _context;

        public DocumentsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult ExportOffer(int id)
        {
            var a = new ActionAsPdf(
                    "Offer",
                    new {id = id})
                    {FileName = "predracun.pdf"};
            a.Cookies = Request.Cookies.AllKeys.ToDictionary(k => k, k => Request.Cookies[k].Value);
            a.FormsAuthenticationCookieName = System.Web.Security.FormsAuthentication.FormsCookieName;
            a.CustomSwitches = "--load-error-handling ignore";
            return a;
        }
        public ActionResult ExportInvoice(int id)
        {
            var a = new ActionAsPdf(
                    "Invoice",
                    new {id = id})
                    {FileName = "racun.pdf"};
            a.Cookies = Request.Cookies.AllKeys.ToDictionary(k => k, k => Request.Cookies[k].Value);
            a.FormsAuthenticationCookieName = System.Web.Security.FormsAuthentication.FormsCookieName;
            a.CustomSwitches = "--load-error-handling ignore";
            return a;
        }
        public ActionResult ExportDeliveryNote(int id)
        {
            var a = new ActionAsPdf(
                    "DeliveryNote",
                    new {id = id})
                    {FileName = "dobavnica.pdf"};
            a.Cookies = Request.Cookies.AllKeys.ToDictionary(k => k, k => Request.Cookies[k].Value);
            a.FormsAuthenticationCookieName = System.Web.Security.FormsAuthentication.FormsCookieName;
            a.CustomSwitches = "--load-error-handling ignore";
            return a;
        }

        public List<Document> GetDocuments()
        {
            var documents = new List<Document>();
            foreach (var document in _context.Documents.Include(c => c.Client).Include(d => d.Client.Country))
            {
                documents.Add(document);
            }
            return documents;
        }

        public List<Article> GetArticles()
        {
            var articles = new List<Article>();
            foreach (var article in _context.Articles.Include(c => c.Product))
            {
                articles.Add(article);
            }
            return articles;
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
            var document = GetDocuments().SingleOrDefault(d => d.DocumentId == id);
            var articles = GetArticles().Where(a => a.DocumentId == id).ToList();

            if (document == null)
            {
                return HttpNotFound();
            }

            var viewModel = new DocumentDetailsModel()
            {
                Document = document,
                ArticlesList = articles
            };

            return View("Details", viewModel);
        }

        public ActionResult Offer(int id)
        {
            var document = GetDocuments().SingleOrDefault(d => d.DocumentId == id);
            var articles = GetArticles().Where(a => a.DocumentId == id).ToList();

            if (document == null)
            {
                return HttpNotFound();
            }

            var viewModel = new DocumentDetailsModel()
            {
                Document = document,
                ArticlesList = articles
            };

            return View("Offer", viewModel);
        }
        public ActionResult Invoice(int id)
        {
            var document = GetDocuments().SingleOrDefault(d => d.DocumentId == id);
            var articles = GetArticles().Where(a => a.DocumentId == id).ToList();

            if (document == null)
            {
                return HttpNotFound();
            }

            var viewModel = new DocumentDetailsModel()
            {
                Document = document,
                ArticlesList = articles
            };

            return View("Invoice", viewModel);
        }
        public ActionResult DeliveryNote(int id)
        {
            var document = GetDocuments().SingleOrDefault(d => d.DocumentId == id);
            var articles = GetArticles().Where(a => a.DocumentId == id).ToList();

            if (document == null)
            {
                return HttpNotFound();
            }

            var viewModel = new DocumentDetailsModel()
            {
                Document = document,
                ArticlesList = articles
            };

            return View("DeliveryNote", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageInvoices)]
        public ActionResult Edit(int id)
        {
            var document = _context.Documents.SingleOrDefault(p => p.DocumentId == id);
            var articles = GetArticles().Where(a => a.DocumentId == id).ToList();
            var clients = _context.Clients.ToList();

            if (document == null)
            {
                return HttpNotFound();
            }

            var viewModel = new DocumentDetailsModel()
            {
                Document = document,
                ClientsList = clients,
                ArticlesList = articles
            };

            return View("Edit", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageInvoices)]
        public ActionResult New()
        {
            var articles = GetArticles();
            var clients = _context.Clients.ToList();
            List<Product> products = _context.Products.ToList();

            var newDocument = new DocumentDetailsModel()
            {
                ClientsList = clients,
                ArticlesList = articles,
                ProductsList = products
            };

            return View("New", newDocument);
        }
    }
}