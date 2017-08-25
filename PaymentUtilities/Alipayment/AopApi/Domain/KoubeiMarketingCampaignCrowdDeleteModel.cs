using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// KoubeiMarketingCampaignCrowdDeleteModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiMarketingCampaignCrowdDeleteModel : AopObject
    {
        /// <summary>
        /// 人群组的唯一标识ID
        /// </summary>
        [XmlElement("crowd_group_id")]
        public string CrowdGroupId { get; set; }
    }
}
