using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.OAuth2ApiSI
{
    public static class ServiceFactory
    {
        public static IAuthService GetAuthService()
        {
            return new AuthService();
        }

        public static IOAuth2AuthService GetOAuth2AuthService()
        {
            return new OAuth2AuthService();
        }
    }
}
