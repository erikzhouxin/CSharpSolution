using EZOper.TechTester.DModels.Entities.WorksBigsail.Honor3Supervise;
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

namespace EZOper.TechTester.DataAccess.EZMssql.Works.Bigsail
{
    public partial class Honor3SuperviseEntities : DbContext
    {
        public Honor3SuperviseEntities()
            : base("name=WorksBigsailHonor3SuperviseEntities")
        {
        }

        public virtual DbSet<BookEditions> BookEditions { get; set; }
        public virtual DbSet<CatalogDimensionRelation> CatalogDimensionRelation { get; set; }
        public virtual DbSet<CommandInfo> CommandInfo { get; set; }
        public virtual DbSet<DatabaseDistribution> DatabaseDistribution { get; set; }
        public virtual DbSet<EducationBureau_ExperimentSettings> EducationBureau_ExperimentSettings { get; set; }
        public virtual DbSet<EducationBureauFilesControl> EducationBureauFilesControl { get; set; }
        public virtual DbSet<EducationBureauRegistry> EducationBureauRegistry { get; set; }
        public virtual DbSet<EducationBureauUsers> EducationBureauUsers { get; set; }
        public virtual DbSet<EducationLockUnlockOperLog> EducationLockUnlockOperLog { get; set; }
        public virtual DbSet<EducationUsersSchoolRange> EducationUsersSchoolRange { get; set; }
        public virtual DbSet<EquipmentCatalogs> EquipmentCatalogs { get; set; }
        public virtual DbSet<EquipmentItems> EquipmentItems { get; set; }
        public virtual DbSet<EquipmentReferenceUnitPrice> EquipmentReferenceUnitPrice { get; set; }
        public virtual DbSet<EquipmentStandardDimensions> EquipmentStandardDimensions { get; set; }
        public virtual DbSet<EquipmentStandardRequirements> EquipmentStandardRequirements { get; set; }
        public virtual DbSet<ExperimentItems> ExperimentItems { get; set; }
        public virtual DbSet<GroupingExperimentEquipment> GroupingExperimentEquipment { get; set; }
        public virtual DbSet<OperationLog> OperationLog { get; set; }
        public virtual DbSet<ReferenceUnitPriceProject> ReferenceUnitPriceProject { get; set; }
        public virtual DbSet<SchoolCatalogInit> SchoolCatalogInit { get; set; }
        public virtual DbSet<SchoolNotices> SchoolNotices { get; set; }
        public virtual DbSet<SchoolOrderInfo> SchoolOrderInfo { get; set; }
        public virtual DbSet<SchoolRegistry> SchoolRegistry { get; set; }
        public virtual DbSet<SchoolRenewFee> SchoolRenewFee { get; set; }
        public virtual DbSet<SchoolUsers> SchoolUsers { get; set; }
        public virtual DbSet<SchoolYearFilesRegistry> SchoolYearFilesRegistry { get; set; }
        public virtual DbSet<StandardSchoolClassifications> StandardSchoolClassifications { get; set; }
        public virtual DbSet<StandardVersions> StandardVersions { get; set; }
        public virtual DbSet<SysSettingUser> SysSettingUser { get; set; }
        public virtual DbSet<SchoolUserOperInfo> SchoolUserOperInfo { get; set; }
        public virtual DbSet<VW_BookEdition> VW_BookEdition { get; set; }
        public virtual DbSet<VW_Category> VW_Category { get; set; }
        public virtual DbSet<VW_Experiment> VW_Experiment { get; set; }
        public virtual DbSet<VW_ExperimentCategory> VW_ExperimentCategory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookEditions>()
                .HasMany(e => e.EducationBureau_ExperimentSettings)
                .WithRequired(e => e.BookEditions)
                .HasForeignKey(e => e.BookEditionId);

