using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZOper.TechTester.SQLiteWebSI
{
    public class SysContext
    {
        #region // 约定名称
        public const string TempData_ErrorMsg = "TempData_ErrorMsg";
        public const string Session_AuthCode = "Session_AuthCode";
        #endregion
        #region // 配置约定
        public static readonly string EZOper_TechTester_SQLite_Sqlite3 = ConfigurationManager.ConnectionStrings["EZOper.TechTester.SQLite.sqlite3"].ConnectionString;
        public static readonly bool IsReleaseMode = ConfigurationManager.AppSettings["IsRelease"].Equals("true");
        public static readonly bool IsSettingMode = ConfigurationManager.AppSettings["IsSetting"].Equals("true");
        #endregion

        /// <summary>
        /// 判断是否与当前验证码一致
        /// </summary>
        public static bool IsValidAuthCode(string authCode)
        {
            return !SysContext.IsReleaseMode || (HttpContext.Current.Session[SysContext.Session_AuthCode] != null && HttpContext.Current.Session[SysContext.Session_AuthCode].ToString().Equals(authCode, StringComparison.OrdinalIgnoreCase));
        }
    }
}