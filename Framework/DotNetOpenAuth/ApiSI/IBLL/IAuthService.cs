using EZOper.TechTester.OAuth2ApiDEMV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.OAuth2ApiBLL
{
    public interface IAuthService
    {
        bool IsValid(LogOnViewModel model);
    }
}
