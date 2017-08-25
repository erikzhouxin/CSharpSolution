using System;
using System.Collections.Generic;
using System.Web;

namespace EZOper.PaymentUtilities.Wepayment.WxPayAPI
{
    public class WxPayException : Exception 
    {
        public WxPayException(string msg) : base(msg) 
        {

        }
     }
}