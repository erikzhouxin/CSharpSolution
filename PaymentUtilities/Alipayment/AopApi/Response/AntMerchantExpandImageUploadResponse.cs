using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AntMerchantExpandImageUploadResponse.
    /// </summary>
    public class AntMerchantExpandImageUploadResponse : AopResponse
    {
        /// <summary>
        /// 图片在sfs中的标识
        /// </summary>
        [XmlElement("image_id")]
        public string ImageId { get; set; }
    }
}
