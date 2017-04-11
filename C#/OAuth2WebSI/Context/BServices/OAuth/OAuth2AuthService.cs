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

        public OAuthClient GetOAuthClient(string client)
        {
            return _dataAccess.GetOAuthClient(client);
        }

        public OAuthUsers GetOAuthUsers(string userName)
        {
            return _dataAccess.GetOAuthUsers(userName);
        }

        public List<string> GetOAuthClientAuthorScopes(string client, DateTime issuedUtc, string userName)
        {
            return _dataAccess.GetOAuthClientAuthorScopes(client, issuedUtc, userName);
        }

        public OAuthSymmetricCryptoKey GetSymmetricCryptoKey(string bucket, string handle)
        {
            return _dataAccess.GetSymmetricCryptoKey(bucket, handle);
        }

        public List<OAuthSymmetricCryptoKey> GetSymmetricCryptoKeys(string bucket, string handle)
        {
            return _dataAccess.GetSymmetricCryptoKeys(bucket, handle);
        }

        public List<OAuthSymmetricCryptoKey> GetSymmetricCryptoKeys(string bucket)
        {
            return _dataAccess.GetSymmetricCryptoKeys(bucket);
        }

        public AlertMsg AddOAuthUsers(OAuthUsers oAuthUsers)
        {
            return _dataAccess.AddOAuthUsers(oAuthUsers);
        }

        public AlertMsg AddOAuthClient(OAuthClient client)
        {
            return _dataAccess.AddOAuthClient(client);
        }

        public AlertMsg AddOAuthClientAuthor(OAuthClientAuthor client)
        {
            return _dataAccess.AddOAuthClientAuthor(client);
        }

        public AlertMsg AddOAuthNonce(OAuthNonce nonce)
        {
            return _dataAccess.AddOAuthNonce(nonce);
        }

        public AlertMsg AddOAuthSymmetricCryptoKey(OAuthSymmetricCryptoKey cryptoKey)
        {
            return _dataAccess.AddOAuthSymmetricCryptoKey(cryptoKey);
        }

        public AlertMsg DeleteSymmetricCryptoKey(long cryptoKeyID)
        {
            return _dataAccess.DeleteSymmetricCryptoKey(cryptoKeyID);
        }
    }
}
