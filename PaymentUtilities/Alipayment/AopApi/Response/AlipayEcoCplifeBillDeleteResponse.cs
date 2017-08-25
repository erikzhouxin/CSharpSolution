using System;
using System.Xml.Serialization;
using System.Collections.Generic;


namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayEcoCplifeBillDeleteResponse.
    /// </summary>
    public class AlipayEcoCplifeBillDeleteResponse : AopResponse
    {
        /// <summary>
        /// 不允许删除（支付中或者支付完成）的账单明细条目列表
        /// </summary>
        [XmlArray("alive_bill_entry_list")]
        [XmlArrayItem("c_p_alive_bill_entry_set")]
        public List<CPAliveBillEntrySet> AliveBillEntryList { get; set; }
    }
}
