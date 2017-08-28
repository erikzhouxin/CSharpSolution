using System;
using System.Collections.Generic;
using System.Web;
using System.Threading;

namespace EZOper.NetSiteUtilities.Alipayment
{
    /// <summary>
    /// F2FBiz 的摘要说明
    /// 历史:
    /// 2017-8-27|F2FBiz+F2FMonitor
    /// 2017-8-27|F2FBiz->AlipayF2FBiz
    /// </summary>
    public class AlipayF2FBiz
    {
        /// <summary>
        /// 获取交易服务接口
        /// </summary>
        /// <returns></returns>
        public static IAlipayTradeService GetTradeImpl()
        {
            return GetTradeImpl(AlipayConfig.serverUrl, AlipayConfig.appId, AlipayConfig.merchant_private_key, AlipayConfig.version, AlipayConfig.sign_type, AlipayConfig.alipay_public_key, AlipayConfig.charset);
        }

        /// <summary>
        /// 获取交易服务接口
        /// F2FBiz.CreateClientInstance
        /// </summary>
        /// <param name="serverUrl"></param>
        /// <param name="appId"></param>
        /// <param name="merchant_private_key"></param>
        /// <param name="version"></param>
        /// <param name="sign_type"></param>
        /// <param name="alipay_public_key"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static IAlipayTradeService GetTradeImpl(string serverUrl, string appId, string merchant_private_key, string version, string sign_type, string alipay_public_key, string charset)
        {
            return new AlipayTradeImpl(serverUrl, appId, merchant_private_key, "json", version, sign_type, alipay_public_key, charset);
        }

        /// <summary>
        /// 获取监视器
        /// </summary>
        /// <returns></returns>
        public static IAlipayMonitor GetMonitorImpl()
        {
            return GetMonitorImpl(AlipayConfig.monitorUrl, AlipayConfig.appId, AlipayConfig.merchant_private_key, AlipayConfig.version, AlipayConfig.sign_type, null, AlipayConfig.charset);
        }

        /// <summary>
        /// 获取监视器
        /// F2FMonitor.CreateClientInstance
        /// </summary>
        /// <param name="monitorUrl"></param>
        /// <param name="appId"></param>
        /// <param name="merchant_private_key"></param>
        /// <param name="version"></param>
        /// <param name="sign_type"></param>
        /// <param name="alipay_public_key"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static IAlipayMonitor GetMonitorImpl(string monitorUrl, string appId, string merchant_private_key, string version, string sign_type, string alipay_public_key, string charset)
        {
            return new AlipayMonitorImpl(monitorUrl, appId, merchant_private_key, "json", version, sign_type, alipay_public_key, charset);
        }
    }
}
