using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vodenje_racunov.Models;

namespace vodenje_racunov.ViewModels
{
    public class ManufacturerFormViewModel
    {
        public Manufacturer Manufacturer { get; set; }
        public IEnumerable<Country> CountriesList { get; set; }
    }
}