using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3
{
    /// <summary>
    /// 学校学年档案信息
    /// 1.概念阶段
    /// </summary>
    [Serializable]
    public class SchoolYearFileInfo
    {
        public SchoolYearFileInfo()
        {
            BaseInfo = new SchoolBaseInfo();
            FileInfo = new SchoolFileInfo();
            YearInfo = new SchoolYearInfo();
            RenewalInfo = new SchoolRenewalInfo();
            EducationYearFile = new EducationYearFileInfo();
        }

        /// <summary>
        /// 基本信息
        /// </summary>
        public SchoolBaseInfo BaseInfo { get; set; }

        /// <summary>
        /// 档案信息
        /// </summary>
        public SchoolFileInfo FileInfo { get; set; }

        /// <summary>
        /// 学年信息
        /// </summary>
        public SchoolYearInfo YearInfo { get; set; }

        /// <summary>
        /// 续费信息
        /// </summary>
        public SchoolRenewalInfo RenewalInfo { get; set; }

        /// <summary>
        /// 教育局档案信息
        /// </summary>
        public EducationYearFileInfo EducationYearFile { get; set; }
    }
}
