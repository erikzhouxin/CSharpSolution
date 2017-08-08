namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SchoolCatalogInit")]
    public partial class SchoolCatalogInit
    {
        [Key]
        [Column(Order = 0)]
        public Guid SchoolID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CatalogID { get; set; }

        public bool IsInit { get; set; }

        public bool IsInitAllowed { get; set; }

        public bool IsFirstYear { get; set; }

        [StringLength(64)]
        public string Memo { get; set; }

        public virtual EquipmentCatalogs EquipmentCatalogs { get; set; }

        public virtual SchoolRegistry SchoolRegistry { get; set; }
    }
}
