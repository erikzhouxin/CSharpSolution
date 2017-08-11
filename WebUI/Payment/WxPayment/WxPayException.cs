using System;
using System.Collections.Generic;
using System.Web;

namespace EZOper.CSharpSolution.WebUI.Payment.WxPayment
{
    /// <summary>
    /// 付款执行中的错误异常
    /// </summary>
    public class WxPayException : Exception 
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="msg"></param>
        public WxPayException(string msg) : base(msg) 
        {

        }
     }
}