using System;
using System.Xml.Serialization;


namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayUserAccountGetResponse.
    /// </summary>
    public class AlipayUserAccountGetResponse : AopResponse
    {
        /// <summary>
        /// 支付宝用户账户信息
        /// </summary>
        [XmlElement("alipay_account")]
        public AlipayAccount AlipayAccount { get; set; }
    }
}
