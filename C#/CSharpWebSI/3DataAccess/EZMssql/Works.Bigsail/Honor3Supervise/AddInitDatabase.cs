namespace EZOper.TechTester.DataAccess.EZMssql.Works.Bigsail.Honor3Supervise
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EquipmentCatalog",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        VersionID = c.Long(nullable: false),
                        SchoolType = c.String(nullable: false, maxLength: 16),
                        CategoryType = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 4000),
                        Memo = c.String(nullable: false, maxLength: 1024),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.StandardVersion", t => t.VersionID, cascadeDelete: true)
                .Index(t => t.VersionID);
            
            CreateTable(
                "dbo.EquipmentCatalogDimension",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        CatalogID = c.Long(nullable: false),
                        DimensionID = c.Long(nullable: false),
                        Formula = c.String(nullable: false),
                        IsBasic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EquipmentCatalog", t => t.CatalogID, cascadeDelete: true)
                .ForeignKey("dbo.EquipmentDimension", t => t.DimensionID, cascadeDelete: true)
                .Index(t => t.CatalogID)
                .Index(t => t.DimensionID);
            
            CreateTable(
                "dbo.EquipmentDimension",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        VersionID = c.Long(nullable: false),
                        SchoolType = c.String(nullable: false, maxLength: 20),
                        Name = c.String(nullable: false, maxLength: 64),
                        MaxClass = c.Int(nullable: false),
                        MinClass = c.Int(nullable: false),
                        Memo = c.String(nullable: false, maxLength: 1024),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.StandardVersion", t => t.VersionID, cascadeDelete: true)
                .Index(t => t.VersionID);
            
            CreateTable(
                "dbo.EquipmentRequirement",
                c => new
                    {
                        EquipmentID = c.Long(nullable: false),
                        DimensionID = c.Long(nullable: false),
                        OptionType = c.Int(nullable: false),
                        NumberType = c.Int(nullable: false),
                        Value1 = c.Double(nullable: false),
                        Value2 = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.EquipmentID, t.DimensionID })
                .ForeignKey("dbo.EquipmentDimension", t => t.DimensionID, cascadeDelete: true)
                .ForeignKey("dbo.EquipmentItem", t => t.EquipmentID, cascadeDelete: true)
                .Index(t => t.EquipmentID)
                .Index(t => t.DimensionID);
            
            CreateTable(
                "dbo.EquipmentItem",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        SerialID = c.Long(nullable: false),
                        Number = c.String(nullable: false, maxLength: 32),
                        Name = c.String(nullable: false, maxLength: 128),
                        InternalGroup = c.String(nullable: false, maxLength: 128),
                        ClassifyAndCode = c.String(nullable: false, maxLength: 128),
                        RefStandardCode = c.String(nullable: false, maxLength: 128),
                        SpecifyAndFunction = c.String(nullable: false, maxLength: 128),
                        Unit = c.String(nullable: false, maxLength: 16),
                        SequenceNumber = c.Int(nullable: false),
                        EquipmentType = c.Int(nullable: false),
                        UsageType = c.Int(nullable: false),
                        Memo = c.String(nullable: false, maxLength: 1024),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EquipmentUnitPrice",
                c => new
                    {
                        EquipmentID = c.Long(nullable: false),
                        ProjectID = c.Long(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, storeType: "money"),
                        Memo = c.String(nullable: false, maxLength: 1024),
                    })
                .PrimaryKey(t => new { t.EquipmentID, t.ProjectID })
                .ForeignKey("dbo.EquipmentItem", t => t.EquipmentID, cascadeDelete: true)
                .ForeignKey("dbo.EquipmentUnitPriceProject", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.EquipmentID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.EquipmentUnitPriceProject",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                        Description = c.String(nullable: false, maxLength: 1024),
                        RevisionLog = c.String(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        Memo = c.String(nullable: false, maxLength: 1024),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EquipmentVersionPriceProject",
                c => new
                    {
                        VersionID = c.Long(nullable: false),
                        ProjectID = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 64),
                        DefineType = c.Int(nullable: false),
                        DefinedRegionCode = c.String(nullable: false, maxLength: 32),
                        Rating = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 1024),
                        UsageType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VersionID, t.ProjectID })
                .ForeignKey("dbo.EquipmentUnitPriceProject", t => t.ProjectID, cascadeDelete: true)
                .ForeignKey("dbo.StandardVersion", t => t.VersionID, cascadeDelete: true)
                .Index(t => t.VersionID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.StandardVersion",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                        CreateTime = c.DateTime(nullable: false),
                        Memo = c.String(nullable: false, maxLength: 1024),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EquipmentCatalogAllocation",
                c => new
                    {
                        CatalogID = c.Long(nullable: false),
                        EquipmentID = c.Long(nullable: false),
                        LowGroupCoef = c.Double(nullable: false),
                        HighGroupCoef = c.Double(nullable: false),
                        SmallSchoolGroupCoef = c.Double(nullable: false),
                        ShareType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CatalogID, t.EquipmentID })
                .ForeignKey("dbo.EquipmentCatalog", t => t.CatalogID, cascadeDelete: true)
                .ForeignKey("dbo.EquipmentItem", t => t.EquipmentID, cascadeDelete: true)
                .Index(t => t.CatalogID)
                .Index(t => t.EquipmentID);
            
            CreateTable(
                "dbo.RegistrantOrganizations",
                c => new
                    {
                        OrgCode = c.String(nullable: false, maxLength: 64),
                        OrgName = c.String(),
                        RegName = c.String(),
                        Level = c.Int(nullable: false),
                        SubLevel = c.String(),
                        CombiType = c.Int(nullable: false),
                        ParentCode = c.String(maxLength: 64),
                        Status = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrgCode);
            
            CreateTable(
                "dbo.RegistrantOrgUsers",
                c => new
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
            
            CreateTable(
                "dbo.StandardEquipment",
                c => new
                    {
                        SerialID = c.Long(nullable: false, identity: true),
                        Number = c.String(nullable: false, maxLength: 32),
                        Name = c.String(nullable: false, maxLength: 128),
                        InternalGroup = c.String(nullable: false, maxLength: 128),
                        ClassifyAndCode = c.String(nullable: false, maxLength: 128),
                        RefStandardCode = c.String(nullable: false, maxLength: 128),
                        SpecifyAndFunction = c.String(nullable: false, maxLength: 128),
                        Unit = c.String(nullable: false, maxLength: 16),
                        SequenceNumber = c.Int(nullable: false),
                        EquipmentType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SerialID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegistrantOrgUsers", "OrgCode", "dbo.RegistrantOrganizations");
            DropForeignKey("dbo.EquipmentCatalog", "VersionID", "dbo.StandardVersion");
            DropForeignKey("dbo.EquipmentDimension", "VersionID", "dbo.StandardVersion");
            DropForeignKey("dbo.EquipmentCatalogAllocation", "EquipmentID", "dbo.EquipmentItem");
            DropForeignKey("dbo.EquipmentCatalogAllocation", "CatalogID", "dbo.EquipmentCatalog");
            DropForeignKey("dbo.EquipmentVersionPriceProject", "VersionID", "dbo.StandardVersion");
            DropForeignKey("dbo.EquipmentVersionPriceProject", "ProjectID", "dbo.EquipmentUnitPriceProject");
            DropForeignKey("dbo.EquipmentUnitPrice", "ProjectID", "dbo.EquipmentUnitPriceProject");
            DropForeignKey("dbo.EquipmentUnitPrice", "EquipmentID", "dbo.EquipmentItem");
            DropForeignKey("dbo.EquipmentRequirement", "EquipmentID", "dbo.EquipmentItem");
            DropForeignKey("dbo.EquipmentRequirement", "DimensionID", "dbo.EquipmentDimension");
            DropForeignKey("dbo.EquipmentCatalogDimension", "DimensionID", "dbo.EquipmentDimension");
            DropForeignKey("dbo.EquipmentCatalogDimension", "CatalogID", "dbo.EquipmentCatalog");
            DropIndex("dbo.RegistrantOrgUsers", new[] { "OrgCode" });
            DropIndex("dbo.EquipmentCatalogAllocation", new[] { "EquipmentID" });
            DropIndex("dbo.EquipmentCatalogAllocation", new[] { "CatalogID" });
            DropIndex("dbo.EquipmentVersionPriceProject", new[] { "ProjectID" });
            DropIndex("dbo.EquipmentVersionPriceProject", new[] { "VersionID" });
            DropIndex("dbo.EquipmentUnitPrice", new[] { "ProjectID" });
            DropIndex("dbo.EquipmentUnitPrice", new[] { "EquipmentID" });
            DropIndex("dbo.EquipmentRequirement", new[] { "DimensionID" });
            DropIndex("dbo.EquipmentRequirement", new[] { "EquipmentID" });
            DropIndex("dbo.EquipmentDimension", new[] { "VersionID" });
            DropIndex("dbo.EquipmentCatalogDimension", new[] { "DimensionID" });
            DropIndex("dbo.EquipmentCatalogDimension", new[] { "CatalogID" });
            DropIndex("dbo.EquipmentCatalog", new[] { "VersionID" });
            DropTable("dbo.StandardEquipment");
            DropTable("dbo.RegistrantOrgUsers");
            DropTable("dbo.RegistrantOrganizations");
            DropTable("dbo.EquipmentCatalogAllocation");
            DropTable("dbo.StandardVersion");
            DropTable("dbo.EquipmentVersionPriceProject");
            DropTable("dbo.EquipmentUnitPriceProject");
            DropTable("dbo.EquipmentUnitPrice");
            DropTable("dbo.EquipmentItem");
            DropTable("dbo.EquipmentRequirement");
            DropTable("dbo.EquipmentDimension");
            DropTable("dbo.EquipmentCatalogDimension");
            DropTable("dbo.EquipmentCatalog");
        }
    }
}
