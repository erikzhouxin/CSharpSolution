using System;
using System.Collections.Generic;
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

        public AlertMsg  AddOAuthUsers(OAuthUsers user)
        {
            var helper = new SQLiteHelper();
            var claimedParam = new SQLiteParameter("claimed", user.Claimed);
            var friendlyParam = new SQLiteParameter("friendly", user.Friendly);
            var effResult = helper.ExecNonQuery("INSERT INTO OAuthUsers(Claimed, Friendly) VALUSE(@claimed, @friendly)", claimedParam, friendlyParam);
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
            var effResult = helper.ExecNonQuery("INSERT INTO OAuthClient(Client, Secret, Callback, Name, Type, Time) VALUSE(@client, @secret, @callback, @name, @type, @time)", clientParam, secretParam, callbackParam, nameParam, typeParam, timeParam);
            AlertMsg result = effResult;
            result.IsSuccess = effResult.EffectLines == 1;
            return result;
        }
    }
}
