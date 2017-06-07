namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EquipmentStandardRequirements
    {
        public int ID { get; set; }

        public int EquipmentItemID { get; set; }

        public int DimensionID { get; set; }

        public bool IsOptional { get; set; }

        public bool RequirementQuantity { get; set; }

        [Required]
        [StringLength(10)]
        public string NumberType { get; set; }

        public double Value1 { get; set; }

        public double Value2 { get; set; }

        public virtual EquipmentItems EquipmentItems { get; set; }

        public virtual EquipmentStandardDimensions EquipmentStandardDimensions { get; set; }
    }
}
