namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EducationLockUnlockOperLog")]
    public partial class EducationLockUnlockOperLog
    {
        public long ID { get; set; }

        [Required]
        [StringLength(64)]
        public string RelatID { get; set; }

        [Required]
        [StringLength(64)]
        public string OperID { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(512)]
        public string Reason { get; set; }

        public int SchoolYear { get; set; }

        [Required]
        [StringLength(1024)]
        public string Memo { get; set; }

        public DateTime Time { get; set; }

        public int Type { get; set; }
    }
}
