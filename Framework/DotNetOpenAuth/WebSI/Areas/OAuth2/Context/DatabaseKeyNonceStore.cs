using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using DotNetOpenAuth.Messaging.Bindings;
using EZOper.TechTester.OAuth2ApiSI;

namespace EZOper.TechTester.OAuth2WebSI.Areas.OAuth2
{
    /// <summary>
	/// A database-persisted nonce store.
	/// </summary>
	public class DatabaseKeyNonceStore : INonceStore, ICryptoKeyStore
    {
        private IOAuth2AuthService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseKeyNonceStore"/> class.
        /// </summary>
        public DatabaseKeyNonceStore() : this(ServiceFactory.GetOAuth2AuthService()) { }

        public DatabaseKeyNonceStore(IOAuth2AuthService service)
        {
            _service = service;
        }

        #region INonceStore Members

        /// <summary>
        /// Stores a given nonce and timestamp.
        /// </summary>
        /// <param name="context">The context, or namespace, within which the
        /// <paramref name="nonce"/> must be unique.
        /// The context SHOULD be treated as case-sensitive.
        /// The value will never be <c>null</c> but may be the empty string.</param>
        /// <param name="nonce">A series of random characters.</param>
        /// <param name="timestampUtc">The UTC timestamp that together with the nonce string make it unique
        /// within the given <paramref name="context"/>.
        /// The timestamp may also be used by the data store to clear out old nonces.</param>
        /// <returns>
        /// True if the context+nonce+timestamp (combination) was not previously in the database.
        /// False if the nonce was stored previously with the same timestamp and context.
        /// </returns>
        /// <remarks>
        /// The nonce must be stored for no less than the maximum time window a message may
        /// be processed within before being discarded as an expired message.
        /// This maximum message age can be looked up via the
        /// <see cref="DotNetOpenAuth.Configuration.MessagingElement.MaximumMessageLifetime"/>
        /// property, accessible via the <see cref="DotNetOpenAuth.Configuration.DotNetOpenAuthSection.Configuration"/>
        /// property.
        /// </remarks>
        public bool StoreNonce(string context, string nonce, DateTime timestampUtc)
        {
            return _service.AddOAuthNonce(new OAuthNonce { Context = context, Code = nonce, Time = timestampUtc }).IsSuccess;
        }

        #endregion

        #region ICryptoKeyStore Members

        public CryptoKey GetKey(string bucket, string handle)
        {
            var _db = _service.GetSymmetricCryptoKeys(bucket, handle);
            // Perform a case senstive match
            var matches = from key in _db
                          where string.Equals(key.Bucket, bucket, StringComparison.Ordinal) &&
                          string.Equals(key.Handle, handle, StringComparison.Ordinal)
                          select new CryptoKey(key.Secret, key.ExpiresUtc.AsUtc());
            return matches.FirstOrDefault();
        }

        public IEnumerable<KeyValuePair<string, CryptoKey>> GetKeys(string bucket)
        {
            var _db = _service.GetSymmetricCryptoKeys(bucket);
            return from key in _db
                   orderby key.ExpiresUtc descending
                   select new KeyValuePair<string, CryptoKey>(key.Handle, new CryptoKey(key.Secret, key.ExpiresUtc.AsUtc()));
        }

        public void StoreKey(string bucket, string handle, CryptoKey key)
        {
            _service.AddOAuthSymmetricCryptoKey(new OAuthSymmetricCryptoKey()
            {
                Bucket = bucket,
                Handle = handle,
                Secret = key.Key,
                ExpiresUtc = key.ExpiresUtc,
            });
        }

        public void RemoveKey(string bucket, string handle)
        {
            var match = _service.GetSymmetricCryptoKey(bucket, handle);
            if (match != null)
            {
                _service.DeleteSymmetricCryptoKey(match.ID);
            }
        }

        #endregion
    }
}