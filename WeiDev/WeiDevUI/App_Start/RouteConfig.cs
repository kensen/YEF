using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WeiDevUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //        name: "User",
            //        url: "{controller}/{action}/{page}",
            //        defaults: new { controller = "Home", action = "Index", page = UrlParameter.Optional }
            //    );

            routes.MapRoute("Paging", "{controller}/{action}/page_{page}", new { controller = "Home", action = "Index", page = 1 }, new { action = "Index" });
            routes.MapRoute("OptionalPaging", "{controller}/{action}/pageindex-{page}", new { controller = "Home", action = "Index", page = UrlParameter.Optional }, new { action = "Index" });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

             
        }
    }
}
