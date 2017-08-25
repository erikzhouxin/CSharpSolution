using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayEbppProdmodeUnionbankQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayEbppProdmodeUnionbankQueryModel : AopObject
    {
        /// <summary>
        /// 银联编号
        /// </summary>
        [XmlElement("bank_code")]
        public string BankCode { get; set; }
    }
}
