using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace EZOper.TechTester.OAuth2ApiBLL
{
    public interface IAccountMembershipService
    {
        MembershipCreateStatus CreateUser(string claimedIdentifier, string email);
    }
}
