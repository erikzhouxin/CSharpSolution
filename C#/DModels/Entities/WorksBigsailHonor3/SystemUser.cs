using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Remoting.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Bigsail.Honor3.ModelEntity.SuperviseEntities
{
    [Table("SystemUser", Schema = "dbo")]
    public class SystemUser
    {
        public SystemUser()
        {
            RelatedID = Guid.Empty;
            _roles = new List<RoleType>();
        }
        [Key]
        [Column("ID", TypeName = "uniqueidentifier")]
        [Display(Name = "用户标识", Description = "用户标识")]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("RelatedID", TypeName = "uniqueidentifier")]
        [Display(Name = "关联标识", Description = "关联标识")]
        public Guid RelatedID { get; set; }

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

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Roles", TypeName = "nvarchar(max)")]
        [Display(Name = "角色", Description = "角色")]
        public string Roles { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Permissions", TypeName = "nvarchar(max)")]
        [Display(Name = "权限", Description = "权限")]
        public string Permissions { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("UsageType", TypeName = "int")]
        [Display(Name = "使用类型", Description = "使用类型")]
        public UsageType UsageType { get; set; }

        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("CreateTime", TypeName = "datetime")]
        [Display(Name = "创建时间", Description = "创建时间")]
        public string CreateTime { get; set; }

        [MaxLength(1024, ErrorMessage = "{0}限制长度为1024位")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [Column("Memo", TypeName = "nvarchar")]
        [Display(Name = "注释", Description = "说明")]
        public string Memo { get; set; }

        private List<RoleType> _roles;
        [NotMapped]
        public List<RoleType> RoleTypes
        {
            get
            {
                if (_roles.Any())
                {
                    foreach (var role in Roles.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        RoleType roleType;
                        if(Enum.TryParse(role, out roleType))
                        {
                            _roles.Add(roleType);
                        }
                    }
                }
                return _roles;
            }
        }
    }
}
