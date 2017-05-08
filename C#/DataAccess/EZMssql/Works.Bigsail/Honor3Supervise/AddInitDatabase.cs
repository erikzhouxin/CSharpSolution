namespace EZOper.TechTester.DataAccess.EZMssql.Works.Bigsail.Honor3Supervise
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddInitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable("dbo.RegistrantOrganizations", c => new
            {
                OrgCode = c.String(nullable: false, maxLength: 64),
                OrgName = c.String(nullable: false, maxLength: 128),
                RegName = c.String(nullable: false, maxLength: 128),
                Level = c.Int(nullable: false),
                SubLevel = c.String(nullable: false, maxLength: 16),
                CombiType = c.Int(nullable: false),
                ParentCode = c.String(maxLength: 64),
                Status = c.Int(nullable: false),
                Time = c.DateTime(nullable: false),
            })
            .PrimaryKey(t => t.OrgCode)
            .ForeignKey("dbo.RegistrantOrganizations", t => t.ParentCode, cascadeDelete: false)
            .Index(t => t.ParentCode);

            CreateTable("dbo.RegistrantOrgUsers", c => new
            {
                ID = c.Guid(nullable: false),
                OrgCode = c.String(nullable: false, maxLength: 64),
                Account = c.String(nullable: false, maxLength: 64),
                Salt = c.String(nullable: false, maxLength: 256),
                Password = c.String(nullable: false, maxLength: 256),
                Permissions = c.String(nullable: false),
                Status = c.Int(nullable: false),
                Time = c.DateTime(nullable: false),
                Memo = c.String(nullable: false, maxLength: 1024),
            })
            .PrimaryKey(t => t.ID)
            .ForeignKey("dbo.RegistrantOrganizations", t => t.OrgCode, cascadeDelete: true)
            .Index(t => t.OrgCode);

        }

        public override void Down()
        {
            DropForeignKey("dbo.RegistrantOrgUsers", "OrgCode", "dbo.RegistrantOrganizations");
            DropForeignKey("dbo.RegistrantOrganizations", "ParentCode", "dbo.RegistrantOrganizations");
            DropIndex("dbo.RegistrantOrgUsers", new[] { "OrgCode" });
            DropIndex("dbo.RegistrantOrganizations", new[] { "ParentCode" });
            DropTable("dbo.RegistrantOrgUsers");
            DropTable("dbo.RegistrantOrganizations");
        }
    }
}
