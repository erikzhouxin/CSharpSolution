using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayZdataassetsFcdatalabZdatamergetaskResponse.
    /// </summary>
    public class AlipayZdataassetsFcdatalabZdatamergetaskResponse : AopResponse
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }
    }
}
