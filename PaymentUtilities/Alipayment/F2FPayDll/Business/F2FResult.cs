using EZOper.PaymentUtilities.Alipayment.AopApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace EZOper.PaymentUtilities.Alipayment.F2FPayDll
{

    /// <summary>
    /// F2FResult 的摘要说明
    /// </summary>
    public abstract class F2FResult
    {
        public abstract bool IsSuccess();
        public abstract AopResponse AopResponse();

    }
}