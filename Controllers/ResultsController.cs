using MvcBasic.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Web.Mvc;
using System.Net;


namespace MvcBasic.Controllers
{
    public class ResultsController : Controller
    {
        private FriendContext db = new FriendContext();

        public ActionResult ClientCallActionResult()
        {
            return View();
        }

        #region 回傳ViewResult物件

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Index2()
        {
            return new ViewResult();
        }

        public ViewResult Index3()
        {
            return View();
        }

        public ActionResult Index4()
        {
            return new ViewResult();
        }

        //呼叫View()方法,同時傳入一個model物件
        public ViewResult FriendsList()
        {
            List<Friend> friends = new List<Friend>
            {
                new Friend { ID=1, Name="David", Email="david@gmail.com" },
                new Friend { ID=1, Name="Mary", Email="mary@gmail.com" },
                new Friend { ID=1, Name="Cindy", Email="cindy@gmail.com" },
            };

            return View(friends);
        }

        //GetMassage()以指定View名稱調用Message.cshtml檢視
        public ViewResult GetMessage()
        {
            return View("Message");
        }

        #endregion  回傳PartialViewResult物件

        #region 回傳PartialViewResult物件
        public PartialViewResult getPartialCard()
        {
            //SimpleCardPartial.cshtml部分檢視
            return PartialView("SimpleCardPartial");
        }

        #endregion 回傳ContentResult物件

        #region 回傳ContentResult物件
        public ContentResult About()
        {
            return Content("聖殿祭司"); //回傳純文字
        }

        public ContentResult AboutName()
        {
            return Content("<h3>聖殿祭司</h3>", "text/plain");  //回傳純文字
        }

        public ContentResult getInfomation()
        {
            //指定編碼
            string info = "這是plain text純文字";
            return Content(info, "text/plain", Encoding.UTF8);  //回傳純文字,並指定編碼
        }

        public ContentResult AboutMe()
        {
            //回傳HTML Tags
            string time = DateTime.Now.ToLongTimeString();
            return Content($"<h2>聖殿祭司, {time}</h2>", "text/html");  //回傳html
        }

        public ContentResult AlertMessage()
        {
            //要回傳一段JavaScript也不成問題
            string script = "<script> alert('This is JavaScriptResult!'); </script>";

            return Content(script, "application/javascript");
        }

        #endregion

        #region 回傳EmptyResult物件
        public EmptyResult Empty()
        {
            return new EmptyResult();
        }


        public EmptyResult Nothing()
        {
            EmptyResult empty = new EmptyResult();
            return empty;
        }

        public EmptyResult DoNothing()
        {
            return null;
        }

        #endregion

        #region 回傳JavaScriptResult物件
        public JavaScriptResult JsFunction()
        {
            string script = "function showMessage(){ alert('這是JavaScriptResult定義的function'); }";

            return JavaScript(script);
        }
        #endregion

        #region 回傳JsonResult物件
        public JsonResult JsonFriends()
        {
            List<Friend> friends = new List<Friend>
            {
                new Friend { ID=1, Name="David", Email="david@gmail.com", City="Taipei", Phone="0925-157-886" },
                new Friend { ID=1, Name="Mary", Email="mary@gmail.com",City="Taoyuan" , Phone="0970-286-335"},
                new Friend { ID=1, Name="Cindy", Email="cindy@gmail.com",City="Kaohsiung", Phone="0937-258-119" },
            };

            return Json(friends, JsonRequestBehavior.AllowGet);
            //return Json(friends, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }


        #endregion


        #region 回傳FilePathResult物件
        //回傳JPG圖片
        public FilePathResult ImageFile(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                id = "vader";
            }

            var picture = $"~/assets/images/{id}.jpg";
            return File(picture, "image/jpg");
        }

        //回傳PDF
        public FilePathResult PdfFile()
        {
            string pdfName = @"~/assets/documents/AnnualSalesReport.pdf";
            string contentType = "application/pdf";
            string downloadName = "模範購物公司年度營收報告.pdf";

            return File(pdfName, contentType, downloadName);
        }

