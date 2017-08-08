namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SchoolNotices
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SchoolNotices()
        {
            SchoolRegistry = new HashSet<SchoolRegistry>();
        }

        [Key]
        public int NoticeID { get; set; }

        [Required]
        [StringLength(256)]
        public string NoticeTitle { get; set; }

        [Required]
        public string NoticeContent { get; set; }

        public DateTime CreateTime { get; set; }

        [StringLength(1024)]
        public string Remark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SchoolRegistry> SchoolRegistry { get; set; }
    }
}
