using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.DModels.Entities.WorksBigsail
{
    /// <summary>
    /// 区域级别枚举
    /// 1.数据库
    /// </summary>
    public enum RegionLevelEnum
    {
        [Display(Name = "未定义")]
        Unknown = 0,
        [Display(Name = "国家")]
        Country = 10,
        [Display(Name = "省")]
        Province = 20,
        [Display(Name = "市（州）")]
        City = 30,
        [Display(Name = "县、区")]
        County = 40,
        [Display(Name = "乡、镇")]
        Township = 50,
        [Display(Name = "村、社")]
        Village = 60,
        [Display(Name = "组、队")]
        Team = 70,
        [Display(Name = "学校")]
        School = 80,
    }
}
