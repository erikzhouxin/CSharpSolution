using System;
using System.Collections.Generic;
using System.Web;
using System.IO;

namespace EZOper.CSharpSolution.WebUI.Payment.WxPayment
{
    /// <summary>
    /// 简单日志操作
    /// Log
    /// </summary>
    public class WxPayLog
    {
        /// <summary>
        /// 向日志文件写入调试信息
        /// </summary>
        /// <param name="className">类名</param>
        /// <param name="content">写入内容</param>
        public static void Debug(string className, string content)
        {
            if (WxPayConfig.LogLevel >= 3)
            {
                WriteLog("DEBUG", className, content);
            }
        }

        /// <summary>
        /// 向日志文件写入运行时信息
        /// </summary>
        /// <param name="className">类名</param>
        /// <param name="content">写入内容</param> 
        public static void Info(string className, string content)
        {
            if (WxPayConfig.LogLevel >= 2)
            {
                WriteLog("INFO", className, content);
            }
        }

        /// <summary>
        /// 向日志文件写入出错信息
        /// </summary>
        /// <param name="className">类名</param>
        /// <param name="content">写入内容</param> 
        public static void Error(string className, string content)
        {
            if (WxPayConfig.LogLevel >= 1)
            {
                WriteLog("ERROR", className, content);
            }
        }

        /// <summary>
        /// 实际的写日志操作
        /// </summary>
        /// <param name="type">日志记录类型</param>
        /// <param name="className">类名</param>
        /// <param name="content">写入内容</param> 
        protected static void WriteLog(string type, string className, string content)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");//获取当前系统时间
            string filename = WxPayConfig.LogPath + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";//用日期对日志文件命名

            //创建或打开日志文件，向日志文件末尾追加记录
            StreamWriter mySw = File.AppendText(filename);

            //向日志文件写入内容
            string write_content = time + " " + type + " " + className + ": " + content;
            mySw.WriteLine(write_content);

            //关闭日志文件
            mySw.Close();
        }
    }
}