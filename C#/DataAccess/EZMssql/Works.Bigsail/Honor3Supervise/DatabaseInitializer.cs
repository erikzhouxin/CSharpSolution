using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigsail.Honor3.ModelEntity.SuperviseEntities.MigrationHistory
{
    /// <summary>
    /// 数据库初始化操作类
    /// </summary>
    public static partial class DatabaseInitializer
    {
        /// <summary>
        /// 数据库初始化
        /// </summary>
        public static void Supervise()
        {
            Database.SetInitializer<SuperviseDbContext>(new CreateDatabaseIfNotExists<SuperviseDbContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SuperviseDbContext, Configuration>());
            // SetSqlGenerator("System.Data.SqlClient", new NonSystemTableSqlGenerator()); 
        }
    }
}
