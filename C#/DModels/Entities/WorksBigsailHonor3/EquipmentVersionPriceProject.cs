using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigsail.Honor3.ModelEntity.SuperviseEntities
{
    [Table("EquipmentVersionPriceProject", Schema = "dbo")]
    public class EquipmentVersionPriceProject
    {
        [Key]
        [Column("VersionID", Order = 0, TypeName = "bigint")]
        [Display(Name = "版本标识", Description = "版本标识")]
        public Int64 VersionID { get; set; }

        [Key]
        [Column("ProjectID", Order = 1, TypeName = "bigint")]
        [Display(Name = "版本标识", Description = "版本标识")]
        public Int64 ProjectID { get; set; }

        [MaxLength(64, ErrorMessage = "{0}限制长度为64位")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Name", TypeName = "nvarchar")]
        [Display(Name = "显示名称", Description = "显示名称")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("DefineType", TypeName = "int")]
        [Display(Name = "定义类型", Description = "定义类型")]
        public DefineType DefineType { get; set; }

        [MaxLength(32, ErrorMessage = "{0}限制长度为32位")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("DefinedRegionCode", TypeName = "nvarchar")]
        [Display(Name = "定义区域代码", Description = "定义区域代码")]
        public string DefinedRegionCode { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Rating", TypeName = "int")]
        [Display(Name = "定义等级", Description = "定义等级")]
        public int Rating { get; set; }

        [MaxLength(1024, ErrorMessage = "{0}限制长度为1024位")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Description", TypeName = "nvarchar")]
        [Display(Name = "项目描述", Description = "项目描述")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("UsageType", TypeName = "int")]
        [Display(Name = "是否可用", Description = "版本名称")]
        public UsageType UsageType { get; set; }
        
        [ForeignKey("VersionID")]
        public virtual StandardVersion StandardVersion { get; set; }

        [ForeignKey("ProjectID")]
        public virtual EquipmentUnitPriceProject EquipmentUnitPriceProject { get; set; }
    }
}