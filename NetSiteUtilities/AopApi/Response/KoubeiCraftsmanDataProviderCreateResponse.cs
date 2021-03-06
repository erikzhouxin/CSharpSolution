using System;
using System.Xml.Serialization;

namespace EZOper.NetSiteUtilities.AopApi
{
    /// <summary>
    /// KoubeiCraftsmanDataProviderCreateResponse.
    /// </summary>
    public class KoubeiCraftsmanDataProviderCreateResponse : AopResponse
    {
        /// <summary>
        /// 手艺人id
        /// </summary>
        [XmlElement("craftsman_id")]
        public string CraftsmanId { get; set; }
    }
}
