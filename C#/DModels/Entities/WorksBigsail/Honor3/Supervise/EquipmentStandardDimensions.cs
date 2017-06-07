namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EquipmentStandardDimensions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EquipmentStandardDimensions()
        {
            CatalogDimensionRelation = new HashSet<CatalogDimensionRelation>();
            EquipmentStandardRequirements = new HashSet<EquipmentStandardRequirements>();
        }

        public int ID { get; set; }

        public int SchoolClassificationID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int ClassTotalLeft { get; set; }

        public int ClassTotalRight { get; set; }

        [Required]
        [StringLength(10)]
        public string EquipmentStandard { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CatalogDimensionRelation> CatalogDimensionRelation { get; set; }

        public virtual StandardSchoolClassifications StandardSchoolClassifications { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipmentStandardRequirements> EquipmentStandardRequirements { get; set; }
    }
}
