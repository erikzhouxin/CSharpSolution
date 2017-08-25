using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// KoubeiMarketingMallTradeSubscribeModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiMarketingMallTradeSubscribeModel : AopObject
    {
        /// <summary>
        /// 卡模版id
        /// </summary>
        [XmlElement("card_template_id")]
        public string CardTemplateId { get; set; }

        /// <summary>
        /// 商圈id
        /// </summary>
        [XmlElement("mall_id")]
        public string MallId { get; set; }
    }
}
