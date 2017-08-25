using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// KoubeiSalesKbassetStuffProduceorderBatchqueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiSalesKbassetStuffProduceorderBatchqueryModel : AopObject
    {
        /// <summary>
        /// 每页容量：最小1，最大100
        /// </summary>
        [XmlElement("page_size")]
        public string PageSize { get; set; }
    }
}
