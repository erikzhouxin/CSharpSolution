using System;
using System.Xml.Serialization;


namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// KoubeiMarketingDataCustomreportDetailQueryResponse.
    /// </summary>
    public class KoubeiMarketingDataCustomreportDetailQueryResponse : AopResponse
    {
        /// <summary>
        /// 自定义报表规则条件的详细信息
        /// </summary>
        [XmlElement("report_condition_info")]
        public CustomReportCondition ReportConditionInfo { get; set; }
    }
}
