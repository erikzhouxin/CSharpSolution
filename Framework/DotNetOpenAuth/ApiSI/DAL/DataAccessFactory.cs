using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.OAuth2ApiDAL
{
    internal static class DataAccessFactory
    {
        internal static IAuthDataAccess GetAuthDataAccess()
        {
            return new AuthDataAccess();
        }
    }
}
