using System;
using System.Xml.Serialization;


namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayTrustUserScoreGetResponse.
    /// </summary>
    public class AlipayTrustUserScoreGetResponse : AopResponse
    {
        /// <summary>
        /// 芝麻信用通过模型计算出的该用户的芝麻信用评分
        /// </summary>
        [XmlElement("ali_trust_score")]
        public AliTrustScore AliTrustScore { get; set; }
    }
}
