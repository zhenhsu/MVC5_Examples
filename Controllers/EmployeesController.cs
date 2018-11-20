using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBasic.Models;

namespace MvcBasic.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EmployeeList()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { ID = 10001, Name = "David", Phone = "0933-154228", Email ="david@gmail.com" },
                new Employee { ID = 10002, Name = "Mary", Phone = "0925-157886", Email ="mary@gmail.com" },
                new Employee { ID = 10003, Name = "John", Phone = "0921-335884", Email ="john@gmail.com" },
                new Employee { ID = 10004, Name = "Cindy", Phone = "0971-628322", Email ="cindy@gmail.com" },
                new Employee { ID = 10005, Name = "Rose", Phone = "0933-154228",  Email ="rose@gmail.com" }
            };

            return View(employees);
        }
    }
}