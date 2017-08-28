using System;
using System.Xml.Serialization;

namespace EZOper.NetSiteUtilities.AopApi
{
    /// <summary>
    /// AlipayOpenPublicLabelCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenPublicLabelCreateModel : AopObject
    {
        /// <summary>
        /// 标签名
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
