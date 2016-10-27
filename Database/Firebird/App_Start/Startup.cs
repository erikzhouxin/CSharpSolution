using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EZOper.TechTester.FirebirdDB.WebSI.Startup))]
namespace EZOper.TechTester.FirebirdDB.WebSI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
