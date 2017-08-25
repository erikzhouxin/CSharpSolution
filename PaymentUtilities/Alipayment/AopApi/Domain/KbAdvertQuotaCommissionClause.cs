using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// KbAdvertQuotaCommissionClause Data Structure.
    /// </summary>
    [Serializable]
    public class KbAdvertQuotaCommissionClause : AopObject
    {
        /// <summary>
        /// 固定金额
        /// </summary>
        [XmlElement("quota_amount")]
        public string QuotaAmount { get; set; }
    }
}
