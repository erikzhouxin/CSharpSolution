namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ExperimentItems
    {
        public Guid ID { get; set; }

        public int CatalogID { get; set; }

        public int Grade { get; set; }

        public int EditionId { get; set; }

        public bool IsLastTerm { get; set; }

        public int? Sequence { get; set; }

        [Required]
        [StringLength(64)]
        public string Chapter { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public string RequiredEquipments { get; set; }

        public bool IsDemonstration { get; set; }

        [StringLength(10)]
        public string ExperimentType { get; set; }

        public bool MustBeDone { get; set; }

        [StringLength(512)]
        public string Remark { get; set; }

        public virtual BookEditions BookEditions { get; set; }

        public virtual EquipmentCatalogs EquipmentCatalogs { get; set; }
    }
}
