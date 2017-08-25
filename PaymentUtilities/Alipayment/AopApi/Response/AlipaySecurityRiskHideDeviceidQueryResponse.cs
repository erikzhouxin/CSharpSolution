using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipaySecurityRiskHideDeviceidQueryResponse.
    /// </summary>
    public class AlipaySecurityRiskHideDeviceidQueryResponse : AopResponse
    {
        /// <summary>
        /// 设备指纹的apdid
        /// </summary>
        [XmlElement("deviceid")]
        public string Deviceid { get; set; }
    }
}
