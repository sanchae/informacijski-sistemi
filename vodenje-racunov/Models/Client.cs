using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vodenje_racunov.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vnesi ime.")]
        [Display(Name = "Ime in priimek / naziv")]
        public string Name { get; set; } //name and surname / company name

        [Required(ErrorMessage = "Izberi tip")]
        [Display(Name = "Tip osebe")]
        public string Type { get; set; } //pravna oseba, fizična oseba, s.p.

        [Display(Name = "Matična številka")]
        public string RegistrationNumber { get; set; }

        //contact info
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Vnesite veljaven email.")]
        public string Email { get; set; }

        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Davčna številka")]
        public string taxNumber { get; set; }

        [Display(Name = "Davčni zavezanec")]
        public bool taxPayer { get; set; }

        //location info
        [Display(Name = "Ulica")]
        public string StreetName { get; set; }

        [Display(Name = "Hišna št.")]
        public string StreetNumber { get; set; }

        [Display(Name = "Poštna št.")]
        public string PostNumber { get; set; }

        [Display(Name = "Kraj/mesto")]
        public string City { get; set; }
        public Country Country { get; set; }

        [Display(Name = "Država")]
        public int CountryId { get; set; }
    }
}