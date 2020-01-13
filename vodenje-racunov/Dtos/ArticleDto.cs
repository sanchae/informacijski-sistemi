using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vodenje_racunov.Models;

namespace vodenje_racunov.Dtos
{
    public class ArticleDto
    {
        public int ArticleId { get; set; }
        public DocumentDto Document { get; set; }
        public int DocumentId { get; set; }
        public ProductDto Product { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; } //product.sellingPrice * Quantity
        public decimal Discount { get; set; }
        public decimal taxRate { get; set; }
        public decimal assemblyPrice { get; set; }
    }
}