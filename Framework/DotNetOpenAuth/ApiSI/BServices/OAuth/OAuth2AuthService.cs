using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.OAuth2ApiSI
{
    internal class OAuth2AuthService : IOAuth2AuthService
    {
        OAuth2AuthDataAccess _dataAccess;
        public OAuth2AuthService()
        {
            _dataAccess = new OAuth2AuthDataAccess();
        }

        public bool IsUserNameValid(string userName)
        {
            return _dataAccess.IsUserNameValid(userName);
        }

        public AlertMsg AddOAuthUsers(OAuthUsers oAuthUsers)
        {
            return _dataAccess.AddOAuthUsers(oAuthUsers);
        }

        public AlertMsg AddOAuthClient(OAuthClient client)
        {
            return _dataAccess.AddOAuthClient(client);
        }
    }
}
