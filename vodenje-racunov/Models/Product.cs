    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vodenje_racunov.Models;

namespace vodenje_racunov.Models
{
    public class Product
    {
        public int ProductId { get; set; }


        [Required(ErrorMessage = "Vnesi polno ime.")]
        [StringLength(255)]
        [Display(Name = "Naziv")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Vnesi kratko ime.")]
        [Display(Name = "Kratek naziv")]
        public string ShortName { get; set; }


        [Required(ErrorMessage = "Neveljavna vrednost.")]
        [Display(Name = "Nabavna cena")]
        public double PurchasePrice { get; set; }


        [Required(ErrorMessage = "Neveljavna vrednost.")]
        [Display(Name = "Prodajna cena")]
        public double SellingPrice { get; set; }


        [Required(ErrorMessage = "Neveljavna vrednost.")]
        [Range(0, 100, ErrorMessage = "Vrednost mora biti med 0 in 100")]
        [Display(Name = "Garancija (v mesecih)")]
        public int WarrantyInMonths { get; set; }

        public Manufacturer Manufacturer { get; set; }


        [Required(ErrorMessage = "Izberi proizvajalca.")]
        [Display(Name = "Proizvajalec")]
        public byte ManufacturerId { get; set; }

        public Category Category { get; set; }


        [Required(ErrorMessage = "Izberi kategorijo.")]
        [Display(Name = "Kategorija")]
        public int CategoryId { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

    }
}