using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigsail.Honor3.ModelEntity.SuperviseEntities
{
    [Table("EquipmentUnitPrice", Schema = "dbo")]
    public class EquipmentUnitPrice
    {
        [Key]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("EquipmentID", Order = 0, TypeName = "bigint")]
        [Display(Name = "设备标识", Description = "设备标识")]
        public Int64 EquipmentID { get; set; }

        [Key]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("ProjectID", Order = 1, TypeName = "bigint")]
        [Display(Name = "项目标识", Description = "项目标识")]
        public Int64 ProjectID { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("UnitPrice", TypeName = "money")]
        [Display(Name = "单价(元)", Description = "单价(元)")]
        public decimal UnitPrice { get; set; }

        [MaxLength(1024, ErrorMessage = "{0}限制长度为1024位")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Memo", TypeName = "nvarchar")]
        [Display(Name = "说明", Description = "备注")]
        public string Memo { get; set; }

        [ForeignKey("ProjectID")]
        public virtual EquipmentUnitPriceProject EquipmentUnitPriceProject { get; set; }

        [ForeignKey("EquipmentID")]
        public virtual EquipmentItem EquipmentItem { get; set; }
    }
}