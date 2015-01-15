using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeiDevUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string t)
        {
            //return View();
            if (string.IsNullOrEmpty(t))
            {
                return View();
            }
            else
            {
                RazorView rv = new RazorView(this.ControllerContext, "~/WeiViews/" + t + "/Home/Index.cshtml", "~/WeiViews/Shared/_layout.cshtml", true, new string[] { "cshtml", "vbhtml" });
                // IView rv = new ThemeRazorView("Base");
                return View(rv);
            }

           
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

        public ActionResult Login()
        {
            ViewBag.Message = "Login page.";

            return View();
        }
    }
}