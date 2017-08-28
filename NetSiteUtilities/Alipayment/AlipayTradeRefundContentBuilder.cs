using System;
using System.Collections.Generic;
using System.Web;


namespace EZOper.NetSiteUtilities.Alipayment
{
    /// <summary>
    /// AlipayTradeRefundContentBuilder 的摘要说明
    /// </summary>
    public class AlipayTradeRefundContentBuilder : AlipayJsonBuilder
    {
        public string trade_no { get; set; }

        public string out_trade_no { get; set; }

        public string refund_amount { get; set; }

        public string out_request_no { get; set; }

        public string refund_reason { get; set; }
        
        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}