using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3
{
    [Table("EquipmentRequirement", Schema = "dbo")]
    public class EquipmentRequirement
    {
        [Key]
        [Column("EquipmentID", Order = 0, TypeName = "bigint")]
        [Display(Name = "设备标识", Description = "设备标识")]
        public Int64 EquipmentID { get; set; }

        [Key]
        [Column("DimensionID", Order = 1, TypeName = "bigint")]
        [Display(Name = "维度标识", Description = "维度标识")]
        public Int64 DimensionID { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("OptionType", TypeName = "int")]
        [Display(Name = "选配方式", Description = "选配方式")]
        public RequiredOptionEnum OptionType { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("NumberType", TypeName = "int")]
        [Display(Name = "数量类型", Description = "数量类型")]
        public NumberTypeEnum NumberType { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Value1", TypeName = "float")]
        [Display(Name = "数值1", Description = "数值1")]
        public double Value1 { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Value2", TypeName = "float")]
        [Display(Name = "数值2", Description = "数值2")]
        public double Value2 { get; set; }

        [ForeignKey("EquipmentID")]
        public virtual EquipmentItem EquipmentItem { get; set; }

        [ForeignKey("DimensionID")]
        public virtual EquipmentDimension EquipmentDimension { get; set; }
    }
}