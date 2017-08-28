using System;
using System.Collections.Generic;
using System.Web;

namespace EZOper.NetSiteUtilities.Wepayment
{
    public class WxPayException : Exception 
    {
        public WxPayException(string msg) : base(msg) 
        {

        }
     }
}