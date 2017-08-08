using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3
{
    /// <summary>
    /// 教育局学年档案信息
    /// 1.概念阶段
    /// </summary>
    [Serializable]
    public class EducationYearFileInfo
    {
        public EducationYearFileInfo()
        {
            BaseInfo = new EducationBaseInfo();
            FileInfo = new EducationFileInfo();
            YearInfo = new EducationYearInfo();
            RenewalInfo = new EducationRenewalInfo();
        }

        /// <summary>
        /// 基本信息
        /// </summary>
        public EducationBaseInfo BaseInfo { get; set; }

        /// <summary>
        /// 档案信息
        /// </summary>
        public EducationFileInfo FileInfo { get; set; }

        /// <summary>
        /// 学年信息
        /// </summary>
        public EducationYearInfo YearInfo { get; set; }

        /// <summary>
        /// 续费信息
        /// </summary>
        public EducationRenewalInfo RenewalInfo { get; set; }
    }
}
