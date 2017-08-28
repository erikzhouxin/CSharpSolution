using EZOper.NetSiteUtilities.AopApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace EZOper.NetSiteUtilities.Alipayment
{

    /// <summary>
    /// F2FResult 的摘要说明
    /// 历史:
    /// 2017-8-27|F2FResult->AlipayF2FResult
    /// </summary>
    public abstract class AlipayF2FResult
    {
        public abstract bool IsSuccess();
        public abstract AopResponse AopResponse();

    }
}