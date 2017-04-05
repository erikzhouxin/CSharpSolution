using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.OAuth2ApiSI
{
    internal class OAuth2AuthDataAccess
    {
        public bool IsUserNameValid(string userName)
        {
            var helper = new SQLiteHelper();
            var accountParam = new SQLiteParameter("claimed", userName);
            var resultTable = helper.GetDataTable("SELECT OAuthUsers.Claimed FROM OAuthUsers WHERE Claimed = @claimed", accountParam);
            return resultTable.Rows.Count == 1;
        }

        public OAuthUsers GetOAuthUsers(string userName)
        {
            var helper = new SQLiteHelper();
            var accountParam = new SQLiteParameter("claimed", userName);
            var resultTab = helper.GetDataTable("SELECT ID, Claimed, Friendly) FROM OAuthUsers WHERE Claimed = @claimed", accountParam);
            if (resultTab.Rows.Count > 0)
            {
                var row = resultTab.Rows[0];
                return new OAuthUsers()
                {
                    ID = Convert.ToInt64(row["ID"]),
                    Claimed = row["Claimed"].ToString(),
                    Friendly = row["Friendly"].ToString(),
                };
            }
            return null;
        }

        public OAuthClient GetOAuthClient(string client)
        {
            var helper = new SQLiteHelper();
            var clientParam = new SQLiteParameter("client", client);
            var resultTab = helper.GetDataTable("SELECT OAuthClient.ID, OAuthClient.Client, OAuthClient.Secret, OAuthClient.Callback, OAuthClient.Name, OAuthClient.Type, OAuthClient.Time FROM OAuthClient WHERE Client = @client", clientParam);
            if (resultTab.Rows.Count > 0)
            {
                var row = resultTab.Rows[0];
                return new OAuthClient()
                {
                    ID = Convert.ToInt64(row["ID"]),
                    Client = row["Client"].ToString(),
                    Secret = row["Secret"].ToString(),
                    Callback = row["Callback"].ToString(),
                    Name = row["Name"].ToString(),
                    Type = Convert.ToInt32(row["Type"]),
                    Time = new DateTime(Convert.ToInt64(row["Time"])),
                };
            }
            return null;
        }

        public List<string> GetOAuthClientAuthorScopes(string client, DateTime issuedTime, string userName)
        {
            var helper = new SQLiteHelper();
            var clientParam = new SQLiteParameter("client", client);
            var timeParam = new SQLiteParameter("time", issuedTime.Ticks);
            var nowParam = new SQLiteParameter("nowUtc", DateTime.Now.Ticks);
            var nameParam = new SQLiteParameter("userName", userName);
            var resultTab = helper.GetDataTable("SELECT OAuthClientAuthor.Scope FROM OAuthClientAuthor INNER JOIN OAuthClient ON OAuthClientAuthor.ClientId = OAuthClient.ID INNER JOIN OAuthUsers ON OAuthUsers.ID = OAuthClientAuthor.UserID WHERE Client = @client AND OAuthClientAuthor.Time <= @time AND OAuthClientAuthor.ExpireUtc >= @nowUtc AND OAuthUsers.Claimed = @userName", clientParam, timeParam, nowParam, nameParam);
            var result = new List<string>();
            foreach (DataRow item in resultTab.Rows)
            {
                result.Add(item["Scope"].ToString());
            }
            return result;
        }

        public List<OAuthSymmetricCryptoKey> GetSymmetricCryptoKeys(string bucket)
        {
            var helper = new SQLiteHelper();
            var bucketParam = new SQLiteParameter("bucket", bucket);
            var resultTab = helper.GetDataTable("SELECT OAuthSymmetricCryptoKey.ID, OAuthSymmetricCryptoKey.Bucket, OAuthSymmetricCryptoKey.Handle, OAuthSymmetricCryptoKey.Secret, OAuthSymmetricCryptoKey.ExpiresUtc FROM OAuthSymmetricCryptoKey WHERE OAuthSymmetricCryptoKey.Bucket = @bucket", bucketParam);
            var result = new List<OAuthSymmetricCryptoKey>();
            foreach (DataRow row in resultTab.Rows)
            {
                var model = new OAuthSymmetricCryptoKey();
                model.ID = Convert.ToInt64(row["ID"]);
                model.Bucket = row["Bucket"].ToString();
                model.Handle = row["Handle"].ToString();
                model.Secret = Encoding.Unicode.GetBytes(row["Secret"].ToString());
                model.ExpiresUtc = new DateTime(Convert.ToInt64(row["ExpiresUtc"]));
                result.Add(model);
            }
            return result;
        }

        public List<OAuthSymmetricCryptoKey> GetSymmetricCryptoKeys(string bucket, string handle)
        {
            var helper = new SQLiteHelper();
            var bucketParam = new SQLiteParameter("bucket", bucket);
            var handleParam = new SQLiteParameter("handle", bucket);
            var resultTab = helper.GetDataTable("SELECT OAuthSymmetricCryptoKey.ID, OAuthSymmetricCryptoKey.Bucket, OAuthSymmetricCryptoKey.Handle, OAuthSymmetricCryptoKey.Secret, OAuthSymmetricCryptoKey.ExpiresUtc FROM OAuthSymmetricCryptoKey WHERE OAuthSymmetricCryptoKey.Bucket = @bucket AND OAuthSymmetricCryptoKey.Handle = @handle", bucketParam, handleParam);
            var result = new List<OAuthSymmetricCryptoKey>();
            foreach (DataRow row in resultTab.Rows)
            {
                var model = new OAuthSymmetricCryptoKey();
                model.ID = Convert.ToInt64(row["ID"]);
                model.Bucket = row["Bucket"].ToString();
                model.Handle = row["Handle"].ToString();
                model.Secret = Encoding.Unicode.GetBytes(row["Secret"].ToString());
                model.ExpiresUtc = new DateTime(Convert.ToInt64(row["ExpiresUtc"]));
                result.Add(model);
            }
            return result;
        }

        public OAuthSymmetricCryptoKey GetSymmetricCryptoKey(string bucket, string handle)
        {
            var helper = new SQLiteHelper();
            var bucketParam = new SQLiteParameter("bucket", bucket);
            var handleParam = new SQLiteParameter("handle", bucket);
            var resultTab = helper.GetDataTable("SELECT OAuthSymmetricCryptoKey.ID, OAuthSymmetricCryptoKey.Bucket, OAuthSymmetricCryptoKey.Handle, OAuthSymmetricCryptoKey.Secret, OAuthSymmetricCryptoKey.ExpiresUtc FROM OAuthSymmetricCryptoKey WHERE OAuthSymmetricCryptoKey.Bucket = @bucket AND OAuthSymmetricCryptoKey.Handle = @handle LIMIT 0,1", bucketParam, handleParam);
            if (resultTab.Rows.Count > 0)
            {
                var row = resultTab.Rows[0];
                var model = new OAuthSymmetricCryptoKey();
                model.ID = Convert.ToInt64(row["ID"]);
                model.Bucket = row["Bucket"].ToString();
                model.Handle = row["Handle"].ToString();
                model.Secret = Encoding.Unicode.GetBytes(row["Secret"].ToString());
                model.ExpiresUtc = new DateTime(Convert.ToInt64(row["ExpiresUtc"]));
                return model;
            }
            return null;
        }

        public AlertMsg AddOAuthUsers(OAuthUsers user)
        {
            var helper = new SQLiteHelper();
            var claimedParam = new SQLiteParameter("claimed", user.Claimed);
            var friendlyParam = new SQLiteParameter("friendly", user.Friendly);
            var effResult = helper.ExecNonQuery("INSERT INTO OAuthUsers(Claimed, Friendly) VALUES(@claimed, @friendly)", claimedParam, friendlyParam);
            AlertMsg result = effResult;
            result.IsSuccess = effResult.EffectLines == 1;
            return result;
        }

        public AlertMsg AddOAuthClient(OAuthClient client)
        {
            var helper = new SQLiteHelper();
            var clientParam = new SQLiteParameter("client", client.Client);
            var secretParam = new SQLiteParameter("secret", client.Secret);
            var callbackParam = new SQLiteParameter("callback", client.Callback);
            var nameParam = new SQLiteParameter("name", client.Name);
            var typeParam = new SQLiteParameter("type", client.Type);
            var timeParam = new SQLiteParameter("time", client.Time.Ticks);
            var effResult = helper.ExecNonQuery("INSERT INTO OAuthClient(Client, Secret, Callback, Name, Type, Time) VALUES(@client, @secret, @callback, @name, @type, @time)", clientParam, secretParam, callbackParam, nameParam, typeParam, timeParam);
            AlertMsg result = effResult;
            result.IsSuccess = effResult.EffectLines == 1;
            return result;
        }

        public AlertMsg AddOAuthClientAuthor(OAuthClientAuthor client)
        {
            var helper = new SQLiteHelper();
            var clientIdParam = new SQLiteParameter("clientId", client.ClientID);
            var userIdParam = new SQLiteParameter("userId", client.UserID);
            var scopeParam = new SQLiteParameter("scope", client.Scope);
            var expireUtcParam = new SQLiteParameter("expireUtc", client.ExpireUtc.Ticks);
            var timeParam = new SQLiteParameter("time", client.Time.Ticks);
            var effResult = helper.ExecNonQuery("INSERT INTO OAuthClientAuthor (ClientId, UserId, Scope, ExpireUtc, Time) VALUES (@clientId, @userId, @scope, @expireUtc, @time);", clientIdParam, userIdParam, scopeParam, expireUtcParam, timeParam);
            AlertMsg result = effResult;
            result.IsSuccess = effResult.EffectLines == 1;
            return result;
        }

        public AlertMsg AddOAuthNonce(OAuthNonce nonce)
        {
            var helper = new SQLiteHelper();
            var contextParam = new SQLiteParameter("context", nonce.Context);
            var codeParam = new SQLiteParameter("code", nonce.Code);
            var timeParam = new SQLiteParameter("time", nonce.Time.Ticks);
            var effResult = helper.ExecNonQuery("INSERT INTO OAuthNonce (Context, Code, Time) VALUES (@context, @code, @time);", contextParam, codeParam, timeParam);
            AlertMsg result = effResult;
            result.IsSuccess = effResult.EffectLines == 1;
            return result;
        }

        public AlertMsg AddOAuthSymmetricCryptoKey(OAuthSymmetricCryptoKey cryptoKey)
        {
            var helper = new SQLiteHelper();
            var bucketParam = new SQLiteParameter("bucket", cryptoKey.Bucket);
            var handleParam = new SQLiteParameter("handle", cryptoKey.Handle);
            var secretParam = new SQLiteParameter("secret", Encoding.Unicode.GetString(cryptoKey.Secret));
            var expiresUtcParam = new SQLiteParameter("expiresUtc", cryptoKey.ExpiresUtc.Ticks);
            var effResult = helper.ExecNonQuery("INSERT INTO OAuthSymmetricCryptoKey (Bucket, Handle, Secret, ExpiresUtc) VALUES (@bucket, @handle, @secret, @expiresUtc);", bucketParam, handleParam, secretParam, expiresUtcParam);
            AlertMsg result = effResult;
            result.IsSuccess = effResult.EffectLines == 1;
            return result;
        }

        public AlertMsg DeleteSymmetricCryptoKey(long cryptoKeyID)
        {
            var helper = new SQLiteHelper();
            var idParam = new SQLiteParameter("id", cryptoKeyID);
            var effResult = helper.ExecNonQuery("DELETE FROM OAuthSymmetricCryptoKey WHERE ID = @id;", idParam);
            AlertMsg result = effResult;
            result.IsSuccess = effResult.EffectLines == 1;
            return result;
        }

    }
}
