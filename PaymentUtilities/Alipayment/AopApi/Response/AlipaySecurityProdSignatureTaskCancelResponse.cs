using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipaySecurityProdSignatureTaskCancelResponse.
    /// </summary>
    public class AlipaySecurityProdSignatureTaskCancelResponse : AopResponse
    {
        /// <summary>
        /// 是否更新成功
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }
    }
}
