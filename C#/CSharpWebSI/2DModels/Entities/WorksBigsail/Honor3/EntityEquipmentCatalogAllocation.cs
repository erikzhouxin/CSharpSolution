using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3
{
    [Table("EquipmentCatalogAllocation", Schema = "dbo")]
    public class EquipmentCatalogAllocation
    {
        [Key]
        [Column("CatalogID", Order = 0, TypeName = "bigint")]
        [Display(Name = "版本标识", Description = "版本标识")]
        public Int64 CatalogID { get; set; }
        
        [Key]
        [Column("EquipmentID", Order = 1, TypeName = "bigint")]
        [Display(Name = "设备标识", Description = "设备标识")]
        public Int64 EquipmentID { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("LowGroupCoef", TypeName = "float")]
        [Display(Name = "低分组系数", Description = "低分组系数")]
        public double LowGroupCoef { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("HighGroupCoef", TypeName = "float")]
        [Display(Name = "高分组系数", Description = "高分组系数")]
        public double HighGroupCoef { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("SmallSchoolGroupCoef", TypeName = "float")]
        [Display(Name = "小规模学校分组系数", Description = "小规模学校分组系数")]
        public double SmallSchoolGroupCoef { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("ShareType", TypeName = "int")]
        [Display(Name = "共用类型", Description = "共用类型")]
        public EquipmentSharedEnum ShareType { get; set; }

        [ForeignKey("CatalogID")]
        public EquipmentCatalog EquipmentCatalog { get; set; }

        [ForeignKey("EquipmentID")]
        public EquipmentItem EquipmentItem { get; set; }
    }
}