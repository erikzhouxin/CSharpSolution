namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EquipmentItems
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EquipmentItems()
        {
            EquipmentStandardRequirements = new HashSet<EquipmentStandardRequirements>();
        }

        public int ID { get; set; }

        public int EquipmentCatalogID { get; set; }

        [Required]
        [StringLength(50)]
        public string Number { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string InternalGroup { get; set; }

        [Required]
        [StringLength(50)]
        public string ClassificationAndCodes { get; set; }

        [Required]
        [StringLength(50)]
        public string ReferenceStandardCode { get; set; }

        [Required]
        [StringLength(200)]
        public string SpecificationAndFunction { get; set; }

        [Required]
        [StringLength(10)]
        public string QuantitativeUnit { get; set; }

        [Required]
        [StringLength(512)]
        public string Memo { get; set; }

        public int SequenceNumber { get; set; }

        [Column(TypeName = "money")]
        public decimal ReferenceUnitPrice { get; set; }

        public bool IsEasyConsume { get; set; }

        public bool IsNineYearShared { get; set; }

        public virtual EquipmentCatalogs EquipmentCatalogs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipmentStandardRequirements> EquipmentStandardRequirements { get; set; }

        public virtual GroupingExperimentEquipment GroupingExperimentEquipment { get; set; }
    }
}
