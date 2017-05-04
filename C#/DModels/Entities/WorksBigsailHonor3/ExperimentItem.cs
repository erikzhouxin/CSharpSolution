using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigsail.Honor3.ModelEntity.SuperviseEntities
{
    [Table("ExperimentItem", Schema = "dbo")]
    public class ExperimentItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID", TypeName = "bigint")]
        [Display(Name = "实验标识", Description = "实验标识")]
        public Int64 ID { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("SerialID", TypeName = "bigint")]
        [Display(Name = "实验标识", Description = "实验标识")]
        public Int64 SerialID { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Grade", TypeName = "int")]
        [Display(Name = "年级", Description = "年级")]
        public SchoolGradeType Grade { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Semester", TypeName = "int")]
        [Display(Name = "学期", Description = "学期")]
        public SemesterType Semester { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("SequenceNumber", TypeName = "int")]
        [Display(Name = "排列序号", Description = "排列序号")]
        public int SequenceNumber { get; set; }

        [StringLength(64, ErrorMessage = "{0}限制长度为64位字符")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Chapter", TypeName = "nvarchar")]
        [Display(Name = "章节", Description = "章节")]
        public string Chapter { get; set; }

        [StringLength(256, ErrorMessage = "{0}限制长度为256位字符")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Title", TypeName = "nvarchar")]
        [Display(Name = "章节标题", Description = "章节标题")]
        public string Title { get; set; }

        [StringLength(128, ErrorMessage = "{0}限制长度为128位字符")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Name", TypeName = "nvarchar")]
        [Display(Name = "实验名称", Description = "实验名称")]
        public string Name { get; set; }

        [StringLength(1024, ErrorMessage = "{0}限制长度为1024位字符")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Summary", TypeName = "nvarchar")]
        [Display(Name = "实验简介", Description = "实验简介")]
        public string Summary { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Content", TypeName = "nvarchar(max)")]
        [Display(Name = "实验内容", Description = "实验内容")]
        public string Content { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("OtherEquipments", TypeName = "nvarchar(max)")]
        [Display(Name = "其他设备", Description = "其他设备")]
        public string OtherEquipments { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("ExperimentType", TypeName = "int")]
        [Display(Name = "实验类型", Description = "实验类型")]
        public ExperimentType ExperimentType { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("OptionType", TypeName = "int")]
        [Display(Name = "实验配备", Description = "实验配备")]
        public OptionType OptionType { get; set; }

        [StringLength(1024, ErrorMessage = "{0}限制长度为1024位字符")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Memo", TypeName = "nvarchar")]
        [Display(Name = "备注", Description = "说明")]
        public string Memo { get; set; }
    }
}
