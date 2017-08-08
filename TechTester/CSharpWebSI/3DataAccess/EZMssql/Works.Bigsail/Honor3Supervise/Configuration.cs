using EZOper.TechTester.DModels;
using EZOper.TechTester.DModels.Entities;
using EZOper.TechTester.DModels.Entities.WorksBigsail;
using EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace EZOper.TechTester.DataAccess.EZMssql.Works.Bigsail.Honor3Supervise
{
    sealed class Configuration : DbMigrationsConfiguration<Honor3SuperviseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            MigrationsDirectory = @"EZMssql\Works.Bigsail\Honor3Supervise";
        }

        protected override void Seed(Honor3SuperviseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            var defaultUserPassword = new UserPassword();
            context.RegistrantOrganization.AddOrUpdate(
              p => p.OrgCode,
              new RegistrantOrganization()
              {
                  OrgCode = "000000",
                  OrgName = "EZOper.Works.Bigsail.Honor3",
                  RegName = "EZOper.Works.Bigsail.Honor3",
                  Level = RegionLevelEnum.Unknown,
                  SubLevel = string.Empty,
                  CombiType = RegionCombinationEnum.Unknown,
                  ParentCode = null,
                  Status = InfoUsageEnum.Enabled,
                  Time = DateTime.Now,
                  Users = new List<RegistrantOrgUsers>()
                  {
                      new RegistrantOrgUsers()
                      {
                          ID = Guid.NewGuid(),
                          OrgCode= "000000",
                          Account = DataDefinition.UserAdminAccount,
                          Salt = defaultUserPassword.Salt,
                          Password = defaultUserPassword.HashPassword,
                          Permissions = string.Empty,
                          Status = InfoUsageEnum.Enabled,
                          Memo = string.Empty,
                          Time = DateTime.Now,
                      },
                  },
                   
              }
            );
            context.SaveChanges();
        }

        internal void Seed()
        {
            Seed(new Honor3SuperviseContext());
        }
    }
}
