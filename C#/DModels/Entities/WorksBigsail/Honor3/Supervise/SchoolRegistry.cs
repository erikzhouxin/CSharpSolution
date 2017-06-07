namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SchoolRegistry")]
    public partial class SchoolRegistry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SchoolRegistry()
        {
            SchoolCatalogInit = new HashSet<SchoolCatalogInit>();
            SchoolOrderInfo = new HashSet<SchoolOrderInfo>();
            SchoolYearFilesRegistry = new HashSet<SchoolYearFilesRegistry>();
            SchoolRenewFee = new HashSet<SchoolRenewFee>();
            SchoolUsers = new HashSet<SchoolUsers>();
        }

        public Guid ID { get; set; }

        public Guid EducationBureauID { get; set; }

        [Required]
        [StringLength(50)]
        public string SchoolCode { get; set; }

        [Required]
        [StringLength(50)]
        public string RegisteredName { get; set; }

        [Required]
        [StringLength(20)]
        public string SchoolType { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }

        public string Memo { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsNineYearSchool { get; set; }

        public int ValideYearRenew { get; set; }

        public int? NoticeID { get; set; }

        [StringLength(64)]
        public string ValidType { get; set; }

        public DateTime? ValidTime { get; set; }

        public DateTime? RenewTime { get; set; }

        public int CombinationType { get; set; }

        [Required]
        [StringLength(50)]
        public string RelationCode { get; set; }

        public virtual EducationBureauRegistry EducationBureauRegistry { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SchoolCatalogInit> SchoolCatalogInit { get; set; }

        public virtual SchoolNotices SchoolNotices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SchoolOrderInfo> SchoolOrderInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SchoolYearFilesRegistry> SchoolYearFilesRegistry { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SchoolRenewFee> SchoolRenewFee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SchoolUsers> SchoolUsers { get; set; }
    }
}
