using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EZOper.TechTester.SQLiteWebSI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            var context = new AreaRegistrationContext("Home", routes);
            context.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Auth", action = "LogOn", id = UrlParameter.Optional },
                namespaces: new string[] { "EZOper.TechTester.SQLiteWebSI.Areas.Home.Controllers" }
            );
        }
    }
}
