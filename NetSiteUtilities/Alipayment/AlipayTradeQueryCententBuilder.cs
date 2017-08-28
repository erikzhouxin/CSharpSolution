using System;
using System.Collections.Generic;
using System.Web;


namespace EZOper.NetSiteUtilities.Alipayment
{
    /// <summary>
    /// AlipayTradeQueryCententBuilder 的摘要说明
    /// </summary>
    public class AlipayTradeQueryContentBuilder : AlipayJsonBuilder
    {
        public string trade_no { get; set; }
        public string out_trade_no { get; set; }
        
        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}