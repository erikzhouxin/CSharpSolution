using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace EZOper.CSharpSolution.WebUI.Payment.WxPayment
{
    /// <summary>
    /// 配置账号信息
    /// </summary>
    public class WxPayConfig
    {
        /// <summary>
        /// 绑定支付的APPID（必须配置）
        /// </summary>
        public static string AppID
        {
            get
            {
                return PaymentConfig.WeChatAppID;
            }
        }

        /// <summary>
        /// 商户号（必须配置）
        /// </summary>
        public static string MchID
        {
            get
            {
                return PaymentConfig.WeChatMchID;
            }
        }

        /// <summary>
        /// 商户支付密钥，参考开户邮件设置（必须配置）
        /// </summary>
        public static string Key
        {
            get
            {
                return PaymentConfig.WeChatKey;
            }
        }

        /// <summary>
        /// 公众帐号secert
        /// 仅JSAPI支付的时候需要配置
        /// </summary>
        public static string AppSecret
        {
            get
            {
                return PaymentConfig.WeChatAppSecret;
            }
        }

        /// <summary>
        /// 证书路径,注意应该填写绝对路径（仅退款、撤销订单时需要）
        /// cert/apiclient_cert.p12
        /// </summary>
        public static string SslCertPath
        {
            get
            {
                return PaymentConfig.WeChatSslCertPath;
            }
        }

        /// <summary>
        /// 证书访问密码
        /// </summary>
        public static string SslCertPassword
        {
            get
            {
                return PaymentConfig.WeChatSslCertPassword;
            }
        }

        /// <summary>
        /// 支付结果通知回调url，用于商户接收支付结果
        /// </summary>
        public static string NotifyUrl
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// 商户系统后台机器IP
        /// 此参数可手动配置也可在程序中自动获取
        /// </summary>
        public static string IP
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// 代理服务器设置
        /// 默认IP和端口号分别为0.0.0.0和0，此时不开启代理（如有需要才设置）
        /// </summary>
        public static string ProxyUrl
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// 上报信息配置
        /// 测速上报等级，0.关闭上报; 1.仅错误时上报; 2.全量上报
        /// </summary>
        public static int ReportLevel
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// 日志级别
        /// 日志等级，0.不输出日志；1.只输出错误信息; 2.输出错误和正常信息; 3.输出错误信息、正常信息和调试信息
        /// </summary>
        public static int LogLevel
        {
            get
            {
                return 0;
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
                    _logPath = HttpContext.Current.Server.MapPath(PaymentConfig.WeChatLogPath);
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