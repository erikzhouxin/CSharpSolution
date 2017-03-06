using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.OAuth2ApiBLL
{
    public static class ServiceFactory
    {
        public static IAuthService GetAuthService()
        {
            return new AuthService();
        }
    }
}
