using System;
using System.Xml.Serialization;

namespace EZOper.NetSiteUtilities.AopApi
{
    /// <summary>
    /// AlipayMarketingVoucherAuthSendResponse.
    /// </summary>
    public class AlipayMarketingVoucherAuthSendResponse : AopResponse
    {
        /// <summary>
        /// 券ID
        /// </summary>
        [XmlElement("voucher_id")]
        public string VoucherId { get; set; }
    }
}
