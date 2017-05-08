using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3
{
    [Table("EquipmentCatalogDimension", Schema = "dbo")]
    public class EquipmentCatalogDimension
    {
        [Key]
        [Column("ID", TypeName = "bigint")]
        [Display(Name = "关系标识", Description = "关系标识")]
        public Int64 ID { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("CatalogID", TypeName = "bigint")]
        [Display(Name = "科目标识", Description = "科目标识")]
        public Int64 CatalogID { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("DimensionID", TypeName = "bigint")]
        [Display(Name = "维度标识", Description = "维度标识")]
        public Int64 DimensionID { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Formula", TypeName = "nvarchar(max)")]
        [Display(Name = "计算公式", Description = "计算公式")]
        public string Formula { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("IsBasic", TypeName = "bit")]
        [Display(Name = "是否基础", Description = "是否基础")]
        public bool IsBasic { get; set; }

        [ForeignKey("DimensionID")]
        public virtual EquipmentDimension EquipmentDimension { get; set; }

        [ForeignKey("CatalogID")]
        public virtual EquipmentCatalog EquipmentCatalog { get; set; }
    }
}