using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayOpenPublicGroupDeleteModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenPublicGroupDeleteModel : AopObject
    {
        /// <summary>
        /// 需要删除的用户分组的id
        /// </summary>
        [XmlElement("group_id")]
        public string GroupId { get; set; }
    }
}
