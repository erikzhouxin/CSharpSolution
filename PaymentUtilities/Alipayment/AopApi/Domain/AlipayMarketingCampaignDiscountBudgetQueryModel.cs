using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayMarketingCampaignDiscountBudgetQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayMarketingCampaignDiscountBudgetQueryModel : AopObject
    {
        /// <summary>
        /// 预算名称
        /// </summary>
        [XmlElement("budget_id")]
        public string BudgetId { get; set; }
    }
}
