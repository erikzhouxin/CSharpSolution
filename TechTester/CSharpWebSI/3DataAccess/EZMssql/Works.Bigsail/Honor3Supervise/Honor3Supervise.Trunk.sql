USE [Honor4]
GO
/****** Object:  Table [dbo].[StandardVersions]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[StandardVersions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Version] [nvarchar](50) NOT NULL,
	[IsCurrent] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Memo] [nvarchar](max) NULL,
	CONSTRAINT [PK_StandardVersions] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [IX_StandardVersions_Version] UNIQUE ([Version] ASC)
)
GO
/****** Object:  Table [dbo].[StandardSchoolClassifications]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[StandardSchoolClassifications](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VersionID] [int] NOT NULL,
	[SchoolType] [nvarchar](10) NOT NULL,
	CONSTRAINT [PK_StandardSchoolClassifications] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_StandardSchoolClassifications_StandardVersions] FOREIGN KEY([VersionID]) REFERENCES [dbo].[StandardVersions] ([ID]) ON UPDATE CASCADE ON DELETE CASCADE
)
GO
/****** Object:  Table [dbo].[EquipmentCatalogs]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[EquipmentCatalogs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SchoolClassificationID] [int] NOT NULL,
	[CatalogName] [nvarchar](50) NOT NULL,
	CONSTRAINT [PK_EquipmentCatalogs] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [IX_EquipmentCatalogs_SchoolClassificationID_CatalogName] UNIQUE([SchoolClassificationID] ASC,[CatalogName] ASC),
	CONSTRAINT [FK_EquipmentCatalogs_StandardSchoolClassifications] FOREIGN KEY([SchoolClassificationID]) REFERENCES [dbo].[StandardSchoolClassifications] ([ID]) ON UPDATE CASCADE ON DELETE CASCADE
)
GO
/****** Object:  Table [dbo].[EquipmentItems]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[EquipmentItems](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EquipmentCatalogID] [int] NOT NULL,
	[Number] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[InternalGroup] [nvarchar](50) NOT NULL,
	[ClassificationAndCodes] [nvarchar](50) NOT NULL,
	[ReferenceStandardCode] [nvarchar](50) NOT NULL,
	[SpecificationAndFunction] [nvarchar](200) NOT NULL,
	[QuantitativeUnit] [nvarchar](10) NOT NULL,
	[Memo] [nvarchar](512) NOT NULL,
	[SequenceNumber] [int] NOT NULL,
	[ReferenceUnitPrice] [money] NOT NULL CONSTRAINT [DF_EquipmentItems_ReferenceUnitPrice]  DEFAULT (0),
	[IsEasyConsume] [bit] NOT NULL CONSTRAINT [DF_EquipmentItems_IsEasyConsume]  DEFAULT ((0)),
	[IsNineYearShared] [bit] NOT NULL CONSTRAINT [DF_EquipmentItems_IsNineYearShared]  DEFAULT ((0)), -- 是否一贯制共享
	CONSTRAINT [PK_EquipmentItems] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [IX_EquipmentItems_EquipmentCatalogID_SequenceNumber] UNIQUE ([EquipmentCatalogID] ASC,[SequenceNumber] ASC),
	CONSTRAINT [FK_EquipmentItems_EquipmentCatalogs] FOREIGN KEY([EquipmentCatalogID]) REFERENCES [dbo].[EquipmentCatalogs] ([ID]) ON UPDATE CASCADE ON DELETE CASCADE
)
GO
/****** Object:  Table [dbo].[ReferenceUnitPriceProject]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[ReferenceUnitPriceProject](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StandardVersionsID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[UserDefined] [bit] NOT NULL,
	[FromRegionCode] [char](6) NOT NULL,
	[FromRegionName] [nvarchar](50) NOT NULL,
	[Rating] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[RevisionLog] [nvarchar](max) NOT NULL,
	CONSTRAINT [PK_ReferenceUnitPriceProject] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [IX_ReferenceUnitPriceProject_StandardVersionsID_Name] UNIQUE ([StandardVersionsID] ASC,[Name] ASC),
	CONSTRAINT [FK_ReferenceUnitPriceProject_StandardVersions] FOREIGN KEY([StandardVersionsID]) REFERENCES [dbo].[StandardVersions] ([ID]) ON UPDATE CASCADE ON DELETE CASCADE
)
GO
/****** Object:  Table [dbo].[EquipmentReferenceUnitPrice]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[EquipmentReferenceUnitPrice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[EquipmentItemID] [int] NOT NULL,
	[ReferenceUnitPrice] [money] NOT NULL,
	CONSTRAINT [PK_EquipmentReferenceUnitPrice] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [IX_EquipmentReferenceUnitPrice_ProjectID_EquipmentItemID] UNIQUE ([ProjectID] ASC,[EquipmentItemID] ASC),
	CONSTRAINT [FK_EquipmentReferenceUnitPrice_ReferenceUnitPriceProject] FOREIGN KEY([ProjectID]) REFERENCES [dbo].[ReferenceUnitPriceProject] ([ID]) ON UPDATE CASCADE ON DELETE CASCADE
)
GO
/****** Object:  Table [dbo].[EquipmentStandardDimensions]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[EquipmentStandardDimensions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SchoolClassificationID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ClassTotalLeft] [int] NOT NULL,
	[ClassTotalRight] [int] NOT NULL,
	[EquipmentStandard] [nvarchar](10) NOT NULL,
	CONSTRAINT [PK_EquipmentStandardDimensions] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [IX_EquipmentStandardDimensions_Name] UNIQUE ([Name] ASC),
	CONSTRAINT [IX_EquipmentStandardDimensions_SchoolClassificationID_ClassTotalLeft_Right_Standard] UNIQUE ([SchoolClassificationID] ASC,[ClassTotalLeft] ASC,[ClassTotalRight] ASC,[EquipmentStandard] ASC),
	CONSTRAINT [FK_EquipmentStandardDimensions_StandardSchoolClassifications] FOREIGN KEY([SchoolClassificationID]) REFERENCES [dbo].[StandardSchoolClassifications] ([ID]) ON UPDATE CASCADE ON DELETE CASCADE
)
GO
/****** Object:  Table [dbo].[CatalogDimensionRelation]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[CatalogDimensionRelation](
	[CatalogId] [int] NOT NULL,
	[DimensionId] [int] NOT NULL,
	[Formula] [nvarchar](50) NULL,
	[IsBasic] [bit] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	CONSTRAINT [PK_CatalogDimensionRelation] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [IX_CatalogDimensionRelation_CatalogID_DimensionID] UNIQUE ([CatalogId] ASC,[DimensionId] ASC),
	CONSTRAINT [FK_CatalogDimensionRelation_EquipmentCatalogs] FOREIGN KEY([CatalogId]) REFERENCES [dbo].[EquipmentCatalogs] ([ID]) ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT [FK_CatalogDimensionRelation_EquipmentStandardDimensions] FOREIGN KEY([DimensionId]) REFERENCES [dbo].[EquipmentStandardDimensions] ([ID])
)
GO
/****** Object:  Table [dbo].[EquipmentStandardRequirements]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[EquipmentStandardRequirements](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EquipmentItemID] [int] NOT NULL,
	[DimensionID] [int] NOT NULL,
	[IsOptional] [bit] NOT NULL,
	[RequirementQuantity] [bit] NOT NULL,
	[NumberType] [nvarchar](10) NOT NULL,
	[Value1] [float] NOT NULL,
	[Value2] [float] NOT NULL,
	CONSTRAINT [PK_EquipmentStandardRequirements] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [IX_EquipmentStandardRequirements_EquipmentItemID_DimensionID] UNIQUE ([EquipmentItemID] ASC,[DimensionID] ASC),
	CONSTRAINT [FK_EquipmentStandardRequirements_EquipmentItems] FOREIGN KEY([EquipmentItemID]) REFERENCES [dbo].[EquipmentItems] ([ID]),
	CONSTRAINT [FK_EquipmentStandardRequirements_EquipmentStandardDimensions] FOREIGN KEY([DimensionID]) REFERENCES [dbo].[EquipmentStandardDimensions] ([ID]) ON UPDATE CASCADE ON DELETE CASCADE
)
GO
/****** Object:  Table [dbo].[GroupingExperimentEquipment]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[GroupingExperimentEquipment](
	[EquipmentItemID] [int] NOT NULL,
	[LowStandardGroupingPeopleNumber] [float] NOT NULL CONSTRAINT [DF_GroupingExperimentEquipment_LowStandardGroupingPeopleNumber]  DEFAULT ((0)),
	[HighStandardGroupingPeopleNumber] [float] NOT NULL CONSTRAINT [DF_GroupingExperimentEquipment_HighStandardGroupingPeopleNumber]  DEFAULT ((0)),
	[SmallSchoolGroupingPeopleNumber] [float] NOT NULL CONSTRAINT [DF_GroupingExperimentEquipment_SmallSchoolGroupingPeopleNumber]  DEFAULT ((1)),
	[TeachSchoolGroupingPeopleNumber] [float] NOT NULL CONSTRAINT [DF_GroupingExperimentEquipment_TeachSchoolGroupingPeopleNumber]  DEFAULT ((1)),
	CONSTRAINT [PK_GroupingExperimentEquipment] PRIMARY KEY CLUSTERED ([EquipmentItemID] ASC),
	CONSTRAINT [FK_GroupingExperimentEquipment_EquipmentItems] FOREIGN KEY([EquipmentItemID]) REFERENCES [dbo].[EquipmentItems] ([ID]) ON UPDATE CASCADE ON DELETE CASCADE
)
GO
/****** Object:  Table [dbo].[OperationLog]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[OperationLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OperationTime] [datetime] NOT NULL,
	[OperationType] [int] NOT NULL,
	[Range] [nvarchar](50) NOT NULL,
	[ItemId] [int] NOT NULL,
	[OtherInfo] [nvarchar](2000) NULL,
	[ProcessTime] [datetime] NULL,
	[SchoolClassificationID] [int] NOT NULL,
	[ParentId] [int] NOT NULL,
	CONSTRAINT [PK_OperationLog] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_OperationLog_StandardSchoolClassifications] FOREIGN KEY([SchoolClassificationID]) REFERENCES [dbo].[StandardSchoolClassifications] ([ID]) ON UPDATE CASCADE ON DELETE CASCADE
)
GO
/****** Object:  Table [dbo].[CommandInfo]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[CommandInfo](
	[CommandId] [int] IDENTITY(1,1) NOT NULL,
	[CommandType] [varchar](200) NOT NULL,
	[CommandParams] [varchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[ExecuteTime] [datetime] NULL,
	CONSTRAINT [PK_CommandInfo] PRIMARY KEY CLUSTERED ([CommandId] ASC)
)
GO
/****** Object:  Table [dbo].[BookEditions]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[BookEditions](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[DisplayName] [nvarchar](64) NOT NULL,
	[Publisher] [nvarchar](128) NOT NULL,
	[PublishDate] [datetime] NOT NULL,
	[Memo] [nvarchar](512) NULL,
	CONSTRAINT [PK_BookEditions] PRIMARY KEY CLUSTERED ([ID] ASC)
)
GO
/****** Object:  Table [dbo].[ExperimentItems]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[ExperimentItems](
	[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_ExperimentItems_ID]  DEFAULT (NEWID()),
	[CatalogID] [int] NOT NULL,
	[Grade] [int] NOT NULL,
	[EditionId] [int] NOT NULL,
	[IsLastTerm] [bit] NOT NULL,
	[Sequence] [int] NULL,
	[Chapter] [nvarchar](64) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[RequiredEquipments] [nvarchar](max) NULL,
	[IsDemonstration] [bit] NOT NULL,
	[ExperimentType] [nvarchar](10) NULL,
	[MustBeDone] [bit] NOT NULL,
	[Remark] [nvarchar](512) NULL,
	CONSTRAINT [PK_ExperimentItems] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_ExperimentItems_BookEditions] FOREIGN KEY([EditionId]) REFERENCES [dbo].[BookEditions] ([ID]),
	CONSTRAINT [FK_ExperimentItems_EquipmentCatalogs] FOREIGN KEY([CatalogID]) REFERENCES [dbo].[EquipmentCatalogs] ([ID]) ON UPDATE CASCADE ON DELETE CASCADE
)
GO
/****** Object:  Table [dbo].[SchoolNotices]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[SchoolNotices](
	[NoticeID] [int] IDENTITY(1,1) NOT NULL,
	[NoticeTitle] [varchar](256) NOT NULL,
	[NoticeContent] [varchar](max) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Remark] [varchar](1024) NULL,
	CONSTRAINT [PK_SchoolNotices] PRIMARY KEY CLUSTERED ([NoticeID] ASC)
)
GO
/****** Object:  Table [dbo].[EducationBureauRegistry]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[EducationBureauRegistry](
	[ID] [uniqueidentifier] NOT NULL,
	[RegisteredName] [nvarchar](50) NOT NULL,
	[RegionCode] [char](6) NOT NULL,
	[RegionName] [nvarchar](50) NOT NULL,
	[LevelType] [nvarchar](10) NOT NULL,
	[State] [nvarchar](50) NOT NULL CONSTRAINT [DF_EducationBureaus_Enabled]  DEFAULT ((1)),
	[Memo] [nvarchar](max) NULL,
	[CreateDate] [datetime] NOT NULL,
	CONSTRAINT [PK_EducationBureaus] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [IX_EducationBureauRegistry_RegionCode] UNIQUE ([RegionCode] ASC)
)
GO
/****** Object:  Table [dbo].[DatabaseDistribution]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[DatabaseDistribution](
	[EducationBureauID] [uniqueidentifier] NOT NULL,
	[ServerType] [nvarchar](64) NOT NULL,
	[ServerName] [nvarchar](1024) NOT NULL,
	[DbName] [nvarchar](64) NOT NULL CONSTRAINT [DF_DatabaseDistribution_DbName] DEFAULT ('Honor3School'),
	[AuthenticationType] [nvarchar](64) NOT NULL,
	[Account] [nvarchar](64) NOT NULL,
	[Password] [varchar](64) NOT NULL,
	CONSTRAINT [PK_DatabaseDistribution] PRIMARY KEY CLUSTERED ([EducationBureauID] ASC),
	CONSTRAINT [FK_DatabaseDistribution_EducationBureauRegistry] FOREIGN KEY([EducationBureauID]) REFERENCES [dbo].[EducationBureauRegistry] ([ID]) ON UPDATE CASCADE ON DELETE CASCADE
)
GO
/****** Object:  Table [dbo].[EducationBureauUsers]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[EducationBureauUsers](
	[ID] [uniqueidentifier] NOT NULL,
	[EducationBureauID] [uniqueidentifier] NOT NULL,
	[Account] [nvarchar](64) NOT NULL,
	[Salt] [nvarchar](64) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[RoleType] [int] NOT NULL CONSTRAINT [DF_EducationBureauUsers_RoleType]  DEFAULT ((1)),
	[UserName] [nvarchar](64) NOT NULL CONSTRAINT [DF_EducationBureauUsers_UserName]  DEFAULT (''),
	[Phone] [nvarchar](32) NOT NULL CONSTRAINT [DF_EducationBureauUsers_Phone]  DEFAULT (''),
	[CreateDate] [datetime] NOT NULL,
	[Permissions] [nvarchar](max) NOT NULL CONSTRAINT [DF_EducationBureauUsers_Permissions]  DEFAULT (''),
	[Enabled] [bit] NOT NULL CONSTRAINT [DF_EducationBureauUsers_Enabled]  DEFAULT ((1)),
	[Memo] [nvarchar](1024) NULL,
	CONSTRAINT [PK_EducationBureauUsers] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [IX_EducationBureauUsers_EducationBureauID_Account] UNIQUE ([EducationBureauID] ASC,[Account] ASC),
	CONSTRAINT [FK_EducationBureauUsers_EducationBureaus] FOREIGN KEY([EducationBureauID]) REFERENCES [dbo].[EducationBureauRegistry] ([ID]) ON UPDATE CASCADE ON DELETE CASCADE
)
GO
/****** Object:  Table [dbo].[EducationUsersSchoolRange]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[EducationUsersSchoolRange](
	[UserID] [uniqueidentifier] NOT NULL,
	[RangeID] [int] NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[SchoolCodes] [nvarchar](max) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[Memo] [nvarchar](1024) NULL,
	CONSTRAINT [PK_EducationUsersSchoolRange] PRIMARY KEY CLUSTERED ([UserID] ASC),
	CONSTRAINT [IX_EducationUsersSchoolRange_RangeID] UNIQUE ([RangeID] ASC),
	CONSTRAINT [FK_EducationUsersSchoolRange_EducationBureauUsers] FOREIGN KEY([UserID]) REFERENCES [dbo].[EducationBureauUsers] ([ID]) ON UPDATE CASCADE ON DELETE CASCADE
)
GO
/****** Object:  Table [dbo].[EducationBureauFilesControl]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[EducationBureauFilesControl](
	[ID] [uniqueidentifier] NOT NULL,
	[EducationBureauID] [uniqueidentifier] NOT NULL,
	[Year] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Linkman] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[SchoolFileLocked] [bit] NOT NULL,
	[AllowSchoolCreateFiles] [bit] NOT NULL,
	[PrimarySchoolEquipmentStandard] [nvarchar](10) NOT NULL,
	[JuniorSchoolEquipmentStandard] [nvarchar](10) NOT NULL,
	[StandardVersionID] [int] NOT NULL,
	[PrimaryPresentationGroupingExperimentStandard] [nvarchar](50) NOT NULL CONSTRAINT [DF_EducationBureauFilesControl_PrimaryPresentationGroupingExperimentStandard]  DEFAULT (''),
	[JuniorPresentationGroupingExperimentStandard] [nvarchar](50) NOT NULL CONSTRAINT [DF_EducationBureauFilesControl_JuniorPresentationGroupingExperimentStandard]  DEFAULT (''),
	[PrimarySchoolPermission] [nvarchar](200) NULL,
	[JuniorSchoolPermission] [nvarchar](200) NULL,
	[ReferenceUnitPriceProjectId] [int] NOT NULL,
	[IsExperimentSettingEnabled] [bit] NOT NULL CONSTRAINT [DF_EducationBureauFilesControl_IsExperimentSettingEnabled]  DEFAULT ((0)),
	[StandardDescription] [int] NOT NULL CONSTRAINT [DF_EducationBureauFilesControl_StandardDescription]  DEFAULT ((0)),
	CONSTRAINT [PK_EducationBureauFileControl] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [IX_EducationBureauFilesControl_EducationBureauID_Year] UNIQUE ([EducationBureauID] ASC,[Year] ASC),
	CONSTRAINT [FK_EducationBureauFileControl_EducationBureauRegistry] FOREIGN KEY([EducationBureauID]) REFERENCES [dbo].[EducationBureauRegistry] ([ID]) ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT [FK_EducationBureauFilesControl_ReferenceUnitPriceProject] FOREIGN KEY([ReferenceUnitPriceProjectId]) REFERENCES [dbo].[ReferenceUnitPriceProject] ([ID]),
	CONSTRAINT [FK_EducationBureauFilesControl_StandardVersions] FOREIGN KEY([StandardVersionID]) REFERENCES [dbo].[StandardVersions] ([ID])
)
GO
/****** Object:  Table [dbo].[SchoolRegistry]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[SchoolRegistry](
	[ID] [uniqueidentifier] NOT NULL,
	[EducationBureauID] [uniqueidentifier] NOT NULL,
	[SchoolCode] [nvarchar](50) NOT NULL,
	[RegisteredName] [nvarchar](50) NOT NULL,
	[SchoolType] [nvarchar](20) NOT NULL,
	[State] [nvarchar](50) NOT NULL CONSTRAINT [DF_SchoolRegistry_State]  DEFAULT ((1)),
	[Memo] [nvarchar](max) NULL,
	[CreateDate] [datetime] NOT NULL,
	[IsNineYearSchool] [bit] NOT NULL CONSTRAINT [DF_SchoolRegistry_IsNineYearSchool]  DEFAULT ((0)),
	[ValideYearRenew] [int] NOT NULL CONSTRAINT [DF_SchoolRegistry_ValideYearRenew]  DEFAULT ((2014)),
	[NoticeID] [int] NULL,
	[ValidType] [nvarchar](64) NULL,
	[ValidTime] [datetime] NULL,
	[RenewTime] [datetime] NULL,
	[CombinationType] [int] NOT NULL CONSTRAINT [DF_SchoolRegistry_CombinationType]  DEFAULT ((1601)),
	[RelationCode] [nvarchar](50) NOT NULL, -- 一贯制关联代码
	CONSTRAINT [PK_Schools] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [IX_SchoolRegistry_SchoolCode] UNIQUE ([SchoolCode] ASC),
	CONSTRAINT [FK_SchoolRegistry_SchoolNotices] FOREIGN KEY([NoticeID]) REFERENCES [dbo].[SchoolNotices] ([NoticeID]),
	CONSTRAINT [FK_Schools_EducationBureaus] FOREIGN KEY([EducationBureauID]) REFERENCES [dbo].[EducationBureauRegistry] ([ID]) ON UPDATE CASCADE ON DELETE CASCADE
)
GO
/****** Object:  Table [dbo].[SchoolUsers]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[SchoolUsers](
	[ID] [uniqueidentifier] NOT NULL,
	[SchoolRegistryID] [uniqueidentifier] NOT NULL,
	[Account] [nvarchar](50) NOT NULL,
	[Salt] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[Permissions] [nvarchar](max) NOT NULL CONSTRAINT [DF_SchoolUsers_Permissions]  DEFAULT (''),
	[CreateDate] [datetime] NOT NULL,
	[Enabled] [bit] NOT NULL CONSTRAINT [DF_SchoolUsers_Enabled]  DEFAULT ((1)),
	CONSTRAINT [PK_SchoolUsers] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [IX_SchoolUsers_SchoolRegistryID_Account] UNIQUE ([SchoolRegistryID] ASC,[Account] ASC),
	CONSTRAINT [FK_SchoolUsers_Schools] FOREIGN KEY([SchoolRegistryID]) REFERENCES [dbo].[SchoolRegistry] ([ID]) ON UPDATE CASCADE ON DELETE CASCADE
)
GO
/****** Object:  Table [dbo].[SchoolYearFilesRegistry]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[SchoolYearFilesRegistry](
	[ID] [uniqueidentifier] NOT NULL,
	[FilesControlID] [uniqueidentifier] NOT NULL,
	[SchoolRegistryID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[SponsorType] [nvarchar](20) NOT NULL,
	[BelongType] [nvarchar](20) NOT NULL,
	[Phone] [nvarchar](50) NULL,
	[Linkman] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[ClassTotal] [int] NOT NULL,
	[SchoolNetworkModel] [nvarchar](50) NOT NULL,
	[NumberOfStudents] [int] NOT NULL,
	[HealthRoomSettings] [nvarchar](50) NOT NULL,
	[IntegratedPracticeActivity] [nvarchar](200) NOT NULL,
	[EquipmentStandardDimensionID] [int] NOT NULL,
	[MaxNumberOfClass] [int] NOT NULL CONSTRAINT [DF_SchoolYearFilesRegistry_MaxNumberOfClass]  DEFAULT ((0)),
	[AnotherPartNineYearSchoolClassTotal] [int] NOT NULL CONSTRAINT [DF_SchoolYearFilesRegistry_AnotherPartNineYearSchoolClassTotal]  DEFAULT ((0)),
	[BoardingType] [nvarchar](20) NOT NULL CONSTRAINT [DF_SchoolYearFilesRegistry_BoardingType]  DEFAULT ('无寄宿条件'),
	[NumberOfBoardingStudents] [int] NOT NULL CONSTRAINT [DF_SchoolYearFilesRegistry_NumberOfBoardingStudents]  DEFAULT ((0)),
	[NumberOfCanOperateComputerStudents] [int] NOT NULL CONSTRAINT [DF_SchoolYearFilesRegistry_NumberOfCanOperateComputerStudents]  DEFAULT ((0)),
	[IsSmallScale] [bit] NOT NULL CONSTRAINT [DF_SchoolYearFilesRegistry_IsSmallScale]  DEFAULT ((0)),
	[ContainedGrades] [varchar](20) NOT NULL CONSTRAINT [DF_SchoolYearFilesRegistry_ContainedGrades]  DEFAULT (''),
	[SchoolDescription] [int] NOT NULL CONSTRAINT [DF_SchoolYearFilesRegistry_SchoolDescription]  DEFAULT ((0)),
	[ApproveQuota] [money] NOT NULL CONSTRAINT [DF_SchoolYearFilesRegistry_ApproveQuota]  DEFAULT ((1000)),
	[MaxQuota] [money] NOT NULL CONSTRAINT [DF_SchoolYearFilesRegistry_MaxQuota]  DEFAULT ((2000)),
	[Location] [int] NOT NULL CONSTRAINT [DF_SchoolYearFilesRegistry_Location]  DEFAULT ((0)),
	[ConversionType] [int] NOT NULL CONSTRAINT [DF_SchoolYearFilesRegistry_ConversionType]  DEFAULT ((0)),
	[SeniorClassTotal] [int] NOT NULL CONSTRAINT [DF_SchoolYearFilesRegistry_SeniorClassTotal]  DEFAULT ((0)),
	[SeniorStudents] [int] NOT NULL CONSTRAINT [DF_SchoolYearFilesRegistry_SeniorStudents]  DEFAULT ((0)),
	[SeniorBoardingStudents] [int] NOT NULL CONSTRAINT [DF_SchoolYearFilesRegistry_SeniorBoardingStudents]  DEFAULT ((0)),
	[StandardComputeMode] [int] NOT NULL CONSTRAINT [DF_SchoolYearFilesRegistry_StandardComputeMode]  DEFAULT ((2001)),
	[IsLocked] [bit] NOT NULL,
	[LockedCatalogs] [nvarchar](max) NOT NULL,
	[LockedTime] [datetime] NOT NULL,
	CONSTRAINT [PK_SchoolHistoryFiles] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [IX_SchoolYearFilesRegistry_FilesControlID_SchoolRegistryID] UNIQUE ([FilesControlID] ASC,[SchoolRegistryID] ASC),
	CONSTRAINT [FK_SchoolHistoryFiles_SchoolRegistry] FOREIGN KEY([SchoolRegistryID]) REFERENCES [dbo].[SchoolRegistry] ([ID]),
	CONSTRAINT [FK_SchoolHistoryFiles_EducationBureauFileControl] FOREIGN KEY([FilesControlID]) REFERENCES [dbo].[EducationBureauFilesControl] ([ID]) ON UPDATE CASCADE ON DELETE CASCADE
)
GO
/****** Object:  Table [dbo].[EducationBureau_ExperimentSettings]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[EducationBureau_ExperimentSettings](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EducationFileID] [uniqueidentifier] NOT NULL,
	[CatalogID] [int] NOT NULL,
	[Grade] [int] NOT NULL,
	[BookEditionId] [int] NOT NULL,
	CONSTRAINT [PK_EducationBureau_ExperimentSettings] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_EducationBureau_ExperimentSettings_BookEditions] FOREIGN KEY([BookEditionId]) REFERENCES [dbo].[BookEditions] ([ID]) ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT [FK_EducationBureau_ExperimentSettings_EducationBureauFilesControl] FOREIGN KEY([EducationFileID]) REFERENCES [dbo].[EducationBureauFilesControl] ([ID]) ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT [FK_EducationBureau_ExperimentSettings_EquipmentCatalogs] FOREIGN KEY([CatalogID]) REFERENCES [dbo].[EquipmentCatalogs] ([ID])
)
GO
/****** Object:  Table [dbo].[EducationLockUnlockOperLog]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[EducationLockUnlockOperLog](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[RelatID] [nvarchar](64) NOT NULL,
	[OperID] [nvarchar](64) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Reason] [nvarchar](512) NOT NULL,
	[SchoolYear] [int] NOT NULL,
	[Memo] [nvarchar](1024) NOT NULL,
	[Time] [datetime] NOT NULL,
	[Type] [int] NOT NULL,
	CONSTRAINT [PK_EducationLockUnlockOperLog] PRIMARY KEY CLUSTERED ([ID] ASC)
)
GO
/****** Object:  Table [dbo].[SchoolCatalogInit]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[SchoolCatalogInit](
	[SchoolID] [uniqueidentifier] NOT NULL,
	[CatalogID] [int] NOT NULL,
	[IsInit] [bit] NOT NULL,
	[IsInitAllowed] [bit] NOT NULL,
	[IsFirstYear] [bit] NOT NULL,
	[Memo] [nvarchar](64) NULL,
	CONSTRAINT [PK_SchoolCatalogInit] PRIMARY KEY CLUSTERED ([SchoolID] ASC,[CatalogID] ASC),
	CONSTRAINT [FK_SchoolCatalogInit_EquipmentCatalogs] FOREIGN KEY([CatalogID]) REFERENCES [dbo].[EquipmentCatalogs] ([ID]),
	CONSTRAINT [FK_SchoolCatalogInit_SchoolRegistry] FOREIGN KEY([SchoolID]) REFERENCES [dbo].[SchoolRegistry] ([ID]) ON UPDATE CASCADE ON DELETE CASCADE
)
GO
/****** Object:  Table [dbo].[SchoolOrderInfo]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[SchoolOrderInfo](
	[OrderID] [uniqueidentifier] NOT NULL,
	[SchoolRegistryID] [uniqueidentifier] NOT NULL,
	[SchoolYear] [int] NOT NULL,
	[RemittorName] [nvarchar](256) NULL,
	[RemittorEmail] [nvarchar](256) NULL,
	[TotalMoney] [money] NOT NULL,
	[PayType] [nvarchar](64) NOT NULL,
	[PayBank] [nvarchar](128) NULL,
	[Subject] [nvarchar](128) NOT NULL,
	[SubjectDescr] [nvarchar](256) NULL,
	[OrderStatus] [nvarchar](32) NOT NULL,
	[TradeID] [nvarchar](128) NULL,
	[TradeStatus] [nvarchar](32) NULL,
	[ClientIP] [nvarchar](256) NULL,
	[ClientTimestamp] [nvarchar](128) NULL,
	[OperTime] [datetime] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[URLData] [nvarchar](max) NULL,
	[UserName] [nvarchar](64) NOT NULL,
	[TeacherName] [nvarchar](64) NOT NULL,
	[Remark] [varchar](max) NULL,
	CONSTRAINT [PK_SchoolOrderInfo] PRIMARY KEY CLUSTERED ([OrderID] ASC),
	CONSTRAINT [FK_SchoolOrderInfo_SchoolRegistry] FOREIGN KEY([SchoolRegistryID]) REFERENCES [dbo].[SchoolRegistry] ([ID]) ON UPDATE CASCADE ON DELETE CASCADE
)
GO
/****** Object:  Table [dbo].[SchoolRenewFee]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[SchoolRenewFee](
	[SchoolRegistryID] [uniqueidentifier] NOT NULL,
	[SchoolYear] [int] NOT NULL,
	[UnitPrice] [int] NOT NULL,
	[RemittorName] [nvarchar](64) NULL,
	[RemittorUnit] [nvarchar](256) NULL,
	[RemittorPhone] [nvarchar](32) NULL,
	[RemitMoney] [int] NULL,
	[RemitType] [nvarchar](128) NULL,
	[RemitTime] [datetime] NULL,
	[RenewState] [nvarchar](32) NOT NULL,
	[ApproveTime] [datetime] NULL,
	[Remark] [nvarchar](1024) NULL,
	CONSTRAINT [PK_SchoolRenewFee] PRIMARY KEY CLUSTERED ([SchoolRegistryID] ASC,[SchoolYear] DESC),
	CONSTRAINT [FK_SchoolRenewFee_SchoolRegistry] FOREIGN KEY([SchoolRegistryID]) REFERENCES [dbo].[SchoolRegistry] ([ID]) ON UPDATE CASCADE ON DELETE CASCADE
)
GO
/****** Object:  Table [dbo].[SchoolUserOperInfo]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[SchoolUserOperInfo](
	[SchoolYearFileID] [uniqueidentifier] NOT NULL,
	[SchoolCode] [nvarchar](50) NOT NULL,
	[Account] [nvarchar](256) NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[OperContent] [nvarchar](max) NOT NULL,
	[OperIP] [nvarchar](64) NOT NULL,
	[RoleType] [int] NOT NULL,
	[OperType] [int] NOT NULL,
	[OperTime] [datetime] NOT NULL,
	CONSTRAINT [FK_SchoolUserOperInfo_SchoolRegistry] FOREIGN KEY([SchoolCode]) REFERENCES [dbo].[SchoolRegistry] ([SchoolCode]) ON UPDATE CASCADE ON DELETE CASCADE
)
GO
CREATE NONCLUSTERED INDEX [IX_SchoolUserOperInfo_SchoolCode] ON [dbo].[SchoolUserOperInfo]
(
	[SchoolCode] ASC
)
GO
/****** Object:  Table [dbo].[SysSettingUser]    Script Date: 2017/6/6 16:29:46 ******/
CREATE TABLE [dbo].[SysSettingUser](
	[Account] [nvarchar](64) NOT NULL,
	[UserName] [nvarchar](64) NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[Salt] [nvarchar](128) NOT NULL,
	[Role] [nvarchar](1024) NOT NULL,
	[Memo] [nvarchar](1024) NULL,
	CONSTRAINT [PK_SysSettingUser] PRIMARY KEY CLUSTERED 
	(
		[Account] ASC
	)
)
GO
/****** Object:  View [dbo].[VW_BookEdition]    Script Date: 2017/6/6 16:29:46 ******/
CREATE VIEW [dbo].[VW_BookEdition]
AS
SELECT DISTINCT 
	dbo.StandardSchoolClassifications.SchoolType, 
	dbo.EquipmentCatalogs.CatalogName, 
	dbo.ExperimentItems.Grade, 
	dbo.BookEditions.Name AS BookEditionName, 
	dbo.BookEditions.ID AS EditionId
