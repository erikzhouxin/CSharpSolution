using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigsail.Honor3.ModelEntity.SuperviseEntities
{
    [Table("EquipmentCatalog", Schema = "dbo")]
    public class EquipmentCatalog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID", TypeName = "bigint")]
        [Display(Name = "科目标识", Description = "科目标识")]
        public Int64 ID { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("VersionID", TypeName = "bigint")]
        [Display(Name = "科目标识", Description = "科目标识")]
        public Int64 VersionID { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("SchoolType", TypeName = "int")]
        [Display(Name = "学校类型", Description = "学校类型")]
        public SchoolType SchoolType { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("CategoryType", TypeName = "int")]
        [Display(Name = "设备大类", Description = "设备大类")]
        public CategoryType CategoryType { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Name", TypeName = "nvarchar")]
        [Display(Name = "科目名称", Description = "科目名称")]
        public string Name { get; set; }

        [MaxLength(1024, ErrorMessage = "{0}限制长度1024位字符")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Memo", TypeName = "nvarchar")]
        [Display(Name = "说明", Description = "备注")]
        public string Memo { get; set; }

        [ForeignKey("VersionID")]
        public virtual StandardVersion StandardVersion { get; set; }

        public virtual ICollection<EquipmentCatalogAllocation> EquipmentVersionAllocation { get; set; }

        public virtual ICollection<EquipmentCatalogDimension> EquipmentCatalogDimension { get; set; }
    }
}