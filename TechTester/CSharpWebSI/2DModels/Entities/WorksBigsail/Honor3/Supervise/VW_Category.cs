namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VW_Category
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
        public Guid EducationFileId { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(10)]
        public string SchoolType { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string CatalogName { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CategoryId { get; set; }
    }
}
