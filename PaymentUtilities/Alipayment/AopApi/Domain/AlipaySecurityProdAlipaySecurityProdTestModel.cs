using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipaySecurityProdAlipaySecurityProdTestModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipaySecurityProdAlipaySecurityProdTestModel : AopObject
    {
        /// <summary>
        /// ddd
        /// </summary>
        [XmlArray("cds")]
        [XmlArrayItem("string")]
        public List<string> Cds { get; set; }

        /// <summary>
        /// aaa
        /// </summary>
        [XmlElement("ddd")]
        public string Ddd { get; set; }
    }
}
