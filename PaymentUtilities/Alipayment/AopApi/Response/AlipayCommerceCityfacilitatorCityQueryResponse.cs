using System;
using System.Xml.Serialization;
using System.Collections.Generic;


namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayCommerceCityfacilitatorCityQueryResponse.
    /// </summary>
    public class AlipayCommerceCityfacilitatorCityQueryResponse : AopResponse
    {
        /// <summary>
        /// 城市列表
        /// </summary>
        [XmlArray("citys")]
        [XmlArrayItem("city_function")]
        public List<CityFunction> Citys { get; set; }
    }
}
