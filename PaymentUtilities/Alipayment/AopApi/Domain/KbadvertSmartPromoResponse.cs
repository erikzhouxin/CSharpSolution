using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// KbadvertSmartPromoResponse Data Structure.
    /// </summary>
    [Serializable]
    public class KbadvertSmartPromoResponse : AopObject
    {
        /// <summary>
        /// 智能营销分组ID
        /// </summary>
        [XmlElement("group_id")]
        public string GroupId { get; set; }

        /// <summary>
        /// 智能营销方案ID
        /// </summary>
        [XmlElement("plan_id")]
        public string PlanId { get; set; }
    }
}
