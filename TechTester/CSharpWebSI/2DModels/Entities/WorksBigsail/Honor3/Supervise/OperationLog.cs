namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OperationLog")]
    public partial class OperationLog
    {
        public int Id { get; set; }

        public DateTime OperationTime { get; set; }

        public int OperationType { get; set; }

        [Required]
        [StringLength(50)]
        public string Range { get; set; }

        public int ItemId { get; set; }

        [StringLength(2000)]
        public string OtherInfo { get; set; }

        public DateTime? ProcessTime { get; set; }

        public int SchoolClassificationID { get; set; }

        public int ParentId { get; set; }

        public virtual StandardSchoolClassifications StandardSchoolClassifications { get; set; }
    }
}
