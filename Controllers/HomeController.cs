using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();

            //return View(Index");
            //return View(About");
            //return View("~/Views/Home/Index.cshtml");
            //return View("~/Views/Results/Index.cshtml");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}