FROM
	dbo.BookEditions INNER JOIN
	dbo.ExperimentItems ON dbo.BookEditions.ID = dbo.ExperimentItems.EditionId INNER JOIN
	dbo.EquipmentCatalogs ON dbo.ExperimentItems.CatalogID = dbo.EquipmentCatalogs.ID INNER JOIN
	dbo.StandardSchoolClassifications ON dbo.EquipmentCatalogs.SchoolClassificationID = dbo.StandardSchoolClassifications.ID
GO
/****** Object:  View [dbo].[VW_Experiment]    Script Date: 2017/6/6 16:29:46 ******/
CREATE VIEW [dbo].[VW_Experiment]
AS
SELECT TOP (100) PERCENT
	A.RegionCode, 
	A.Year, 
	A.SchoolType, 
	A.CatalogName, 
	A.CatalogID, 
	A.Grade, 
	A.BookEditionId, 
	B.EditionName, 
	B.ExperimentItemId, 
	B.IsLastTerm, 
	B.Chapter, 
	B.ExperimentName, 
	B.RequiredEquipments, 
	B.IsDemonstration, 
	B.MustBeDone, 
	B.Remark, 
	B.ExperimentType, 
	B.Sequence
FROM
	(SELECT   
		dbo.EducationBureauRegistry.RegionCode, 
		dbo.EducationBureauFilesControl.Year, 
		dbo.StandardSchoolClassifications.SchoolType, 
		dbo.EquipmentCatalogs.CatalogName, 
		dbo.EducationBureau_ExperimentSettings.CatalogID, 
		dbo.EducationBureau_ExperimentSettings.Grade, 
		dbo.EducationBureau_ExperimentSettings.BookEditionId
	FROM      
		dbo.EducationBureauFilesControl INNER JOIN
		dbo.EducationBureauRegistry ON dbo.EducationBureauFilesControl.EducationBureauID = dbo.EducationBureauRegistry.ID INNER JOIN
		dbo.EducationBureau_ExperimentSettings ON dbo.EducationBureauFilesControl.ID = dbo.EducationBureau_ExperimentSettings.EducationFileID INNER JOIN
		dbo.EquipmentCatalogs ON dbo.EducationBureau_ExperimentSettings.CatalogID = dbo.EquipmentCatalogs.ID INNER JOIN
		dbo.StandardSchoolClassifications ON dbo.EquipmentCatalogs.SchoolClassificationID = dbo.StandardSchoolClassifications.ID) AS A INNER JOIN
	(SELECT   
		dbo.BookEditions.Name AS EditionName, 
		dbo.ExperimentItems.ID AS ExperimentItemId, 
		dbo.ExperimentItems.CatalogID, 
		dbo.ExperimentItems.Grade, 
		dbo.ExperimentItems.EditionId, 
		dbo.ExperimentItems.IsLastTerm, 
		dbo.ExperimentItems.Chapter, 
		dbo.ExperimentItems.Name AS ExperimentName, 
		dbo.ExperimentItems.RequiredEquipments, 
		dbo.ExperimentItems.IsDemonstration, 
		dbo.ExperimentItems.ExperimentType, 
		dbo.ExperimentItems.MustBeDone, 
		dbo.ExperimentItems.Remark, 
		dbo.ExperimentItems.Sequence
	FROM 
		dbo.BookEditions INNER JOIN
		dbo.ExperimentItems ON dbo.BookEditions.ID = dbo.ExperimentItems.EditionId) AS B ON A.BookEditionId = B.EditionId AND A.CatalogID = B.CatalogID AND A.Grade = B.Grade
