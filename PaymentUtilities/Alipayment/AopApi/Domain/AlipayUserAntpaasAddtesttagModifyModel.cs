using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayUserAntpaasAddtesttagModifyModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayUserAntpaasAddtesttagModifyModel : AopObject
    {
        /// <summary>
        /// 支付宝账户id
        /// </summary>
        [XmlElement("account_no")]
        public string AccountNo { get; set; }
    }
}
