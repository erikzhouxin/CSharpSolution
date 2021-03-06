using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace EZOper.TechTester.DataAccess.EZMssql.Works.Bigsail.Honor3School
{
    internal sealed class Configuration : DbMigrationsConfiguration<Honor3SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            MigrationsDirectory = @"EZMssql\Works.Bigsail\Honor3Supervise";
        }

        protected override void Seed(Honor3SchoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
