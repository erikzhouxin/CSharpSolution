using System.Web;
using System.Text;
using System.IO;
using System.Net;
using System;
using System.Collections.Generic;

namespace EZOper.CSharpSolution.WebUI.Payment.AlipayCode
{
    /// <summary>
    /// 类名：Config
    /// 功能：基础配置类
    /// 详细：设置帐户有关信息及返回路径
    /// 版本：3.3
    /// 日期：2012-07-05
    /// 说明：
    /// 如何获取安全校验码和合作身份者ID
    /// 1.用您的签约支付宝账号登录支付宝网站(www.alipay.com)
    /// 2.点击“商家服务”(https://b.alipay.com/order/myOrder.htm)
    /// 3.点击“查询合作者身份(PID)”、“查询安全校验码(Key)”
    /// 历史：
    /// 2017-8-10|精简代码
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// 获取或设置合作者身份ID
        /// 以2088开头由16位纯数字组成的字符串
        /// </summary>
        public static string Partner
        {
            get
            {
                return PaymentConfig.AlipayPartner;
            }
        }

        /// <summary>
        /// 获取或设置合作者身份ID
        /// </summary>
        public static string Seller_email
        {
            get
            {
                return PaymentConfig.AlipaySellerEmail;
            }
        }

        /// <summary>
        /// 交易安全检验码
        /// 由数字和字母组成的32位字符串
        /// </summary>
        public static string Key
        {
            get
            {
                return PaymentConfig.AlipayKey;
            }
        }

        /// <summary>
        /// 获取字符编码格式
        /// 选择项：gbk、utf-8,必须小写,且不允许有空格
        /// </summary>
        public static string Input_charset
        {
            get
            {
                return "utf-8";
            }
        }

        /// <summary>
        /// 获取签名方式
        /// 选择项：RSA、DSA、MD5,必须大写,且不允许有空格
        /// </summary>
        public static string Sign_type
        {
            get
            {
                return "MD5";
            }
        }

        private static string _logPath;
        /// <summary>
        /// 获取存放日志路径
        /// </summary>
        public static string LogPath
        {
            get
            {
                if (_logPath == null)
                {
                    _logPath = HttpContext.Current.Server.MapPath(PaymentConfig.AlipayLogPath);
                    if (!Directory.Exists(_logPath))
                    {
                        Directory.CreateDirectory(_logPath);
                    }
                }
                return _logPath;
            }
        }
    }
}