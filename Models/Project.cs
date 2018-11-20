using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcBasic.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Display(Name ="章名")]
        public string Chapter { get; set; }
        [Display(Name = "ASP.NET MVC專案名稱")]
        public string Program { get; set; }
    }
}