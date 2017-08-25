using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// ProdParams Data Structure.
    /// </summary>
    [Serializable]
    public class ProdParams : AopObject
    {
        /// <summary>
        /// 预授权业务信息
        /// </summary>
        [XmlElement("auth_biz_params")]
        public string AuthBizParams { get; set; }
    }
}
