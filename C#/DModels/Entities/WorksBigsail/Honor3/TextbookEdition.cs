using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3
{
    [Table("TextbookEdition", Schema = "dbo")]
    public class TextbookEdition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID", TypeName = "bigint")]
        [Display(Name = "教材版本标识", Description = "教材版本标识")]
        public Int64 ID { get; set; }

        [MaxLength(64, ErrorMessage = "{0}限制长度64位字符")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Name", TypeName = "nvarchar")]
        [Display(Name = "版本名称", Description = "版本名称")]
        public string Name { get; set; }

        [MaxLength(64, ErrorMessage = "{0}限制长度64位字符")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("DisplayName", TypeName = "nvarchar")]
        [Display(Name = "显示名称", Description = "显示名称")]
        public string DisplayName { get; set; }

        [MaxLength(256, ErrorMessage = "{0}限制长度256位字符")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("DisplayName", TypeName = "nvarchar")]
        [Display(Name = "出版社名称", Description = "出版社名称")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("PublishDate", TypeName = "datetime")]
        [Display(Name = "出版时间", Description = "出版时间")]
        public DateTime PublishDate { get; set; }

        [MaxLength(1024, ErrorMessage = "{0}限制长度1024位字符")]
        [Column("DisplayName", TypeName = "nvarchar")]
        [Display(Name = "注释", Description = "说明")]
        public string Memo { get; set; }
    }
}
