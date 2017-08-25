using System;
using System.Xml.Serialization;


namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayMarketingCardOpenResponse.
    /// </summary>
    public class AlipayMarketingCardOpenResponse : AopResponse
    {
        /// <summary>
        /// 商户卡信息（包括支付宝分配的业务卡号）
        /// </summary>
        [XmlElement("card_info")]
        public MerchantCard CardInfo { get; set; }
    }
}
