using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace EntityModel
{
    /// <summary>
    /// Define the EntityModle about　Customer in RoomService
    /// Author：chenkai DAte:2011年3月15日15:50:54
    /// </summary>
    [Serializable]
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public bool CustomerSex { get; set; }
        public int CustomerAge { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime SignDate { get; set; }
    }
}
