using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;

[assembly: OwinStartupAttribute(typeof(EZOper.TechTester.EZWebTemplate.Startup))]
namespace EZOper.TechTester.EZWebTemplate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var configuration = new HttpConfiguration();
            WebApiConfig.Register(configuration);
            app.UseWebApi(configuration);
        }

        public void ConfigureAuth(IAppBuilder app)
        {

        }
    }
}