ORDER BY B.Sequence
GO
/****** Object:  View [dbo].[VW_ExperimentCategory]    Script Date: 2017/6/6 16:29:46 ******/
CREATE VIEW [dbo].[VW_ExperimentCategory]
AS
SELECT   
	dbo.EducationBureauRegistry.RegionCode, 
	dbo.EducationBureauFilesControl.Year, 
	dbo.StandardSchoolClassifications.SchoolType, 
	dbo.EquipmentCatalogs.CatalogName, 
	dbo.EquipmentCatalogs.ID AS CategoryId, 
	dbo.EducationBureau_ExperimentSettings.Grade, 
	dbo.EducationBureau_ExperimentSettings.BookEditionId
FROM     
	dbo.EducationBureauFilesControl INNER JOIN
	dbo.EducationBureauRegistry ON dbo.EducationBureauFilesControl.EducationBureauID = dbo.EducationBureauRegistry.ID INNER JOIN
	dbo.StandardSchoolClassifications ON dbo.EducationBureauFilesControl.StandardVersionID = dbo.StandardSchoolClassifications.VersionID INNER JOIN
	dbo.EquipmentCatalogs ON dbo.EquipmentCatalogs.SchoolClassificationID = dbo.StandardSchoolClassifications.ID INNER JOIN 
	dbo.EducationBureau_ExperimentSettings ON dbo.EducationBureauFilesControl.ID = dbo.EducationBureau_ExperimentSettings.EducationFileID AND dbo.EquipmentCatalogs.ID = dbo.EducationBureau_ExperimentSettings.CatalogID
