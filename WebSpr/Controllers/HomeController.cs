using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BEFLSPR.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            ViewBag.Message = "Измените этот шаблон, чтобы быстро приступить к работе над приложением ASP.NET MVC.";
            return Redirect("http://dc.befl.ru/Ang/");
            //return View();
        }

        public ActionResult Angular()
        {        
            return View();      
        }

        public ActionResult About()
        {
            ViewBag.Message = "Страница описания приложения.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Страница контактов.";
            return View();
        }
    }
}
