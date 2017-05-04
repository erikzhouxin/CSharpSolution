using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.DModels.Entities.WorksBigsailHonor3
{
    /// <summary>
    /// 组织类型枚举
    /// </summary>
    public enum OrganizationTypeEnum
    {
        [Display(Name = "未定义")]
        Unknown = 0,
        [Display(Name = "山区县")]
        Coteau = 91700,
        [Display(Name = "川区县")]
        Plain = 917110112,

        [Display(Name = "幼儿园")]
        Preschool = 917110151,
        [Display(Name = "小学")]
        PrimarySchool = 917110152,
        [Display(Name = "初中")]
        JuniorSchool = 917110153,
        [Display(Name = "高中")]
        HighSchool = 917110154,
        [Display(Name = "大学")]
        CollegeSchool = 917110155,
    }
}
