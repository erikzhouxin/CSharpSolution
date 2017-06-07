namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EducationBureauFilesControl")]
    public partial class EducationBureauFilesControl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EducationBureauFilesControl()
        {
            EducationBureau_ExperimentSettings = new HashSet<EducationBureau_ExperimentSettings>();
            SchoolYearFilesRegistry = new HashSet<SchoolYearFilesRegistry>();
        }

        public Guid ID { get; set; }

        public Guid EducationBureauID { get; set; }

        public int Year { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Linkman { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public bool SchoolFileLocked { get; set; }

        public bool AllowSchoolCreateFiles { get; set; }

        [Required]
        [StringLength(10)]
        public string PrimarySchoolEquipmentStandard { get; set; }

        [Required]
        [StringLength(10)]
        public string JuniorSchoolEquipmentStandard { get; set; }

        public int StandardVersionID { get; set; }

        [Required]
        [StringLength(50)]
        public string PrimaryPresentationGroupingExperimentStandard { get; set; }

        [Required]
        [StringLength(50)]
        public string JuniorPresentationGroupingExperimentStandard { get; set; }

        [StringLength(200)]
        public string PrimarySchoolPermission { get; set; }

        [StringLength(200)]
        public string JuniorSchoolPermission { get; set; }

        public int ReferenceUnitPriceProjectId { get; set; }

        public bool IsExperimentSettingEnabled { get; set; }

        public int StandardDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationBureau_ExperimentSettings> EducationBureau_ExperimentSettings { get; set; }

        public virtual EducationBureauRegistry EducationBureauRegistry { get; set; }

        public virtual ReferenceUnitPriceProject ReferenceUnitPriceProject { get; set; }

        public virtual StandardVersions StandardVersions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SchoolYearFilesRegistry> SchoolYearFilesRegistry { get; set; }
    }
}
