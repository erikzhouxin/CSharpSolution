using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EZOper.TechTester.EZWebTemplate
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            AreaRegistrationContext areaRegistrationContext;
            #region // 服务域
            areaRegistrationContext = new AreaRegistrationContext("Services", routes);
            areaRegistrationContext.MapRoute(
                 name: "Services",
                 url: "Services/{controller}/{action}/{id}",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "EZOper.TechTester.EZWebTemplate.Areas.Services.Controllers" }
             );
            #endregion
            #region // 帮助域
            areaRegistrationContext = new AreaRegistrationContext("Help", routes);
            areaRegistrationContext.MapRoute(
                 name: "Help",
                 url: "Help/{controller}/{action}/{id}",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "EZOper.TechTester.EZWebTemplate.Areas.Help.Controllers" }
             );
            #endregion
            #region // 原型域
            areaRegistrationContext = new AreaRegistrationContext("Prototypes", routes);
            areaRegistrationContext.MapRoute(
                 name: "Prototypes",
                 url: "Prototypes/{controller}/{action}/{id}",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "EZOper.TechTester.EZWebTemplate.Areas.Prototypes.Controllers" }
             );
            #endregion
            #region // 基础域-Home
            areaRegistrationContext = new AreaRegistrationContext("Home", routes);
            areaRegistrationContext.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "EZOper.TechTester.EZWebTemplate.Areas.Home.Controllers" }
            );
            #endregion
        }
    }
}
