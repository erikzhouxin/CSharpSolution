using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigsail.Honor3.ModelEntity
{
    /// <summary>
    /// 学校类型
    /// </summary>
    public enum SchoolType
    {
        [Display(Name = "小学", GroupName = "小学")]
        Primary = 1,
        [Display(Name = "初中", GroupName = "初级中学")]
        Junior = 2,
        [Display(Name = "高中", GroupName = "高级中学")]
        Senior = 3,
    }
}
