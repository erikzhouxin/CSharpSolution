namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SysSettingUser")]
    public partial class SysSettingUser
    {
        [Key]
        [StringLength(64)]
        public string Account { get; set; }

        [Required]
        [StringLength(64)]
        public string UserName { get; set; }

        [Required]
        [StringLength(128)]
        public string Password { get; set; }

        [Required]
        [StringLength(128)]
        public string Salt { get; set; }

        [Required]
        [StringLength(1024)]
        public string Role { get; set; }

        [StringLength(1024)]
        public string Memo { get; set; }
    }
}
