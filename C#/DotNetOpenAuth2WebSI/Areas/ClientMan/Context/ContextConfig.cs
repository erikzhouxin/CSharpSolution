using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EZOper.TechTester.DotNetOpenAuth2WebSI.Areas.ClientMan
{
    public class ContextConfig
    {
        public static string OpenApiAddress = ConfigurationManager.AppSettings["OpenApiAddress"];

    }
}