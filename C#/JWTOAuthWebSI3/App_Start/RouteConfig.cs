using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EZOper.TechTester.JWTOAuthWebSI3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            AreaRegistrationContext areaRegistrationContext;
            #region // 帮助域
            areaRegistrationContext = new AreaRegistrationContext("Help", routes);
            areaRegistrationContext.MapRoute(
                 name: "Help",
                 url: "Help/{controller}/{action}/{id}",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "EZOper.TechTester.JWTOAuthWebSI3.Areas.Help.Controllers" }
             );
            #endregion
            #region // 基础域-Home
            areaRegistrationContext = new AreaRegistrationContext("Home", routes);
            areaRegistrationContext.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "EZOper.TechTester.JWTOAuthWebSI3.Areas.Home.Controllers" }
            );
            #endregion
        }
    }
}
