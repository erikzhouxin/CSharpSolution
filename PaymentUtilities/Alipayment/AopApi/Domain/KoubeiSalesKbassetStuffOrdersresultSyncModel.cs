using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// KoubeiSalesKbassetStuffOrdersresultSyncModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiSalesKbassetStuffOrdersresultSyncModel : AopObject
    {
        /// <summary>
        /// 物料单据反馈列表，最大200条
        /// </summary>
        [XmlArray("orders_feedback")]
        [XmlArrayItem("access_orders_feed_back")]
        public List<AccessOrdersFeedBack> OrdersFeedback { get; set; }
    }
}
