using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vodenje_racunov.Dtos
{
    public class ManufacturerDto
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerStreetName { get; set; }
        public string ManufacturerStreetNumber { get; set; }
        public string ManufacturerPostNumber { get; set; }
        public string ManufacturerCity { get; set; }
        public int CountryId { get; set; }
        public CountryDto Country { get; set; }
        public string ManufacturerEmail { get; set; }
        public string ManufacturerPhoneNumber { get; set; }
    }
}