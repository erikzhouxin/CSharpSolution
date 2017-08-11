using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.CSharpSolution.WebUI.Payment
{
    internal static class PaymentConfig
    {
        #region // 支付宝=Alipay
        /// <summary>
        /// 合作身份者ID，以2088开头由16位纯数字组成的字符串
        /// AlipayCode.Config.Partner
        /// </summary>
        internal const string AlipayPartner = "";

        /// <summary>
        /// 收款支付宝账号
        /// AlipayCode.Config.Seller_email
        /// </summary>
        internal const string AlipaySellerEmail = "";

        /// <summary>
        /// 交易安全检验码，由数字和字母组成的32位字符串
        /// AlipayCode.Config.Key
        /// </summary>
        internal const string AlipayKey = "";

        /// <summary>
        /// 日志存放目录
        /// AlipayCode.Config.LogPath
        /// </summary>
        internal const string AlipayLogPath = @"\Content\Logs\Alipay";
        #endregion
        #region // 微信支付=WeChatPay|WxPay
        /// <summary>
        /// 绑定支付的APPID（必须配置）
        /// WxPayment.Config.AppID
        /// </summary>
        internal const string WeChatAppID = "";

        /// <summary>
        /// 商户支付密钥，参考开户邮件设置（必须配置）
        /// WxPayment.Config.Key
        /// </summary>
        internal const string WeChatKey = "";

        /// <summary>
        /// 商户号（必须配置）
        /// WxPayment.Config.MchID
        /// </summary>
        internal const string WeChatMchID = "";

        /// <summary>
        /// 公众帐号secert（仅JSAPI支付的时候需要配置）
        /// WxPayment.Config.AppSecret
        /// </summary>
        internal const string WeChatAppSecret = "";

        /// <summary>
        /// 证书路径（仅退款、撤销订单时需要配置）
        /// 注意应该填写绝对路径
        /// </summary>
        internal const string WeChatSslCertPath = "";

        /// <summary>
        /// 证书密码（仅退款、撤销订单时需要配置）
        /// </summary>
        internal const string WeChatSslCertPassword = "";

        /// <summary>
        /// 日志存放目录
        /// WxPayment.Config.LogPath
        /// </summary>
        internal const string WeChatLogPath = @"\Content\Logs\Wxpay";
        #endregion
    }
}
