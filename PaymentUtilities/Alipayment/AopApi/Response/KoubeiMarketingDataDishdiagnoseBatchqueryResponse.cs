using System;
using System.Xml.Serialization;
using System.Collections.Generic;


namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// KoubeiMarketingDataDishdiagnoseBatchqueryResponse.
    /// </summary>
    public class KoubeiMarketingDataDishdiagnoseBatchqueryResponse : AopResponse
    {
        /// <summary>
        /// 查询返回的详情数据
        /// </summary>
        [XmlArray("item_diagnose_list")]
        [XmlArrayItem("item_diagnose_detail")]
        public List<ItemDiagnoseDetail> ItemDiagnoseList { get; set; }

        /// <summary>
        /// 记录的总条数
        /// </summary>
        [XmlElement("total")]
        public long Total { get; set; }
    }
}
