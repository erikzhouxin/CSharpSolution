using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace EZOper.TechTester.OAuth2ApiBLL
{
    public static class EZModelsServiceFactory
    {
        public static IFormsAuthenticationService GetFormsAuthenticationService()
        {
            return new FormsAuthenticationService();
        }

        public static IAccountMembershipService GetAccountMembershipService(MembershipProvider provider = null)
        {
            return new AccountMembershipService(provider);
        }
    }
}
