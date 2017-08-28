using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EZOper.NetSiteUtilities.Alipayment
{
    /// <summary>
    /// IAlipayMonitor 的摘要说明
    /// </summary>
    public interface IAlipayMonitor
    {
        /// <summary>
        /// 云监控接口
        /// </summary>
        AlipayF2FMonitorResult mcloudMonitor(AlipayMonitorContentBuilder builder);
    }
}