using EZOper.TechTester.OAuth2ApiDEMV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.OAuth2ApiDAL
{
    internal interface IAuthDataAccess
    {
        bool IsValid(LogOnViewModel model);
    }
}
