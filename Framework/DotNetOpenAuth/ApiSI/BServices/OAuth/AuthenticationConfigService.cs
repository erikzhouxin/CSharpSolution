using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace EZOper.TechTester.OAuth2ApiSI
{
    public class AuthenticationConfigService
    {
        public static void ConfigureGlobal(HttpConfiguration globalConfig)
        {
            globalConfig.MessageHandlers.Add(new AuthenticationServiceHandler(CreateConfiguration()));
            globalConfig.MessageHandlers.Add(new CorsServiceHandler());
        }

        private static AuthenticationConfiguration CreateConfiguration()
        {
            var cfg = new AuthenticationConfiguration();

            return cfg;
        }
    }
}
