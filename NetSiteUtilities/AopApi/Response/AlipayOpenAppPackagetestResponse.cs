using System;
using System.Xml.Serialization;

namespace EZOper.NetSiteUtilities.AopApi
{
    /// <summary>
    /// AlipayOpenAppPackagetestResponse.
    /// </summary>
    public class AlipayOpenAppPackagetestResponse : AopResponse
    {
        /// <summary>
        /// testtest
        /// </summary>
        [XmlElement("testtesttesttest")]
        public string Testtesttesttest { get; set; }
    }
}
