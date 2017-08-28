using System;
using System.Xml.Serialization;


namespace EZOper.NetSiteUtilities.AopApi
{
    /// <summary>
    /// KoubeiCateringTablelistQueryResponse.
    /// </summary>
    public class KoubeiCateringTablelistQueryResponse : AopResponse
    {
        /// <summary>
        /// 返回tablelistresult列表
        /// </summary>
        [XmlElement("tableinfo_result")]
        public TableInfoResult TableinfoResult { get; set; }
    }
}
