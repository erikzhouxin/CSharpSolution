using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigsail.Honor3.ModelEntity.SuperviseEntities
{
    [Table("EquipmentUnitPriceProject", Schema = "dbo")]
    public class EquipmentUnitPriceProject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID", TypeName = "bigint")]
        [Display(Name = "参考单价项目标识", Description = "参考单价项目标识")]
        public Int64 ID { get; set; }
        
        [MaxLength(64, ErrorMessage = "{0}限制长度为64位")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Name", TypeName = "nvarchar")]
        [Display(Name = "显示名称", Description = "显示名称")]
        public string Name { get; set; }
        
        [MaxLength(1024, ErrorMessage = "{0}限制长度为1024位")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Description", TypeName = "nvarchar")]
        [Display(Name = "项目描述", Description = "项目描述")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("RevisionLog", TypeName = "nvarchar(max)")]
        [Display(Name = "修订日志", Description = "修订日志")]
        public string RevisionLog { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("CreateTime", TypeName = "datetime")]
        [Display(Name = "创建时间", Description = "创建时间")]
        public DateTime CreateTime { get; set; }

        [MaxLength(1024, ErrorMessage = "{0}限制长度为1024位")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Memo", TypeName = "nvarchar")]
        [Display(Name = "说明", Description = "备注")]
        public string Memo { get; set; }
        
        public virtual ICollection<EquipmentUnitPrice> EquipmentUnitPrice { get; set; }

        public virtual ICollection<EquipmentVersionPriceProject> EquipmentVersionPriceProject { get; set; }
    }
}