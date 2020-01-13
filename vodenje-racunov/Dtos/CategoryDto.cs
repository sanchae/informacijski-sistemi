using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vodenje_racunov.Dtos
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}