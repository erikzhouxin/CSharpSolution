using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayEcoRenthouseKaBaseinfoQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayEcoRenthouseKaBaseinfoQueryModel : AopObject
    {
        /// <summary>
        /// kaCode唯一标识
        /// </summary>
        [XmlElement("ka_code")]
        public string KaCode { get; set; }
    }
}
