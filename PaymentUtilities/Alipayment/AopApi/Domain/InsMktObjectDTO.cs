using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// InsMktObjectDTO Data Structure.
    /// </summary>
    [Serializable]
    public class InsMktObjectDTO : AopObject
    {
        /// <summary>
        /// 活动标的id
        /// </summary>
        [XmlElement("obj_id")]
        public string ObjId { get; set; }

        /// <summary>
        /// 标的类型
        /// </summary>
        [XmlElement("type")]
        public long Type { get; set; }
    }
}
