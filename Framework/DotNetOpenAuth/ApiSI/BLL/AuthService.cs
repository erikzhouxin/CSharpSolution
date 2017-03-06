using EZOper.TechTester.OAuth2ApiDAL;
using EZOper.TechTester.OAuth2ApiDEMV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.OAuth2ApiBLL
{
    internal class AuthService : IAuthService
    {
        private IAuthDataAccess _dataAccess;
        public AuthService()
        {
            _dataAccess = DataAccessFactory.GetAuthDataAccess();
        }

        public bool IsValid(LogOnViewModel model)
        {
            return _dataAccess.IsValid(model);
        }
    }
}
