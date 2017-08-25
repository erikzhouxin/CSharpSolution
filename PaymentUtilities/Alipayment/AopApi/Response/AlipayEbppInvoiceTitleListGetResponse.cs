using System;
using System.Xml.Serialization;
using System.Collections.Generic;


namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayEbppInvoiceTitleListGetResponse.
    /// </summary>
    public class AlipayEbppInvoiceTitleListGetResponse : AopResponse
    {
        /// <summary>
        /// 抬头列表
        /// </summary>
        [XmlArray("title_list")]
        [XmlArrayItem("invoice_title_model")]
        public List<InvoiceTitleModel> TitleList { get; set; }
    }
}
