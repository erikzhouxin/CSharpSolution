using Aop.Api.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace EZOper.CSharpSolution.WebUI.Alipayment
{
    /// <summary>
    /// IAlipayMonitor 的摘要说明
    /// </summary>
    public interface IAlipayMonitor
    {

        //云监控接口
        AlipayF2FMonitorResult mcloudMonitor(AlipayMonitorContentBuilder builder);
    }

}