using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// MybankFinanceYulibaoPriceQueryResponse.
    /// </summary>
    public class MybankFinanceYulibaoPriceQueryResponse : AopResponse
    {
        /// <summary>
        /// 余利宝行情信息列表
        /// </summary>
        [XmlArray("ylb_price_detail_infos")]
        [XmlArrayItem("y_l_b_price_detail_info")]
        public List<YLBPriceDetailInfo> YlbPriceDetailInfos { get; set; }
    }
}
