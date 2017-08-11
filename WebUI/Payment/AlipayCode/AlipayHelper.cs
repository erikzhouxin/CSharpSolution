using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace EZOper.CSharpSolution.WebUI.Payment.AlipayCode
{
    /// <summary>
    /// 支付宝帮助类
    /// 已弃用-20170810
    /// </summary>
    [Obsolete("替代方案:Submit.GetRequest,此类中的两个方法实现相同")]
    public class AlipayHelper
    {
        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        [Obsolete("替代方案:Submit.GetRequest")]
        public static SortedDictionary<string, string> GetRequestPost(NameValueCollection requestForm)
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();

            //Load Form variables into NameValueCollection variable.
            NameValueCollection coll = requestForm;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], requestForm[requestItem[i]]);
            }

            return sArray;
        }


        /// <summary>
        /// 获取支付宝GET过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        [Obsolete("替代方案:Submit.GetRequest")]
        public static SortedDictionary<string, string> GetRequestGet(NameValueCollection requestQueryString)
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();

            //Load Form variables into NameValueCollection variable.
            NameValueCollection coll = requestQueryString;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], requestQueryString[requestItem[i]]);
            }

            return sArray;
        }

    }
}