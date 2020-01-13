using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vodenje_racunov.Models;

namespace vodenje_racunov.Dtos
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; } //name and surname / company name
        public string Type { get; set; } //pravna oseba, fizična oseba, s.p.
        public string RegistrationNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string taxNumber { get; set; }
        public bool taxPayer { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string PostNumber { get; set; }
        public string City { get; set; }
        public CountryDto Country { get; set; }
        public int CountryId { get; set; }
    }
}