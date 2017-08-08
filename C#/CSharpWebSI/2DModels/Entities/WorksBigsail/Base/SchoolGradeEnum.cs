using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.DModels.Entities.WorksBigsail
{
    public enum SchoolGradeEnum
    {
        [Display(Name = "一年级", GroupName = "小学")]
        FirstGrade = 1,
        [Display(Name = "二年级", GroupName = "小学")]
        SecondGrade = 2,
        [Display(Name = "三年级", GroupName = "小学")]
        ThirdGrade = 3,
        [Display(Name = "四年级", GroupName = "小学")]
        ForthGrade = 4,
        [Display(Name = "五年级", GroupName = "小学")]
        FifthGrade = 5,
        [Display(Name = "六年级", GroupName = "小学")]
        SixthGrade = 6,
        [Display(Name = "七年级", GroupName = "初中")]
        SeventhGrade = 7,
        [Display(Name = "八年级", GroupName = "初中")]
        EighthGrade = 8,
        [Display(Name = "九年级", GroupName = "初中")]
        NinthGrade = 9,
    }
}
