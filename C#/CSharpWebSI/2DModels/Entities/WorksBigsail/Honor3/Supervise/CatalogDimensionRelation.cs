namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CatalogDimensionRelation")]
    public partial class CatalogDimensionRelation
    {
        public int CatalogId { get; set; }

        public int DimensionId { get; set; }

        [StringLength(50)]
        public string Formula { get; set; }

        public bool IsBasic { get; set; }

        public int ID { get; set; }

        public virtual EquipmentCatalogs EquipmentCatalogs { get; set; }

        public virtual EquipmentStandardDimensions EquipmentStandardDimensions { get; set; }
    }
}
