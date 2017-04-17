using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.DModels
{
    /// <summary>
    /// 用户特殊用户名
    /// </summary>
    public class UserAccount
    {
        public const string Admin = DataDefinition.UserAdminAccount;

        public string Account { get; set; }

        public string Password { get; set; }

        public string Code { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string AuthCode { get; set; }

        public bool IsAdmin { get { return IsAdminUser(Account); } }

        public static bool IsAdminUser(string account)
        {
            if (string.IsNullOrWhiteSpace(account))
            {
                return false;
            }
            return account.Trim().ToLower() == Admin;
        }
    }
}
