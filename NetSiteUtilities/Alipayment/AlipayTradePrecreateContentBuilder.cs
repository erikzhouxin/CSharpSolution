using System;
using System.Collections.Generic;
using System.Web;


namespace EZOper.NetSiteUtilities.Alipayment
{
    /// <summary>
    /// AlipayTradePrecreateContentBuilder 的摘要说明
    /// </summary>
    public class AlipayTradePrecreateContentBuilder : AlipayJsonBuilder
    {
        public string out_trade_no {get;set;}
        public string seller_id {get;set;}
        public string total_amount { get; set; }
        public string discountable_amount { get; set; }
        public string undiscountable_amount { get; set; }
        public string subject { get; set; }
        public string body { get; set; }

        public List<AlipayGoodsInfo> goods_detail{get;set;}
        public string operator_id { get; set; }

        public string store_id { get; set; }

        public string terminal_id { get; set; }

        public AlipayExtendParams extend_params { get; set; }
        public string time_expire { get; set; }
        public string timeout_express { get; set; }
        
        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}