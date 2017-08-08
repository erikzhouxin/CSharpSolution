namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EquipmentReferenceUnitPrice")]
    public partial class EquipmentReferenceUnitPrice
    {
        public int ID { get; set; }

        public int ProjectID { get; set; }

        public int EquipmentItemID { get; set; }

        [Column(TypeName = "money")]
        public decimal ReferenceUnitPrice { get; set; }

        public virtual ReferenceUnitPriceProject ReferenceUnitPriceProject { get; set; }
    }
}
