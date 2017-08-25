using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayMarketingCampaignRuleTagQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayMarketingCampaignRuleTagQueryModel : AopObject
    {
        /// <summary>
        /// 签约商户下属机构唯一编号
        /// </summary>
        [XmlElement("mpid")]
        public string Mpid { get; set; }
    }
}
