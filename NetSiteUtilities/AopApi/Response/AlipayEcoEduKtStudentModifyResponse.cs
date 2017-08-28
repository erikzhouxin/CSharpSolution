using System;
using System.Xml.Serialization;

namespace EZOper.NetSiteUtilities.AopApi
{
    /// <summary>
    /// AlipayEcoEduKtStudentModifyResponse.
    /// </summary>
    public class AlipayEcoEduKtStudentModifyResponse : AopResponse
    {
        /// <summary>
        /// Y：代表成功；N：代表失败
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }
    }
}
