using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayEbppProdmodeInstshortnameQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayEbppProdmodeInstshortnameQueryModel : AopObject
    {
        /// <summary>
        /// 出账机构中文名称
        /// </summary>
        [XmlElement("chargeinst_cn_name")]
        public string ChargeinstCnName { get; set; }
    }
}
