using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayOpenPublicLifeDebarkApplyResponse.
    /// </summary>
    public class AlipayOpenPublicLifeDebarkApplyResponse : AopResponse
    {
        /// <summary>
        /// 下架成功后返回的提示
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }
    }
}
