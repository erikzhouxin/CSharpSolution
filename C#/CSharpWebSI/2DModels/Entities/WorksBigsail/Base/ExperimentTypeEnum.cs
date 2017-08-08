using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.DModels.Entities.WorksBigsail
{
    /// <summary>
    /// 实验类型枚举
    /// 1.数据库
    /// </summary>
    public enum ExperimentTypeEnum
    {
        [Display(Name = "演示实验")]
        Demo = 1,
        [Display(Name = "分组实验")]
        Group = 2,
        [Display(Name = "探究实验")]
        Research = 3,
    }
}
