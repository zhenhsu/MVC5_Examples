using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBasic.Models;

namespace MvcBasic.Controllers
{
    public class PassDataController : Controller
    {
        List<Employee> empsList = new List<Employee>
            {
                new Employee { ID = 10001, Name = "David", Phone = "0933-154228", Email ="david@gmail.com" },
                new Employee { ID = 10002, Name = "Mary", Phone = "0925-157886", Email ="mary@gmail.com" },
                new Employee { ID = 10003, Name = "John", Phone = "0921-335884", Email ="john@gmail.com" },
                new Employee { ID = 10004, Name = "Cindy", Phone = "0971-628322", Email ="cindy@gmail.com" },
                new Employee { ID = 10005, Name = "Rose", Phone = "0933-154228",  Email ="rose@gmail.com" }
            };

        // GET: PassData
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PassViewData()
        {
            //ViewData
            ViewData["Name"] = "Kevin";		    //儲存字串
            ViewData["Age"] = 33;               //儲存整數
            ViewData["Single"] = true;          //儲存布林值
            ViewData["Employees"] = empsList;   //儲存model集合物件
            
            return View();
        }

        public ActionResult PassViewBag()
        {
            //ViewBag
            ViewBag.Nickname = "Mary";
            ViewBag.Height = 168;
            ViewBag.Weight = 52;
            ViewBag.Married = false;
            ViewBag.EmpsList = empsList;    //儲存model集合物件

            return View();
        }

        public ActionResult PassModel()
        {
            //1.呼叫View()方法時，直接將model當成參數傳入
            return View(empsList);

            //2.將model物件指定給ViewData.Model屬性
            //ViewData.Model = empsList;
            //return View();
        }

        public ActionResult PassTempData()
        {
            TempData["ErrorMessage"]="無足夠權限存取系統資料, 請連絡系統管理人員";
            TempData["UserName"] = "David";
            TempData["Time"] = DateTime.Now.ToLongTimeString();
            return RedirectToAction("ErrorMessage", "ErrorHandler");
        }


        public ActionResult PetShop()
        {
            //1.使用ViewData傳遞資料到View
            ViewData["Company"] = "汪星人寵物店";

            //2.使用ViewBag傳遞資料到View
            ViewBag.Address = "台北市信義區松山路100號";

            //宣告一個List泛型集合,代表model資料模型
            List<string> petsList = new List<string>();
            petsList.Add("狗");
            petsList.Add("猫");
            petsList.Add("魚");
            petsList.Add("鼠");
            petsList.Add("變色龍");

            //3.將petSList資料模型指派給ViewData.Model屬性, 傳遞到View
            ViewData.Model = petsList;

            return View();

            //實際上傳送model物件給View,會更常使用View(petsList)語法取代
            //return View(petsList);
        }

        public ActionResult StronglyTypedView()
        {
            //傳送單筆資料
            Employee employee = new Employee
            {
                ID = 10001,
                Name = "David",
                Phone = "0933-154228",
                Email = "david@gmail.com"
            };

            return View(employee);
        }

        public ActionResult StronglyTypedViewList()
        {
            //以List<Employee>泛型集合傳送多筆資料
            return View(empsList);
        }
    }
}