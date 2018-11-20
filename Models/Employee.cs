using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcBasic.Models
{
    public class Employee
    {
        //[Display(Name = "員工編號")]
        public int ID { get; set; }
        //[Display(Name = "名字")]
        public string Name { get; set; }
        //[Display(Name = "連絡電話")]
        public string Phone { get; set; }
        //[Display(Name = "電子郵件")]
        public string Email { get; set; }
    }
}