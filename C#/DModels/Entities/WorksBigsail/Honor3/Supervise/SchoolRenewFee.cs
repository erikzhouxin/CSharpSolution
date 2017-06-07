namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SchoolRenewFee")]
    public partial class SchoolRenewFee
    {
        [Key]
        [Column(Order = 0)]
        public Guid SchoolRegistryID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SchoolYear { get; set; }

        public int UnitPrice { get; set; }

        [StringLength(64)]
        public string RemittorName { get; set; }

        [StringLength(256)]
        public string RemittorUnit { get; set; }

        [StringLength(32)]
        public string RemittorPhone { get; set; }

        public int? RemitMoney { get; set; }

        [StringLength(128)]
        public string RemitType { get; set; }

        public DateTime? RemitTime { get; set; }

        [Required]
        [StringLength(32)]
        public string RenewState { get; set; }

        public DateTime? ApproveTime { get; set; }

        [StringLength(1024)]
        public string Remark { get; set; }

        public virtual SchoolRegistry SchoolRegistry { get; set; }
    }
}