            modelBuilder.Entity<BookEditions>()
                .HasMany(e => e.ExperimentItems)
                .WithRequired(e => e.BookEditions)
                .HasForeignKey(e => e.EditionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CommandInfo>()
                .Property(e => e.CommandType)
                .IsUnicode(false);

            modelBuilder.Entity<CommandInfo>()
                .Property(e => e.CommandParams)
                .IsUnicode(false);

            modelBuilder.Entity<DatabaseDistribution>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<EducationBureauFilesControl>()
                .HasMany(e => e.EducationBureau_ExperimentSettings)
                .WithRequired(e => e.EducationBureauFilesControl)
                .HasForeignKey(e => e.EducationFileID);

            modelBuilder.Entity<EducationBureauFilesControl>()
                .HasMany(e => e.SchoolYearFilesRegistry)
                .WithRequired(e => e.EducationBureauFilesControl)
                .HasForeignKey(e => e.FilesControlID);

            modelBuilder.Entity<EducationBureauRegistry>()
                .Property(e => e.RegionCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EducationBureauRegistry>()
                .HasOptional(e => e.DatabaseDistribution)
                .WithRequired(e => e.EducationBureauRegistry)
                .WillCascadeOnDelete();

            modelBuilder.Entity<EducationBureauRegistry>()
                .HasMany(e => e.EducationBureauFilesControl)
                .WithRequired(e => e.EducationBureauRegistry)
                .HasForeignKey(e => e.EducationBureauID);

            modelBuilder.Entity<EducationBureauRegistry>()
                .HasMany(e => e.EducationBureauUsers)
                .WithRequired(e => e.EducationBureauRegistry)
                .HasForeignKey(e => e.EducationBureauID);

            modelBuilder.Entity<EducationBureauRegistry>()
                .HasMany(e => e.SchoolRegistry)
                .WithRequired(e => e.EducationBureauRegistry)
                .HasForeignKey(e => e.EducationBureauID);

            modelBuilder.Entity<EducationBureauUsers>()
                .HasOptional(e => e.EducationUsersSchoolRange)
                .WithRequired(e => e.EducationBureauUsers)
                .WillCascadeOnDelete();

            modelBuilder.Entity<EquipmentCatalogs>()
                .HasMany(e => e.CatalogDimensionRelation)
                .WithRequired(e => e.EquipmentCatalogs)
                .HasForeignKey(e => e.CatalogId);

            modelBuilder.Entity<EquipmentCatalogs>()
                .HasMany(e => e.EducationBureau_ExperimentSettings)
                .WithRequired(e => e.EquipmentCatalogs)
                .HasForeignKey(e => e.CatalogID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EquipmentCatalogs>()
                .HasMany(e => e.EquipmentItems)
                .WithRequired(e => e.EquipmentCatalogs)
                .HasForeignKey(e => e.EquipmentCatalogID);

            modelBuilder.Entity<EquipmentCatalogs>()
                .HasMany(e => e.ExperimentItems)
                .WithRequired(e => e.EquipmentCatalogs)
                .HasForeignKey(e => e.CatalogID);

            modelBuilder.Entity<EquipmentCatalogs>()
                .HasMany(e => e.SchoolCatalogInit)
                .WithRequired(e => e.EquipmentCatalogs)
                .HasForeignKey(e => e.CatalogID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EquipmentItems>()
                .Property(e => e.ReferenceUnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EquipmentItems>()
                .HasMany(e => e.EquipmentStandardRequirements)
                .WithRequired(e => e.EquipmentItems)
                .HasForeignKey(e => e.EquipmentItemID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EquipmentItems>()
                .HasOptional(e => e.GroupingExperimentEquipment)
                .WithRequired(e => e.EquipmentItems)
                .WillCascadeOnDelete();

            modelBuilder.Entity<EquipmentReferenceUnitPrice>()
                .Property(e => e.ReferenceUnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EquipmentStandardDimensions>()
                .HasMany(e => e.CatalogDimensionRelation)
                .WithRequired(e => e.EquipmentStandardDimensions)
                .HasForeignKey(e => e.DimensionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EquipmentStandardDimensions>()
                .HasMany(e => e.EquipmentStandardRequirements)
                .WithRequired(e => e.EquipmentStandardDimensions)
                .HasForeignKey(e => e.DimensionID);

            modelBuilder.Entity<ReferenceUnitPriceProject>()
                .Property(e => e.FromRegionCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ReferenceUnitPriceProject>()
                .HasMany(e => e.EducationBureauFilesControl)
                .WithRequired(e => e.ReferenceUnitPriceProject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReferenceUnitPriceProject>()
                .HasMany(e => e.EquipmentReferenceUnitPrice)
                .WithRequired(e => e.ReferenceUnitPriceProject)
                .HasForeignKey(e => e.ProjectID);

            modelBuilder.Entity<SchoolNotices>()
                .Property(e => e.NoticeTitle)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolNotices>()
                .Property(e => e.NoticeContent)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolNotices>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolOrderInfo>()
                .Property(e => e.TotalMoney)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SchoolOrderInfo>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolRegistry>()
                .HasMany(e => e.SchoolCatalogInit)
                .WithRequired(e => e.SchoolRegistry)
                .HasForeignKey(e => e.SchoolID);

            modelBuilder.Entity<SchoolRegistry>()
                .HasMany(e => e.SchoolYearFilesRegistry)
                .WithRequired(e => e.SchoolRegistry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SchoolYearFilesRegistry>()
                .Property(e => e.ContainedGrades)
                .IsUnicode(false);

            modelBuilder.Entity<SchoolYearFilesRegistry>()
                .Property(e => e.ApproveQuota)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SchoolYearFilesRegistry>()
                .Property(e => e.MaxQuota)
                .HasPrecision(19, 4);

            modelBuilder.Entity<StandardSchoolClassifications>()
                .HasMany(e => e.EquipmentCatalogs)
                .WithRequired(e => e.StandardSchoolClassifications)
                .HasForeignKey(e => e.SchoolClassificationID);

            modelBuilder.Entity<StandardSchoolClassifications>()
                .HasMany(e => e.EquipmentStandardDimensions)
                .WithRequired(e => e.StandardSchoolClassifications)
                .HasForeignKey(e => e.SchoolClassificationID);

            modelBuilder.Entity<StandardSchoolClassifications>()
                .HasMany(e => e.OperationLog)
                .WithRequired(e => e.StandardSchoolClassifications)
                .HasForeignKey(e => e.SchoolClassificationID);

            modelBuilder.Entity<StandardVersions>()
                .HasMany(e => e.EducationBureauFilesControl)
                .WithRequired(e => e.StandardVersions)
                .HasForeignKey(e => e.StandardVersionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StandardVersions>()
                .HasMany(e => e.StandardSchoolClassifications)
                .WithRequired(e => e.StandardVersions)
                .HasForeignKey(e => e.VersionID);

            modelBuilder.Entity<VW_Category>()
                .Property(e => e.RegionCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VW_Experiment>()
                .Property(e => e.RegionCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VW_ExperimentCategory>()
                .Property(e => e.RegionCode)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
