using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3
{
    public class RegistrantOrganization
    {
        [Key]
        [MaxLength(64, ErrorMessage = "{0}限制长度为64位")]
        [Required(ErrorMessage = "{0}是必填字段")]
        [RegularExpression(@"^(\d{6})|(\d{12})", ErrorMessage = "组织代码必须是县区六位数字或学校十二位数字")]
        [Column("OrgCode", TypeName = "nvarchar")]
        [Display(Name = "组织代码", Description = "县区代码是六位数字,学校代码是十二位数字,组织代码是唯一标识")]
        public string OrgCode { get; set; }

        [Display(Name = "组织名称", Description = "组织的标准名称,县区为教育局名称,学校为全称")]
        public string OrgName { get; set; }

        [Display(Name = "注册名称", Description = "组织注册时的区域名称")]
        public string RegName { get; set; }

        [Display(Name = "区域级别", Description = "区域级别:省市县乡村及学校")]
        public RegionLevelEnum Level { get; set; }

        [Display(Name = "子区域级别", Description = "子区域级别:学校类型,小学,初中等,非学校级别无用")]
        public string SubLevel { get; set; }

        [Display(Name = "组合类型", Description = "组合类型")]
        public RegionCombinationEnum CombiType { get; set; }
        
        [MaxLength(64, ErrorMessage = "{0}限制长度为64位")]
        [Column("ParentCode", TypeName = "nvarchar")]
        [Display(Name = "父级代码", Description = "组织注册的父级代码")]
        public string ParentCode { get; set; }

        [Display(Name = "状态", Description = "组织的状态")]
        public InfoUsageEnum Status { get; set; }

        [Display(Name = "注册时间", Description = "组织注册时保存时间")]
        public DateTime Time { get; set; }

        [ForeignKey("OrgCode")]
        public virtual RegistrantOrganization ParentOrg { get; set; }

        public virtual ICollection<RegistrantOrgUsers> Users { get; set; }
    }
}
