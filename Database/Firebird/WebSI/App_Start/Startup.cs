using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EZOper.TechTester.FirebirdWebSI.Startup))]
namespace EZOper.TechTester.FirebirdWebSI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