GO
/****** Object:  View [dbo].[VW_Category]]    Script Date: 2017/6/6 16:29:46 ******/
CREATE VIEW [dbo].[VW_Category]
AS
SELECT 
	dbo.EducationBureauRegistry.RegionCode, 
	dbo.EducationBureauFilesControl.Year, 
	dbo.EducationBureauFilesControl.ID AS EducationFileId, 
	dbo.StandardSchoolClassifications.SchoolType, 
	dbo.EquipmentCatalogs.CatalogName, 
	dbo.EquipmentCatalogs.ID AS CategoryId
FROM 
	dbo.EducationBureauFilesControl INNER JOIN
	dbo.EducationBureauRegistry ON dbo.EducationBureauFilesControl.EducationBureauID = dbo.EducationBureauRegistry.ID INNER JOIN
	dbo.StandardSchoolClassifications ON dbo.EducationBureauFilesControl.StandardVersionID = dbo.StandardSchoolClassifications.VersionID INNER JOIN 
	dbo.EquipmentCatalogs ON dbo.EquipmentCatalogs.SchoolClassificationID = dbo.StandardSchoolClassifications.ID
GO
/****** Object:  StoredProcedure [dbo].[PROC_DeleteSchoolFile]    Script Date: 2017/6/6 16:29:46 ******/
CREATE PROCEDURE [dbo].[PROC_DeleteSchoolFile](@schoolCode varchar(32) = '',@schoolYear int = 2000,@result bit = 0 output,@message nvarchar(512) = '执行命令时出错' output)
AS
BEGIN 
DECLARE @schoolYearFileId uniqueidentifier
DECLARE @schoolRegistryId uniqueidentifier
SELECT @schoolYearFileId = SchoolYearFilesRegistry.ID, @schoolRegistryId = SchoolRegistry.ID FROM SchoolYearFilesRegistry INNER JOIN SchoolRegistry ON SchoolRegistry.ID = SchoolYearFilesRegistry.SchoolRegistryID INNER JOIN EducationBureauFilesControl ON EducationBureauFilesControl.ID = SchoolYearFilesRegistry.FilesControlID WHERE SchoolCode = @schoolCode AND Year = @schoolYear
IF @schoolYearFileId IS NULL
BEGIN
	SET @result = 1
	SET @message = '教育局数据库中学校档案已删除'
	RETURN 200
