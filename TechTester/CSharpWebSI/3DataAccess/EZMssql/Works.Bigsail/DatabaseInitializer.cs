using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.DataAccess.EZMssql.Works.Bigsail
{
    /// <summary>
    /// 数据库初始化操作类
    /// </summary>
    public static partial class DatabaseInitializer
    {
        /// <summary>
        /// 数据库初始化
        /// </summary>
        public static void Honor3Supervise()
        {
            Database.SetInitializer<Honor3SuperviseContext>(new CreateDatabaseIfNotExists<Honor3SuperviseContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Honor3SuperviseContext, Honor3Supervise.Configuration>());
            // SetSqlGenerator("System.Data.SqlClient", new NonSystemTableSqlGenerator()); 
        }

        public static void Honor3School()
        {
            Database.SetInitializer<Honor3SchoolContext>(new CreateDatabaseIfNotExists<Honor3SchoolContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Honor3SchoolContext, Honor3School.Configuration>());
            // SetSqlGenerator("System.Data.SqlClient", new NonSystemTableSqlGenerator()); 
        }
    }
}
