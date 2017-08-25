using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// KoubeiMarketingDataCustomreportDeleteModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiMarketingDataCustomreportDeleteModel : AopObject
    {
        /// <summary>
        /// 自定义报表规则的KEY
        /// </summary>
        [XmlElement("condition_key")]
        public string ConditionKey { get; set; }
    }
}
