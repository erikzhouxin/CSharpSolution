using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayOpenPublicContactFollowBatchqueryResponse.
    /// </summary>
    public class AlipayOpenPublicContactFollowBatchqueryResponse : AopResponse
    {
        /// <summary>
        /// 联系人关注者列表
        /// </summary>
        [XmlArray("contact_follow_list")]
        [XmlArrayItem("contact_follower")]
        public List<ContactFollower> ContactFollowList { get; set; }
    }
}
