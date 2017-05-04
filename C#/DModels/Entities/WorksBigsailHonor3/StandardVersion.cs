using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigsail.Honor3.ModelEntity.SuperviseEntities
{
    [Table("StandardVersion", Schema = "dbo")]
    public class StandardVersion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID", TypeName = "bigint")]
        [Display(Name = "版本标识", Description = "版本标识")]
        public long ID { get; set; }

        [MaxLength(64, ErrorMessage = "{0}限制长度为64位")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Name", TypeName = "nvarchar")]
        [Display(Name = "版本名称", Description = "版本名称")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("CreateTime", TypeName = "datetime")]
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        [MaxLength(1024, ErrorMessage = "{0}限制长度为1024位")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Memo", TypeName = "nvarchar")]
        [Display(Name = "描述说明")]
        public string Memo { get; set; }
    }
}