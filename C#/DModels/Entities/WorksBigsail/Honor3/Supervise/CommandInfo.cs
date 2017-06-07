namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CommandInfo")]
    public partial class CommandInfo
    {
        [Key]
        public int CommandId { get; set; }

        [Required]
        [StringLength(200)]
        public string CommandType { get; set; }

        [Required]
        [StringLength(50)]
        public string CommandParams { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? ExecuteTime { get; set; }
    }
}
