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
    public class AlipayF2FPayResult
    {
        public AlipayTradePayResponse response { get; set; }

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