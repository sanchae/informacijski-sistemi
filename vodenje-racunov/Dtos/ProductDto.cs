using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vodenje_racunov.Models;

namespace vodenje_racunov.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public double PurchasePrice { get; set; }

        public double SellingPrice { get; set; }

        public int WarrantyInMonths { get; set; }

        public byte ManufacturerId { get; set; }

        public ManufacturerDto Manufacturer { get; set; }

        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }

        public string Description { get; set; }
    }
}