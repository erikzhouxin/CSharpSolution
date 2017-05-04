using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.DModels.Entities.WorksBigsail
{
    public class RegistrantOrganization
    {
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "组织代码不能为空")]
        [RegularExpression(@"^(\d{6})|(\d{12})", ErrorMessage = "组织代码必须是县区六位数字或学校十二位数字")]
        [Display(Name = "组织代码", Description = "县区代码是六位数字,学校代码是十二位数字,组织代码是唯一标识")]
        public string OrgCode { get; set; }

        [Display(Name = "组织名称", Description = "组织的名称,县区为教育局名称,学校为全称")]
        public string OrgName { get; set; }

        [Display(Name = "注册名称", Description = "组织注册时的名称,县区为区域名称,学校为简称")]
        public string RegisteredName { get; set; }

        public 
    }
}
