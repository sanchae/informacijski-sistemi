using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace vodenje_racunov.Models
{
    public class Country
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryId { get; set; }

        [Display(Name = "Država")]
        [Required(ErrorMessage = "Vnesi ime države.")]
        public string CountryName { get; set; }
    }
}