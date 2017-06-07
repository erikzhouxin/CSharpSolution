namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SchoolUsers
    {
        public Guid ID { get; set; }

        public Guid SchoolRegistryID { get; set; }

        [Required]
        [StringLength(50)]
        public string Account { get; set; }

        [Required]
        [StringLength(50)]
        public string Salt { get; set; }

        [Required]
        [StringLength(200)]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        [Required]
        public string Permissions { get; set; }

        public DateTime CreateDate { get; set; }

        public bool Enabled { get; set; }

        public virtual SchoolRegistry SchoolRegistry { get; set; }
    }
}
