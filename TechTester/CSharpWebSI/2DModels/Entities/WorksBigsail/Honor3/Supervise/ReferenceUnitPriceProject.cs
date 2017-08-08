namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReferenceUnitPriceProject")]
    public partial class ReferenceUnitPriceProject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReferenceUnitPriceProject()
        {
            EducationBureauFilesControl = new HashSet<EducationBureauFilesControl>();
            EquipmentReferenceUnitPrice = new HashSet<EquipmentReferenceUnitPrice>();
        }

        public int ID { get; set; }

        public int StandardVersionsID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool UserDefined { get; set; }

        [Required]
        [StringLength(6)]
        public string FromRegionCode { get; set; }

        [Required]
        [StringLength(50)]
        public string FromRegionName { get; set; }

        public int Rating { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public string RevisionLog { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationBureauFilesControl> EducationBureauFilesControl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipmentReferenceUnitPrice> EquipmentReferenceUnitPrice { get; set; }

        public virtual StandardVersions StandardVersions { get; set; }
    }
}
