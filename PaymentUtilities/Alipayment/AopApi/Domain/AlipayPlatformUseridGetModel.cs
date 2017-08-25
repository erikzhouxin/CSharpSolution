using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayPlatformUseridGetModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayPlatformUseridGetModel : AopObject
    {
        /// <summary>
        /// openId的列表
        /// </summary>
        [XmlArray("open_ids")]
        [XmlArrayItem("string")]
        public List<string> OpenIds { get; set; }
    }
}
