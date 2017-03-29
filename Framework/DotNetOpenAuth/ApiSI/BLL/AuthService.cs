using EZOper.TechTester.OAuth2ApiSI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.OAuth2ApiBLL
{
    internal class AuthService : IAuthService
    {
        private AuthDataAccess _dataAccess;
        public AuthService()
        {
            _dataAccess = new AuthDataAccess();
        }

        public bool IsValid(LogOnViewModel model)
        {
            return _dataAccess.IsValid(model);
        }
    }
}
