using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayEbppUserChargeinstQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayEbppUserChargeinstQueryModel : AopObject
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
