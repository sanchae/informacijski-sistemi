using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vodenje_racunov.Models;

namespace vodenje_racunov.Dtos
{
    public class ArticlesDto
    {
        public List<ArticleDto> Articles { get; set; }
    }
}