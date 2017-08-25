using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayEcapiprodDataPutResponse.
    /// </summary>
    public class AlipayEcapiprodDataPutResponse : AopResponse
    {
        /// <summary>
        /// 数据版本
        /// </summary>
        [XmlElement("data_version")]
        public string DataVersion { get; set; }
    }
}
