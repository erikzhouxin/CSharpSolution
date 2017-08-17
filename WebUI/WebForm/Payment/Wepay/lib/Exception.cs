using System;
using System.Collections.Generic;
using System.Web;

namespace EZOper.CSharpSolution.WebUI.WebForm.Payment.Wepay.WxPayAPI
{
    public class WxPayException : Exception 
    {
        public WxPayException(string msg) : base(msg) 
        {

        }
     }
}