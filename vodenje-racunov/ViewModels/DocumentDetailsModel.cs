using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vodenje_racunov.Models;

namespace vodenje_racunov.ViewModels
{
    public class DocumentDetailsModel
    {
        public Document Document { get; set; }
        public List<Client> ClientsList { get; set; }
        public List<Article> ArticlesList { get; set; }
        public List<Product> ProductsList { get; set; }
    }
}