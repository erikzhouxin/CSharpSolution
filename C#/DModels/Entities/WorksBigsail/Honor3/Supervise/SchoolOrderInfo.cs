namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SchoolOrderInfo")]
    public partial class SchoolOrderInfo
    {
        [Key]
        public Guid OrderID { get; set; }

        public Guid SchoolRegistryID { get; set; }

        public int SchoolYear { get; set; }

        [StringLength(256)]
        public string RemittorName { get; set; }

        [StringLength(256)]
        public string RemittorEmail { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalMoney { get; set; }

        [Required]
        [StringLength(64)]
        public string PayType { get; set; }

        [StringLength(128)]
        public string PayBank { get; set; }

        [Required]
        [StringLength(128)]
        public string Subject { get; set; }

        [StringLength(256)]
        public string SubjectDescr { get; set; }

        [Required]
        [StringLength(32)]
        public string OrderStatus { get; set; }

        [StringLength(128)]
        public string TradeID { get; set; }

        [StringLength(32)]
        public string TradeStatus { get; set; }

        [StringLength(256)]
        public string ClientIP { get; set; }

        [StringLength(128)]
        public string ClientTimestamp { get; set; }

        public DateTime OperTime { get; set; }

        public DateTime CreateTime { get; set; }

        public string URLData { get; set; }

        [Required]
        [StringLength(64)]
        public string UserName { get; set; }

        [Required]
        [StringLength(64)]
        public string TeacherName { get; set; }

        public string Remark { get; set; }

        public virtual SchoolRegistry SchoolRegistry { get; set; }
    }
}
