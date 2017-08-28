using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace EZOper.NetSiteUtilities.Alipayment
{
    /// <summary>
    /// GoodsInfo 的摘要说明
    /// 历史:
    /// 2017-8-27|GoodsInfo->AlipayGoodsInfo
    /// </summary>
    public class AlipayGoodsInfo
    {
        public string goods_id { get; set; }

        public string alipay_goods_id { get; set; }

        public string goods_name { get; set; }

        public string quantity { get; set; }
        public string price { get; set; }

        public string goods_category { get; set; }

        public string body { get; set; }
    }
}