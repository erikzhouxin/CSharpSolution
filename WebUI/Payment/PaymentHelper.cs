using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using ThoughtWorks.QRCode.Codec;

namespace EZOper.CSharpSolution.WebUI.Payment
{
    /// <summary>
    /// 支付帮助类
    /// </summary>
    public static class PaymentHelper
    {
        /// <summary>
        /// 获取GET|POST过来通知消息字典
        /// {key:参数名,value:参数值}
        /// </summary>
        /// <returns>字典</returns>
        public static Dictionary<string, string> GetRequestDic(this NameValueCollection queryString)
        {
            var result = new Dictionary<string, string>();
            if (queryString == null || queryString.AllKeys.Length <= 0)
            {
                return result;
            }
            foreach (var item in queryString.AllKeys)
            {
                result.Add(item, queryString[item]);
            }
            return result;
        }
    }
}