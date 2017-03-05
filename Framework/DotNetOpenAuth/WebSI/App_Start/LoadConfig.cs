using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.OAuth2WebSI
{
    public class RuntimeConfig
    {
        private static object lockObj = new object();

        /// <summary>
        /// 是否发布
        /// </summary>
        public bool IsDebugMode { get; private set; } = false;

        /// <summary>
        /// 是否设置模式
        /// </summary>
        public bool IsSettingMode { get; private set; } = false;

        /// <summary>
        /// 是否允许远程访问
        /// </summary>
        public bool IsRemoteSetting { get; private set; } = false;

        /// <summary>
        /// 允许远程访问的IP地址
        /// </summary>
        public List<string> RemoteAccessIP { get; private set; } = new List<string>();

        /// <summary>
        /// 是否启用性能日志
        /// </summary>
        public bool IsPerformLog { get; private set; } = false;

        /// <summary>
        /// 上传文件虚拟目录
        /// </summary>
        public string Directory_VirtualUpload { get; private set; } = "/Content/Upload/";

        /// <summary>
        /// 缓存文件虚拟目录
        /// </summary>
        public string Directory_VirtualTemp { get; private set; } = "/Content/Upload/";

        public RuntimeConfig GetInstance()
        {
            lock (lockObj)
            {
                return new RuntimeConfig();
            }
        }
    }
}
