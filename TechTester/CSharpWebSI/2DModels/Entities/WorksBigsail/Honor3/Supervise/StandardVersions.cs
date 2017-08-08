namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StandardVersions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StandardVersions()
        {
            EducationBureauFilesControl = new HashSet<EducationBureauFilesControl>();
            ReferenceUnitPriceProject = new HashSet<ReferenceUnitPriceProject>();
            StandardSchoolClassifications = new HashSet<StandardSchoolClassifications>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Version { get; set; }

        public bool IsCurrent { get; set; }

        public DateTime CreateDate { get; set; }

        public string Memo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationBureauFilesControl> EducationBureauFilesControl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReferenceUnitPriceProject> ReferenceUnitPriceProject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StandardSchoolClassifications> StandardSchoolClassifications { get; set; }
    }
}
