using System;
using System.Xml.Serialization;


namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayMarketingToolFengdieActivityQueryResponse.
    /// </summary>
    public class AlipayMarketingToolFengdieActivityQueryResponse : AopResponse
    {
        /// <summary>
        /// H5应用详情
        /// </summary>
        [XmlElement("activity")]
        public FengdieActivity Activity { get; set; }
    }
}
