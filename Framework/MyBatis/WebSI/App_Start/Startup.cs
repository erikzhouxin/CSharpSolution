using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EZOper.TechTester.MyBatisWebSI.Startup))]
namespace EZOper.TechTester.MyBatisWebSI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
