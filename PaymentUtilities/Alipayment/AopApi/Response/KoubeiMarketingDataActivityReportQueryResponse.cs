using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// KoubeiMarketingDataActivityReportQueryResponse.
    /// </summary>
    public class KoubeiMarketingDataActivityReportQueryResponse : AopResponse
    {
        /// <summary>
        /// 报表
        /// </summary>
        [XmlElement("report_data")]
        public string ReportData { get; set; }
    }
}
