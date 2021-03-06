﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.DModels.Entities.WorksBigsail
{
    public enum SemesterTypeEnum
    {
        [Display(Name = "上学期")]
        LastTerm = 1,
        [Display(Name = "下学期")]
        NextTerm = 2,
        [Display(Name = "学年")]
        SchoolYear = LastTerm & NextTerm,
    }
}
