using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayMarketingCampaignCertCreateResponse.
    /// </summary>
    public class AlipayMarketingCampaignCertCreateResponse : AopResponse
    {
        /// <summary>
        /// 凭证id
        /// </summary>
        [XmlElement("lot_number")]
        public string LotNumber { get; set; }
    }
}
