using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigsail.Honor3.ModelEntity
{
    /// <summary>
    /// 角色枚举
    /// </summary>
    public enum RoleType
    {
        [Display(Name = "匿名用户", GroupName = "全部")]
        Anonym = 0,
        #region // 学校
        [Display(Name = "学校匿名用户", GroupName = "学校")]
        SchoolAnonym = 1000000,
        [Display(Name = "系统管理员", GroupName = "学校")]
        SchoolAdmin = 1000001,
        [Display(Name = "设备管理员", GroupName = "学校")]
        SchoolEquipment = 1000002,
        [Display(Name = "任课教师", GroupName = "学校")]
        SchoolTeacher = 1000003,
        [Display(Name = "校长", GroupName = "学校")]
        SchoolMaster = 1000004,
        [Display(Name = "总务主任", GroupName = "学校")]
        SchoolAffairs = 1000005,
        [Display(Name = "教务主任", GroupName = "学校")]
        SchoolEducational = 1000006,
        [Display(Name = "其他管理员", GroupName = "学校")]
        SchoolOthers = 1000007,
        #endregion
        #region // 设置
        [Display(Name = "设置匿名用户", GroupName = "设置")]
        SettingAnonym = 1000050,
        [Display(Name = "系统管理员", GroupName = "设置")]
        SettingAdmin = 1000051
        #endregion
    }
}
