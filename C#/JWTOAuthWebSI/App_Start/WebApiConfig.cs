using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EZOper.TechTester.JWTOAuthWebSI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "Api/{controller}/{action}/{id}",
                defaults: new { area = "ZApi", id = RouteParameter.Optional }
            );

            // config.Formatters.Remove(config.Formatters.JsonFormatter);
            // config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
