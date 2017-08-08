namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EducationUsersSchoolRange")]
    public partial class EducationUsersSchoolRange
    {
        [Key]
        public Guid UserID { get; set; }

        public int RangeID { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [Required]
        public string SchoolCodes { get; set; }

        public bool Enabled { get; set; }

        [StringLength(1024)]
        public string Memo { get; set; }

        public virtual EducationBureauUsers EducationBureauUsers { get; set; }
    }
}
