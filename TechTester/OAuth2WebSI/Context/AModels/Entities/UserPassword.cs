﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.OAuth2ApiSI
{
    public class UserPassword
    {
        public UserPassword() : this(Guid.Empty, "erikzhouxin") { }
        public UserPassword(string password) : this(Guid.NewGuid(), password) { }
        public UserPassword(Guid salt, string password)
        {
            Salt = salt;
            Password = password;
        }

        public Guid Salt { get; private set; }

        public string Password { get; private set; }

        private string _hashPassword;

        public string HashPassword
        {
            get
            {
                if (_hashPassword == null)
                {
                    _hashPassword = CalcHashPassword(Password, Salt);
                }
                return _hashPassword;
            }
        }

        /// <summary>
        /// 获得散列后的密码
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt">盐值</param>
        /// <returns></returns>
        private static string CalcHashPassword(string password, Guid salt)
        {
            string passwordSalt = password + salt.ToString("N");
            var s = new SHA1Managed();
            var enc = new UTF8Encoding();
            s.ComputeHash(enc.GetBytes(passwordSalt));
            return BitConverter.ToString(s.Hash).Replace("-", "");
        }
    }
}
