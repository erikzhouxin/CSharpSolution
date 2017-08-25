using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayOpenPublicMessageTotalSendResponse.
    /// </summary>
    public class AlipayOpenPublicMessageTotalSendResponse : AopResponse
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        [XmlElement("message_id")]
        public string MessageId { get; set; }
    }
}
