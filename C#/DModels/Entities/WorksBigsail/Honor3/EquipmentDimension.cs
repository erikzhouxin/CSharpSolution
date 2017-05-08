using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3
{
    [Table("EquipmentDimension", Schema = "dbo")]
    public class EquipmentDimension
    {
        [Key]
        [Column("ID", TypeName = "bigint")]
        [Display(Name = "维度标识", Description = "维度标识")]
        public Int64 ID { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("VersionID", TypeName = "bigint")]
        [Display(Name = "版本标识", Description = "版本标识")]
        public Int64 VersionID { get; set; }

        [MaxLength(20, ErrorMessage = "{0}限制长度为20位")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("SchoolType", TypeName = "nvarchar")]
        [Display(Name = "学校类型", Description = "学校类型")]
        public string SchoolType { get; set; }

        [MaxLength(64, ErrorMessage = "{0}限制长度为64位")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Name", TypeName = "nvarchar")]
        [Display(Name = "维度名称", Description = "维度名称")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("MaxClass", TypeName = "int")]
        [Display(Name = "最大班额", Description = "最大班额")]
        public int MaxClass { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("MinClass", TypeName = "int")]
        [Display(Name = "最小班额", Description = "最小班额")]
        public int MinClass { get; set; }

        [MaxLength(1024, ErrorMessage = "{0}限制长度为1024位")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Display(Name = "备注", Description = "说明")]
        public string Memo { get; set; }

        [ForeignKey("VersionID")]
        public virtual StandardVersion StandardVersion { get; set; }

        public virtual ICollection<EquipmentCatalogDimension> EquipmentCatalogDimension { get; set; }

        public virtual ICollection<EquipmentRequirement> EquipmentRequirement { get; set; }
    }
}