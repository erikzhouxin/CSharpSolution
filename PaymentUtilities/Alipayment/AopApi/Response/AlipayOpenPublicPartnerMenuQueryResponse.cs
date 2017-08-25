using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayOpenPublicPartnerMenuQueryResponse.
    /// </summary>
    public class AlipayOpenPublicPartnerMenuQueryResponse : AopResponse
    {
        /// <summary>
        /// 服务窗菜单
        /// </summary>
        [XmlElement("public_menu")]
        public string PublicMenu { get; set; }
    }
}
