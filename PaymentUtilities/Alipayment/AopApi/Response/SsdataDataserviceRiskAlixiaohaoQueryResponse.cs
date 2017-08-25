using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// SsdataDataserviceRiskAlixiaohaoQueryResponse.
    /// </summary>
    public class SsdataDataserviceRiskAlixiaohaoQueryResponse : AopResponse
    {
        /// <summary>
        /// 是否阿里小号
        /// </summary>
        [XmlElement("is_alixiaohao")]
        public bool IsAlixiaohao { get; set; }
    }
}
