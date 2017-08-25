using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// Paragraph Data Structure.
    /// </summary>
    [Serializable]
    public class Paragraph : AopObject
    {
        /// <summary>
        /// 图片列表
        /// </summary>
        [XmlArray("pictures")]
        [XmlArrayItem("picture")]
        public List<Picture> Pictures { get; set; }

        /// <summary>
        /// 正文介绍
        /// </summary>
        [XmlElement("text")]
        public string Text { get; set; }
    }
}
