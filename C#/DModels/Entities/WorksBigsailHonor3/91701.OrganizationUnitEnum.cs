using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.DModels.Entities.WorksBigsailHonor3
{
    /// <summary>
    /// 组织单位枚举
    /// </summary>
    public enum OrganizationUnitEnum
    {
        [Display(Name = "未定义")]
        Unknown = 0,
        [Display(Name = "国家")]
        Country = 9170101,
        [Display(Name = "省")]
        Province = 9170102,
        [Display(Name = "市（州）")]
        City = 9170103,
        [Display(Name = "县、区")]
        County = 9170104,
        [Display(Name = "乡、镇")]
        Township = 9170105,
        [Display(Name = "村、社")]
        Village = 9170106,
        [Display(Name = "学校")]
        School = 9170107,
    }
}
