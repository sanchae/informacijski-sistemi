using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace vodenje_racunov.Models
{
    public class Category
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Display(Name = "Kategorija")]
        [Required(ErrorMessage = "Vnesi naziv kategorije.")]
        public string CategoryName { get; set; }

        [Display(Name = "Opis")]
        public string CategoryDescription { get; set; }
    }
}