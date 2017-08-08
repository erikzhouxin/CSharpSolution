using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.DModels.Entities.WorksBigsail
{ 
    /// <summary>
    /// 区域组合类型
    /// </summary>
    public enum RegionCombinationEnum
    {
        Unknown = 0,
        [Display(Name = "普通学校")]
        NormalSchool = 101,
        [Display(Name = "九年一贯制")]
        NineYearSchool = 102,
        [Display(Name = "十二年一贯制")]
        TwelveYearSchool = 103,
        [Display(Name = "完全中学")]
        CompleteMiddleSchool = 104,
    }
}
