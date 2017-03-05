using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.OAuth2ApiSI.IDL
{
    /// <summary>
    /// 用户特殊用户名
    /// </summary>
    public class UserAccount
    {
        public const string Admin = "admin";

        public static bool IsAdmin(string account)
        {
            if (string.IsNullOrWhiteSpace(account))
            {
                return false;
            }
            return account.Trim().ToLower() == Admin;
        }
    }
}
