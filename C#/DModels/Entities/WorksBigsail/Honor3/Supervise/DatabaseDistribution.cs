namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DatabaseDistribution")]
    public partial class DatabaseDistribution
    {
        [Key]
        public Guid EducationBureauID { get; set; }

        [Required]
        [StringLength(64)]
        public string ServerType { get; set; }

        [Required]
        [StringLength(1024)]
        public string ServerName { get; set; }

        [Required]
        [StringLength(64)]
        public string DbName { get; set; }

        [Required]
        [StringLength(64)]
        public string AuthenticationType { get; set; }

        [Required]
        [StringLength(64)]
        public string Account { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }

        public virtual EducationBureauRegistry EducationBureauRegistry { get; set; }
    }
}
