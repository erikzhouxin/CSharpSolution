using System;
using System.Xml.Serialization;
using System.Collections.Generic;


namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayCommerceCityfacilitatorVoucherBatchqueryResponse.
    /// </summary>
    public class AlipayCommerceCityfacilitatorVoucherBatchqueryResponse : AopResponse
    {
        /// <summary>
        /// 查询到的订单信息列表
        /// </summary>
        [XmlArray("tickets")]
        [XmlArrayItem("ticket_detail_info")]
        public List<TicketDetailInfo> Tickets { get; set; }
    }
}
