using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Remoting.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3
{
    [Table("RegistrantOrgUsers", Schema = "dbo")]
    public class RegistrantOrgUsers
    {
        [Key]
        [Column("ID", TypeName = "uniqueidentifier")]
        [Display(Name = "用户标识", Description = "用户标识")]
        public Guid ID { get; set; }

        [MaxLength(64, ErrorMessage = "{0}限制长度为64位")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("OrgCode", TypeName = "nvarchar")]
        [Display(Name = "关联标识", Description = "关联标识")]
        public string OrgCode { get; set; }

        [MaxLength(64, ErrorMessage = "{0}限制长度为64位")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Account", TypeName = "nvarchar")]
        [Display(Name = "用户名", Description = "用户名")]
        public string Account { get; set; }

        [MaxLength(256, ErrorMessage = "{0}限制长度为256位")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Salt", TypeName = "nvarchar")]
        [Display(Name = "盐值", Description = "盐值")]
        public string Salt { get; set; }

        [MaxLength(256, ErrorMessage = "{0}限制长度为256位")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Password", TypeName = "nvarchar")]
        [Display(Name = "密码", Description = "密码")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "{0}是必填字段")]
        [Column("Permissions", TypeName = "nvarchar(max)")]
        [Display(Name = "权限", Description = "权限")]
        public string Permissions { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Status", TypeName = "int")]
        [Display(Name = "使用类型", Description = "使用类型")]
        public InfoUsageEnum Status { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Time", TypeName = "datetime")]
        [Display(Name = "创建时间", Description = "创建时间")]
        public DateTime Time { get; set; }

        [MaxLength(1024, ErrorMessage = "{0}限制长度为1024位")]
        [Required(AllowEmptyStrings = true, ErrorMessage = "{0}是必填字段")]
        [Column("Memo", TypeName = "nvarchar")]
        [Display(Name = "注释", Description = "说明")]
        public string Memo { get; set; }

        [ForeignKey("OrgCode")]
        public virtual RegistrantOrganization Organization { get; set; }
    }
}
