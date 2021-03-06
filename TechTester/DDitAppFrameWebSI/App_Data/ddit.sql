USE [master]
GO
/****** Object:  Database [DDit]    Script Date: 2017/6/5 16:02:49 ******/
CREATE DATABASE [DDit]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DDit', FILENAME = N'E:\Appdata\Framework\DDitRapidDevFramework\DDitApplicationFrame\App_Data\DDit.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DDit_log', FILENAME = N'E:\Appdata\Framework\DDitRapidDevFramework\DDitApplicationFrame\App_Data\DDit_log.ldf' , SIZE = 3840KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DDit] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DDit].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DDit] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DDit] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DDit] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DDit] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DDit] SET ARITHABORT OFF 
GO
ALTER DATABASE [DDit] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DDit] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DDit] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DDit] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DDit] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DDit] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DDit] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DDit] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DDit] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DDit] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DDit] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DDit] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DDit] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DDit] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DDit] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DDit] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DDit] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DDit] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DDit] SET  MULTI_USER 
GO
ALTER DATABASE [DDit] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DDit] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DDit] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DDit] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DDit] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DDit]
GO
/****** Object:  Schema [Base]    Script Date: 2017/6/5 16:02:49 ******/
CREATE SCHEMA [Base]
GO
/****** Object:  Schema [Table]    Script Date: 2017/6/5 16:02:49 ******/
CREATE SCHEMA [Table]
GO
/****** Object:  Schema [Test]    Script Date: 2017/6/5 16:02:49 ******/
CREATE SCHEMA [Test]
GO
/****** Object:  Table [Base].[Button]    Script Date: 2017/6/5 16:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[Button](
	[Button_ID] [int] IDENTITY(1,1) NOT NULL,
	[Button_OpID] [nvarchar](100) NULL,
	[Button_Name] [nvarchar](100) NOT NULL,
	[Button_Operation] [nvarchar](100) NULL,
	[Button_Magic] [nvarchar](100) NULL,
	[Button_Describe] [nvarchar](100) NULL,
	[Create_Time] [datetime] NULL,
	[Update_Time] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [Base].[Dictionary]    Script Date: 2017/6/5 16:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Base].[Dictionary](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DicCategoryID] [int] NOT NULL,
	[DicValue] [varchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL CONSTRAINT [DF_Dictionary_Enabled]  DEFAULT ((1)),
	[Create_Time] [datetime] NOT NULL CONSTRAINT [DF_Dictionary_Create_Time]  DEFAULT (getdate()),
	[Update_Time] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Base].[DictionaryCategory]    Script Date: 2017/6/5 16:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Base].[DictionaryCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Category] [varchar](100) NOT NULL,
	[Enabled] [bit] NOT NULL CONSTRAINT [DF_DictionaryCategory_Enabled]  DEFAULT ((1)),
	[Create_Time] [datetime] NOT NULL CONSTRAINT [DF_DictionaryCategory_Create_Time]  DEFAULT (getdate()),
	[Update_Time] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Base].[LoginLog]    Script Date: 2017/6/5 16:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[LoginLog](
	[Login_ID] [int] IDENTITY(1,1) NOT NULL,
	[Login_Name] [nvarchar](100) NOT NULL,
	[Login_Nicker] [nvarchar](100) NOT NULL,
	[Login_IP] [nvarchar](100) NOT NULL,
	[Login_Time] [datetime] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [Base].[Menu]    Script Date: 2017/6/5 16:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[Menu](
	[Menu_ID] [int] IDENTITY(1,1) NOT NULL,
	[Menu_Name] [nvarchar](50) NOT NULL,
	[Menu_Url] [nvarchar](200) NULL,
	[Menu_ParentID] [int] NULL,
	[Menu_Order] [int] NOT NULL,
	[Menu_Icon] [nvarchar](100) NULL,
	[IsVisible] [int] NULL CONSTRAINT [DF_Menu_IsVisible]  DEFAULT ((1)),
	[Create_Time] [datetime] NULL,
	[Update_Time] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [Base].[Menu_Button]    Script Date: 2017/6/5 16:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[Menu_Button](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Menu_ID] [int] NULL,
	[Button_ID] [int] NULL,
	[OrderBy] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [Base].[Role]    Script Date: 2017/6/5 16:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[Role](
	[Role_ID] [int] IDENTITY(1,1) NOT NULL,
	[Role_Name] [nvarchar](100) NOT NULL,
	[Role_Description] [nvarchar](500) NULL,
	[Create_Time] [datetime] NOT NULL,
	[Update_Time] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [Base].[Role_Button]    Script Date: 2017/6/5 16:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[Role_Button](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Role_ID] [int] NULL,
	[Menu_ID] [int] NULL,
	[Button_ID] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [Base].[Role_Menu]    Script Date: 2017/6/5 16:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[Role_Menu](
	[RoleMenu_ID] [int] IDENTITY(1,1) NOT NULL,
	[Role_ID] [int] NOT NULL,
	[Menu_ID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [Base].[SystemInfo]    Script Date: 2017/6/5 16:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[SystemInfo](
	[System_ID] [int] IDENTITY(1,1) NOT NULL,
	[System_Title] [nvarchar](100) NULL,
	[System_Version] [nvarchar](50) NULL,
	[System_Copyright] [nvarchar](100) NULL,
	[IsValidCode] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [Base].[User]    Script Date: 2017/6/5 16:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[User](
	[User_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_Name] [nvarchar](100) NOT NULL,
	[User_Password] [nvarchar](100) NOT NULL,
	[User_Reallyname] [nvarchar](50) NOT NULL,
	[HeadPortrait] [nvarchar](500) NULL,
	[Department_ID] [int] NOT NULL,
	[IsEnable] [bit] NOT NULL CONSTRAINT [DF_User_IsEnable]  DEFAULT ((1)),
	[Create_Time] [datetime] NOT NULL,
	[Update_Time] [datetime] NULL,
	[Remark] [nvarchar](500) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [Base].[User_Role]    Script Date: 2017/6/5 16:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Base].[User_Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NOT NULL,
	[Role_ID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [Test].[Account]    Script Date: 2017/6/5 16:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Test].[Account](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[TestID] [int] NULL,
	[Total] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [Test].[test]    Script Date: 2017/6/5 16:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Test].[test](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[age] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Base].[Button] ON 

INSERT [Base].[Button] ([Button_ID], [Button_OpID], [Button_Name], [Button_Operation], [Button_Magic], [Button_Describe], [Create_Time], [Update_Time]) VALUES (1, N'Create', N'新增', N'CreateModal', N'glyphicon glyphicon-plus', N'用于创建信息', CAST(N'2016-03-25 15:26:05.087' AS DateTime), CAST(N'2016-04-15 09:45:49.573' AS DateTime))
INSERT [Base].[Button] ([Button_ID], [Button_OpID], [Button_Name], [Button_Operation], [Button_Magic], [Button_Describe], [Create_Time], [Update_Time]) VALUES (2, N'Edit', N'编辑', NULL, N'glyphicon glyphicon-pencil', N'用于编辑信息', CAST(N'2016-03-25 15:26:05.087' AS DateTime), NULL)
INSERT [Base].[Button] ([Button_ID], [Button_OpID], [Button_Name], [Button_Operation], [Button_Magic], [Button_Describe], [Create_Time], [Update_Time]) VALUES (3, N'Delete', N'删除', NULL, N'glyphicon glyphicon-remove', N'用于删除信息', CAST(N'2016-03-25 15:26:05.087' AS DateTime), NULL)
INSERT [Base].[Button] ([Button_ID], [Button_OpID], [Button_Name], [Button_Operation], [Button_Magic], [Button_Describe], [Create_Time], [Update_Time]) VALUES (4, N'DownLoad', N'下载', NULL, N'glyphicon glyphicon-download', N'用于下载信息', CAST(N'2016-03-25 15:26:05.087' AS DateTime), NULL)
INSERT [Base].[Button] ([Button_ID], [Button_OpID], [Button_Name], [Button_Operation], [Button_Magic], [Button_Describe], [Create_Time], [Update_Time]) VALUES (7, N'export', N'导出', N'#wdaw', N'glyphicon glyphicon-export', N'导出相关Execl', CAST(N'2016-03-25 15:26:05.087' AS DateTime), CAST(N'2016-03-28 11:23:19.983' AS DateTime))
INSERT [Base].[Button] ([Button_ID], [Button_OpID], [Button_Name], [Button_Operation], [Button_Magic], [Button_Describe], [Create_Time], [Update_Time]) VALUES (9, N'import', N'导入', NULL, N'glyphicon glyphicon-import', N'导入相关数据', CAST(N'2016-03-28 16:44:30.417' AS DateTime), NULL)
INSERT [Base].[Button] ([Button_ID], [Button_OpID], [Button_Name], [Button_Operation], [Button_Magic], [Button_Describe], [Create_Time], [Update_Time]) VALUES (10, N'distributionRole', N'分配角色', NULL, N'glyphicon glyphicon-user', NULL, CAST(N'2016-04-14 16:24:47.140' AS DateTime), NULL)
INSERT [Base].[Button] ([Button_ID], [Button_OpID], [Button_Name], [Button_Operation], [Button_Magic], [Button_Describe], [Create_Time], [Update_Time]) VALUES (11, N'Disabled', N'禁用', NULL, N'glyphicon glyphicon-ban-circle', N'不删除修改状态', CAST(N'2016-04-15 10:07:45.247' AS DateTime), CAST(N'2016-05-06 13:17:27.377' AS DateTime))
INSERT [Base].[Button] ([Button_ID], [Button_OpID], [Button_Name], [Button_Operation], [Button_Magic], [Button_Describe], [Create_Time], [Update_Time]) VALUES (5, N'UpLoad', N'上传', NULL, N'glyphicon glyphicon-upload', N'用户上传文件', CAST(N'2016-03-25 15:26:05.087' AS DateTime), NULL)
SET IDENTITY_INSERT [Base].[Button] OFF
SET IDENTITY_INSERT [Base].[Dictionary] ON 

INSERT [Base].[Dictionary] ([ID], [DicCategoryID], [DicValue], [Enabled], [Create_Time], [Update_Time]) VALUES (1, 1, N'市场部', 1, CAST(N'2016-04-21 00:00:00.000' AS DateTime), CAST(N'2017-05-04 10:43:35.213' AS DateTime))
INSERT [Base].[Dictionary] ([ID], [DicCategoryID], [DicValue], [Enabled], [Create_Time], [Update_Time]) VALUES (2, 1, N'技术部', 0, CAST(N'2016-04-21 00:00:00.000' AS DateTime), CAST(N'2017-05-04 10:43:47.003' AS DateTime))
INSERT [Base].[Dictionary] ([ID], [DicCategoryID], [DicValue], [Enabled], [Create_Time], [Update_Time]) VALUES (3, 1, N'客服部', 1, CAST(N'2016-04-22 00:00:00.000' AS DateTime), NULL)
INSERT [Base].[Dictionary] ([ID], [DicCategoryID], [DicValue], [Enabled], [Create_Time], [Update_Time]) VALUES (4, 1, N'服务部', 1, CAST(N'2016-04-23 00:00:00.000' AS DateTime), CAST(N'2016-04-29 11:01:00.480' AS DateTime))
INSERT [Base].[Dictionary] ([ID], [DicCategoryID], [DicValue], [Enabled], [Create_Time], [Update_Time]) VALUES (12, 16, N'测试1', 1, CAST(N'2017-05-03 11:56:43.187' AS DateTime), NULL)
INSERT [Base].[Dictionary] ([ID], [DicCategoryID], [DicValue], [Enabled], [Create_Time], [Update_Time]) VALUES (13, 16, N'测试3', 1, CAST(N'2017-05-03 15:10:26.193' AS DateTime), CAST(N'2017-05-03 15:21:28.433' AS DateTime))
INSERT [Base].[Dictionary] ([ID], [DicCategoryID], [DicValue], [Enabled], [Create_Time], [Update_Time]) VALUES (14, 16, N'测试4', 0, CAST(N'2017-05-03 15:12:07.377' AS DateTime), CAST(N'2017-05-03 15:21:45.397' AS DateTime))
INSERT [Base].[Dictionary] ([ID], [DicCategoryID], [DicValue], [Enabled], [Create_Time], [Update_Time]) VALUES (15, 16, N'测试2', 1, CAST(N'2017-05-03 15:18:25.703' AS DateTime), NULL)
INSERT [Base].[Dictionary] ([ID], [DicCategoryID], [DicValue], [Enabled], [Create_Time], [Update_Time]) VALUES (16, 16, N'测试2', 1, CAST(N'2017-05-03 15:18:52.430' AS DateTime), NULL)
INSERT [Base].[Dictionary] ([ID], [DicCategoryID], [DicValue], [Enabled], [Create_Time], [Update_Time]) VALUES (17, 16, N'测试3', 1, CAST(N'2017-05-03 15:20:52.557' AS DateTime), NULL)
INSERT [Base].[Dictionary] ([ID], [DicCategoryID], [DicValue], [Enabled], [Create_Time], [Update_Time]) VALUES (18, 16, N'测试3', 1, CAST(N'2017-05-03 16:01:02.790' AS DateTime), NULL)
SET IDENTITY_INSERT [Base].[Dictionary] OFF
SET IDENTITY_INSERT [Base].[DictionaryCategory] ON 

INSERT [Base].[DictionaryCategory] ([ID], [Category], [Enabled], [Create_Time], [Update_Time]) VALUES (1, N'部门', 1, CAST(N'2016-04-21 00:00:00.000' AS DateTime), CAST(N'2017-05-03 14:11:12.577' AS DateTime))
INSERT [Base].[DictionaryCategory] ([ID], [Category], [Enabled], [Create_Time], [Update_Time]) VALUES (16, N'测试用的', 1, CAST(N'2017-05-03 10:56:33.760' AS DateTime), NULL)
SET IDENTITY_INSERT [Base].[DictionaryCategory] OFF
SET IDENTITY_INSERT [Base].[LoginLog] ON 

INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (122, N'admin', N'王洪洋', N'192.168.40.23', CAST(N'2016-04-13 11:30:26.127' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (123, N'admin', N'王洪洋', N'192.168.40.23', CAST(N'2016-04-13 17:21:14.617' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (3, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-02 16:23:36.200' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (4, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-02 16:26:42.237' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (5, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-02 16:29:44.780' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (6, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-04 10:59:29.757' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (7, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-04 11:10:45.910' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (8, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-04 11:12:19.557' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (11, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-04 11:43:41.267' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (12, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-04 11:44:28.120' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (13, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-04 11:45:00.357' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (16, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-04 16:38:55.383' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (17, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-04 16:41:37.587' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (18, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-04 16:44:31.307' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (19, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-04 16:46:31.130' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (20, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-04 16:55:35.977' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (21, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-07 14:32:48.627' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (22, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-07 14:34:07.107' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (23, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-07 14:35:05.430' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (24, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-07 14:42:12.357' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (25, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-07 14:54:50.847' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (26, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-07 14:56:00.950' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (29, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-07 15:37:41.523' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (30, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-07 15:40:15.707' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (31, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-10 16:02:31.527' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (32, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-10 16:04:16.897' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (33, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-10 16:04:34.850' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (34, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-10 16:14:23.713' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (35, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-10 18:11:51.283' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (36, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-10 18:15:50.657' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (37, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-11 10:08:35.780' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (38, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-11 10:09:22.680' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (39, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-11 10:12:03.247' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (40, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-11 10:16:28.180' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (41, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-11 10:53:39.810' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (42, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-11 10:55:25.463' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (43, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-11 10:56:47.147' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (44, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-11 13:32:24.437' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (45, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-11 13:40:50.307' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (46, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-11 14:10:42.557' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (47, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-11 15:23:38.103' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (48, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-11 15:41:53.530' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (49, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-14 10:57:41.060' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (50, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-14 11:11:41.253' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (51, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-14 11:12:33.753' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (52, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-14 11:54:44.327' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (54, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-14 15:20:35.740' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (56, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-14 17:34:32.100' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (58, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-14 17:41:43.267' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (59, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-14 17:42:56.220' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (60, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-14 17:43:55.050' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (64, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-14 18:04:48.120' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (65, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-14 18:05:56.177' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (66, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-14 18:11:27.873' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (67, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-15 09:10:09.500' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (68, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-15 09:27:06.303' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (69, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-15 09:31:45.090' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (90, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-15 17:16:21.577' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (91, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-16 16:03:10.337' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (92, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-21 09:09:06.663' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (93, N'admin', N'王洪洋', N'192.168.40.23', CAST(N'2016-03-21 10:19:22.727' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (94, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-22 09:30:03.443' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (95, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-25 09:30:25.197' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (96, N'admin', N'王洪洋', N'192.168.40.23', CAST(N'2016-03-25 09:34:31.633' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (97, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-28 09:35:17.050' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (98, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-29 11:24:33.933' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (99, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-30 10:06:03.040' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (100, N'admin', N'王洪洋', N'192.168.40.23', CAST(N'2016-03-30 11:43:44.237' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (101, N'admin', N'王洪洋', N'192.168.40.23', CAST(N'2016-03-30 11:49:42.463' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (103, N'admin', N'王洪洋', N'192.168.40.23', CAST(N'2016-03-31 13:36:15.060' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (104, N'admin', N'王洪洋', N'::1', CAST(N'2016-04-05 11:07:40.563' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (105, N'admin', N'王洪洋', N'127.0.0.1', CAST(N'2016-04-05 16:41:33.767' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (106, N'admin', N'王洪洋', N'127.0.0.1', CAST(N'2016-04-05 17:47:48.960' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (107, N'admin', N'王洪洋', N'127.0.0.1', CAST(N'2016-04-05 17:48:42.353' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (108, N'admin', N'王洪洋', N'127.0.0.1', CAST(N'2016-04-05 17:53:30.183' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (110, N'admin', N'王洪洋', N'192.168.40.5', CAST(N'2016-04-05 17:55:31.557' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (111, N'admin', N'王洪洋', N'::1', CAST(N'2016-04-07 09:57:18.323' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (114, N'admin', N'王洪洋', N'::1', CAST(N'2016-04-08 10:31:29.630' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (115, N'admin', N'王洪洋', N'::1', CAST(N'2016-04-11 09:12:56.773' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (116, N'admin', N'王洪洋', N'::1', CAST(N'2016-04-11 15:38:30.797' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (117, N'admin', N'王洪洋', N'::1', CAST(N'2016-04-11 15:40:00.567' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (118, N'admin', N'王洪洋', N'::1', CAST(N'2016-04-11 15:42:36.200' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (119, N'admin', N'王洪洋', N'::1', CAST(N'2016-04-11 15:45:03.270' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (120, N'admin', N'王洪洋', N'::1', CAST(N'2016-04-11 16:49:39.117' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (121, N'admin', N'王洪洋', N'::1', CAST(N'2016-04-12 10:07:37.610' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (125, N'admin', N'王洪洋', N'192.168.40.23', CAST(N'2016-04-14 10:20:14.287' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (126, N'admin', N'王洪洋', N'192.168.40.33', CAST(N'2016-04-14 17:29:47.883' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (127, N'admin', N'王洪洋', N'::1', CAST(N'2016-04-15 09:37:37.290' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (128, N'admin', N'王洪洋', N'::1', CAST(N'2016-04-18 10:02:56.223' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (130, N'admin', N'王洪洋', N'::1', CAST(N'2016-04-19 14:20:12.227' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (131, N'admin', N'王洪洋', N'192.168.40.23', CAST(N'2016-04-20 10:23:37.787' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (132, N'admin', N'王洪洋', N'192.168.40.23', CAST(N'2016-04-20 11:29:18.300' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (133, N'admin', N'王洪洋', N'::1', CAST(N'2016-04-21 10:44:04.267' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (134, N'admin', N'王洪洋', N'::1', CAST(N'2016-04-21 15:46:37.197' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (136, N'admin', N'王洪洋', N'127.0.0.1', CAST(N'2016-04-22 10:15:07.190' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (137, N'admin', N'王洪洋', N'127.0.0.1', CAST(N'2016-04-22 10:24:09.770' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (138, N'admin', N'王洪洋', N'::1', CAST(N'2016-04-22 14:09:52.713' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (139, N'admin', N'王洪洋', N'::1', CAST(N'2016-04-22 16:30:46.173' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (140, N'admin', N'王洪洋', N'::1', CAST(N'2016-04-23 14:25:01.403' AS DateTime))
GO
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (141, N'admin', N'王洪洋', N'::1', CAST(N'2016-04-23 14:25:52.237' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (142, N'nana', N'娜娜', N'::1', CAST(N'2016-04-23 14:33:03.827' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (143, N'admin', N'王洪洋', N'::1', CAST(N'2016-04-23 14:34:53.903' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (144, N'nana', N'娜娜', N'::1', CAST(N'2016-04-23 14:34:59.210' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (145, N'nana', N'娜娜', N'::1', CAST(N'2016-04-23 14:36:01.967' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (146, N'nana', N'娜娜', N'::1', CAST(N'2016-04-23 14:36:26.123' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (147, N'nana', N'娜神', N'::1', CAST(N'2016-04-23 14:37:11.550' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (148, N'nana', N'娜神', N'192.168.40.53', CAST(N'2016-04-23 14:37:30.387' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (149, N'nana', N'娜四一定', N'::1', CAST(N'2016-04-23 14:40:17.120' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (155, N'admin', N'超级管理员', N'::1', CAST(N'2016-04-25 09:53:19.630' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (9, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-04 11:32:31.267' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (10, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-04 11:35:43.233' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (14, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-04 15:11:02.900' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (15, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-04 15:12:54.430' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (109, N'admin', N'王洪洋', N'192.168.40.53', CAST(N'2016-04-05 17:54:08.977' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (124, N'admin', N'王洪洋', N'192.168.40.23', CAST(N'2016-04-13 17:22:54.903' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (135, N'admin', N'王洪洋', N'192.168.40.23', CAST(N'2016-04-21 15:49:51.417' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (27, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-07 14:57:19.350' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (28, N'whywhy898', N'王洪洋', N'::1', CAST(N'2016-03-07 14:59:28.940' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (112, N'admin', N'王洪洋', N'192.168.40.5', CAST(N'2016-04-07 10:38:34.883' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (113, N'admin', N'王洪洋', N'192.168.40.2', CAST(N'2016-04-07 10:40:34.220' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (129, N'admin', N'王洪洋', N'192.168.40.23', CAST(N'2016-04-18 14:48:03.103' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (150, N'nana', N'娜四一定', N'::1', CAST(N'2016-04-23 14:52:32.050' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (151, N'nana', N'娜就是神', N'::1', CAST(N'2016-04-23 14:52:59.817' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (152, N'jimi', N'吉米', N'::1', CAST(N'2016-04-23 14:57:14.650' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (153, N'admin', N'王洪洋', N'::1', CAST(N'2016-04-23 14:57:50.033' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (154, N'admin', N'超级管理员', N'::1', CAST(N'2016-04-23 14:59:20.237' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (53, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-14 14:45:10.347' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (55, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-14 15:54:51.947' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (57, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-14 17:38:34.787' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (61, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-14 17:48:38.933' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (62, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-14 17:50:56.093' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (63, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-14 17:57:18.673' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (70, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-15 10:43:41.930' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (71, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-15 10:56:43.450' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (72, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-15 11:23:11.883' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (73, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-15 11:26:39.353' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (74, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-15 11:28:39.907' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (75, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-15 11:31:05.070' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (76, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-15 11:32:42.147' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (77, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-15 11:33:38.800' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (78, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-15 11:35:32.267' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (79, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-15 11:46:57.760' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (80, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-15 11:56:33.747' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (81, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-15 12:01:27.887' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (82, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-15 13:07:45.887' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (83, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-15 13:09:37.463' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (84, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-15 13:12:24.423' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (85, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-15 14:04:14.677' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (86, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-15 14:05:06.537' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (87, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-15 14:06:50.673' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (88, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-15 15:22:17.887' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (89, N'admin', N'王洪洋', N'::1', CAST(N'2016-03-15 15:27:46.440' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (102, N'admin', N'王洪洋', N'192.168.40.23', CAST(N'2016-03-30 14:38:34.060' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (156, N'admin', N'超级管理员', N'::1', CAST(N'2016-04-25 16:25:27.147' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (157, N'admin', N'超级管理员', N'::1', CAST(N'2016-04-28 10:12:41.273' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (158, N'admin', N'超级管理员', N'192.168.40.5', CAST(N'2016-04-28 13:33:39.743' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (159, N'admin', N'超级管理员', N'192.168.40.5', CAST(N'2016-04-29 10:56:51.787' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (160, N'admin', N'超级管理员', N'192.168.40.5', CAST(N'2016-04-29 14:37:12.447' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (161, N'admin', N'超级管理员', N'192.168.40.23', CAST(N'2016-04-29 14:41:49.167' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (162, N'admin', N'超级管理员', N'192.168.40.23', CAST(N'2016-04-29 14:46:34.803' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (163, N'admin', N'超级管理员', N'::1', CAST(N'2016-05-05 13:54:59.677' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (164, N'admin', N'超级管理员', N'::1', CAST(N'2016-05-06 09:51:17.713' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (165, N'admin', N'超级管理员', N'::1', CAST(N'2016-05-06 10:17:56.643' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (166, N'admin', N'超级管理员', N'::1', CAST(N'2016-05-06 10:21:56.060' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (170, N'admin', N'超级管理员', N'::1', CAST(N'2016-05-06 10:29:13.493' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (171, N'admin', N'超级管理员', N'::1', CAST(N'2016-05-06 10:36:46.487' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (172, N'admin', N'超级管理员', N'::1', CAST(N'2016-05-06 10:38:12.293' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (173, N'admin', N'超级管理员', N'::1', CAST(N'2016-05-06 10:39:29.040' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (174, N'admin', N'超级管理员', N'::1', CAST(N'2016-05-06 10:41:50.283' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (178, N'admin', N'超级管理员', N'::1', CAST(N'2016-06-29 10:19:43.040' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (179, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-04 14:25:26.707' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (180, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-04 16:55:06.137' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (181, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-05 09:38:38.200' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (182, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-06 09:55:02.767' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (183, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-06 10:11:42.390' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (184, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-06 10:13:29.497' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (185, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-06 10:19:09.310' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (186, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-06 10:29:07.870' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (187, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-06 10:37:20.883' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (188, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-06 10:42:11.397' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (189, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-06 15:30:23.027' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (190, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-07 14:13:59.613' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (191, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-07 16:04:36.150' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (192, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-15 10:31:28.303' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (193, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-15 10:36:57.297' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (194, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-15 13:38:42.650' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (195, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-15 13:45:36.977' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (198, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-18 11:57:46.027' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (199, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-18 13:14:12.217' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (200, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-18 13:18:48.863' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (201, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-18 13:36:48.683' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (202, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-18 14:16:18.817' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (203, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-18 14:18:52.040' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (206, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-18 14:26:35.430' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (207, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-18 14:30:29.073' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (208, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-18 14:34:54.367' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (209, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-18 14:37:44.587' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (211, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-19 09:33:28.397' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (212, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-19 09:39:12.490' AS DateTime))
GO
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (213, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-19 13:59:28.727' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (216, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-20 13:34:15.113' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (217, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-21 14:31:48.163' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (218, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-22 09:40:02.573' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (220, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-22 13:37:07.410' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (221, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-25 14:25:51.447' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (222, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-26 14:46:25.257' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (223, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-27 10:14:20.577' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (225, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-27 12:01:00.253' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (226, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-27 14:01:12.707' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (227, N'admin', N'超级管理员', N'::1', CAST(N'2016-08-01 17:27:52.980' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (228, N'admin', N'超级管理员', N'::1', CAST(N'2016-08-01 17:50:26.763' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (229, N'admin', N'超级管理员', N'::1', CAST(N'2016-08-02 11:26:14.340' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (230, N'admin', N'超级管理员', N'::1', CAST(N'2016-08-02 11:28:12.320' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (231, N'admin', N'超级管理员', N'::1', CAST(N'2016-08-04 10:53:45.967' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (232, N'admin', N'超级管理员', N'::1', CAST(N'2016-08-04 10:59:22.050' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (234, N'admin', N'超级管理员', N'::1', CAST(N'2016-08-04 11:02:52.147' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (235, N'admin', N'超级管理员', N'::1', CAST(N'2016-08-04 11:12:02.387' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (236, N'admin', N'超级管理员', N'::1', CAST(N'2016-08-08 16:23:36.927' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (237, N'admin', N'超级管理员', N'::1', CAST(N'2016-08-09 10:23:43.917' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (238, N'admin', N'超级管理员', N'::1', CAST(N'2016-08-10 16:43:25.847' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (239, N'admin', N'超级管理员', N'::1', CAST(N'2016-08-16 11:21:39.597' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (241, N'admin', N'超级管理员', N'::1', CAST(N'2016-08-17 10:27:05.687' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (242, N'admin', N'超级管理员', N'::1', CAST(N'2016-08-17 10:34:25.753' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (245, N'admin', N'超级管理员', N'::1', CAST(N'2016-08-18 09:47:15.210' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (246, N'admin', N'超级管理员', N'::1', CAST(N'2016-08-18 09:50:39.043' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (247, N'admin', N'超级管理员', N'::1', CAST(N'2016-11-14 15:48:19.213' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (248, N'admin', N'超级管理员', N'::1', CAST(N'2016-11-15 09:50:39.803' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (249, N'admin', N'超级管理员', N'::1', CAST(N'2016-11-15 09:58:06.387' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (251, N'admin', N'超级管理员', N'::1', CAST(N'2016-11-17 10:40:02.527' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (252, N'admin', N'超级管理员', N'::1', CAST(N'2017-02-07 11:11:55.047' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (253, N'admin', N'超级管理员', N'::1', CAST(N'2017-02-07 11:19:09.543' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (254, N'admin', N'超级管理员', N'::1', CAST(N'2017-02-08 14:00:47.040' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (255, N'admin', N'超级管理员', N'::1', CAST(N'2017-02-08 15:38:42.767' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (261, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-07 10:14:07.153' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (262, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-07 10:15:35.337' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (263, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-07 10:20:51.673' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (264, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-07 10:26:37.847' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (265, N'why778', N'小杰', N'::1', CAST(N'2017-04-07 10:30:45.033' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (266, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-07 10:37:24.223' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (267, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-21 13:37:51.957' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (268, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-21 13:56:09.193' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (270, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-21 14:53:03.977' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (271, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-21 15:22:52.020' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (272, N'admin', N'超级管理员', N'192.168.40.19', CAST(N'2017-04-21 15:33:51.203' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (273, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-21 15:35:42.170' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (274, N'admin', N'超级管理员', N'192.168.40.35', CAST(N'2017-04-21 15:36:09.237' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (275, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-21 15:55:40.750' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (277, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-24 10:27:40.910' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (278, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-24 11:19:44.567' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (280, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-25 09:57:20.317' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (281, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-25 10:04:09.137' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (283, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-25 10:16:01.123' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (284, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-25 10:23:38.533' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (289, N'admin', N'超级管理员', N'127.0.0.1', CAST(N'2017-04-25 11:07:12.127' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (292, N'admin', N'超级管理员', N'127.0.0.1', CAST(N'2017-04-25 15:27:27.683' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (293, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-26 08:47:08.357' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (299, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-27 09:41:47.590' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (301, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-27 10:23:40.787' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (304, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-27 13:30:25.723' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (308, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-28 09:41:21.613' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (309, N'layer5', N'关羽', N'::1', CAST(N'2017-04-28 09:48:55.150' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (310, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-28 09:49:17.960' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (311, N'layer5', N'关羽', N'::1', CAST(N'2017-04-28 09:59:53.577' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (312, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-28 10:00:30.310' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (314, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-02 09:42:20.193' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (317, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-02 14:21:08.943' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (318, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-02 14:49:08.473' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (321, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-03 10:07:39.953' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (322, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-03 10:12:27.603' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (325, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-03 10:46:58.627' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (326, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-03 13:35:32.727' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (327, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-03 13:41:13.577' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (328, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-03 13:42:26.977' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (330, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-04 10:19:47.720' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (332, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-04 13:47:28.987' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (334, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-05 09:32:42.380' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (337, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-09 10:55:16.830' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (167, N'admin', N'超级管理员', N'::1', CAST(N'2016-05-06 10:24:53.373' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (168, N'admin', N'超级管理员', N'::1', CAST(N'2016-05-06 10:27:04.360' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (169, N'admin', N'超级管理员', N'::1', CAST(N'2016-05-06 10:27:39.527' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (175, N'admin', N'超级管理员', N'::1', CAST(N'2016-05-06 10:44:17.090' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (176, N'admin', N'超级管理员', N'::1', CAST(N'2016-05-06 10:46:33.153' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (177, N'admin', N'超级管理员', N'::1', CAST(N'2016-05-06 10:47:27.287' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (233, N'admin', N'超级管理员', N'::1', CAST(N'2016-08-04 11:02:19.343' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (243, N'admin', N'超级管理员', N'::1', CAST(N'2016-08-17 10:35:05.757' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (250, N'admin', N'超级管理员', N'::1', CAST(N'2016-11-15 10:41:37.213' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (256, N'admin', N'超级管理员', N'::1', CAST(N'2017-02-08 16:06:32.563' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (269, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-21 14:18:49.380' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (279, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-24 11:34:27.967' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (282, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-25 10:07:47.493' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (295, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-26 15:13:49.083' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (302, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-27 11:56:13.087' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (303, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-27 11:58:34.757' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (320, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-02 16:28:51.260' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (323, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-03 10:15:53.383' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (324, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-03 10:35:00.697' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (336, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-05 11:40:13.683' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (338, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-10 13:40:57.420' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (339, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-10 14:01:00.020' AS DateTime))
GO
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (340, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-10 14:31:52.337' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (341, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-11 11:46:30.507' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (342, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-12 09:32:53.653' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (344, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-12 10:30:42.657' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (346, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-12 11:22:08.237' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (348, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-12 13:09:16.967' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (349, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-12 13:16:44.150' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (350, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-12 13:56:24.610' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (352, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-12 16:12:55.093' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (353, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-15 13:12:42.370' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (354, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-15 14:10:57.677' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (355, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-15 14:40:32.697' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (356, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-15 14:45:25.410' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (359, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-15 17:20:36.957' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (360, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-16 09:39:50.317' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (361, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-16 10:08:49.457' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (362, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-16 15:28:19.183' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (365, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-16 16:09:36.077' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (368, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-16 16:54:58.340' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (374, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-17 09:40:35.480' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (375, N'admin', N'超级管理员', N'192.168.40.35', CAST(N'2017-05-17 10:02:24.970' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (376, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-17 10:37:01.653' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (380, N'admin', N'超级管理员', N'192.168.40.35', CAST(N'2017-05-17 10:48:55.597' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (383, N'admin', N'超级管理员', N'192.168.40.35', CAST(N'2017-05-17 11:12:45.217' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (384, N'admin', N'超级管理员', N'::1', CAST(N'2017-06-05 11:34:52.800' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (385, N'admin', N'超级管理员', N'::1', CAST(N'2017-06-05 11:36:26.880' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (386, N'ezx', N'ezx', N'::1', CAST(N'2017-06-05 11:38:58.230' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (387, N'admin', N'超级管理员', N'::1', CAST(N'2017-06-05 11:41:46.167' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (196, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-15 15:05:00.680' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (197, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-15 15:07:55.207' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (204, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-18 14:21:56.880' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (205, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-18 14:23:18.157' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (210, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-18 14:41:12.400' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (219, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-22 10:08:44.257' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (224, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-27 10:45:49.890' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (240, N'admin', N'超级管理员', N'::1', CAST(N'2016-08-16 14:51:01.780' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (294, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-26 10:09:52.107' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (296, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-26 15:17:31.177' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (297, N'layer5', N'关羽', N'::1', CAST(N'2017-04-26 15:18:56.443' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (298, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-26 15:19:09.397' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (300, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-27 10:07:36.230' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (305, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-27 15:16:16.420' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (306, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-27 17:20:18.570' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (307, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-27 17:24:05.607' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (331, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-04 11:28:22.290' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (333, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-04 13:55:13.327' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (335, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-05 11:27:17.350' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (214, N'admin', N'超级管理员', N'::1', CAST(N'2016-07-19 14:19:24.937' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (215, N'admin', N'超级管理员', N'127.0.0.1', CAST(N'2016-07-19 14:35:04.997' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (343, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-12 09:50:46.020' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (345, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-12 11:19:17.527' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (347, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-12 11:55:50.433' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (351, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-12 14:08:08.810' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (244, N'admin', N'超级管理员', N'::1', CAST(N'2016-08-17 10:36:19.533' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (257, N'admin', N'超级管理员', N'::1', CAST(N'2017-02-08 16:08:49.967' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (258, N'admin', N'超级管理员', N'::1', CAST(N'2017-02-08 16:10:08.017' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (259, N'admin', N'超级管理员', N'::1', CAST(N'2017-02-08 16:14:21.917' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (260, N'admin', N'超级管理员', N'::1', CAST(N'2017-02-08 16:16:12.417' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (276, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-21 16:01:10.767' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (285, N'admin', N'超级管理员', N'127.0.0.1', CAST(N'2017-04-25 10:48:28.543' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (286, N'admin', N'超级管理员', N'127.0.0.1', CAST(N'2017-04-25 10:49:51.227' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (287, N'admin', N'超级管理员', N'127.0.0.1', CAST(N'2017-04-25 10:58:59.633' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (288, N'admin', N'超级管理员', N'127.0.0.1', CAST(N'2017-04-25 10:59:51.373' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (290, N'admin', N'超级管理员', N'127.0.0.1', CAST(N'2017-04-25 13:53:00.993' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (291, N'admin', N'超级管理员', N'127.0.0.1', CAST(N'2017-04-25 14:58:45.787' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (313, N'admin', N'超级管理员', N'::1', CAST(N'2017-04-28 10:21:31.233' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (315, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-02 11:39:46.303' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (316, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-02 13:30:36.237' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (319, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-02 15:30:12.480' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (329, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-03 15:49:55.007' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (357, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-15 16:15:42.637' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (358, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-15 16:23:33.513' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (363, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-16 15:46:36.997' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (364, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-16 16:06:03.383' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (366, N'admin', N'超级管理员', N'192.168.40.35', CAST(N'2017-05-16 16:44:45.970' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (367, N'admin', N'超级管理员', N'192.168.40.35', CAST(N'2017-05-16 16:49:09.310' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (369, N'admin', N'超级管理员', N'192.168.40.35', CAST(N'2017-05-16 16:54:04.867' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (370, N'admin', N'超级管理员', N'192.168.40.35', CAST(N'2017-05-16 16:54:30.713' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (371, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-16 17:15:14.857' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (372, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-16 17:29:12.763' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (373, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-16 17:47:10.813' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (377, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-17 10:40:34.080' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (378, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-17 10:42:00.230' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (379, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-17 10:45:17.607' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (381, N'admin', N'超级管理员', N'::1', CAST(N'2017-05-17 10:53:53.070' AS DateTime))
INSERT [Base].[LoginLog] ([Login_ID], [Login_Name], [Login_Nicker], [Login_IP], [Login_Time]) VALUES (382, N'admin', N'超级管理员', N'192.168.40.35', CAST(N'2017-05-17 11:10:53.720' AS DateTime))
SET IDENTITY_INSERT [Base].[LoginLog] OFF
SET IDENTITY_INSERT [Base].[Menu] ON 

INSERT [Base].[Menu] ([Menu_ID], [Menu_Name], [Menu_Url], [Menu_ParentID], [Menu_Order], [Menu_Icon], [IsVisible], [Create_Time], [Update_Time]) VALUES (1, N'系统设置', N'youare', NULL, 1, N'glyphicon glyphicon-text59', 1, CAST(N'2016-03-21 14:33:02.930' AS DateTime), NULL)
INSERT [Base].[Menu] ([Menu_ID], [Menu_Name], [Menu_Url], [Menu_ParentID], [Menu_Order], [Menu_Icon], [IsVisible], [Create_Time], [Update_Time]) VALUES (4, N'用户管理', N'/User/Index', 1, 1, N'glyphicon glyphicon-text57', 1, CAST(N'2016-03-21 14:33:02.930' AS DateTime), NULL)
INSERT [Base].[Menu] ([Menu_ID], [Menu_Name], [Menu_Url], [Menu_ParentID], [Menu_Order], [Menu_Icon], [IsVisible], [Create_Time], [Update_Time]) VALUES (5, N'角色管理', N'/Role/Index', 1, 2, N'glyphicon glyphicon-text57', 1, CAST(N'2016-03-21 14:33:02.930' AS DateTime), NULL)
INSERT [Base].[Menu] ([Menu_ID], [Menu_Name], [Menu_Url], [Menu_ParentID], [Menu_Order], [Menu_Icon], [IsVisible], [Create_Time], [Update_Time]) VALUES (9, N'菜单管理', N'/Menu/Index', 1, 4, N'glyphicon glyphicon-text58', 1, CAST(N'2016-03-21 14:33:02.930' AS DateTime), NULL)
INSERT [Base].[Menu] ([Menu_ID], [Menu_Name], [Menu_Url], [Menu_ParentID], [Menu_Order], [Menu_Icon], [IsVisible], [Create_Time], [Update_Time]) VALUES (28, N'按钮管理', N'/Button/Index', 1, 5, N'glyphicon glyphicon-text2', 0, CAST(N'2016-03-23 09:56:14.143' AS DateTime), NULL)
INSERT [Base].[Menu] ([Menu_ID], [Menu_Name], [Menu_Url], [Menu_ParentID], [Menu_Order], [Menu_Icon], [IsVisible], [Create_Time], [Update_Time]) VALUES (29, N'统计报表', N'', NULL, 2, N'glyphicon glyphicon-text23', 0, CAST(N'2016-03-23 10:17:21.763' AS DateTime), NULL)
INSERT [Base].[Menu] ([Menu_ID], [Menu_Name], [Menu_Url], [Menu_ParentID], [Menu_Order], [Menu_Icon], [IsVisible], [Create_Time], [Update_Time]) VALUES (30, N'日志管理', N'/Log/Index', 1, 7, N'glyphicon glyphicon-text27', 0, CAST(N'2016-03-23 10:19:02.620' AS DateTime), NULL)
INSERT [Base].[Menu] ([Menu_ID], [Menu_Name], [Menu_Url], [Menu_ParentID], [Menu_Order], [Menu_Icon], [IsVisible], [Create_Time], [Update_Time]) VALUES (31, N'核心业务', N'', NULL, 3, N'glyphicon glyphicon-text16', 0, CAST(N'2016-03-23 13:49:45.340' AS DateTime), NULL)
INSERT [Base].[Menu] ([Menu_ID], [Menu_Name], [Menu_Url], [Menu_ParentID], [Menu_Order], [Menu_Icon], [IsVisible], [Create_Time], [Update_Time]) VALUES (32, N'组织结构', N'', 29, 6, N'glyphicon glyphicon-text5', 0, CAST(N'2016-03-23 13:50:59.197' AS DateTime), NULL)
INSERT [Base].[Menu] ([Menu_ID], [Menu_Name], [Menu_Url], [Menu_ParentID], [Menu_Order], [Menu_Icon], [IsVisible], [Create_Time], [Update_Time]) VALUES (33, N'数据字典', N'/Dictionary/Index', 1, 6, N'glyphicon glyphicon-text', 0, CAST(N'2016-03-23 15:21:15.297' AS DateTime), NULL)
SET IDENTITY_INSERT [Base].[Menu] OFF
SET IDENTITY_INSERT [Base].[Menu_Button] ON 

INSERT [Base].[Menu_Button] ([ID], [Menu_ID], [Button_ID], [OrderBy]) VALUES (22, 35, 3, 1)
INSERT [Base].[Menu_Button] ([ID], [Menu_ID], [Button_ID], [OrderBy]) VALUES (23, 35, 1, 2)
INSERT [Base].[Menu_Button] ([ID], [Menu_ID], [Button_ID], [OrderBy]) VALUES (24, 35, 4, 3)
INSERT [Base].[Menu_Button] ([ID], [Menu_ID], [Button_ID], [OrderBy]) VALUES (25, 35, 2, 4)
INSERT [Base].[Menu_Button] ([ID], [Menu_ID], [Button_ID], [OrderBy]) VALUES (26, 32, 1, 1)
INSERT [Base].[Menu_Button] ([ID], [Menu_ID], [Button_ID], [OrderBy]) VALUES (27, 32, 2, 2)
INSERT [Base].[Menu_Button] ([ID], [Menu_ID], [Button_ID], [OrderBy]) VALUES (28, 32, 3, 3)
INSERT [Base].[Menu_Button] ([ID], [Menu_ID], [Button_ID], [OrderBy]) VALUES (36, 4, 1, 1)
INSERT [Base].[Menu_Button] ([ID], [Menu_ID], [Button_ID], [OrderBy]) VALUES (37, 4, 2, 2)
INSERT [Base].[Menu_Button] ([ID], [Menu_ID], [Button_ID], [OrderBy]) VALUES (38, 4, 11, 3)
INSERT [Base].[Menu_Button] ([ID], [Menu_ID], [Button_ID], [OrderBy]) VALUES (39, 4, 10, 4)
INSERT [Base].[Menu_Button] ([ID], [Menu_ID], [Button_ID], [OrderBy]) VALUES (10, 33, 1, 1)
INSERT [Base].[Menu_Button] ([ID], [Menu_ID], [Button_ID], [OrderBy]) VALUES (11, 33, 2, 2)
INSERT [Base].[Menu_Button] ([ID], [Menu_ID], [Button_ID], [OrderBy]) VALUES (12, 33, 3, 3)
INSERT [Base].[Menu_Button] ([ID], [Menu_ID], [Button_ID], [OrderBy]) VALUES (13, 33, 4, 4)
INSERT [Base].[Menu_Button] ([ID], [Menu_ID], [Button_ID], [OrderBy]) VALUES (50, 43, 1, 1)
INSERT [Base].[Menu_Button] ([ID], [Menu_ID], [Button_ID], [OrderBy]) VALUES (51, 43, 2, 2)
INSERT [Base].[Menu_Button] ([ID], [Menu_ID], [Button_ID], [OrderBy]) VALUES (52, 43, 3, 3)
INSERT [Base].[Menu_Button] ([ID], [Menu_ID], [Button_ID], [OrderBy]) VALUES (53, 5, 9, 1)
INSERT [Base].[Menu_Button] ([ID], [Menu_ID], [Button_ID], [OrderBy]) VALUES (54, 5, 10, 2)
SET IDENTITY_INSERT [Base].[Menu_Button] OFF
SET IDENTITY_INSERT [Base].[Role] ON 

INSERT [Base].[Role] ([Role_ID], [Role_Name], [Role_Description], [Create_Time], [Update_Time]) VALUES (1, N'管理员', N'超级管理员', CAST(N'2016-03-03 00:00:00.000' AS DateTime), NULL)
INSERT [Base].[Role] ([Role_ID], [Role_Name], [Role_Description], [Create_Time], [Update_Time]) VALUES (2, N'操作员', N'处理申请单的', CAST(N'2016-03-03 00:00:00.000' AS DateTime), NULL)
INSERT [Base].[Role] ([Role_ID], [Role_Name], [Role_Description], [Create_Time], [Update_Time]) VALUES (3, N'部门经理', N'管理者', CAST(N'2016-03-04 00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [Base].[Role] OFF
SET IDENTITY_INSERT [Base].[Role_Button] ON 

INSERT [Base].[Role_Button] ([ID], [Role_ID], [Menu_ID], [Button_ID]) VALUES (33, 3, 4, 1)
INSERT [Base].[Role_Button] ([ID], [Role_ID], [Menu_ID], [Button_ID]) VALUES (34, 3, 4, 2)
INSERT [Base].[Role_Button] ([ID], [Role_ID], [Menu_ID], [Button_ID]) VALUES (35, 3, 4, 11)
INSERT [Base].[Role_Button] ([ID], [Role_ID], [Menu_ID], [Button_ID]) VALUES (93, 1, 4, 1)
INSERT [Base].[Role_Button] ([ID], [Role_ID], [Menu_ID], [Button_ID]) VALUES (94, 1, 4, 2)
INSERT [Base].[Role_Button] ([ID], [Role_ID], [Menu_ID], [Button_ID]) VALUES (95, 1, 4, 11)
INSERT [Base].[Role_Button] ([ID], [Role_ID], [Menu_ID], [Button_ID]) VALUES (96, 1, 4, 10)
INSERT [Base].[Role_Button] ([ID], [Role_ID], [Menu_ID], [Button_ID]) VALUES (36, 3, 4, 10)
INSERT [Base].[Role_Button] ([ID], [Role_ID], [Menu_ID], [Button_ID]) VALUES (97, 1, 33, 1)
INSERT [Base].[Role_Button] ([ID], [Role_ID], [Menu_ID], [Button_ID]) VALUES (98, 1, 33, 2)
INSERT [Base].[Role_Button] ([ID], [Role_ID], [Menu_ID], [Button_ID]) VALUES (99, 1, 33, 3)
INSERT [Base].[Role_Button] ([ID], [Role_ID], [Menu_ID], [Button_ID]) VALUES (100, 1, 33, 4)
SET IDENTITY_INSERT [Base].[Role_Button] OFF
SET IDENTITY_INSERT [Base].[Role_Menu] ON 

INSERT [Base].[Role_Menu] ([RoleMenu_ID], [Role_ID], [Menu_ID]) VALUES (24, 1, 34)
INSERT [Base].[Role_Menu] ([RoleMenu_ID], [Role_ID], [Menu_ID]) VALUES (14, 3, 4)
INSERT [Base].[Role_Menu] ([RoleMenu_ID], [Role_ID], [Menu_ID]) VALUES (15, 3, 5)
INSERT [Base].[Role_Menu] ([RoleMenu_ID], [Role_ID], [Menu_ID]) VALUES (4, 1, 8)
INSERT [Base].[Role_Menu] ([RoleMenu_ID], [Role_ID], [Menu_ID]) VALUES (5, 2, 1)
INSERT [Base].[Role_Menu] ([RoleMenu_ID], [Role_ID], [Menu_ID]) VALUES (6, 2, 4)
INSERT [Base].[Role_Menu] ([RoleMenu_ID], [Role_ID], [Menu_ID]) VALUES (10, 2, 5)
INSERT [Base].[Role_Menu] ([RoleMenu_ID], [Role_ID], [Menu_ID]) VALUES (16, 3, 9)
INSERT [Base].[Role_Menu] ([RoleMenu_ID], [Role_ID], [Menu_ID]) VALUES (17, 3, 28)
INSERT [Base].[Role_Menu] ([RoleMenu_ID], [Role_ID], [Menu_ID]) VALUES (18, 3, 30)
INSERT [Base].[Role_Menu] ([RoleMenu_ID], [Role_ID], [Menu_ID]) VALUES (25, 1, 35)
INSERT [Base].[Role_Menu] ([RoleMenu_ID], [Role_ID], [Menu_ID]) VALUES (22, 1, 4)
INSERT [Base].[Role_Menu] ([RoleMenu_ID], [Role_ID], [Menu_ID]) VALUES (23, 1, 33)
INSERT [Base].[Role_Menu] ([RoleMenu_ID], [Role_ID], [Menu_ID]) VALUES (26, 1, 36)
INSERT [Base].[Role_Menu] ([RoleMenu_ID], [Role_ID], [Menu_ID]) VALUES (27, 1, 37)
INSERT [Base].[Role_Menu] ([RoleMenu_ID], [Role_ID], [Menu_ID]) VALUES (28, 1, 38)
INSERT [Base].[Role_Menu] ([RoleMenu_ID], [Role_ID], [Menu_ID]) VALUES (29, 1, 39)
INSERT [Base].[Role_Menu] ([RoleMenu_ID], [Role_ID], [Menu_ID]) VALUES (30, 1, 40)
INSERT [Base].[Role_Menu] ([RoleMenu_ID], [Role_ID], [Menu_ID]) VALUES (31, 1, 41)
INSERT [Base].[Role_Menu] ([RoleMenu_ID], [Role_ID], [Menu_ID]) VALUES (32, 1, 42)
INSERT [Base].[Role_Menu] ([RoleMenu_ID], [Role_ID], [Menu_ID]) VALUES (33, 1, 43)
INSERT [Base].[Role_Menu] ([RoleMenu_ID], [Role_ID], [Menu_ID]) VALUES (34, 1, 1)
SET IDENTITY_INSERT [Base].[Role_Menu] OFF
SET IDENTITY_INSERT [Base].[User] ON 

INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (1, N'admin', N'123456', N'超级管理员', N'20160423heel.jpg', 1, 1, CAST(N'2016-12-12 00:00:00.000' AS DateTime), CAST(N'2016-12-12 00:00:00.000' AS DateTime), N'好皇帝')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (2, N'admin1', N'123456', N'管理员1', NULL, 1, 1, CAST(N'2016-03-14 09:53:14.380' AS DateTime), CAST(N'2016-03-14 09:53:14.380' AS DateTime), N'内阁总管')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (3, N'admin2', N'123456', N'管理员2', NULL, 1, 1, CAST(N'2016-03-14 09:53:27.910' AS DateTime), CAST(N'2016-03-14 09:53:27.910' AS DateTime), N'内阁总管')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (4, N'admin3', N'123456', N'管理员3', NULL, 1, 1, CAST(N'2016-03-14 09:53:36.367' AS DateTime), CAST(N'2016-03-14 09:53:36.367' AS DateTime), N'内阁总管')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (5, N'admin4', N'123456', N'管理员4', NULL, 1, 1, CAST(N'2016-03-14 09:53:45.683' AS DateTime), CAST(N'2016-03-14 09:53:45.683' AS DateTime), N'内阁总管')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (6, N'admin5', N'123456', N'管理员5', NULL, 1, 1, CAST(N'2016-03-14 09:53:57.647' AS DateTime), CAST(N'2016-03-14 09:53:57.647' AS DateTime), N'内阁总管')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (7, N'admin6', N'123456', N'管理员6', NULL, 1, 1, CAST(N'2016-03-14 09:54:05.393' AS DateTime), CAST(N'2016-03-14 09:54:05.393' AS DateTime), N'内阁总管')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (8, N'admin7', N'123456', N'管理员7', NULL, 1, 1, CAST(N'2016-03-14 09:54:12.717' AS DateTime), CAST(N'2016-03-14 09:54:12.717' AS DateTime), N'内阁总管')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (9, N'admin8', N'123456', N'管理员8', NULL, 1, 1, CAST(N'2016-03-14 09:54:21.290' AS DateTime), CAST(N'2016-03-14 09:54:21.290' AS DateTime), N'内阁总管')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (10, N'admin9', N'123456', N'管理员9', NULL, 1, 1, CAST(N'2016-03-14 09:54:29.183' AS DateTime), CAST(N'2016-03-14 09:54:29.183' AS DateTime), N'内阁总管')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (11, N'admin10', N'123456', N'管理员10', NULL, 2, 1, CAST(N'2016-03-14 09:54:36.927' AS DateTime), CAST(N'2016-03-14 09:54:36.927' AS DateTime), N'内阁总管')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (12, N'admin11', N'123456', N'管理员11', NULL, 2, 1, CAST(N'2016-03-14 09:54:44.440' AS DateTime), CAST(N'2016-03-14 09:54:44.440' AS DateTime), N'内阁总管')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (13, N'admin12', N'123456', N'管理员12', NULL, 2, 1, CAST(N'2016-03-14 09:54:52.293' AS DateTime), CAST(N'2016-03-14 09:54:52.293' AS DateTime), N'内阁总管')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (14, N'admin13', N'123456', N'管理员13', NULL, 1, 1, CAST(N'2016-03-14 09:54:59.203' AS DateTime), CAST(N'2016-03-14 09:54:59.203' AS DateTime), N'内阁总管')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (15, N'admin14', N'123456', N'管理员14', NULL, 1, 1, CAST(N'2016-03-14 09:55:07.010' AS DateTime), CAST(N'2016-03-14 09:55:07.010' AS DateTime), N'内阁总管')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (16, N'admin15', N'123456', N'管理员15', NULL, 1, 1, CAST(N'2016-03-14 09:55:14.960' AS DateTime), CAST(N'2016-03-14 09:55:14.960' AS DateTime), N'内阁总管')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (17, N'admin16', N'123456', N'管理员16', NULL, 1, 1, CAST(N'2016-03-14 09:55:22.100' AS DateTime), CAST(N'2016-03-14 09:55:22.100' AS DateTime), N'内阁总管')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (18, N'moon1', N'123456', N'第五种族', NULL, 2, 0, CAST(N'2016-03-14 09:55:28.757' AS DateTime), CAST(N'2016-05-06 11:54:56.673' AS DateTime), NULL)
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (19, N'admin18', N'123456', N'管理员18', NULL, 1, 0, CAST(N'2016-03-14 09:55:36.713' AS DateTime), CAST(N'2016-03-14 09:55:36.713' AS DateTime), N'内阁总管')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (20, N'admin19', N'123456', N'管理员19', NULL, 1, 1, CAST(N'2016-03-14 09:55:43.930' AS DateTime), CAST(N'2016-03-14 09:55:43.930' AS DateTime), N'内阁总管')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (21, N'admin20', N'123456', N'管理员20', NULL, 1, 1, CAST(N'2016-03-14 09:55:53.020' AS DateTime), CAST(N'2016-03-14 09:55:53.020' AS DateTime), N'内阁总管')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (22, N'admin21', N'123456', N'管理员21', NULL, 1, 1, CAST(N'2016-03-14 09:56:01.597' AS DateTime), CAST(N'2016-03-14 09:56:01.597' AS DateTime), N'内阁总管')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (23, N'admin22', N'123456', N'管理员22', NULL, 1, 1, CAST(N'2016-03-14 09:56:08.280' AS DateTime), CAST(N'2016-03-14 09:56:08.280' AS DateTime), N'内阁总管')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (24, N'admin23', N'123456', N'管理员23', NULL, 1, 1, CAST(N'2016-03-14 09:56:15.353' AS DateTime), CAST(N'2016-03-14 09:56:15.353' AS DateTime), N'内阁总管')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (25, N'admin24', N'123456', N'管理员24', NULL, 1, 1, CAST(N'2016-03-14 09:56:24.387' AS DateTime), CAST(N'2016-03-14 09:56:24.387' AS DateTime), N'内阁总管')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (26, N'admin25', N'123456', N'管理员25', NULL, 1, 1, CAST(N'2016-03-14 09:56:31.940' AS DateTime), CAST(N'2016-03-14 09:56:31.940' AS DateTime), N'内阁总管')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (27, N'whywhy898', N'123456', N'小红红', NULL, 1, 1, CAST(N'2016-03-16 17:09:55.080' AS DateTime), NULL, N'也许吧')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (28, N'whywhy999', N'123456', N'小绿绿', NULL, 1, 0, CAST(N'2016-03-16 17:23:47.013' AS DateTime), NULL, N'你好')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (29, N'laoWang', N'123456', N'老王', NULL, 2, 1, CAST(N'2016-03-16 17:28:39.153' AS DateTime), CAST(N'2016-04-14 17:23:59.163' AS DateTime), N'老虎来了')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (30, N'xiaoniu', N'123456', N'大妞', NULL, 1, 1, CAST(N'2016-03-17 14:55:51.760' AS DateTime), CAST(N'2016-03-17 15:25:23.490' AS DateTime), N'这是我的大妞谁都别动！~')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (31, N'nana', N'123456', N'娜就是神', N'20160423-nana.jpg', 1, 0, CAST(N'2016-04-15 14:02:09.457' AS DateTime), CAST(N'2016-04-23 14:52:52.183' AS DateTime), N'我去恶趣味')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (32, N'jimi', N'123456', N'吉米1', N'20160423-fd7bc8df93a2c6b56cd328e7b968c6f9.jpg', 2, 1, CAST(N'2016-04-23 14:57:06.937' AS DateTime), CAST(N'2016-04-23 15:47:10.183' AS DateTime), N'吉米小子里面的主角')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (33, N'Envrioment', N'123456', N'环境', N'', 2, 0, CAST(N'2016-05-06 11:36:48.623' AS DateTime), NULL, NULL)
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (34, N'sky', N'123123', N'天王', N'', 2, 0, CAST(N'2016-05-06 11:55:48.913' AS DateTime), NULL, NULL)
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (35, N'why778', N'123456', N'小杰', N'', 3, 1, CAST(N'2017-04-07 10:30:12.873' AS DateTime), NULL, N'只是个天才')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (36, N'layer1', N'123456', N'弹出层', N'20170425-u=2264996490,553047999&fm=23&gp=0.jpg', 3, 0, CAST(N'2017-04-25 18:00:09.177' AS DateTime), CAST(N'2017-05-10 17:34:43.747' AS DateTime), N'第一次请求')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (37, N'layer2', N'123456', N'弹出层2', N'20170425-u=1278896632,2852512441&fm=11&gp=0.jpg', 3, 0, CAST(N'2017-04-25 18:04:17.637' AS DateTime), NULL, N'123123123123')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (38, N'layer3', N'123456', N'adawd', N'', 3, 0, CAST(N'2017-04-25 18:05:20.007' AS DateTime), NULL, NULL)
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (39, N'layer4', N'123456', N'小鳄鱼1', N'20170426-u=1628747648,1114534703fm=23gp=0.jpg', 3, 0, CAST(N'2017-04-26 10:16:39.323' AS DateTime), CAST(N'2017-04-26 14:20:02.603' AS DateTime), N'我是一只鳄鱼王1')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (40, N'layer5', N'123456', N'关羽', N'20170426-u=3022300017,1716944448fm=11gp=0.jpg.png', 3, 1, CAST(N'2017-04-26 15:18:45.340' AS DateTime), CAST(N'2017-05-11 14:41:24.023' AS DateTime), N'阿斯达是大势')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (41, N'liubang', N'123456', N'刘邦101', N'20170512-u=2264996490,553047999fm=23gp=0.jpg', 1, 1, CAST(N'2017-05-12 10:31:44.077' AS DateTime), CAST(N'2017-05-12 10:31:55.907' AS DateTime), N'刘邦牛逼')
INSERT [Base].[User] ([User_ID], [User_Name], [User_Password], [User_Reallyname], [HeadPortrait], [Department_ID], [IsEnable], [Create_Time], [Update_Time], [Remark]) VALUES (42, N'ezx', N'ezx', N'ezx', N'', 1, 1, CAST(N'2017-06-05 11:35:50.577' AS DateTime), CAST(N'2017-06-05 11:38:11.983' AS DateTime), N'但是发')
SET IDENTITY_INSERT [Base].[User] OFF
SET IDENTITY_INSERT [Base].[User_Role] ON 

INSERT [Base].[User_Role] ([ID], [User_ID], [Role_ID]) VALUES (33, 31, 2)
INSERT [Base].[User_Role] ([ID], [User_ID], [Role_ID]) VALUES (28, 1, 2)
INSERT [Base].[User_Role] ([ID], [User_ID], [Role_ID]) VALUES (29, 1, 3)
INSERT [Base].[User_Role] ([ID], [User_ID], [Role_ID]) VALUES (30, 30, 2)
INSERT [Base].[User_Role] ([ID], [User_ID], [Role_ID]) VALUES (31, 30, 3)
INSERT [Base].[User_Role] ([ID], [User_ID], [Role_ID]) VALUES (34, 31, 3)
INSERT [Base].[User_Role] ([ID], [User_ID], [Role_ID]) VALUES (32, 1, 1)
INSERT [Base].[User_Role] ([ID], [User_ID], [Role_ID]) VALUES (35, 40, 1)
INSERT [Base].[User_Role] ([ID], [User_ID], [Role_ID]) VALUES (36, 39, 1)
INSERT [Base].[User_Role] ([ID], [User_ID], [Role_ID]) VALUES (41, 41, 3)
INSERT [Base].[User_Role] ([ID], [User_ID], [Role_ID]) VALUES (39, 38, 1)
INSERT [Base].[User_Role] ([ID], [User_ID], [Role_ID]) VALUES (40, 38, 2)
SET IDENTITY_INSERT [Base].[User_Role] OFF
SET IDENTITY_INSERT [Test].[Account] ON 

INSERT [Test].[Account] ([AccountID], [TestID], [Total]) VALUES (1, 4, 800)
SET IDENTITY_INSERT [Test].[Account] OFF
SET IDENTITY_INSERT [Test].[test] ON 

INSERT [Test].[test] ([ID], [Name], [age]) VALUES (4, N'whywhy898', 31)
SET IDENTITY_INSERT [Test].[test] OFF
USE [master]
GO
ALTER DATABASE [DDit] SET  READ_WRITE 
GO
