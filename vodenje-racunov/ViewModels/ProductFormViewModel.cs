using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vodenje_racunov.Models;

namespace vodenje_racunov.ViewModels
{
    public class ProductFormViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Category> CategoriesList { get; set; }
        public IEnumerable<Manufacturer> ManufacturersList { get; set; }
    }
}