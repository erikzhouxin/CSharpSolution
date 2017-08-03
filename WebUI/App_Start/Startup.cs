using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartupAttribute(typeof(EZOper.CSharpSolution.WebUI.Startup))]
namespace EZOper.CSharpSolution.WebUI
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
