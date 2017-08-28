using System;
using System.Collections.Generic;
using System.IO;
//using System.Linq;
using System.Text;
using System.Web;

namespace EZOper.NetSiteUtilities.Alipayment
{
    /// <summary>
    /// 日志工具类
    /// 历史:
    /// 2017-8-27|LogHelper
    /// </summary>
    public class AlipayLog
    {
        private static string LogFile = GetAlipayLog();
        /// <summary>
        /// 带参数的构造函数
        /// </summary>
        /// <param name="logFile"></param>
        private static string GetAlipayLog()
        {
            var logFile = AppDomain.CurrentDomain.BaseDirectory + "/Content/Logs/Alipay/log.txt";
            if (!File.Exists(logFile))
            {
                FileStream fs = File.Create(logFile);
                fs.Close();
            }
            return logFile;
        }
        /// <summary>
        /// 追加一条信息
        /// </summary>
        /// <param name="text"></param>
        public static void Write(string text)
        {
            using (StreamWriter sw = new StreamWriter(LogFile, true, Encoding.UTF8))
            {
                sw.Write(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ") + text);
            }
        }
        /// <summary>
        /// 追加一条信息
        /// </summary>
        /// <param name="logFile"></param>
        /// <param name="text"></param>
        public static void Write(string logFile, string text)
        {
            using (StreamWriter sw = new StreamWriter(logFile, true, Encoding.UTF8))
            {
                sw.Write(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ") + text);
            }
        }
        /// <summary>
        /// 追加一行信息
        /// </summary>
        /// <param name="text"></param>
        public static void WriteLine(string text)
        {
            text += "\r\n";
            using (StreamWriter sw = new StreamWriter(LogFile, true, Encoding.UTF8))
            {
                sw.Write(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ") + text);
            }
        }
        /// <summary>
        /// 追加一行信息
        /// </summary>
        /// <param name="logFile"></param>
        /// <param name="text"></param>
        public static void WriteLine(string logFile, string text)
        {
            text += "\r\n";
            using (StreamWriter sw = new StreamWriter(logFile, true, Encoding.UTF8))
            {
                sw.Write(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ") + text);
            }
        }

    }
}