﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EZOper.TechTester.OAuth2WebSI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            AreaRegistrationContext areaRegContext;
            
            areaRegContext = new AreaRegistrationContext("ZApi", routes);
            areaRegContext.MapRoute(
                 name: "ZApi",
                 url: "ZApi/{controller}/{action}/{id}",
                 defaults: new { controller = "Help", action = "Api", id = UrlParameter.Optional },
                 namespaces: new[] { "EZOper.TechTester.OAuth2WebSI.Areas.ZApi.Controllers" }
             );

            areaRegContext = new AreaRegistrationContext("Home", routes);
            areaRegContext.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Auth", action = "LogOn", id = UrlParameter.Optional },
                namespaces: new [] { "EZOper.TechTester.OAuth2WebSI.Areas.Home.Controllers" }
            );
        }
    }
}
