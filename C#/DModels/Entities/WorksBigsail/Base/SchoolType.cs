using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.DModels.Entities.WorksBigsail
{
    /// <summary>
    /// 学校类型
    /// 1.数据库
    /// 2.固定添加
    /// </summary>
    public class SchoolType
    {
        public const string Primary = "小学";
        public const string Junior = "初中";
        public const string Senior = "高中";
    }
}
