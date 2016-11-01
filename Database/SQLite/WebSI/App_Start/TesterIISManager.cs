using System;
using System.Text;
using System.Threading;
using System.IO;
using Microsoft.Web.Administration;

namespace EZOper.TechTester.SQLiteWebSI
{
    public class TesterIISManager
    {

        const string AppPoolName = "ImpactNM";
        const string WebSiteName = "ImpactNM.School.Svn";
        const int SleepTime = 1000 * 60;

        public static void start()
        {
            new Thread(RecoveryAppPool) { IsBackground = true }.Start();
            new Thread(RecoveryWebSite) { IsBackground = true }.Start();

            //防止程序退出
            while (true)
            {
                Thread.Sleep(SleepTime);
            }
        }

        static void RecoveryAppPool()
        {
            while (true)
            {
                var sm = new ServerManager();
                var pool = sm.ApplicationPools[AppPoolName];
                if (pool != null && pool.State == ObjectState.Stopped)
                {
                    WriteLog("检测到应用池" + AppPoolName + "停止服务");
                    WriteLog("正在启动应用池" + AppPoolName);
                    if (pool.Start() == ObjectState.Started)
                    {
                        WriteLog("成功启动应用池" + AppPoolName);
                    }
                    else
                    {
                        WriteLog("启动应用池" + AppPoolName + "失败. " + SleepTime / 60 + "秒后重试启动");
                    }
                }
                sm.Dispose();
                sm = null;
                Thread.Sleep(SleepTime);
            }
        }

        static void RecoveryWebSite()
        {
            while (true)
            {
                var sm = new ServerManager();
                var site = sm.Sites[WebSiteName];
                if (site != null && site.State == ObjectState.Stopped)
                {
                    WriteLog("检测到网站" + WebSiteName + "停止服务");
                    WriteLog("正在启动网站" + WebSiteName);
                    if (site.Start() == ObjectState.Started)
                    {
                        WriteLog("成功启动网站" + WebSiteName);
                    }
                    else
                    {
                        WriteLog("启动网站" + WebSiteName + "失败. " + SleepTime / 60 + "秒后重试启动");
                    }
                }
                sm.Dispose();
                sm = null;
                Thread.Sleep(SleepTime);
            }
        }

        static void WriteLog(string msg)
        {
            var fPath = "E:\\RecoveryWebsiteLog.txt";
            if (!File.Exists(fPath))
            {
                File.Create(fPath).Close();
            }

            using (StreamWriter sw = new StreamWriter(fPath, true, Encoding.UTF8))
            {
                sw.WriteLine(string.Format("{0} , 时间{1}", msg, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")));
            }
        }
    }
}
