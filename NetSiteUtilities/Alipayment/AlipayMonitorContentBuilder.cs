using System;
using System.Collections.Generic;
using System.Web;

namespace EZOper.NetSiteUtilities.Alipayment
{
    /// <summary>
    /// AlipayMonitorContentBuilder 的摘要说明
    /// </summary>
    public class AlipayMonitorContentBuilder : AlipayJsonBuilder
    {
        public List<AlipayTradeInfo> trade_info { get; set; }
   
        public string product { get; set; }

        public string type { get; set; }
        public string equipment_id { get; set; }
        public string time { get; set; }
        public string store_id { get; set; }
        public string network_type { get; set; }
        public string equipment_status { get; set; }
        public string sys_service_provider_id { get; set; }
        public string mac { get; set; }
        
        public override bool Validate()
        {
            if (String.IsNullOrEmpty(product))
            {
                throw new NullReferenceException("product should not be NULL!");
            }
         
            return true;
        }
    }
}