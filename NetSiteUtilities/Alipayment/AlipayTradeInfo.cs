using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace EZOper.NetSiteUtilities.Alipayment
{
    /// <summary>
    /// TradeInfo 的摘要说明
    /// 历史:
    /// 2017-8-27|TradeInfo->AlipayTradeInfo
    /// </summary>
    public class AlipayTradeInfo
    {
        public string OTN { get; set; }

        public string TC { get; set; }

        public string STAT { get; set; }
    }
}