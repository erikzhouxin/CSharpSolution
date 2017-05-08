using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZOper.TechTester.DModels.Entities.WorksBigsail;
using EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3;

namespace EZOper.TechTester.DataAccess.EZMssql.Works.Bigsail
{
    internal class Honor3SuperviseContext : DbContext
    {
        public Honor3SuperviseContext() : base("name=WorksBigsailHonor3Supervise")
        {
        }

        /// <summary>
        /// 组织机构注册信息
        /// </summary>
        public virtual DbSet<RegistrantOrganization> RegistrantOrganization { get; set; }

        /// <summary>
        /// 组织机构用户信息
        /// </summary>
        public virtual DbSet<RegistrantOrgUsers> RegistrantOrgUsers { get; set; }

        public virtual DbSet<StandardVersion> StandardVersion { get; set; }

        public virtual DbSet<StandardEquipment> StandardEquipment { get; set; }

        public virtual DbSet<EquipmentCatalog> EquipmentCatalog { get; set; }
    }
}
