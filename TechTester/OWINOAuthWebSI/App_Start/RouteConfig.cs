using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EZOper.TechTester.OWINOAuthWebSI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            AreaRegistrationContext areaRegistrationContext;
            #region // 接口域
            areaRegistrationContext = new AreaRegistrationContext("ZApi", routes);
            areaRegistrationContext.MapRoute(
                 name: "ZApi",
                 url: "ZApi/{controller}/{action}/{id}",
                 defaults: new { controller = "Help", action = "Api", id = UrlParameter.Optional },
                 namespaces: new[] { "EZOper.TechTester.OWINOAuthWebSI.Areas.ZApi.Controllers" }
             );
            #endregion
            #region // 基础域-Home
            areaRegistrationContext = new AreaRegistrationContext("Home", routes);
            areaRegistrationContext.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "EZOper.TechTester.OWINOAuthWebSI.Areas.Home.Controllers" }
            );
            #endregion
        }
    }
}
