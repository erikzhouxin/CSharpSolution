using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EZOper.TechTester.SQLiteWebSI.Startup))]
namespace EZOper.TechTester.SQLiteWebSI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
