using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.OAuth2ApiSI
{
    public interface IOAuth2AuthService
    {
        bool IsUserNameValid(string userName);

        AlertMsg AddOAuthUsers(OAuthUsers user);

        AlertMsg AddOAuthClient(OAuthClient client);
    }
}
