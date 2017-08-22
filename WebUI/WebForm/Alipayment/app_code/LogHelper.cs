using System;
using System.Collections.Generic;
using System.IO;
//using System.Linq;
using System.Text;
using System.Web;


namespace EZOper.CSharpSolution.WebUI.WebForm.Alipayment
{
    /// <summary>
    /// 日志工具类
    /// </summary>
    public class LogHelper
    {
        string logFile = "";
        /// <summary>
        /// 不带参数的构造函数
        /// </summary>
        public LogHelper() : this(AppDomain.CurrentDomain.BaseDirectory + "/Content/Logs/Alipayment/log.txt")
        { }

        /// <summary>
        /// 带参数的构造函数
        /// </summary>
        /// <param name="logFile"></param>
        private LogHelper(string logFile)
        {
            this.logFile = logFile;
            if (!File.Exists(logFile))
            {
                var logPath = Path.GetDirectoryName(logFile);
                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }
                FileStream fs = File.Create(logFile);
                fs.Close();
            }
        }
        /// <summary>
        /// 追加一条信息
        /// </summary>
        /// <param name="text"></param>
        public void Write(string text)
        {
            using (StreamWriter sw = new StreamWriter(logFile, true, Encoding.UTF8))
            {
                sw.Write(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ") + text);
            }
        }
        /// <summary>
        /// 追加一条信息
        /// </summary>
        /// <param name="logFile"></param>
        /// <param name="text"></param>
        public void Write(string logFile, string text)
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
        public void WriteLine(string text)
        {
            text += "\r\n";
            using (StreamWriter sw = new StreamWriter(logFile, true, Encoding.UTF8))
            {
                sw.Write(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ") + text);
            }
        }
        /// <summary>
        /// 追加一行信息
        /// </summary>
        /// <param name="logFile"></param>
        /// <param name="text"></param>
        public void WriteLine(string logFile, string text)
        {
            text += "\r\n";
            using (StreamWriter sw = new StreamWriter(logFile, true, Encoding.UTF8))
            {
                sw.Write(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ") + text);
            }
        }

    }
}