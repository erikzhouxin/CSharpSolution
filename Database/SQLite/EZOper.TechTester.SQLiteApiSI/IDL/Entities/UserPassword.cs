using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.SQLiteApiSI.IDL
{
    public class UserPassword
    {
        public UserPassword()
            : this(Guid.Empty.ToString(), "erikzhouxin")
        { }
        public UserPassword(string password)
            : this(Guid.NewGuid().ToString(), password)
        { }
        public UserPassword(string salt, string password)
        {
            Salt = salt;
            Password = password;
        }

        public string Salt { get; private set; }

        public string Password { get; private set; }

        public string HashPassword
        {
            get
            {
                return CalcHashPassword(Password, Salt);
            }
        }

        /// <summary>
        /// 获得散列后的密码
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt">盐值</param>
        /// <returns></returns>
        private static string CalcHashPassword(string password, string salt)
        {
            string passwordSalt = password + salt;
            var s = new SHA1Managed();
            var enc = new UTF8Encoding();
            s.ComputeHash(enc.GetBytes(passwordSalt));
            return BitConverter.ToString(s.Hash).Replace("-", "");
        }
    }
}