END
DECLARE @maxYear int
SELECT @maxYear = MAX(EducationBureauFilesControl.Year) FROM SchoolYearFilesRegistry INNER JOIN SchoolRegistry ON SchoolRegistry.ID = SchoolYearFilesRegistry.SchoolRegistryID INNER JOIN EducationBureauFilesControl ON EducationBureauFilesControl.ID = SchoolYearFilesRegistry.FilesControlID WHERE SchoolCode = @schoolCode GROUP BY SchoolCode
IF @maxYear != @schoolYear
BEGIN
	SET @result = 0
	SET @message = '您将删除的学年档案不是该校最新学年，最新学年是' + CAST(@maxYear AS varchar) + '-' + CAST((@maxYear + 1) AS varchar) + '学年，请先删除最新学年档案。'
	RETURN 201
END
BEGIN TRANSACTION
DELETE FROM SchoolYearFilesRegistry WHERE ID = @schoolYearFileId
UPDATE SchoolCatalogInit SET IsFirstYear = CASE WHEN ATable.SchoolFileCount > 1 THEN 0 ELSE 1 END FROM SchoolCatalogInit INNER JOIN (SELECT SchoolYearFilesRegistry.SchoolRegistryID SchoolID, COUNT(SchoolYearFilesRegistry.ID) SchoolFileCount FROM SchoolRegistry LEFT JOIN SchoolYearFilesRegistry ON SchoolRegistry.ID = SchoolYearFilesRegistry.SchoolRegistryID WHERE SchoolYearFilesRegistry.SchoolRegistryID = @schoolRegistryId GROUP BY SchoolYearFilesRegistry.SchoolRegistryID) ATable ON ATable.SchoolID = SchoolCatalogInit.SchoolID WHERE SchoolCatalogInit.SchoolID = @schoolRegistryId
COMMIT
	SET @result = 1
	SET @message = '教育局数据库中学校档案已删除'
