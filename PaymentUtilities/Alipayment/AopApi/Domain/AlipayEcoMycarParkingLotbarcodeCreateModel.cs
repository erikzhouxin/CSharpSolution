using System;
using System.Xml.Serialization;

namespace EZOper.PaymentUtilities.Alipayment.AopApi
{
    /// <summary>
    /// AlipayEcoMycarParkingLotbarcodeCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayEcoMycarParkingLotbarcodeCreateModel : AopObject
    {
        /// <summary>
        /// 停车场编号
        /// </summary>
        [XmlElement("parking_id")]
        public string ParkingId { get; set; }
    }
}
