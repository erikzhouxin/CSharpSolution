using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EZOper.CSharpSolution.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("Content/Json/{*relpath}");

            AreaRegistrationContext areaRegistrationContext;
            #region // 帮助域
            areaRegistrationContext = new AreaRegistrationContext("Help", routes);
            areaRegistrationContext.MapRoute(
                 name: "Help",
                 url: "Help/{controller}/{action}/{id}",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "EZOper.CSharpSolution.WebUI.Areas.Help.Controllers" }
             );
            #endregion
            #region // 基础域-Home
            areaRegistrationContext = new AreaRegistrationContext("Home", routes);
            areaRegistrationContext.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "EZOper.CSharpSolution.WebUI.Areas.Home.Controllers" }
            );
            #endregion
        }
    }
}
