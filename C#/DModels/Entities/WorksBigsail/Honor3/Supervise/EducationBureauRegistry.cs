namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EducationBureauRegistry")]
    public partial class EducationBureauRegistry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EducationBureauRegistry()
        {
            EducationBureauFilesControl = new HashSet<EducationBureauFilesControl>();
            EducationBureauUsers = new HashSet<EducationBureauUsers>();
            SchoolRegistry = new HashSet<SchoolRegistry>();
        }

        public Guid ID { get; set; }

        [Required]
        [StringLength(50)]
        public string RegisteredName { get; set; }

        [Required]
        [StringLength(6)]
        public string RegionCode { get; set; }

        [Required]
        [StringLength(50)]
        public string RegionName { get; set; }

        [Required]
        [StringLength(10)]
        public string LevelType { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }

        public string Memo { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual DatabaseDistribution DatabaseDistribution { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationBureauFilesControl> EducationBureauFilesControl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationBureauUsers> EducationBureauUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SchoolRegistry> SchoolRegistry { get; set; }
    }
}