        //回傳XML檔
        public FilePathResult XmlFile()
        {
            string filePath = @"~/assets/xml/customers.xml";

            return File(filePath, "application/xml", "customers.xml");
        }

        //回傳HTML檔(將EmployeeList.cshtml回傳)
        public FilePathResult htmlFile()
        {
            string filePath = @"~/Views/Employees/EmployeeList.cshtml";

            return File(filePath, "text/html", "EmployeeList.html");
        }

        #endregion

        #region FileContentResult
        public FileContentResult ByteArrayContent()
        {
            //Bitmap bitmap = new Bitmap(@"C:\MvcExamples\MvcActionResults\MvcActionResults\Assets\images\darthmual.jpg");
            Bitmap bitmap = new Bitmap(Server.MapPath(@"~/Assets/images/darthmual.jpg"));
            ImageConverter converter = new ImageConverter();
            byte[] imageArray = (byte[])converter.ConvertTo(bitmap, typeof(byte[]));

            return File(imageArray, "application/octet-stream");
            //return File(imageArray, "image/jpeg", "darthmual.jpg");
        }
        #endregion

        #region 回傳FileStreamResult物件
        public FileStreamResult FileStream()
        {
            MemoryStream ms = new MemoryStream();
            Bitmap bitmap = new Bitmap(Server.MapPath(@"~/Assets/images/darthmual.jpg"));
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Seek(0, SeekOrigin.Begin);

            return File(ms, "image/jpeg", "starwar.jpg");
        }


        #endregion


        #region 回傳RedirectResult物件
        //傳統的導向語法
        public void getFriends()
        {
            //HTTP/1.1 302 Found, 臨時轉向
            Response.Redirect("/Friends/Index");
            //HTTP/1.1 301 Moved Permanently, 永久轉向
            //Response.RedirectPermanent("/Friends/Index");
        }

        //Http 302 -- 臨時轉向,例如Login登入
        public RedirectResult getProducts()
        {
            return Redirect("/Account/Login"); 
        }

        //Http 301 -- 永久轉向, 例如網站搬到新的Domain
        public RedirectResult goNewHome()
        {
            return RedirectPermanent("https://NewHome.com.tw"); //永久導向新的Domain
        }

        #endregion

        #region RedirecToRouteResult
        // RedirectToAction()指定Action/Controller名稱作轉向
        // RedirectToRoute()指定URL路由資訊作轉向
        public ActionResult Create([Bind(Include = "ID,Name,Phone,Email,City")] Friend friend)
        {
            if (ModelState.IsValid)
            {
                db.Friends.Add(friend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(friend);
        }

        public RedirectToRouteResult redirectFriendIndex()
        {
            return RedirectToAction("Index", "Friends");
        }

        public RedirectToRouteResult redirectFriendEdit(int Id)
        {
            return RedirectToAction("Edit", "Friends", new { id = Id });
        }

        public RedirectToRouteResult redirectFriendDelete(int Id)
        {
            return RedirectToRoute(new { controller = "Friends", action = "Delete", id = Id });
        }

        //使用RouteConfig.cs中的"FriendDetials"路由定義作轉向
        public RedirectToRouteResult redirectFriendDetails(int Id)
        {
            return RedirectToRoute("FriendDetials", new { id = 3 });
        }

        #endregion

        #region  回傳HttpStatusCodeResult類型

        //Http 404
        public HttpNotFoundResult NotFoundError()
        {
            return HttpNotFound();
            //return HttpNotFound("Nothing here.");
        }

        //Http 404
        public HttpStatusCodeResult StatusCode404()
        {
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            //return new HttpStatusCodeResult(404, "Found nothing.");
        }

        //Http 500
        public HttpStatusCodeResult StatusCode500()
        {
            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            //return new HttpStatusCodeResult(500, "The Server is stopping.");

        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //Http 404
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = db.Friends.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }


        //Http 401
        public HttpUnauthorizedResult Unauthorized()
        {
            return new HttpUnauthorizedResult("Access is denied.");
        }
        #endregion

    }
}