using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayOpenAppYufalingsanyaowubYufalingsanyaowubQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenAppYufalingsanyaowubYufalingsanyaowubQueryModel : AopObject
    {
        /// <summary>
        /// yufaa
        /// </summary>
        [XmlElement("yufaa")]
        public string Yufaa { get; set; }
    }
}
