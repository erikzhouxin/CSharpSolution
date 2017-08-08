using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EZOper.TechTester.CSharpWebSI
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
                 namespaces: new[] { "EZOper.TechTester.CSharpWebSI.Areas.ZApi.Controllers" }
             );
            #endregion
            #region // 服务域
            areaRegistrationContext = new AreaRegistrationContext("Services", routes);
            areaRegistrationContext.MapRoute(
                 name: "Services",
                 url: "Services/{controller}/{action}/{id}",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "EZOper.TechTester.CSharpWebSI.Areas.Services.Controllers" }
             );
            #endregion
            #region // 工作域
            areaRegistrationContext = new AreaRegistrationContext("Works.Bigsail.Honor3", routes);
            areaRegistrationContext.MapRoute(
                 name: "Works.Bigsail.Honor3",
                 url: "Works/Bigsail/Honor3/{controller}/{action}/{id}",
                 defaults: new { controller = "Auth", action = "LogOn", id = UrlParameter.Optional },
                 namespaces: new[] { "EZOper.TechTester.CSharpWebSI.Areas.Works.Bigsail.Honor3.Controllers" }
             );
            #endregion
            #region // 原型域
            areaRegistrationContext = new AreaRegistrationContext("Prototypes", routes);
            areaRegistrationContext.MapRoute(
                 name: "Prototypes",
                 url: "Prototypes/{controller}/{action}/{id}",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "EZOper.TechTester.CSharpWebSI.Areas.Prototypes.Controllers" }
             );
            #endregion
            #region // 公共域
            areaRegistrationContext = new AreaRegistrationContext("Home", routes);
            areaRegistrationContext.MapRoute(
                 name: "Default",
                 url: "{controller}/{action}/{id}",
                 defaults: new { controller = "Authentication", action = "LogOn", id = UrlParameter.Optional },
                 namespaces: new[] { "EZOper.TechTester.CSharpWebSI.Areas.Home.Controllers" }
             );
            #endregion
        }
    }
}
