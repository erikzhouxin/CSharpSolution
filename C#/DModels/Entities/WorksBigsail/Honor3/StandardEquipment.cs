using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3
{
    [Table("StandardEquipment", Schema = "dbo")]
    public class StandardEquipment
    {
        [Key]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("SerialID", TypeName = "bigint")]
        [Display(Name = "设备标识", Description = "设备标识")]
        public Int64 SerialID { get; set; }

        [MaxLength(32, ErrorMessage = "{0}限制长度32位字符")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Number", TypeName = "nvarchar")]
        [Display(Name = "设备编号", Description = "设备编号")]
        public string Number { get; set; }

        [MaxLength(128, ErrorMessage = "{0}限制长度128位字符")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Name", TypeName = "nvarchar")]
        [Display(Name = "设备名称", Description = "项目名称")]
        public string Name { get; set; }

        [MaxLength(128, ErrorMessage = "{0}限制长度128位字符")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("InternalGroup", TypeName = "nvarchar")]
        [Display(Name = "内部分组", Description = "内部分组")]
        public string InternalGroup { get; set; }

        [MaxLength(128, ErrorMessage = "{0}限制长度128位字符")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("ClassifyAndCode", TypeName = "nvarchar")]
        [Display(Name = "分类与代码", Description = "分类与代码")]
        public string ClassifyAndCode { get; set; }

        [MaxLength(128, ErrorMessage = "{0}限制长度128位字符")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("RefStandardCode", TypeName = "nvarchar")]
        [Display(Name = "引用标准", Description = "引用标准")]
        public string RefStandardCode { get; set; }

        [MaxLength(128, ErrorMessage = "{0}限制长度128位字符")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("SpecifyAndFunction", TypeName = "nvarchar")]
        [Display(Name = "规格型号", Description = "规格型号功能")]
        public string SpecifyAndFunction { get; set; }

        [MaxLength(16, ErrorMessage = "{0}限制长度16位字符")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Unit", TypeName = "nvarchar")]
        [Display(Name = "单位", Description = "量化单位")]
        public string Unit { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("SequenceNumber", TypeName = "int")]
        [Display(Name = "排序序号", Description = "排序序号")]
        public int SequenceNumber { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("EquipmentType", TypeName = "int")]
        [Display(Name = "设备类型", Description = "设备类型")]
        public EquipmentTypeEnum EquipmentType { get; set; }
    }
}
