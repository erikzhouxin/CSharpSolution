using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.DModels.Entities.WorksBigsail
{
    public enum RequiredOptionEnum
    {
        None = 0,
        [Display(Name = "基本")]
        Basic = 1,
        [Display(Name = "选配")]
        Optional = 2,
    }
}
