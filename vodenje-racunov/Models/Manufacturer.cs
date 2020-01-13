using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace vodenje_racunov.Models
{
    public class Manufacturer
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte ManufacturerId { get; set; }

        [Required(ErrorMessage = "Vnesite ime proizvajalca")]
        [Display(Name = "Ime")]
        public string ManufacturerName { get; set; }

        [Display(Name = "Ulica")]
        public string ManufacturerStreetName { get; set; }

        [Display(Name = "Hišna št.")]
        public string ManufacturerStreetNumber { get; set; }

        [Display(Name = "Poštna št.")]
        public string ManufacturerPostNumber { get; set; }

        [Display(Name = "Kraj/mesto")]
        public string ManufacturerCity { get; set; }
        public Country Country { get; set; }

        [Display(Name = "Država")]
        public int CountryId { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Vnesite veljaven email.")]
        public string ManufacturerEmail { get; set; }

        [Display(Name = "Tel.")]
        public string ManufacturerPhoneNumber { get; set; }
    }
}