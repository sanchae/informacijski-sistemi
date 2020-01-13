using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vodenje_racunov.Models;

namespace vodenje_racunov.ViewModels
{
    public class ClientFormViewModel
    {
        public Client Client { get; set; }
        public IEnumerable<Country> CountriesList { get; set; }
    }
}