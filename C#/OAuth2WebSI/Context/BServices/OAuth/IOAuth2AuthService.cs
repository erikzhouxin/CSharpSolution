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

        OAuthUsers GetOAuthUsers(string userName);

        OAuthClient GetOAuthClient(string client);

        List<string> GetOAuthClientAuthorScopes(string clientIdentifier, DateTime issuedUtc, string userName);

        OAuthSymmetricCryptoKey GetSymmetricCryptoKey(string bucket, string handle);

        List<OAuthSymmetricCryptoKey> GetSymmetricCryptoKeys(string bucket, string handle);

        List<OAuthSymmetricCryptoKey> GetSymmetricCryptoKeys(string bucket);

        AlertMsg AddOAuthUsers(OAuthUsers user);

        AlertMsg AddOAuthClient(OAuthClient client);

        AlertMsg AddOAuthClientAuthor(OAuthClientAuthor client);

        AlertMsg AddOAuthNonce(OAuthNonce nonce);

        AlertMsg AddOAuthSymmetricCryptoKey(OAuthSymmetricCryptoKey cryptoKey);

        AlertMsg DeleteSymmetricCryptoKey(long cryptoKeyID);
    }
}
