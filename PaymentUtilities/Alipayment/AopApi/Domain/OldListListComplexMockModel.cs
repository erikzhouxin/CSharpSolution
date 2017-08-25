using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// OldListListComplexMockModel Data Structure.
    /// </summary>
    [Serializable]
    public class OldListListComplexMockModel : AopObject
    {
        /// <summary>
        /// 复杂模型list
        /// </summary>
        [XmlArray("cm_list")]
        [XmlArrayItem("old_complext_mock_model")]
        public List<OldComplextMockModel> CmList { get; set; }
    }
}
