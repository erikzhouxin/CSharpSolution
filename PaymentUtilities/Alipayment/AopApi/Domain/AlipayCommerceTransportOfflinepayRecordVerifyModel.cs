using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayCommerceTransportOfflinepayRecordVerifyModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayCommerceTransportOfflinepayRecordVerifyModel : AopObject
    {
        /// <summary>
        /// 原始脱机记录信息
        /// </summary>
        [XmlElement("record")]
        public string Record { get; set; }
    }
}
