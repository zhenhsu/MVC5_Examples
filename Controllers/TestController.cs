using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ViewResult ShowMessage()
        {
            return View("Massage"); //指定錯誤的檢視名稱
            
            //return View("Message");  //這是正確名稱
        }
    }
}