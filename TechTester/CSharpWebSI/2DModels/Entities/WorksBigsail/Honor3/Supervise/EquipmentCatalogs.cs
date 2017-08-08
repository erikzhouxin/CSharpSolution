namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EquipmentCatalogs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EquipmentCatalogs()
        {
            CatalogDimensionRelation = new HashSet<CatalogDimensionRelation>();
            EducationBureau_ExperimentSettings = new HashSet<EducationBureau_ExperimentSettings>();
            EquipmentItems = new HashSet<EquipmentItems>();
            ExperimentItems = new HashSet<ExperimentItems>();
            SchoolCatalogInit = new HashSet<SchoolCatalogInit>();
        }

        public int ID { get; set; }

        public int SchoolClassificationID { get; set; }

        [Required]
        [StringLength(50)]
        public string CatalogName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CatalogDimensionRelation> CatalogDimensionRelation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationBureau_ExperimentSettings> EducationBureau_ExperimentSettings { get; set; }

        public virtual StandardSchoolClassifications StandardSchoolClassifications { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipmentItems> EquipmentItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExperimentItems> ExperimentItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SchoolCatalogInit> SchoolCatalogInit { get; set; }
    }
}
