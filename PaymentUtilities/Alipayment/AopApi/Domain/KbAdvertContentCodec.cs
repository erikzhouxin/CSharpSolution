using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// KbAdvertContentCodec Data Structure.
    /// </summary>
    [Serializable]
    public class KbAdvertContentCodec : AopObject
    {
        /// <summary>
        /// 二维码广告内容
        /// </summary>
        [XmlElement("url")]
        public string Url { get; set; }
    }
}
