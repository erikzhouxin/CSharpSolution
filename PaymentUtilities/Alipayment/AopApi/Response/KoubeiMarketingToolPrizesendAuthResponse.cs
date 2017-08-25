using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// KoubeiMarketingToolPrizesendAuthResponse.
    /// </summary>
    public class KoubeiMarketingToolPrizesendAuthResponse : AopResponse
    {
        /// <summary>
        /// 发奖token，用于校验商户是否有权限给制定用户发奖
        /// </summary>
        [XmlElement("token")]
        public string Token { get; set; }
    }
}
