using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayAssetPointBudgetQueryResponse.
    /// </summary>
    public class AlipayAssetPointBudgetQueryResponse : AopResponse
    {
        /// <summary>
        /// 还可以发放的集分宝个数
        /// </summary>
        [XmlElement("budget_amount")]
        public long BudgetAmount { get; set; }
    }
}
