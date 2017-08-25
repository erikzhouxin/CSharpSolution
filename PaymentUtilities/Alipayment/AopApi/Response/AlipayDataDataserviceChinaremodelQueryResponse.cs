using System;
using System.Xml.Serialization;


namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayDataDataserviceChinaremodelQueryResponse.
    /// </summary>
    public class AlipayDataDataserviceChinaremodelQueryResponse : AopResponse
    {
        /// <summary>
        /// 中再核保模型查询结果
        /// </summary>
        [XmlElement("result")]
        public AlipayChinareModelResult Result { get; set; }
    }
}
