using System;
using System.Xml.Serialization;

namespace EZOper.NetSiteUtilities.AopApi
{
    /// <summary>
    /// AlipayMarketingCampaignDiscountBudgetAppendResponse.
    /// </summary>
    public class AlipayMarketingCampaignDiscountBudgetAppendResponse : AopResponse
    {
        /// <summary>
        /// 预算ID
        /// </summary>
        [XmlElement("budget_id")]
        public string BudgetId { get; set; }
    }
}
