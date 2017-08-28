using EZOper.NetSiteUtilities.AopApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace EZOper.NetSiteUtilities.Alipayment
{
    /// <summary>
    /// AlipayF2FPayResult 的摘要说明
    /// </summary>
    public class AlipayF2FRefundResult
    {
        public AlipayTradeRefundResponse response { get; set; }

        public AlipayResultEnum Status
        {
            get
            {
                if (response != null)
                {
                    if (response.Code == AlipayResultCode.SUCCESS)
                    {
                        return AlipayResultEnum.SUCCESS;
                    }
                    if (response.Code == AlipayResultCode.ERROR)
                    {
                        return AlipayResultEnum.UNKNOWN;
                    }
                    else
                        return AlipayResultEnum.FAILED;
                }
                else
                {
                    return AlipayResultEnum.UNKNOWN;
                }
            }
        }
    }
}