using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EZOper.TechTester.DotNetOpenAuth2WebSI.Areas.Clients
{
    public class ContextConfig
    {
        public static string TokenEndpoint = ConfigurationManager.AppSettings["TokenEndpoint"];
        public static string AuthorizationEndpoint = ConfigurationManager.AppSettings["AuthorizationEndpoint"];
        /// <summary>
        /// OpenApiAddress = OpenApiAddress.EndsWith("/") ? OpenApiAddress : (OpenApiAddress + "/");
        /// </summary>
        public static string OpenApiAddress = ConfigurationManager.AppSettings["OpenApiAddress"];
    }
}