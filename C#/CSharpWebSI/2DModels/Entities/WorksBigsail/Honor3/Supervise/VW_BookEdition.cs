namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VW_BookEdition
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string SchoolType { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string CatalogName { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Grade { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(64)]
        public string BookEditionName { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EditionId { get; set; }
    }
}
