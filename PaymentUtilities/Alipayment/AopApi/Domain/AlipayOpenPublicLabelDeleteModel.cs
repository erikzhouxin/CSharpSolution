using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayOpenPublicLabelDeleteModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenPublicLabelDeleteModel : AopObject
    {
        /// <summary>
        /// 标签id
        /// </summary>
        [XmlElement("id")]
        public string Id { get; set; }
    }
}
