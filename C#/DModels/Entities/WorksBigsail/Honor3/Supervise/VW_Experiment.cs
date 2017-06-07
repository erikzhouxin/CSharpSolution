namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VW_Experiment
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(6)]
        public string RegionCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Year { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string SchoolType { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string CatalogName { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CatalogID { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Grade { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookEditionId { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(64)]
        public string EditionName { get; set; }

        [Key]
        [Column(Order = 8)]
        public Guid ExperimentItemId { get; set; }

        [Key]
        [Column(Order = 9)]
        public bool IsLastTerm { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(64)]
        public string Chapter { get; set; }

        [Key]
        [Column(Order = 11)]
        public string ExperimentName { get; set; }

        public string RequiredEquipments { get; set; }

        [Key]
        [Column(Order = 12)]
        public bool IsDemonstration { get; set; }

        [Key]
        [Column(Order = 13)]
        public bool MustBeDone { get; set; }

        [StringLength(512)]
        public string Remark { get; set; }

        [StringLength(10)]
        public string ExperimentType { get; set; }

        public int? Sequence { get; set; }
    }
}
