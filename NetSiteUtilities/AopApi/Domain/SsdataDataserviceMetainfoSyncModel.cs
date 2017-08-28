using System;
using System.Xml.Serialization;

namespace EZOper.NetSiteUtilities.AopApi
{
    /// <summary>
    /// SsdataDataserviceMetainfoSyncModel Data Structure.
    /// </summary>
    [Serializable]
    public class SsdataDataserviceMetainfoSyncModel : AopObject
    {
        /// <summary>
        /// 元数据信息
        /// </summary>
        [XmlElement("meta_info")]
        public string MetaInfo { get; set; }
    }
}