RETURN 202
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_DeleteSchoolFile_ID]    Script Date: 2017/6/6 16:29:46 ******/
CREATE PROCEDURE [dbo].[PROC_DeleteSchoolFile_ID]
@schoolYearFileId uniqueidentifier,
@result bit = 0 output,
@message nvarchar(512) = '执行命令时出错' output
AS
DECLARE @schoolCode nvarchar
DECLARE @schoolYear int
SELECT @schoolCode = SchoolCode,@schoolYear = Year FROM SchoolYearFilesRegistry INNER JOIN SchoolRegistry ON SchoolRegistry.ID = SchoolYearFilesRegistry.SchoolRegistryID INNER JOIN EducationBureauFilesControl ON EducationBureauFilesControl.ID = SchoolYearFilesRegistry.FilesControlID WHERE SchoolYearFilesRegistry.ID = @schoolYearFileId
RETURN EXEC PROC_DeleteSchoolFile @schoolCode,@schoolYear,@result = @result,@message = @message
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'教材名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BookEditions', @level2type=N'COLUMN',@level2name=N'Name'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'教材显示名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BookEditions', @level2type=N'COLUMN',@level2name=N'DisplayName'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出版社' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BookEditions', @level2type=N'COLUMN',@level2name=N'Publisher'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出版日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BookEditions', @level2type=N'COLUMN',@level2name=N'PublishDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'服务器类型(sql server或mysql)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DatabaseDistribution', @level2type=N'COLUMN',@level2name=N'ServerType'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'服务器名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DatabaseDistribution', @level2type=N'COLUMN',@level2name=N'ServerName'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份认证类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DatabaseDistribution', @level2type=N'COLUMN',@level2name=N'AuthenticationType'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DatabaseDistribution', @level2type=N'COLUMN',@level2name=N'Account'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DatabaseDistribution', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'教育局档案Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureau_ExperimentSettings', @level2type=N'COLUMN',@level2name=N'EducationFileID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'科目Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureau_ExperimentSettings', @level2type=N'COLUMN',@level2name=N'CatalogID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureau_ExperimentSettings', @level2type=N'COLUMN',@level2name=N'Grade'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'教材版本Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureau_ExperimentSettings', @level2type=N'COLUMN',@level2name=N'BookEditionId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'教育局标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauFilesControl', @level2type=N'COLUMN',@level2name=N'EducationBureauID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学年' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauFilesControl', @level2type=N'COLUMN',@level2name=N'Year'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'教育局名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauFilesControl', @level2type=N'COLUMN',@level2name=N'Name'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理员姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauFilesControl', @level2type=N'COLUMN',@level2name=N'Linkman'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电子邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauFilesControl', @level2type=N'COLUMN',@level2name=N'Email'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauFilesControl', @level2type=N'COLUMN',@level2name=N'Phone'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学校档案锁定' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauFilesControl', @level2type=N'COLUMN',@level2name=N'SchoolFileLocked'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'允许学校创建档案' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauFilesControl', @level2type=N'COLUMN',@level2name=N'AllowSchoolCreateFiles'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'小学装备配备标准(一类、二类、' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauFilesControl', @level2type=N'COLUMN',@level2name=N'PrimarySchoolEquipmentStandard'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'初中装备配备标准(一类、二类、' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauFilesControl', @level2type=N'COLUMN',@level2name=N'JuniorSchoolEquipmentStandard'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标准的版本标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauFilesControl', @level2type=N'COLUMN',@level2name=N'StandardVersionID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'小学演示分组实验仪器配备标准(' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauFilesControl', @level2type=N'COLUMN',@level2name=N'PrimaryPresentationGroupingExperimentStandard'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'初中演示分组实验仪器配备标准(' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauFilesControl', @level2type=N'COLUMN',@level2name=N'JuniorPresentationGroupingExperimentStandard'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实验设置是否有效' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauFilesControl', @level2type=N'COLUMN',@level2name=N'IsExperimentSettingEnabled'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'教育局标准描述,如山区标准,川区标准等' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauFilesControl', @level2type=N'COLUMN',@level2name=N'StandardDescription'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'注册名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauRegistry', @level2type=N'COLUMN',@level2name=N'RegisteredName'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属区域代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauRegistry', @level2type=N'COLUMN',@level2name=N'RegionCode'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属区域名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauRegistry', @level2type=N'COLUMN',@level2name=N'RegionName'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属区域级别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauRegistry', @level2type=N'COLUMN',@level2name=N'LevelType'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态(启用、停用)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauRegistry', @level2type=N'COLUMN',@level2name=N'State'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauRegistry', @level2type=N'COLUMN',@level2name=N'Memo'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauRegistry', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauUsers', @level2type=N'COLUMN',@level2name=N'Account'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'盐值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauUsers', @level2type=N'COLUMN',@level2name=N'Salt'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauUsers', @level2type=N'COLUMN',@level2name=N'Password'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauUsers', @level2type=N'COLUMN',@level2name=N'CreateDate'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EducationBureauUsers', @level2type=N'COLUMN',@level2name=N'Enabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学校分类标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentCatalogs', @level2type=N'COLUMN',@level2name=N'SchoolClassificationID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'目录名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentCatalogs', @level2type=N'COLUMN',@level2name=N'CatalogName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'装备目录标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentItems', @level2type=N'COLUMN',@level2name=N'EquipmentCatalogID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentItems', @level2type=N'COLUMN',@level2name=N'Number'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'项目名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentItems', @level2type=N'COLUMN',@level2name=N'Name'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内部分组' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentItems', @level2type=N'COLUMN',@level2name=N'InternalGroup'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类与代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentItems', @level2type=N'COLUMN',@level2name=N'ClassificationAndCodes'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'引用标准' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentItems', @level2type=N'COLUMN',@level2name=N'ReferenceStandardCode'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'规格型号功能' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentItems', @level2type=N'COLUMN',@level2name=N'SpecificationAndFunction'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'量化单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentItems', @level2type=N'COLUMN',@level2name=N'QuantitativeUnit'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentItems', @level2type=N'COLUMN',@level2name=N'Memo'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'顺序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentItems', @level2type=N'COLUMN',@level2name=N'SequenceNumber'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参考单价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentItems', @level2type=N'COLUMN',@level2name=N'ReferenceUnitPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentReferenceUnitPrice', @level2type=N'COLUMN',@level2name=N'ID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'方案标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentReferenceUnitPrice', @level2type=N'COLUMN',@level2name=N'ProjectID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'装备项目标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentReferenceUnitPrice', @level2type=N'COLUMN',@level2name=N'EquipmentItemID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参考单价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentReferenceUnitPrice', @level2type=N'COLUMN',@level2name=N'ReferenceUnitPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学校分类标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentStandardDimensions', @level2type=N'COLUMN',@level2name=N'SchoolClassificationID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'维度名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentStandardDimensions', @level2type=N'COLUMN',@level2name=N'Name'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总班数区间左值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentStandardDimensions', @level2type=N'COLUMN',@level2name=N'ClassTotalLeft'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总班数区间右值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentStandardDimensions', @level2type=N'COLUMN',@level2name=N'ClassTotalRight'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'装备配备标准(一类、二类、三类)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentStandardDimensions', @level2type=N'COLUMN',@level2name=N'EquipmentStandard'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'装备项目标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentStandardRequirements', @level2type=N'COLUMN',@level2name=N'EquipmentItemID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标准要求的维度标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentStandardRequirements', @level2type=N'COLUMN',@level2name=N'DimensionID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否选配' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentStandardRequirements', @level2type=N'COLUMN',@level2name=N'IsOptional'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'要求数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentStandardRequirements', @level2type=N'COLUMN',@level2name=N'RequirementQuantity'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量类型(固定值、区间值、若干)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentStandardRequirements', @level2type=N'COLUMN',@level2name=N'NumberType'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'值1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentStandardRequirements', @level2type=N'COLUMN',@level2name=N'Value1'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'值2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipmentStandardRequirements', @level2type=N'COLUMN',@level2name=N'Value2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'科目标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExperimentItems', @level2type=N'COLUMN',@level2name=N'CatalogID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'年级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExperimentItems', @level2type=N'COLUMN',@level2name=N'Grade'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'版本标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExperimentItems', @level2type=N'COLUMN',@level2name=N'EditionId'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否上学期（所属学期：上学期, ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExperimentItems', @level2type=N'COLUMN',@level2name=N'IsLastTerm'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'顺序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExperimentItems', @level2type=N'COLUMN',@level2name=N'Sequence'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'章节' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExperimentItems', @level2type=N'COLUMN',@level2name=N'Chapter'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExperimentItems', @level2type=N'COLUMN',@level2name=N'Name'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所需仪器' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExperimentItems', @level2type=N'COLUMN',@level2name=N'RequiredEquipments'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否演示实验' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExperimentItems', @level2type=N'COLUMN',@level2name=N'IsDemonstration'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实验类别（演示实验, 分组实验，' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExperimentItems', @level2type=N'COLUMN',@level2name=N'ExperimentType'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否必做实验（必做/选做）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExperimentItems', @level2type=N'COLUMN',@level2name=N'MustBeDone'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExperimentItems', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'装备项目标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GroupingExperimentEquipment', @level2type=N'COLUMN',@level2name=N'EquipmentItemID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'低配置的分组人数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GroupingExperimentEquipment', @level2type=N'COLUMN',@level2name=N'LowStandardGroupingPeopleNumber'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'高配置的分组人数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GroupingExperimentEquipment', @level2type=N'COLUMN',@level2name=N'HighStandardGroupingPeopleNumber'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'小学教学点分组人数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GroupingExperimentEquipment', @level2type=N'COLUMN',@level2name=N'TeachSchoolGroupingPeopleNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ReferenceUnitPriceProject', @level2type=N'COLUMN',@level2name=N'ID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标准版本标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ReferenceUnitPriceProject', @level2type=N'COLUMN',@level2name=N'StandardVersionsID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'方案名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ReferenceUnitPriceProject', @level2type=N'COLUMN',@level2name=N'Name'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'由用户定义' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ReferenceUnitPriceProject', @level2type=N'COLUMN',@level2name=N'UserDefined'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'来自区域代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ReferenceUnitPriceProject', @level2type=N'COLUMN',@level2name=N'FromRegionCode'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'来自区域名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ReferenceUnitPriceProject', @level2type=N'COLUMN',@level2name=N'FromRegionName'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推荐指数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ReferenceUnitPriceProject', @level2type=N'COLUMN',@level2name=N'Rating'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ReferenceUnitPriceProject', @level2type=N'COLUMN',@level2name=N'CreateDate'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ReferenceUnitPriceProject', @level2type=N'COLUMN',@level2name=N'Description'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修订日志' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ReferenceUnitPriceProject', @level2type=N'COLUMN',@level2name=N'RevisionLog'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'科目标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolCatalogInit', @level2type=N'COLUMN',@level2name=N'CatalogID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否初始化' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolCatalogInit', @level2type=N'COLUMN',@level2name=N'IsInit'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否允许初始化' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolCatalogInit', @level2type=N'COLUMN',@level2name=N'IsInitAllowed'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'通知标志' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolNotices', @level2type=N'COLUMN',@level2name=N'NoticeID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'续费通知标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolNotices', @level2type=N'COLUMN',@level2name=N'NoticeTitle'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'续费通知内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolNotices', @level2type=N'COLUMN',@level2name=N'NoticeContent'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolNotices', @level2type=N'COLUMN',@level2name=N'CreateTime'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolNotices', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单标识号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolOrderInfo', @level2type=N'COLUMN',@level2name=N'OrderID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学校注册ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolOrderInfo', @level2type=N'COLUMN',@level2name=N'SchoolRegistryID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学年' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolOrderInfo', @level2type=N'COLUMN',@level2name=N'SchoolYear'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'付款总价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolOrderInfo', @level2type=N'COLUMN',@level2name=N'TotalMoney'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'付款类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolOrderInfo', @level2type=N'COLUMN',@level2name=N'PayType'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'付款银行' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolOrderInfo', @level2type=N'COLUMN',@level2name=N'PayBank'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolOrderInfo', @level2type=N'COLUMN',@level2name=N'Subject'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolOrderInfo', @level2type=N'COLUMN',@level2name=N'SubjectDescr'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolOrderInfo', @level2type=N'COLUMN',@level2name=N'OrderStatus'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易订单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolOrderInfo', @level2type=N'COLUMN',@level2name=N'TradeID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交易订单状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolOrderInfo', @level2type=N'COLUMN',@level2name=N'TradeStatus'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户IP地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolOrderInfo', @level2type=N'COLUMN',@level2name=N'ClientIP'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户时间戳' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolOrderInfo', @level2type=N'COLUMN',@level2name=N'ClientTimestamp'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上一个操作时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolOrderInfo', @level2type=N'COLUMN',@level2name=N'OperTime'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolOrderInfo', @level2type=N'COLUMN',@level2name=N'CreateTime'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolOrderInfo', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'教育局标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolRegistry', @level2type=N'COLUMN',@level2name=N'EducationBureauID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学校代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolRegistry', @level2type=N'COLUMN',@level2name=N'SchoolCode'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'注册名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolRegistry', @level2type=N'COLUMN',@level2name=N'RegisteredName'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学校类型(小学、初中)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolRegistry', @level2type=N'COLUMN',@level2name=N'SchoolType'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态(启用、停用)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolRegistry', @level2type=N'COLUMN',@level2name=N'State'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolRegistry', @level2type=N'COLUMN',@level2name=N'Memo'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolRegistry', @level2type=N'COLUMN',@level2name=N'CreateDate'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是九年一贯制学校' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolRegistry', @level2type=N'COLUMN',@level2name=N'IsNineYearSchool'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学校组合类型或学校建制,如普通学校,九年一贯制学校,十二年一贯制学校,完全中学等' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolRegistry', @level2type=N'COLUMN',@level2name=N'CombinationType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学校标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolRenewFee', @level2type=N'COLUMN',@level2name=N'SchoolRegistryID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学年' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolRenewFee', @level2type=N'COLUMN',@level2name=N'SchoolYear'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolRenewFee', @level2type=N'COLUMN',@level2name=N'UnitPrice'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'付款人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolRenewFee', @level2type=N'COLUMN',@level2name=N'RemittorName'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'付款人单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolRenewFee', @level2type=N'COLUMN',@level2name=N'RemittorUnit'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'付款人联系方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolRenewFee', @level2type=N'COLUMN',@level2name=N'RemittorPhone'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'付款金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolRenewFee', @level2type=N'COLUMN',@level2name=N'RemitMoney'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'付款方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolRenewFee', @level2type=N'COLUMN',@level2name=N'RemitType'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'付款时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolRenewFee', @level2type=N'COLUMN',@level2name=N'RemitTime'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'付款状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolRenewFee', @level2type=N'COLUMN',@level2name=N'RenewState'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolRenewFee', @level2type=N'COLUMN',@level2name=N'ApproveTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学校标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolUsers', @level2type=N'COLUMN',@level2name=N'SchoolRegistryID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolUsers', @level2type=N'COLUMN',@level2name=N'Account'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'盐值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolUsers', @level2type=N'COLUMN',@level2name=N'Salt'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolUsers', @level2type=N'COLUMN',@level2name=N'Password'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolUsers', @level2type=N'COLUMN',@level2name=N'CreateDate'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolUsers', @level2type=N'COLUMN',@level2name=N'Enabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'档案控制标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolYearFilesRegistry', @level2type=N'COLUMN',@level2name=N'FilesControlID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学校注册标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolYearFilesRegistry', @level2type=N'COLUMN',@level2name=N'SchoolRegistryID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学校名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolYearFilesRegistry', @level2type=N'COLUMN',@level2name=N'Name'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学校举办者类型（教育部门，其他' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolYearFilesRegistry', @level2type=N'COLUMN',@level2name=N'SponsorType'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'隶属性质（省属，市属，县属）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolYearFilesRegistry', @level2type=N'COLUMN',@level2name=N'BelongType'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理员联系电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolYearFilesRegistry', @level2type=N'COLUMN',@level2name=N'Phone'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理员姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolYearFilesRegistry', @level2type=N'COLUMN',@level2name=N'Linkman'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理员电子邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolYearFilesRegistry', @level2type=N'COLUMN',@level2name=N'Email'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总班数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolYearFilesRegistry', @level2type=N'COLUMN',@level2name=N'ClassTotal'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'校园广播网建设模式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolYearFilesRegistry', @level2type=N'COLUMN',@level2name=N'SchoolNetworkModel'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学年初在校生数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolYearFilesRegistry', @level2type=N'COLUMN',@level2name=N'NumberOfStudents'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卫生（保健）室设置情况' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolYearFilesRegistry', @level2type=N'COLUMN',@level2name=N'HealthRoomSettings'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'综合实践活动开设情况' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolYearFilesRegistry', @level2type=N'COLUMN',@level2name=N'IntegratedPracticeActivity'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'执行装备标准的维度标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolYearFilesRegistry', @level2type=N'COLUMN',@level2name=N'EquipmentStandardDimensionID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最大班额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolYearFilesRegistry', @level2type=N'COLUMN',@level2name=N'MaxNumberOfClass'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'一贯制学校的另一部分总班数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolYearFilesRegistry', @level2type=N'COLUMN',@level2name=N'AnotherPartNineYearSchoolClassTotal'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'寄宿制形式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolYearFilesRegistry', @level2type=N'COLUMN',@level2name=N'BoardingType'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'寄宿学生数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolYearFilesRegistry', @level2type=N'COLUMN',@level2name=N'NumberOfBoardingStudents'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'能操作计算机的学生数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolYearFilesRegistry', @level2type=N'COLUMN',@level2name=N'NumberOfCanOperateComputerStudents'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学校所在地,城市->0,县镇->1,农' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolYearFilesRegistry', @level2type=N'COLUMN',@level2name=N'Location'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学校折算类型,如小规模学校折算等' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolYearFilesRegistry', @level2type=N'COLUMN',@level2name=N'ConversionType'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'高中部班数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolYearFilesRegistry', @level2type=N'COLUMN',@level2name=N'SeniorClassTotal'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'高中部学生数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolYearFilesRegistry', @level2type=N'COLUMN',@level2name=N'SeniorStudents'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'高中部寄宿学生数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SchoolYearFilesRegistry', @level2type=N'COLUMN',@level2name=N'SeniorBoardingStudents'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'版本标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StandardSchoolClassifications', @level2type=N'COLUMN',@level2name=N'VersionID'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学校类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StandardSchoolClassifications', @level2type=N'COLUMN',@level2name=N'SchoolType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'版本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StandardVersions', @level2type=N'COLUMN',@level2name=N'Version'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否当前应用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StandardVersions', @level2type=N'COLUMN',@level2name=N'IsCurrent'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StandardVersions', @level2type=N'COLUMN',@level2name=N'CreateDate'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StandardVersions', @level2type=N'COLUMN',@level2name=N'Memo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysSettingUser', @level2type=N'COLUMN',@level2name=N'Account'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名,用于显示' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysSettingUser', @level2type=N'COLUMN',@level2name=N'UserName'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysSettingUser', @level2type=N'COLUMN',@level2name=N'Password'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'盐值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysSettingUser', @level2type=N'COLUMN',@level2name=N'Salt'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysSettingUser', @level2type=N'COLUMN',@level2name=N'Role'
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysSettingUser', @level2type=N'COLUMN',@level2name=N'Memo'
GO