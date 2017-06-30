using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Configuration;
using System.Web.Http;
using System.IdentityModel.Tokens;

[assembly: OwinStartupAttribute(typeof(EZOper.TechTester.JWTOAuthWebSI3.Startup))]
namespace EZOper.TechTester.JWTOAuthWebSI3
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
