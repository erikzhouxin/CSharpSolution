namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SchoolUserOperInfo")]
    public partial class SchoolUserOperInfo
    {
        [Key]
        [Column(Order = 0)]
        public Guid SchoolYearFileID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string SchoolCode { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(256)]
        public string Account { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(256)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 4)]
        public string OperContent { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(64)]
        public string OperIP { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoleType { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OperType { get; set; }

        [Key]
        [Column(Order = 8)]
        public DateTime OperTime { get; set; }
    }
}
