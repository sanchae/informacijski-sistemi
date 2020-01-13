using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace vodenje_racunov.Models
{
    public class Article
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticleId { get; set; }

        public Document Document { get; set; }
        public int DocumentId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public double Quantity { get; set; }
        public decimal Price { get; set; } //product.sellingPrice * Quantity
        public decimal Discount { get; set; }
        public decimal taxRate { get; set; }
        public decimal assemblyPrice { get; set; }
    }
}