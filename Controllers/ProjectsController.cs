using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBasic.Models;

namespace MvcBasic.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Projects
        public ActionResult Index()
        {
            List<Project> projects = new List<Project>
            {
                new Project{ Id=1, Chapter="第一章",Program="firstMVC"},
                new Project{ Id=2, Chapter="第二章", Program="MvcBasic"},
                new Project{ Id=3, Chapter="第三章", Program="MvcBootstrap"},
                new Project{ Id=4, Chapter="第四章", Program="MvcRazor"},
                new Project{ Id=5, Chapter="第五章", Program="MvcCharting"},
                new Project{ Id=6, Chapter="第六章", Program="MvcJsonWebAPI、WebApiServices"},
                new Project{ Id=7, Chapter="第七章", Program="MvcHtmlHelpers"},
                new Project{ Id=8, Chapter="第八章", Program="MvcMobileWeb"},
                new Project{ Id=9, Chapter="第九章", Program="MvcJqueryMobile"},
                new Project{ Id=10, Chapter="第十章", Program="MvcRouting"},
            };

            return View(projects);
        }
    }
}