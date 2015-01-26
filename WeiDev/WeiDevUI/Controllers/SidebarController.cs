using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YEF.AppServices.Services.System;


namespace WeiDevUI.Controllers
{
    public class SidebarController : Controller
    {
        //
        // GET: /Sidebar/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Header()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.Title = "YEFDev";

           

            return PartialView("_Header");
        }

        public ActionResult Footer()
        {
            return PartialView("_Footer");
        }

        public ActionResult Menu(string c="",string a="")
        {
          //  SysMenuInit minit = new SysMenuInit();
            IMenu menu = new MenuService();

            menu.InitXML();

            var obj = menu.GetMenuList(c, a);

           

            return PartialView("_Menu",obj);
            
        }
	}
}