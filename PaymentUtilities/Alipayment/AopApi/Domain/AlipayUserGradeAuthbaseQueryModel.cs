using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayUserGradeAuthbaseQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayUserGradeAuthbaseQueryModel : AopObject
    {
        /// <summary>
        /// 用户的支付宝账户ID
        /// </summary>
        [XmlElement("user_id")]
        public string UserId { get; set; }
    }
}
