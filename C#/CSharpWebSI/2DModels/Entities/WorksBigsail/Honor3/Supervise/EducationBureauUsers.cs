namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EducationBureauUsers
    {
        public Guid ID { get; set; }

        public Guid EducationBureauID { get; set; }

        [Required]
        [StringLength(64)]
        public string Account { get; set; }

        [Required]
        [StringLength(64)]
        public string Salt { get; set; }

        [Required]
        [StringLength(200)]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public int RoleType { get; set; }

        [Required]
        [StringLength(64)]
        public string UserName { get; set; }

        [Required]
        [StringLength(32)]
        public string Phone { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        public string Permissions { get; set; }

        public bool Enabled { get; set; }

        [StringLength(1024)]
        public string Memo { get; set; }

        public virtual EducationBureauRegistry EducationBureauRegistry { get; set; }

        public virtual EducationUsersSchoolRange EducationUsersSchoolRange { get; set; }
    }
}
