namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StandardSchoolClassifications
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StandardSchoolClassifications()
        {
            EquipmentCatalogs = new HashSet<EquipmentCatalogs>();
            EquipmentStandardDimensions = new HashSet<EquipmentStandardDimensions>();
            OperationLog = new HashSet<OperationLog>();
        }

        public int ID { get; set; }

        public int VersionID { get; set; }

        [Required]
        [StringLength(10)]
        public string SchoolType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipmentCatalogs> EquipmentCatalogs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipmentStandardDimensions> EquipmentStandardDimensions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OperationLog> OperationLog { get; set; }

        public virtual StandardVersions StandardVersions { get; set; }
    }
}
