using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// SsdataDataserviceRiskContentVerifyModel Data Structure.
    /// </summary>
    [Serializable]
    public class SsdataDataserviceRiskContentVerifyModel : AopObject
    {
        /// <summary>
        /// 需要识别的文本
        /// </summary>
        [XmlElement("content")]
        public string Content { get; set; }

        /// <summary>
        /// 风险类型，0-垃圾广告，1-暴恐政， 2-涉黄， 3-涉毒，4-涉赌
        /// </summary>
        [XmlElement("risk_type")]
        public string RiskType { get; set; }
    }
}
