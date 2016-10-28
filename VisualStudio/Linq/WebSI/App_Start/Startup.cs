using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EZOper.TechTester.LinqWebSI.Startup))]
namespace EZOper.TechTester.LinqWebSI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
