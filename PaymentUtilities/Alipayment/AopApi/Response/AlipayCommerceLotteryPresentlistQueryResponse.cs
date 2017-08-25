using System;
using System.Xml.Serialization;
using System.Collections.Generic;


namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayCommerceLotteryPresentlistQueryResponse.
    /// </summary>
    public class AlipayCommerceLotteryPresentlistQueryResponse : AopResponse
    {
        /// <summary>
        /// 列表内容
        /// </summary>
        [XmlArray("results")]
        [XmlArrayItem("lottery_present")]
        public List<LotteryPresent> Results { get; set; }

        /// <summary>
        /// 返回的列表的大小
        /// </summary>
        [XmlElement("total_result")]
        public long TotalResult { get; set; }
    }
}
