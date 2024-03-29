USE [Ciemesus-DB]
GO
/****** Object:  DatabaseRole [aspnet_Membership_BasicAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE ROLE [aspnet_Membership_BasicAccess]
GO
/****** Object:  DatabaseRole [aspnet_Membership_FullAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE ROLE [aspnet_Membership_FullAccess]
GO
/****** Object:  DatabaseRole [aspnet_Membership_ReportingAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE ROLE [aspnet_Membership_ReportingAccess]
GO
/****** Object:  DatabaseRole [aspnet_Personalization_BasicAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE ROLE [aspnet_Personalization_BasicAccess]
GO
/****** Object:  DatabaseRole [aspnet_Personalization_FullAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE ROLE [aspnet_Personalization_FullAccess]
GO
/****** Object:  DatabaseRole [aspnet_Personalization_ReportingAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE ROLE [aspnet_Personalization_ReportingAccess]
GO
/****** Object:  DatabaseRole [aspnet_Profile_BasicAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE ROLE [aspnet_Profile_BasicAccess]
GO
/****** Object:  DatabaseRole [aspnet_Profile_FullAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE ROLE [aspnet_Profile_FullAccess]
GO
/****** Object:  DatabaseRole [aspnet_Profile_ReportingAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE ROLE [aspnet_Profile_ReportingAccess]
GO
/****** Object:  DatabaseRole [aspnet_Roles_BasicAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE ROLE [aspnet_Roles_BasicAccess]
GO
/****** Object:  DatabaseRole [aspnet_Roles_FullAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE ROLE [aspnet_Roles_FullAccess]
GO
/****** Object:  DatabaseRole [aspnet_Roles_ReportingAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE ROLE [aspnet_Roles_ReportingAccess]
GO
/****** Object:  DatabaseRole [aspnet_WebEvent_FullAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE ROLE [aspnet_WebEvent_FullAccess]
GO
/****** Object:  Schema [aspnet_Membership_BasicAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE SCHEMA [aspnet_Membership_BasicAccess]
GO
/****** Object:  Schema [aspnet_Membership_FullAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE SCHEMA [aspnet_Membership_FullAccess]
GO
/****** Object:  Schema [aspnet_Membership_ReportingAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE SCHEMA [aspnet_Membership_ReportingAccess]
GO
/****** Object:  Schema [aspnet_Personalization_BasicAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE SCHEMA [aspnet_Personalization_BasicAccess]
GO
/****** Object:  Schema [aspnet_Personalization_FullAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE SCHEMA [aspnet_Personalization_FullAccess]
GO
/****** Object:  Schema [aspnet_Personalization_ReportingAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE SCHEMA [aspnet_Personalization_ReportingAccess]
GO
/****** Object:  Schema [aspnet_Profile_BasicAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE SCHEMA [aspnet_Profile_BasicAccess]
GO
/****** Object:  Schema [aspnet_Profile_FullAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE SCHEMA [aspnet_Profile_FullAccess]
GO
/****** Object:  Schema [aspnet_Profile_ReportingAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE SCHEMA [aspnet_Profile_ReportingAccess]
GO
/****** Object:  Schema [aspnet_Roles_BasicAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE SCHEMA [aspnet_Roles_BasicAccess]
GO
/****** Object:  Schema [aspnet_Roles_FullAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE SCHEMA [aspnet_Roles_FullAccess]
GO
/****** Object:  Schema [aspnet_Roles_ReportingAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE SCHEMA [aspnet_Roles_ReportingAccess]
GO
/****** Object:  Schema [aspnet_WebEvent_FullAccess]    Script Date: 4/6/2014 4:59:03 PM ******/
CREATE SCHEMA [aspnet_WebEvent_FullAccess]
GO
/****** Object:  Table [dbo].[aspnet_Applications]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Applications](
	[ApplicationName] [nvarchar](256) NOT NULL,
	[LoweredApplicationName] [nvarchar](256) NOT NULL,
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](256) NULL,
 CONSTRAINT [PK__aspnet_A__C93A4C9824927208] PRIMARY KEY NONCLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__aspnet_A__17477DE4276EDEB3] UNIQUE NONCLUSTERED 
(
	[LoweredApplicationName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__aspnet_A__309103312A4B4B5E] UNIQUE NONCLUSTERED 
(
	[ApplicationName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[aspnet_Membership]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Membership](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordFormat] [int] NOT NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[MobilePIN] [nvarchar](16) NULL,
	[Email] [nvarchar](256) NULL,
	[LoweredEmail] [nvarchar](256) NULL,
	[PasswordQuestion] [nvarchar](256) NULL,
	[PasswordAnswer] [nvarchar](128) NULL,
	[IsApproved] [bit] NOT NULL,
	[IsLockedOut] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[LastPasswordChangedDate] [datetime] NOT NULL,
	[LastLockoutDate] [datetime] NOT NULL,
	[FailedPasswordAttemptCount] [int] NOT NULL,
	[FailedPasswordAttemptWindowStart] [datetime] NOT NULL,
	[FailedPasswordAnswerAttemptCount] [int] NOT NULL,
	[FailedPasswordAnswerAttemptWindowStart] [datetime] NOT NULL,
	[Comment] [ntext] NULL,
 CONSTRAINT [PK__aspnet_M__1788CC4D4316F928] PRIMARY KEY NONCLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[aspnet_Paths]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Paths](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[PathId] [uniqueidentifier] NOT NULL,
	[Path] [nvarchar](256) NOT NULL,
	[LoweredPath] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK__aspnet_P__CD67DC587C4F7684] PRIMARY KEY NONCLUSTERED 
(
	[PathId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[aspnet_PersonalizationAllUsers]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_PersonalizationAllUsers](
	[PathId] [uniqueidentifier] NOT NULL,
	[PageSettings] [image] NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK__aspnet_P__CD67DC5903F0984C] PRIMARY KEY CLUSTERED 
(
	[PathId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[aspnet_PersonalizationPerUser]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_PersonalizationPerUser](
	[Id] [uniqueidentifier] NOT NULL,
	[PathId] [uniqueidentifier] NULL,
	[UserId] [uniqueidentifier] NULL,
	[PageSettings] [image] NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK__aspnet_P__3214EC0608B54D69] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[aspnet_Profile]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Profile](
	[UserId] [uniqueidentifier] NOT NULL,
	[PropertyNames] [ntext] NOT NULL,
	[PropertyValuesString] [ntext] NOT NULL,
	[PropertyValuesBinary] [image] NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK__aspnet_P__1788CC4C59FA5E80] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[aspnet_Roles]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Roles](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
	[LoweredRoleName] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](256) NULL,
 CONSTRAINT [PK__aspnet_R__8AFACE1B656C112C] PRIMARY KEY NONCLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[aspnet_SchemaVersions]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_SchemaVersions](
	[Feature] [nvarchar](128) NOT NULL,
	[CompatibleSchemaVersion] [nvarchar](128) NOT NULL,
	[IsCurrentVersion] [bit] NOT NULL,
 CONSTRAINT [PK__aspnet_S__5A1E6BC136B12243] PRIMARY KEY CLUSTERED 
(
	[Feature] ASC,
	[CompatibleSchemaVersion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[aspnet_Users]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Users](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[LoweredUserName] [nvarchar](256) NOT NULL,
	[MobileAlias] [nvarchar](16) NULL,
	[IsAnonymous] [bit] NOT NULL,
	[LastActivityDate] [datetime] NOT NULL,
 CONSTRAINT [PK__aspnet_U__1788CC4D25869641] PRIMARY KEY NONCLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[aspnet_UsersInRoles]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_UsersInRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK__aspnet_U__AF2760AD6B24EA82] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[aspnet_WebEvent_Events]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[aspnet_WebEvent_Events](
	[EventId] [char](32) NOT NULL,
	[EventTimeUtc] [datetime] NOT NULL,
	[EventTime] [datetime] NOT NULL,
	[EventType] [nvarchar](256) NOT NULL,
	[EventSequence] [decimal](19, 0) NOT NULL,
	[EventOccurrence] [decimal](19, 0) NOT NULL,
	[EventCode] [int] NOT NULL,
	[EventDetailCode] [int] NOT NULL,
	[Message] [nvarchar](1024) NULL,
	[ApplicationPath] [nvarchar](256) NULL,
	[ApplicationVirtualPath] [nvarchar](256) NULL,
	[MachineName] [nvarchar](256) NOT NULL,
	[RequestUrl] [nvarchar](1024) NULL,
	[ExceptionType] [nvarchar](256) NULL,
	[Details] [ntext] NULL,
 CONSTRAINT [PK__aspnet_W__7944C8101CBC4616] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ciemesus_htLanguages]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciemesus_htLanguages](
	[IDLanguage] [tinyint] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[IsRTL] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDefault] [bit] NOT NULL,
	[Priority] [int] NULL,
 CONSTRAINT [PK_Ciemesus_htLanguages] PRIMARY KEY CLUSTERED 
(
	[IDLanguage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ciemesus_htMediaSubjectTypes]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciemesus_htMediaSubjectTypes](
	[IDMediaSubjectType] [tinyint] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Ciemesus_htMediaSubjectTypes] PRIMARY KEY CLUSTERED 
(
	[IDMediaSubjectType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ciemesus_htPropertyTypes]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciemesus_htPropertyTypes](
	[IDType] [tinyint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Ciemesus_htPropertyTypes] PRIMARY KEY CLUSTERED 
(
	[IDType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ciemesus_htSubjectTypes]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciemesus_htSubjectTypes](
	[IDSubjectType] [tinyint] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Priority] [int] NULL,
 CONSTRAINT [PK_Ciemesus_htSubjectTypes] PRIMARY KEY CLUSTERED 
(
	[IDSubjectType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ciemesus_tGalleryPlugins]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciemesus_tGalleryPlugins](
	[IDSubject] [uniqueidentifier] NOT NULL,
	[IDPlugin] [int] NOT NULL,
	[Options] [nvarchar](max) NULL,
	[CSS] [nvarchar](max) NULL,
	[DateFormat] [nvarchar](50) NULL,
	[GenerateTitle] [bit] NULL,
	[GenerateDesc] [bit] NULL,
	[GenerateDate] [bit] NULL,
	[GenerateAnchor] [bit] NULL,
 CONSTRAINT [PK_Ciemesus_tSubjectPlugins] PRIMARY KEY CLUSTERED 
(
	[IDSubject] ASC,
	[IDPlugin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ciemesus_tLogs]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciemesus_tLogs](
	[IDLog] [bigint] NOT NULL,
	[ModuleName] [nvarchar](128) NULL,
	[XML] [xml] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[UserID] [uniqueidentifier] NOT NULL,
	[UserFullName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Ciemesus_tLogs] PRIMARY KEY CLUSTERED 
(
	[IDLog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ciemesus_tMedias]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciemesus_tMedias](
	[IDMedia] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](128) NOT NULL,
	[FileExtention] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](512) NULL,
	[Date] [datetime] NOT NULL,
	[Url] [nvarchar](256) NULL,
 CONSTRAINT [PK_Ciemesus_tMedia] PRIMARY KEY CLUSTERED 
(
	[IDMedia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ciemesus_tMediaSubjects]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciemesus_tMediaSubjects](
	[IDMedia] [int] NOT NULL,
	[IDSubject] [uniqueidentifier] NOT NULL,
	[IDMediaSubjectType] [tinyint] NOT NULL,
	[Priority] [int] NULL,
 CONSTRAINT [PK_Ciemesus_tMediaSubjects_1] PRIMARY KEY CLUSTERED 
(
	[IDMedia] ASC,
	[IDSubject] ASC,
	[IDMediaSubjectType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ciemesus_tMembers]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciemesus_tMembers](
	[IDMember] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Ciemesus_tMembers] PRIMARY KEY CLUSTERED 
(
	[IDMember] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ciemesus_tPlugins]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciemesus_tPlugins](
	[IDPlugin] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[JSfileName] [nvarchar](256) NOT NULL,
	[Version] [nvarchar](128) NULL,
	[Description] [nvarchar](max) NULL,
	[Settings] [nvarchar](max) NULL,
	[Css] [nvarchar](max) NULL,
	[JSinit] [nvarchar](max) NULL,
 CONSTRAINT [PK_Ciemesus_tPlugins] PRIMARY KEY CLUSTERED 
(
	[IDPlugin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ciemesus_tProperties]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciemesus_tProperties](
	[IDProperty] [int] IDENTITY(1,1) NOT NULL,
	[IDLanguage] [tinyint] NOT NULL,
	[IDType] [tinyint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Ciemesus_tProperties] PRIMARY KEY CLUSTERED 
(
	[IDProperty] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ciemesus_tPropertyItems]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciemesus_tPropertyItems](
	[IDPropertyItem] [int] IDENTITY(1,1) NOT NULL,
	[IDProperty] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Priority] [int] NULL,
 CONSTRAINT [PK_Ciemesus_tPropertyItem] PRIMARY KEY CLUSTERED 
(
	[IDPropertyItem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ciemesus_tSubjectPlugins]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciemesus_tSubjectPlugins](
	[IDSubject] [uniqueidentifier] NOT NULL,
	[IDPlugin] [int] NOT NULL,
	[Options] [nvarchar](max) NULL,
	[CSS] [nvarchar](max) NULL,
 CONSTRAINT [PK_Ciemesus_tSubjectPlugins_1] PRIMARY KEY CLUSTERED 
(
	[IDSubject] ASC,
	[IDPlugin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ciemesus_tSubjectProperties]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciemesus_tSubjectProperties](
	[IDSubject] [uniqueidentifier] NOT NULL,
	[IDProperty] [int] NOT NULL,
	[IsSearchable] [bit] NOT NULL,
 CONSTRAINT [PK_Ciemesus_tSubjectProperties] PRIMARY KEY CLUSTERED 
(
	[IDSubject] ASC,
	[IDProperty] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ciemesus_tSubjectPropertyValues]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciemesus_tSubjectPropertyValues](
	[IDSubject] [uniqueidentifier] NOT NULL,
	[IDProperty] [int] NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Ciemesus_tSubjectPropertyValue] PRIMARY KEY CLUSTERED 
(
	[IDSubject] ASC,
	[IDProperty] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ciemesus_tSubjects]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciemesus_tSubjects](
	[IDSubject] [uniqueidentifier] NOT NULL,
	[IDSubjectType] [tinyint] NOT NULL,
	[IDParent] [uniqueidentifier] NULL,
	[IDLanguage] [tinyint] NULL,
	[IDGallery] [uniqueidentifier] NULL,
	[Title] [nvarchar](255) NULL,
	[Body] [nvarchar](max) NULL,
	[Alias] [nvarchar](128) NULL,
	[Date] [datetime] NULL,
	[IsActive] [bit] NULL,
	[BannerType] [nvarchar](50) NULL,
	[Priority] [int] NULL,
 CONSTRAINT [PK_Ciemesus_tSubjects] PRIMARY KEY CLUSTERED 
(
	[IDSubject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Users_CreateUser]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Users_CreateUser]
    @ApplicationId    uniqueidentifier,
    @UserName         nvarchar(256),
    @IsUserAnonymous  bit,
    @LastActivityDate DATETIME,
    @UserId           uniqueidentifier OUTPUT
AS
BEGIN
    IF( @UserId IS NULL )
        SELECT @UserId = NEWID()
    ELSE
    BEGIN
        IF( EXISTS( SELECT UserId FROM dbo.aspnet_Users
                    WHERE @UserId = UserId ) )
            RETURN -1
    END

    INSERT dbo.aspnet_Users (ApplicationId, UserId, UserName, LoweredUserName, IsAnonymous, LastActivityDate)
    VALUES (@ApplicationId, @UserId, @UserName, LOWER(@UserName), @IsUserAnonymous, @LastActivityDate)

    RETURN 0
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Users_DeleteUser]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Users_DeleteUser]
    @ApplicationName  nvarchar(256),
    @UserName         nvarchar(256),
    @TablesToDeleteFrom int,
    @NumTablesDeletedFrom int OUTPUT
AS
BEGIN
    DECLARE @UserId               uniqueidentifier
    SELECT  @UserId               = NULL
    SELECT  @NumTablesDeletedFrom = 0

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
	    BEGIN TRANSACTION
	    SET @TranStarted = 1
    END
    ELSE
	SET @TranStarted = 0

    DECLARE @ErrorCode   int
    DECLARE @RowCount    int

    SET @ErrorCode = 0
    SET @RowCount  = 0

    SELECT  @UserId = u.UserId
    FROM    dbo.aspnet_Users u, dbo.aspnet_Applications a
    WHERE   u.LoweredUserName       = LOWER(@UserName)
        AND u.ApplicationId         = a.ApplicationId
        AND LOWER(@ApplicationName) = a.LoweredApplicationName

    IF (@UserId IS NULL)
    BEGIN
        GOTO Cleanup
    END

    -- Delete from Membership table if (@TablesToDeleteFrom & 1) is set
    IF ((@TablesToDeleteFrom & 1) <> 0 AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_MembershipUsers') AND (type = 'V'))))
    BEGIN
        DELETE FROM dbo.aspnet_Membership WHERE @UserId = UserId

        SELECT @ErrorCode = @@ERROR,
               @RowCount = @@ROWCOUNT

        IF( @ErrorCode <> 0 )
            GOTO Cleanup

        IF (@RowCount <> 0)
            SELECT  @NumTablesDeletedFrom = @NumTablesDeletedFrom + 1
    END

    -- Delete from aspnet_UsersInRoles table if (@TablesToDeleteFrom & 2) is set
    IF ((@TablesToDeleteFrom & 2) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_UsersInRoles') AND (type = 'V'))) )
    BEGIN
        DELETE FROM dbo.aspnet_UsersInRoles WHERE @UserId = UserId

        SELECT @ErrorCode = @@ERROR,
                @RowCount = @@ROWCOUNT

        IF( @ErrorCode <> 0 )
            GOTO Cleanup

        IF (@RowCount <> 0)
            SELECT  @NumTablesDeletedFrom = @NumTablesDeletedFrom + 1
    END

    -- Delete from aspnet_Profile table if (@TablesToDeleteFrom & 4) is set
    IF ((@TablesToDeleteFrom & 4) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_Profiles') AND (type = 'V'))) )
    BEGIN
        DELETE FROM dbo.aspnet_Profile WHERE @UserId = UserId

        SELECT @ErrorCode = @@ERROR,
                @RowCount = @@ROWCOUNT

        IF( @ErrorCode <> 0 )
            GOTO Cleanup

        IF (@RowCount <> 0)
            SELECT  @NumTablesDeletedFrom = @NumTablesDeletedFrom + 1
    END

    -- Delete from aspnet_PersonalizationPerUser table if (@TablesToDeleteFrom & 8) is set
    IF ((@TablesToDeleteFrom & 8) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_WebPartState_User') AND (type = 'V'))) )
    BEGIN
        DELETE FROM dbo.aspnet_PersonalizationPerUser WHERE @UserId = UserId

        SELECT @ErrorCode = @@ERROR,
                @RowCount = @@ROWCOUNT

        IF( @ErrorCode <> 0 )
            GOTO Cleanup

        IF (@RowCount <> 0)
            SELECT  @NumTablesDeletedFrom = @NumTablesDeletedFrom + 1
    END

    -- Delete from aspnet_Users table if (@TablesToDeleteFrom & 1,2,4 & 8) are all set
    IF ((@TablesToDeleteFrom & 1) <> 0 AND
        (@TablesToDeleteFrom & 2) <> 0 AND
        (@TablesToDeleteFrom & 4) <> 0 AND
        (@TablesToDeleteFrom & 8) <> 0 AND
        (EXISTS (SELECT UserId FROM dbo.aspnet_Users WHERE @UserId = UserId)))
    BEGIN
        DELETE FROM dbo.aspnet_Users WHERE @UserId = UserId

        SELECT @ErrorCode = @@ERROR,
                @RowCount = @@ROWCOUNT

        IF( @ErrorCode <> 0 )
            GOTO Cleanup

        IF (@RowCount <> 0)
            SELECT  @NumTablesDeletedFrom = @NumTablesDeletedFrom + 1
    END

    IF( @TranStarted = 1 )
    BEGIN
	    SET @TranStarted = 0
	    COMMIT TRANSACTION
    END

    RETURN 0

Cleanup:
    SET @NumTablesDeletedFrom = 0

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
	    ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode

END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_AnyDataInTables]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_AnyDataInTables]
    @TablesToCheck int
AS
BEGIN
    -- Check Membership table if (@TablesToCheck & 1) is set
    IF ((@TablesToCheck & 1) <> 0 AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_MembershipUsers') AND (type = 'V'))))
    BEGIN
        IF (EXISTS(SELECT TOP 1 UserId FROM dbo.aspnet_Membership))
        BEGIN
            SELECT N'aspnet_Membership'
            RETURN
        END
    END

    -- Check aspnet_Roles table if (@TablesToCheck & 2) is set
    IF ((@TablesToCheck & 2) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_Roles') AND (type = 'V'))) )
    BEGIN
        IF (EXISTS(SELECT TOP 1 RoleId FROM dbo.aspnet_Roles))
        BEGIN
            SELECT N'aspnet_Roles'
            RETURN
        END
    END

    -- Check aspnet_Profile table if (@TablesToCheck & 4) is set
    IF ((@TablesToCheck & 4) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_Profiles') AND (type = 'V'))) )
    BEGIN
        IF (EXISTS(SELECT TOP 1 UserId FROM dbo.aspnet_Profile))
        BEGIN
            SELECT N'aspnet_Profile'
            RETURN
        END
    END

    -- Check aspnet_PersonalizationPerUser table if (@TablesToCheck & 8) is set
    IF ((@TablesToCheck & 8) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'vw_aspnet_WebPartState_User') AND (type = 'V'))) )
    BEGIN
        IF (EXISTS(SELECT TOP 1 UserId FROM dbo.aspnet_PersonalizationPerUser))
        BEGIN
            SELECT N'aspnet_PersonalizationPerUser'
            RETURN
        END
    END

    -- Check aspnet_PersonalizationPerUser table if (@TablesToCheck & 16) is set
    IF ((@TablesToCheck & 16) <> 0  AND
        (EXISTS (SELECT name FROM sysobjects WHERE (name = N'aspnet_WebEvent_LogEvent') AND (type = 'P'))) )
    BEGIN
        IF (EXISTS(SELECT TOP 1 * FROM dbo.aspnet_WebEvent_Events))
        BEGIN
            SELECT N'aspnet_WebEvent_Events'
            RETURN
        END
    END

    -- Check aspnet_Users table if (@TablesToCheck & 1,2,4 & 8) are all set
    IF ((@TablesToCheck & 1) <> 0 AND
        (@TablesToCheck & 2) <> 0 AND
        (@TablesToCheck & 4) <> 0 AND
        (@TablesToCheck & 8) <> 0 AND
        (@TablesToCheck & 32) <> 0 AND
        (@TablesToCheck & 128) <> 0 AND
        (@TablesToCheck & 256) <> 0 AND
        (@TablesToCheck & 512) <> 0 AND
        (@TablesToCheck & 1024) <> 0)
    BEGIN
        IF (EXISTS(SELECT TOP 1 UserId FROM dbo.aspnet_Users))
        BEGIN
            SELECT N'aspnet_Users'
            RETURN
        END
        IF (EXISTS(SELECT TOP 1 ApplicationId FROM dbo.aspnet_Applications))
        BEGIN
            SELECT N'aspnet_Applications'
            RETURN
        END
    END
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Applications_CreateApplication]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Applications_CreateApplication]
    @ApplicationName      nvarchar(256),
    @ApplicationId        uniqueidentifier OUTPUT
AS
BEGIN
    SELECT  @ApplicationId = ApplicationId FROM dbo.aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName

    IF(@ApplicationId IS NULL)
    BEGIN
        DECLARE @TranStarted   bit
        SET @TranStarted = 0

        IF( @@TRANCOUNT = 0 )
        BEGIN
	        BEGIN TRANSACTION
	        SET @TranStarted = 1
        END
        ELSE
    	    SET @TranStarted = 0

        SELECT  @ApplicationId = ApplicationId
        FROM dbo.aspnet_Applications WITH (UPDLOCK, HOLDLOCK)
        WHERE LOWER(@ApplicationName) = LoweredApplicationName

        IF(@ApplicationId IS NULL)
        BEGIN
            SELECT  @ApplicationId = NEWID()
            INSERT  dbo.aspnet_Applications (ApplicationId, ApplicationName, LoweredApplicationName)
            VALUES  (@ApplicationId, @ApplicationName, LOWER(@ApplicationName))
        END


        IF( @TranStarted = 1 )
        BEGIN
            IF(@@ERROR = 0)
            BEGIN
	        SET @TranStarted = 0
	        COMMIT TRANSACTION
            END
            ELSE
            BEGIN
                SET @TranStarted = 0
                ROLLBACK TRANSACTION
            END
        END
    END
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_CheckSchemaVersion]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_CheckSchemaVersion]
    @Feature                   nvarchar(128),
    @CompatibleSchemaVersion   nvarchar(128)
AS
BEGIN
    IF (EXISTS( SELECT  *
                FROM    dbo.aspnet_SchemaVersions
                WHERE   Feature = LOWER( @Feature ) AND
                        CompatibleSchemaVersion = @CompatibleSchemaVersion ))
        RETURN 0

    RETURN 1
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_ChangePasswordQuestionAndAnswer]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_ChangePasswordQuestionAndAnswer]
    @ApplicationName       nvarchar(256),
    @UserName              nvarchar(256),
    @NewPasswordQuestion   nvarchar(256),
    @NewPasswordAnswer     nvarchar(128)
AS
BEGIN
    DECLARE @UserId uniqueidentifier
    SELECT  @UserId = NULL
    SELECT  @UserId = u.UserId
    FROM    dbo.aspnet_Membership m, dbo.aspnet_Users u, dbo.aspnet_Applications a
    WHERE   LoweredUserName = LOWER(@UserName) AND
            u.ApplicationId = a.ApplicationId  AND
            LOWER(@ApplicationName) = a.LoweredApplicationName AND
            u.UserId = m.UserId
    IF (@UserId IS NULL)
    BEGIN
        RETURN(1)
    END

    UPDATE dbo.aspnet_Membership
    SET    PasswordQuestion = @NewPasswordQuestion, PasswordAnswer = @NewPasswordAnswer
    WHERE  UserId=@UserId
    RETURN(0)
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_CreateUser]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_CreateUser]
    @ApplicationName                        nvarchar(256),
    @UserName                               nvarchar(256),
    @Password                               nvarchar(128),
    @PasswordSalt                           nvarchar(128),
    @Email                                  nvarchar(256),
    @PasswordQuestion                       nvarchar(256),
    @PasswordAnswer                         nvarchar(128),
    @IsApproved                             bit,
    @CurrentTimeUtc                         datetime,
    @CreateDate                             datetime = NULL,
    @UniqueEmail                            int      = 0,
    @PasswordFormat                         int      = 0,
    @UserId                                 uniqueidentifier OUTPUT
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL

    DECLARE @NewUserId uniqueidentifier
    SELECT @NewUserId = NULL

    DECLARE @IsLockedOut bit
    SET @IsLockedOut = 0

    DECLARE @LastLockoutDate  datetime
    SET @LastLockoutDate = CONVERT( datetime, '17540101', 112 )

    DECLARE @FailedPasswordAttemptCount int
    SET @FailedPasswordAttemptCount = 0

    DECLARE @FailedPasswordAttemptWindowStart  datetime
    SET @FailedPasswordAttemptWindowStart = CONVERT( datetime, '17540101', 112 )

    DECLARE @FailedPasswordAnswerAttemptCount int
    SET @FailedPasswordAnswerAttemptCount = 0

    DECLARE @FailedPasswordAnswerAttemptWindowStart  datetime
    SET @FailedPasswordAnswerAttemptWindowStart = CONVERT( datetime, '17540101', 112 )

    DECLARE @NewUserCreated bit
    DECLARE @ReturnValue   int
    SET @ReturnValue = 0

    DECLARE @ErrorCode     int
    SET @ErrorCode = 0

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
	    BEGIN TRANSACTION
	    SET @TranStarted = 1
    END
    ELSE
    	SET @TranStarted = 0

    EXEC dbo.aspnet_Applications_CreateApplication @ApplicationName, @ApplicationId OUTPUT

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    SET @CreateDate = @CurrentTimeUtc

    SELECT  @NewUserId = UserId FROM dbo.aspnet_Users WHERE LOWER(@UserName) = LoweredUserName AND @ApplicationId = ApplicationId
    IF ( @NewUserId IS NULL )
    BEGIN
        SET @NewUserId = @UserId
        EXEC @ReturnValue = dbo.aspnet_Users_CreateUser @ApplicationId, @UserName, 0, @CreateDate, @NewUserId OUTPUT
        SET @NewUserCreated = 1
    END
    ELSE
    BEGIN
        SET @NewUserCreated = 0
        IF( @NewUserId <> @UserId AND @UserId IS NOT NULL )
        BEGIN
            SET @ErrorCode = 6
            GOTO Cleanup
        END
    END

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    IF( @ReturnValue = -1 )
    BEGIN
        SET @ErrorCode = 10
        GOTO Cleanup
    END

    IF ( EXISTS ( SELECT UserId
                  FROM   dbo.aspnet_Membership
                  WHERE  @NewUserId = UserId ) )
    BEGIN
        SET @ErrorCode = 6
        GOTO Cleanup
    END

    SET @UserId = @NewUserId

    IF (@UniqueEmail = 1)
    BEGIN
        IF (EXISTS (SELECT *
                    FROM  dbo.aspnet_Membership m WITH ( UPDLOCK, HOLDLOCK )
                    WHERE ApplicationId = @ApplicationId AND LoweredEmail = LOWER(@Email)))
        BEGIN
            SET @ErrorCode = 7
            GOTO Cleanup
        END
    END

    IF (@NewUserCreated = 0)
    BEGIN
        UPDATE dbo.aspnet_Users
        SET    LastActivityDate = @CreateDate
        WHERE  @UserId = UserId
        IF( @@ERROR <> 0 )
        BEGIN
            SET @ErrorCode = -1
            GOTO Cleanup
        END
    END

    INSERT INTO dbo.aspnet_Membership
                ( ApplicationId,
                  UserId,
                  Password,
                  PasswordSalt,
                  Email,
                  LoweredEmail,
                  PasswordQuestion,
                  PasswordAnswer,
                  PasswordFormat,
                  IsApproved,
                  IsLockedOut,
                  CreateDate,
                  LastLoginDate,
                  LastPasswordChangedDate,
                  LastLockoutDate,
                  FailedPasswordAttemptCount,
                  FailedPasswordAttemptWindowStart,
                  FailedPasswordAnswerAttemptCount,
                  FailedPasswordAnswerAttemptWindowStart )
         VALUES ( @ApplicationId,
                  @UserId,
                  @Password,
                  @PasswordSalt,
                  @Email,
                  LOWER(@Email),
                  @PasswordQuestion,
                  @PasswordAnswer,
                  @PasswordFormat,
                  @IsApproved,
                  @IsLockedOut,
                  @CreateDate,
                  @CreateDate,
                  @CreateDate,
                  @LastLockoutDate,
                  @FailedPasswordAttemptCount,
                  @FailedPasswordAttemptWindowStart,
                  @FailedPasswordAnswerAttemptCount,
                  @FailedPasswordAnswerAttemptWindowStart )

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    IF( @TranStarted = 1 )
    BEGIN
	    SET @TranStarted = 0
	    COMMIT TRANSACTION
    END

    RETURN 0

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
    	ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode

END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_FindUsersByEmail]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_FindUsersByEmail]
    @ApplicationName       nvarchar(256),
    @EmailToMatch          nvarchar(256),
    @PageIndex             int,
    @PageSize              int
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM dbo.aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN 0

    -- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    DECLARE @TotalRecords   int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize - 1 + @PageLowerBound

    -- Create a temp table TO store the select results
    CREATE TABLE #PageIndexForUsers
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        UserId uniqueidentifier
    )

    -- Insert into our temp table
    IF( @EmailToMatch IS NULL )
        INSERT INTO #PageIndexForUsers (UserId)
            SELECT u.UserId
            FROM   dbo.aspnet_Users u, dbo.aspnet_Membership m
            WHERE  u.ApplicationId = @ApplicationId AND m.UserId = u.UserId AND m.Email IS NULL
            ORDER BY m.LoweredEmail
    ELSE
        INSERT INTO #PageIndexForUsers (UserId)
            SELECT u.UserId
            FROM   dbo.aspnet_Users u, dbo.aspnet_Membership m
            WHERE  u.ApplicationId = @ApplicationId AND m.UserId = u.UserId AND m.LoweredEmail LIKE LOWER(@EmailToMatch)
            ORDER BY m.LoweredEmail

    SELECT  u.UserName, m.Email, m.PasswordQuestion, m.Comment, m.IsApproved,
            m.CreateDate,
            m.LastLoginDate,
            u.LastActivityDate,
            m.LastPasswordChangedDate,
            u.UserId, m.IsLockedOut,
            m.LastLockoutDate
    FROM   dbo.aspnet_Membership m, dbo.aspnet_Users u, #PageIndexForUsers p
    WHERE  u.UserId = p.UserId AND u.UserId = m.UserId AND
           p.IndexId >= @PageLowerBound AND p.IndexId <= @PageUpperBound
    ORDER BY m.LoweredEmail

    SELECT  @TotalRecords = COUNT(*)
    FROM    #PageIndexForUsers
    RETURN @TotalRecords
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_FindUsersByName]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_FindUsersByName]
    @ApplicationName       nvarchar(256),
    @UserNameToMatch       nvarchar(256),
    @PageIndex             int,
    @PageSize              int
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM dbo.aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN 0

    -- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    DECLARE @TotalRecords   int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize - 1 + @PageLowerBound

    -- Create a temp table TO store the select results
    CREATE TABLE #PageIndexForUsers
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        UserId uniqueidentifier
    )

    -- Insert into our temp table
    INSERT INTO #PageIndexForUsers (UserId)
        SELECT u.UserId
        FROM   dbo.aspnet_Users u, dbo.aspnet_Membership m
        WHERE  u.ApplicationId = @ApplicationId AND m.UserId = u.UserId AND u.LoweredUserName LIKE LOWER(@UserNameToMatch)
        ORDER BY u.UserName


    SELECT  u.UserName, m.Email, m.PasswordQuestion, m.Comment, m.IsApproved,
            m.CreateDate,
            m.LastLoginDate,
            u.LastActivityDate,
            m.LastPasswordChangedDate,
            u.UserId, m.IsLockedOut,
            m.LastLockoutDate
    FROM   dbo.aspnet_Membership m, dbo.aspnet_Users u, #PageIndexForUsers p
    WHERE  u.UserId = p.UserId AND u.UserId = m.UserId AND
           p.IndexId >= @PageLowerBound AND p.IndexId <= @PageUpperBound
    ORDER BY u.UserName

    SELECT  @TotalRecords = COUNT(*)
    FROM    #PageIndexForUsers
    RETURN @TotalRecords
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetAllUsers]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_GetAllUsers]
    @ApplicationName       nvarchar(256),
    @PageIndex             int,
    @PageSize              int
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM dbo.aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN 0


    -- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    DECLARE @TotalRecords   int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize - 1 + @PageLowerBound

    -- Create a temp table TO store the select results
    CREATE TABLE #PageIndexForUsers
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        UserId uniqueidentifier
    )

    -- Insert into our temp table
    INSERT INTO #PageIndexForUsers (UserId)
    SELECT u.UserId
    FROM   dbo.aspnet_Membership m, dbo.aspnet_Users u
    WHERE  u.ApplicationId = @ApplicationId AND u.UserId = m.UserId
    ORDER BY u.UserName

    SELECT @TotalRecords = @@ROWCOUNT

    SELECT u.UserName, m.Email, m.PasswordQuestion, m.Comment, m.IsApproved,
            m.CreateDate,
            m.LastLoginDate,
            u.LastActivityDate,
            m.LastPasswordChangedDate,
            u.UserId, m.IsLockedOut,
            m.LastLockoutDate
    FROM   dbo.aspnet_Membership m, dbo.aspnet_Users u, #PageIndexForUsers p
    WHERE  u.UserId = p.UserId AND u.UserId = m.UserId AND
           p.IndexId >= @PageLowerBound AND p.IndexId <= @PageUpperBound
    ORDER BY u.UserName
    RETURN @TotalRecords
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetNumberOfUsersOnline]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_GetNumberOfUsersOnline]
    @ApplicationName            nvarchar(256),
    @MinutesSinceLastInActive   int,
    @CurrentTimeUtc             datetime
AS
BEGIN
    DECLARE @DateActive datetime
    SELECT  @DateActive = DATEADD(minute,  -(@MinutesSinceLastInActive), @CurrentTimeUtc)

    DECLARE @NumOnline int
    SELECT  @NumOnline = COUNT(*)
    FROM    dbo.aspnet_Users u(NOLOCK),
            dbo.aspnet_Applications a(NOLOCK),
            dbo.aspnet_Membership m(NOLOCK)
    WHERE   u.ApplicationId = a.ApplicationId                  AND
            LastActivityDate > @DateActive                     AND
            a.LoweredApplicationName = LOWER(@ApplicationName) AND
            u.UserId = m.UserId
    RETURN(@NumOnline)
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetPassword]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_GetPassword]
    @ApplicationName                nvarchar(256),
    @UserName                       nvarchar(256),
    @MaxInvalidPasswordAttempts     int,
    @PasswordAttemptWindow          int,
    @CurrentTimeUtc                 datetime,
    @PasswordAnswer                 nvarchar(128) = NULL
AS
BEGIN
    DECLARE @UserId                                 uniqueidentifier
    DECLARE @PasswordFormat                         int
    DECLARE @Password                               nvarchar(128)
    DECLARE @passAns                                nvarchar(128)
    DECLARE @IsLockedOut                            bit
    DECLARE @LastLockoutDate                        datetime
    DECLARE @FailedPasswordAttemptCount             int
    DECLARE @FailedPasswordAttemptWindowStart       datetime
    DECLARE @FailedPasswordAnswerAttemptCount       int
    DECLARE @FailedPasswordAnswerAttemptWindowStart datetime

    DECLARE @ErrorCode     int
    SET @ErrorCode = 0

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
	    BEGIN TRANSACTION
	    SET @TranStarted = 1
    END
    ELSE
    	SET @TranStarted = 0

    SELECT  @UserId = u.UserId,
            @Password = m.Password,
            @passAns = m.PasswordAnswer,
            @PasswordFormat = m.PasswordFormat,
            @IsLockedOut = m.IsLockedOut,
            @LastLockoutDate = m.LastLockoutDate,
            @FailedPasswordAttemptCount = m.FailedPasswordAttemptCount,
            @FailedPasswordAttemptWindowStart = m.FailedPasswordAttemptWindowStart,
            @FailedPasswordAnswerAttemptCount = m.FailedPasswordAnswerAttemptCount,
            @FailedPasswordAnswerAttemptWindowStart = m.FailedPasswordAnswerAttemptWindowStart
    FROM    dbo.aspnet_Applications a, dbo.aspnet_Users u, dbo.aspnet_Membership m WITH ( UPDLOCK )
    WHERE   LOWER(@ApplicationName) = a.LoweredApplicationName AND
            u.ApplicationId = a.ApplicationId    AND
            u.UserId = m.UserId AND
            LOWER(@UserName) = u.LoweredUserName

    IF ( @@rowcount = 0 )
    BEGIN
        SET @ErrorCode = 1
        GOTO Cleanup
    END

    IF( @IsLockedOut = 1 )
    BEGIN
        SET @ErrorCode = 99
        GOTO Cleanup
    END

    IF ( NOT( @PasswordAnswer IS NULL ) )
    BEGIN
        IF( ( @passAns IS NULL ) OR ( LOWER( @passAns ) <> LOWER( @PasswordAnswer ) ) )
        BEGIN
            IF( @CurrentTimeUtc > DATEADD( minute, @PasswordAttemptWindow, @FailedPasswordAnswerAttemptWindowStart ) )
            BEGIN
                SET @FailedPasswordAnswerAttemptWindowStart = @CurrentTimeUtc
                SET @FailedPasswordAnswerAttemptCount = 1
            END
            ELSE
            BEGIN
                SET @FailedPasswordAnswerAttemptCount = @FailedPasswordAnswerAttemptCount + 1
                SET @FailedPasswordAnswerAttemptWindowStart = @CurrentTimeUtc
            END

            BEGIN
                IF( @FailedPasswordAnswerAttemptCount >= @MaxInvalidPasswordAttempts )
                BEGIN
                    SET @IsLockedOut = 1
                    SET @LastLockoutDate = @CurrentTimeUtc
                END
            END

            SET @ErrorCode = 3
        END
        ELSE
        BEGIN
            IF( @FailedPasswordAnswerAttemptCount > 0 )
            BEGIN
                SET @FailedPasswordAnswerAttemptCount = 0
                SET @FailedPasswordAnswerAttemptWindowStart = CONVERT( datetime, '17540101', 112 )
            END
        END

        UPDATE dbo.aspnet_Membership
        SET IsLockedOut = @IsLockedOut, LastLockoutDate = @LastLockoutDate,
            FailedPasswordAttemptCount = @FailedPasswordAttemptCount,
            FailedPasswordAttemptWindowStart = @FailedPasswordAttemptWindowStart,
            FailedPasswordAnswerAttemptCount = @FailedPasswordAnswerAttemptCount,
            FailedPasswordAnswerAttemptWindowStart = @FailedPasswordAnswerAttemptWindowStart
        WHERE @UserId = UserId

        IF( @@ERROR <> 0 )
        BEGIN
            SET @ErrorCode = -1
            GOTO Cleanup
        END
    END

    IF( @TranStarted = 1 )
    BEGIN
	SET @TranStarted = 0
	COMMIT TRANSACTION
    END

    IF( @ErrorCode = 0 )
        SELECT @Password, @PasswordFormat

    RETURN @ErrorCode

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
    	ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode

END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetPasswordWithFormat]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_GetPasswordWithFormat]
    @ApplicationName                nvarchar(256),
    @UserName                       nvarchar(256),
    @UpdateLastLoginActivityDate    bit,
    @CurrentTimeUtc                 datetime
AS
BEGIN
    DECLARE @IsLockedOut                        bit
    DECLARE @UserId                             uniqueidentifier
    DECLARE @Password                           nvarchar(128)
    DECLARE @PasswordSalt                       nvarchar(128)
    DECLARE @PasswordFormat                     int
    DECLARE @FailedPasswordAttemptCount         int
    DECLARE @FailedPasswordAnswerAttemptCount   int
    DECLARE @IsApproved                         bit
    DECLARE @LastActivityDate                   datetime
    DECLARE @LastLoginDate                      datetime

    SELECT  @UserId          = NULL

    SELECT  @UserId = u.UserId, @IsLockedOut = m.IsLockedOut, @Password=Password, @PasswordFormat=PasswordFormat,
            @PasswordSalt=PasswordSalt, @FailedPasswordAttemptCount=FailedPasswordAttemptCount,
		    @FailedPasswordAnswerAttemptCount=FailedPasswordAnswerAttemptCount, @IsApproved=IsApproved,
            @LastActivityDate = LastActivityDate, @LastLoginDate = LastLoginDate
    FROM    dbo.aspnet_Applications a, dbo.aspnet_Users u, dbo.aspnet_Membership m
    WHERE   LOWER(@ApplicationName) = a.LoweredApplicationName AND
            u.ApplicationId = a.ApplicationId    AND
            u.UserId = m.UserId AND
            LOWER(@UserName) = u.LoweredUserName

    IF (@UserId IS NULL)
        RETURN 1

    IF (@IsLockedOut = 1)
        RETURN 99

    SELECT   @Password, @PasswordFormat, @PasswordSalt, @FailedPasswordAttemptCount,
             @FailedPasswordAnswerAttemptCount, @IsApproved, @LastLoginDate, @LastActivityDate

    IF (@UpdateLastLoginActivityDate = 1 AND @IsApproved = 1)
    BEGIN
        UPDATE  dbo.aspnet_Membership
        SET     LastLoginDate = @CurrentTimeUtc
        WHERE   UserId = @UserId

        UPDATE  dbo.aspnet_Users
        SET     LastActivityDate = @CurrentTimeUtc
        WHERE   @UserId = UserId
    END


    RETURN 0
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetUserByEmail]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_GetUserByEmail]
    @ApplicationName  nvarchar(256),
    @Email            nvarchar(256)
AS
BEGIN
    IF( @Email IS NULL )
        SELECT  u.UserName
        FROM    dbo.aspnet_Applications a, dbo.aspnet_Users u, dbo.aspnet_Membership m
        WHERE   LOWER(@ApplicationName) = a.LoweredApplicationName AND
                u.ApplicationId = a.ApplicationId    AND
                u.UserId = m.UserId AND
                m.LoweredEmail IS NULL
    ELSE
        SELECT  u.UserName
        FROM    dbo.aspnet_Applications a, dbo.aspnet_Users u, dbo.aspnet_Membership m
        WHERE   LOWER(@ApplicationName) = a.LoweredApplicationName AND
                u.ApplicationId = a.ApplicationId    AND
                u.UserId = m.UserId AND
                LOWER(@Email) = m.LoweredEmail

    IF (@@rowcount = 0)
        RETURN(1)
    RETURN(0)
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetUserByName]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_GetUserByName]
    @ApplicationName      nvarchar(256),
    @UserName             nvarchar(256),
    @CurrentTimeUtc       datetime,
    @UpdateLastActivity   bit = 0
AS
BEGIN
    DECLARE @UserId uniqueidentifier

    IF (@UpdateLastActivity = 1)
    BEGIN
        -- select user ID from aspnet_users table
        SELECT TOP 1 @UserId = u.UserId
        FROM    dbo.aspnet_Applications a, dbo.aspnet_Users u, dbo.aspnet_Membership m
        WHERE    LOWER(@ApplicationName) = a.LoweredApplicationName AND
                u.ApplicationId = a.ApplicationId    AND
                LOWER(@UserName) = u.LoweredUserName AND u.UserId = m.UserId

        IF (@@ROWCOUNT = 0) -- Username not found
            RETURN -1

        UPDATE   dbo.aspnet_Users
        SET      LastActivityDate = @CurrentTimeUtc
        WHERE    @UserId = UserId

        SELECT m.Email, m.PasswordQuestion, m.Comment, m.IsApproved,
                m.CreateDate, m.LastLoginDate, u.LastActivityDate, m.LastPasswordChangedDate,
                u.UserId, m.IsLockedOut, m.LastLockoutDate
        FROM    dbo.aspnet_Applications a, dbo.aspnet_Users u, dbo.aspnet_Membership m
        WHERE  @UserId = u.UserId AND u.UserId = m.UserId 
    END
    ELSE
    BEGIN
        SELECT TOP 1 m.Email, m.PasswordQuestion, m.Comment, m.IsApproved,
                m.CreateDate, m.LastLoginDate, u.LastActivityDate, m.LastPasswordChangedDate,
                u.UserId, m.IsLockedOut,m.LastLockoutDate
        FROM    dbo.aspnet_Applications a, dbo.aspnet_Users u, dbo.aspnet_Membership m
        WHERE    LOWER(@ApplicationName) = a.LoweredApplicationName AND
                u.ApplicationId = a.ApplicationId    AND
                LOWER(@UserName) = u.LoweredUserName AND u.UserId = m.UserId

        IF (@@ROWCOUNT = 0) -- Username not found
            RETURN -1
    END

    RETURN 0
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetUserByUserId]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_GetUserByUserId]
    @UserId               uniqueidentifier,
    @CurrentTimeUtc       datetime,
    @UpdateLastActivity   bit = 0
AS
BEGIN
    IF ( @UpdateLastActivity = 1 )
    BEGIN
        UPDATE   dbo.aspnet_Users
        SET      LastActivityDate = @CurrentTimeUtc
        FROM     dbo.aspnet_Users
        WHERE    @UserId = UserId

        IF ( @@ROWCOUNT = 0 ) -- User ID not found
            RETURN -1
    END

    SELECT  m.Email, m.PasswordQuestion, m.Comment, m.IsApproved,
            m.CreateDate, m.LastLoginDate, u.LastActivityDate,
            m.LastPasswordChangedDate, u.UserName, m.IsLockedOut,
            m.LastLockoutDate
    FROM    dbo.aspnet_Users u, dbo.aspnet_Membership m
    WHERE   @UserId = u.UserId AND u.UserId = m.UserId

    IF ( @@ROWCOUNT = 0 ) -- User ID not found
       RETURN -1

    RETURN 0
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_ResetPassword]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_ResetPassword]
    @ApplicationName             nvarchar(256),
    @UserName                    nvarchar(256),
    @NewPassword                 nvarchar(128),
    @MaxInvalidPasswordAttempts  int,
    @PasswordAttemptWindow       int,
    @PasswordSalt                nvarchar(128),
    @CurrentTimeUtc              datetime,
    @PasswordFormat              int = 0,
    @PasswordAnswer              nvarchar(128) = NULL
AS
BEGIN
    DECLARE @IsLockedOut                            bit
    DECLARE @LastLockoutDate                        datetime
    DECLARE @FailedPasswordAttemptCount             int
    DECLARE @FailedPasswordAttemptWindowStart       datetime
    DECLARE @FailedPasswordAnswerAttemptCount       int
    DECLARE @FailedPasswordAnswerAttemptWindowStart datetime

    DECLARE @UserId                                 uniqueidentifier
    SET     @UserId = NULL

    DECLARE @ErrorCode     int
    SET @ErrorCode = 0

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
	    BEGIN TRANSACTION
	    SET @TranStarted = 1
    END
    ELSE
    	SET @TranStarted = 0

    SELECT  @UserId = u.UserId
    FROM    dbo.aspnet_Users u, dbo.aspnet_Applications a, dbo.aspnet_Membership m
    WHERE   LoweredUserName = LOWER(@UserName) AND
            u.ApplicationId = a.ApplicationId  AND
            LOWER(@ApplicationName) = a.LoweredApplicationName AND
            u.UserId = m.UserId

    IF ( @UserId IS NULL )
    BEGIN
        SET @ErrorCode = 1
        GOTO Cleanup
    END

    SELECT @IsLockedOut = IsLockedOut,
           @LastLockoutDate = LastLockoutDate,
           @FailedPasswordAttemptCount = FailedPasswordAttemptCount,
           @FailedPasswordAttemptWindowStart = FailedPasswordAttemptWindowStart,
           @FailedPasswordAnswerAttemptCount = FailedPasswordAnswerAttemptCount,
           @FailedPasswordAnswerAttemptWindowStart = FailedPasswordAnswerAttemptWindowStart
    FROM dbo.aspnet_Membership WITH ( UPDLOCK )
    WHERE @UserId = UserId

    IF( @IsLockedOut = 1 )
    BEGIN
        SET @ErrorCode = 99
        GOTO Cleanup
    END

    UPDATE dbo.aspnet_Membership
    SET    Password = @NewPassword,
           LastPasswordChangedDate = @CurrentTimeUtc,
           PasswordFormat = @PasswordFormat,
           PasswordSalt = @PasswordSalt
    WHERE  @UserId = UserId AND
           ( ( @PasswordAnswer IS NULL ) OR ( LOWER( PasswordAnswer ) = LOWER( @PasswordAnswer ) ) )

    IF ( @@ROWCOUNT = 0 )
        BEGIN
            IF( @CurrentTimeUtc > DATEADD( minute, @PasswordAttemptWindow, @FailedPasswordAnswerAttemptWindowStart ) )
            BEGIN
                SET @FailedPasswordAnswerAttemptWindowStart = @CurrentTimeUtc
                SET @FailedPasswordAnswerAttemptCount = 1
            END
            ELSE
            BEGIN
                SET @FailedPasswordAnswerAttemptWindowStart = @CurrentTimeUtc
                SET @FailedPasswordAnswerAttemptCount = @FailedPasswordAnswerAttemptCount + 1
            END

            BEGIN
                IF( @FailedPasswordAnswerAttemptCount >= @MaxInvalidPasswordAttempts )
                BEGIN
                    SET @IsLockedOut = 1
                    SET @LastLockoutDate = @CurrentTimeUtc
                END
            END

            SET @ErrorCode = 3
        END
    ELSE
        BEGIN
            IF( @FailedPasswordAnswerAttemptCount > 0 )
            BEGIN
                SET @FailedPasswordAnswerAttemptCount = 0
                SET @FailedPasswordAnswerAttemptWindowStart = CONVERT( datetime, '17540101', 112 )
            END
        END

    IF( NOT ( @PasswordAnswer IS NULL ) )
    BEGIN
        UPDATE dbo.aspnet_Membership
        SET IsLockedOut = @IsLockedOut, LastLockoutDate = @LastLockoutDate,
            FailedPasswordAttemptCount = @FailedPasswordAttemptCount,
            FailedPasswordAttemptWindowStart = @FailedPasswordAttemptWindowStart,
            FailedPasswordAnswerAttemptCount = @FailedPasswordAnswerAttemptCount,
            FailedPasswordAnswerAttemptWindowStart = @FailedPasswordAnswerAttemptWindowStart
        WHERE @UserId = UserId

        IF( @@ERROR <> 0 )
        BEGIN
            SET @ErrorCode = -1
            GOTO Cleanup
        END
    END

    IF( @TranStarted = 1 )
    BEGIN
	SET @TranStarted = 0
	COMMIT TRANSACTION
    END

    RETURN @ErrorCode

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
    	ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode

END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_SetPassword]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_SetPassword]
    @ApplicationName  nvarchar(256),
    @UserName         nvarchar(256),
    @NewPassword      nvarchar(128),
    @PasswordSalt     nvarchar(128),
    @CurrentTimeUtc   datetime,
    @PasswordFormat   int = 0
AS
BEGIN
    DECLARE @UserId uniqueidentifier
    SELECT  @UserId = NULL
    SELECT  @UserId = u.UserId
    FROM    dbo.aspnet_Users u, dbo.aspnet_Applications a, dbo.aspnet_Membership m
    WHERE   LoweredUserName = LOWER(@UserName) AND
            u.ApplicationId = a.ApplicationId  AND
            LOWER(@ApplicationName) = a.LoweredApplicationName AND
            u.UserId = m.UserId

    IF (@UserId IS NULL)
        RETURN(1)

    UPDATE dbo.aspnet_Membership
    SET Password = @NewPassword, PasswordFormat = @PasswordFormat, PasswordSalt = @PasswordSalt,
        LastPasswordChangedDate = @CurrentTimeUtc
    WHERE @UserId = UserId
    RETURN(0)
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_UnlockUser]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_UnlockUser]
    @ApplicationName                         nvarchar(256),
    @UserName                                nvarchar(256)
AS
BEGIN
    DECLARE @UserId uniqueidentifier
    SELECT  @UserId = NULL
    SELECT  @UserId = u.UserId
    FROM    dbo.aspnet_Users u, dbo.aspnet_Applications a, dbo.aspnet_Membership m
    WHERE   LoweredUserName = LOWER(@UserName) AND
            u.ApplicationId = a.ApplicationId  AND
            LOWER(@ApplicationName) = a.LoweredApplicationName AND
            u.UserId = m.UserId

    IF ( @UserId IS NULL )
        RETURN 1

    UPDATE dbo.aspnet_Membership
    SET IsLockedOut = 0,
        FailedPasswordAttemptCount = 0,
        FailedPasswordAttemptWindowStart = CONVERT( datetime, '17540101', 112 ),
        FailedPasswordAnswerAttemptCount = 0,
        FailedPasswordAnswerAttemptWindowStart = CONVERT( datetime, '17540101', 112 ),
        LastLockoutDate = CONVERT( datetime, '17540101', 112 )
    WHERE @UserId = UserId

    RETURN 0
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_UpdateUser]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_UpdateUser]
    @ApplicationName      nvarchar(256),
    @UserName             nvarchar(256),
    @Email                nvarchar(256),
    @Comment              ntext,
    @IsApproved           bit,
    @LastLoginDate        datetime,
    @LastActivityDate     datetime,
    @UniqueEmail          int,
    @CurrentTimeUtc       datetime
AS
BEGIN
    DECLARE @UserId uniqueidentifier
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @UserId = NULL
    SELECT  @UserId = u.UserId, @ApplicationId = a.ApplicationId
    FROM    dbo.aspnet_Users u, dbo.aspnet_Applications a, dbo.aspnet_Membership m
    WHERE   LoweredUserName = LOWER(@UserName) AND
            u.ApplicationId = a.ApplicationId  AND
            LOWER(@ApplicationName) = a.LoweredApplicationName AND
            u.UserId = m.UserId

    IF (@UserId IS NULL)
        RETURN(1)

    IF (@UniqueEmail = 1)
    BEGIN
        IF (EXISTS (SELECT *
                    FROM  dbo.aspnet_Membership WITH (UPDLOCK, HOLDLOCK)
                    WHERE ApplicationId = @ApplicationId  AND @UserId <> UserId AND LoweredEmail = LOWER(@Email)))
        BEGIN
            RETURN(7)
        END
    END

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
	    BEGIN TRANSACTION
	    SET @TranStarted = 1
    END
    ELSE
	SET @TranStarted = 0

    UPDATE dbo.aspnet_Users WITH (ROWLOCK)
    SET
         LastActivityDate = @LastActivityDate
    WHERE
       @UserId = UserId

    IF( @@ERROR <> 0 )
        GOTO Cleanup

    UPDATE dbo.aspnet_Membership WITH (ROWLOCK)
    SET
         Email            = @Email,
         LoweredEmail     = LOWER(@Email),
         Comment          = @Comment,
         IsApproved       = @IsApproved,
         LastLoginDate    = @LastLoginDate
    WHERE
       @UserId = UserId

    IF( @@ERROR <> 0 )
        GOTO Cleanup

    IF( @TranStarted = 1 )
    BEGIN
	SET @TranStarted = 0
	COMMIT TRANSACTION
    END

    RETURN 0

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
    	ROLLBACK TRANSACTION
    END

    RETURN -1
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_UpdateUserInfo]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Membership_UpdateUserInfo]
    @ApplicationName                nvarchar(256),
    @UserName                       nvarchar(256),
    @IsPasswordCorrect              bit,
    @UpdateLastLoginActivityDate    bit,
    @MaxInvalidPasswordAttempts     int,
    @PasswordAttemptWindow          int,
    @CurrentTimeUtc                 datetime,
    @LastLoginDate                  datetime,
    @LastActivityDate               datetime
AS
BEGIN
    DECLARE @UserId                                 uniqueidentifier
    DECLARE @IsApproved                             bit
    DECLARE @IsLockedOut                            bit
    DECLARE @LastLockoutDate                        datetime
    DECLARE @FailedPasswordAttemptCount             int
    DECLARE @FailedPasswordAttemptWindowStart       datetime
    DECLARE @FailedPasswordAnswerAttemptCount       int
    DECLARE @FailedPasswordAnswerAttemptWindowStart datetime

    DECLARE @ErrorCode     int
    SET @ErrorCode = 0

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
	    BEGIN TRANSACTION
	    SET @TranStarted = 1
    END
    ELSE
    	SET @TranStarted = 0

    SELECT  @UserId = u.UserId,
            @IsApproved = m.IsApproved,
            @IsLockedOut = m.IsLockedOut,
            @LastLockoutDate = m.LastLockoutDate,
            @FailedPasswordAttemptCount = m.FailedPasswordAttemptCount,
            @FailedPasswordAttemptWindowStart = m.FailedPasswordAttemptWindowStart,
            @FailedPasswordAnswerAttemptCount = m.FailedPasswordAnswerAttemptCount,
            @FailedPasswordAnswerAttemptWindowStart = m.FailedPasswordAnswerAttemptWindowStart
    FROM    dbo.aspnet_Applications a, dbo.aspnet_Users u, dbo.aspnet_Membership m WITH ( UPDLOCK )
    WHERE   LOWER(@ApplicationName) = a.LoweredApplicationName AND
            u.ApplicationId = a.ApplicationId    AND
            u.UserId = m.UserId AND
            LOWER(@UserName) = u.LoweredUserName

    IF ( @@rowcount = 0 )
    BEGIN
        SET @ErrorCode = 1
        GOTO Cleanup
    END

    IF( @IsLockedOut = 1 )
    BEGIN
        GOTO Cleanup
    END

    IF( @IsPasswordCorrect = 0 )
    BEGIN
        IF( @CurrentTimeUtc > DATEADD( minute, @PasswordAttemptWindow, @FailedPasswordAttemptWindowStart ) )
        BEGIN
            SET @FailedPasswordAttemptWindowStart = @CurrentTimeUtc
            SET @FailedPasswordAttemptCount = 1
        END
        ELSE
        BEGIN
            SET @FailedPasswordAttemptWindowStart = @CurrentTimeUtc
            SET @FailedPasswordAttemptCount = @FailedPasswordAttemptCount + 1
        END

        BEGIN
            IF( @FailedPasswordAttemptCount >= @MaxInvalidPasswordAttempts )
            BEGIN
                SET @IsLockedOut = 1
                SET @LastLockoutDate = @CurrentTimeUtc
            END
        END
    END
    ELSE
    BEGIN
        IF( @FailedPasswordAttemptCount > 0 OR @FailedPasswordAnswerAttemptCount > 0 )
        BEGIN
            SET @FailedPasswordAttemptCount = 0
            SET @FailedPasswordAttemptWindowStart = CONVERT( datetime, '17540101', 112 )
            SET @FailedPasswordAnswerAttemptCount = 0
            SET @FailedPasswordAnswerAttemptWindowStart = CONVERT( datetime, '17540101', 112 )
            SET @LastLockoutDate = CONVERT( datetime, '17540101', 112 )
        END
    END

    IF( @UpdateLastLoginActivityDate = 1 )
    BEGIN
        UPDATE  dbo.aspnet_Users
        SET     LastActivityDate = @LastActivityDate
        WHERE   @UserId = UserId

        IF( @@ERROR <> 0 )
        BEGIN
            SET @ErrorCode = -1
            GOTO Cleanup
        END

        UPDATE  dbo.aspnet_Membership
        SET     LastLoginDate = @LastLoginDate
        WHERE   UserId = @UserId

        IF( @@ERROR <> 0 )
        BEGIN
            SET @ErrorCode = -1
            GOTO Cleanup
        END
    END


    UPDATE dbo.aspnet_Membership
    SET IsLockedOut = @IsLockedOut, LastLockoutDate = @LastLockoutDate,
        FailedPasswordAttemptCount = @FailedPasswordAttemptCount,
        FailedPasswordAttemptWindowStart = @FailedPasswordAttemptWindowStart,
        FailedPasswordAnswerAttemptCount = @FailedPasswordAnswerAttemptCount,
        FailedPasswordAnswerAttemptWindowStart = @FailedPasswordAnswerAttemptWindowStart
    WHERE @UserId = UserId

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    IF( @TranStarted = 1 )
    BEGIN
	SET @TranStarted = 0
	COMMIT TRANSACTION
    END

    RETURN @ErrorCode

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
    	ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode

END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Paths_CreatePath]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Paths_CreatePath]
    @ApplicationId UNIQUEIDENTIFIER,
    @Path           NVARCHAR(256),
    @PathId         UNIQUEIDENTIFIER OUTPUT
AS
BEGIN
    BEGIN TRANSACTION
    IF (NOT EXISTS(SELECT * FROM dbo.aspnet_Paths WHERE LoweredPath = LOWER(@Path) AND ApplicationId = @ApplicationId))
    BEGIN
        INSERT dbo.aspnet_Paths (ApplicationId, Path, LoweredPath) VALUES (@ApplicationId, @Path, LOWER(@Path))
    END
    COMMIT TRANSACTION
    SELECT @PathId = PathId FROM dbo.aspnet_Paths WHERE LOWER(@Path) = LoweredPath AND ApplicationId = @ApplicationId
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Personalization_GetApplicationId]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Personalization_GetApplicationId] (
    @ApplicationName NVARCHAR(256),
    @ApplicationId UNIQUEIDENTIFIER OUT)
AS
BEGIN
    SELECT @ApplicationId = ApplicationId FROM dbo.aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationAdministration_DeleteAllState]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_PersonalizationAdministration_DeleteAllState] (
    @AllUsersScope bit,
    @ApplicationName NVARCHAR(256),
    @Count int OUT)
AS
BEGIN
    DECLARE @ApplicationId UNIQUEIDENTIFIER
    EXEC dbo.aspnet_Personalization_GetApplicationId @ApplicationName, @ApplicationId OUTPUT
    IF (@ApplicationId IS NULL)
        SELECT @Count = 0
    ELSE
    BEGIN
        IF (@AllUsersScope = 1)
            DELETE FROM aspnet_PersonalizationAllUsers
            WHERE PathId IN
               (SELECT Paths.PathId
                FROM dbo.aspnet_Paths Paths
                WHERE Paths.ApplicationId = @ApplicationId)
        ELSE
            DELETE FROM aspnet_PersonalizationPerUser
            WHERE PathId IN
               (SELECT Paths.PathId
                FROM dbo.aspnet_Paths Paths
                WHERE Paths.ApplicationId = @ApplicationId)

        SELECT @Count = @@ROWCOUNT
    END
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationAdministration_FindState]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_PersonalizationAdministration_FindState] (
    @AllUsersScope bit,
    @ApplicationName NVARCHAR(256),
    @PageIndex              INT,
    @PageSize               INT,
    @Path NVARCHAR(256) = NULL,
    @UserName NVARCHAR(256) = NULL,
    @InactiveSinceDate DATETIME = NULL)
AS
BEGIN
    DECLARE @ApplicationId UNIQUEIDENTIFIER
    EXEC dbo.aspnet_Personalization_GetApplicationId @ApplicationName, @ApplicationId OUTPUT
    IF (@ApplicationId IS NULL)
        RETURN

    -- Set the page bounds
    DECLARE @PageLowerBound INT
    DECLARE @PageUpperBound INT
    DECLARE @TotalRecords   INT
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize - 1 + @PageLowerBound

    -- Create a temp table to store the selected results
    CREATE TABLE #PageIndex (
        IndexId int IDENTITY (0, 1) NOT NULL,
        ItemId UNIQUEIDENTIFIER
    )

    IF (@AllUsersScope = 1)
    BEGIN
        -- Insert into our temp table
        INSERT INTO #PageIndex (ItemId)
        SELECT Paths.PathId
        FROM dbo.aspnet_Paths Paths,
             ((SELECT Paths.PathId
               FROM dbo.aspnet_PersonalizationAllUsers AllUsers, dbo.aspnet_Paths Paths
               WHERE Paths.ApplicationId = @ApplicationId
                      AND AllUsers.PathId = Paths.PathId
                      AND (@Path IS NULL OR Paths.LoweredPath LIKE LOWER(@Path))
              ) AS SharedDataPerPath
              FULL OUTER JOIN
              (SELECT DISTINCT Paths.PathId
               FROM dbo.aspnet_PersonalizationPerUser PerUser, dbo.aspnet_Paths Paths
               WHERE Paths.ApplicationId = @ApplicationId
                      AND PerUser.PathId = Paths.PathId
                      AND (@Path IS NULL OR Paths.LoweredPath LIKE LOWER(@Path))
              ) AS UserDataPerPath
              ON SharedDataPerPath.PathId = UserDataPerPath.PathId
             )
        WHERE Paths.PathId = SharedDataPerPath.PathId OR Paths.PathId = UserDataPerPath.PathId
        ORDER BY Paths.Path ASC

        SELECT @TotalRecords = @@ROWCOUNT

        SELECT Paths.Path,
               SharedDataPerPath.LastUpdatedDate,
               SharedDataPerPath.SharedDataLength,
               UserDataPerPath.UserDataLength,
               UserDataPerPath.UserCount
        FROM dbo.aspnet_Paths Paths,
             ((SELECT PageIndex.ItemId AS PathId,
                      AllUsers.LastUpdatedDate AS LastUpdatedDate,
                      DATALENGTH(AllUsers.PageSettings) AS SharedDataLength
               FROM dbo.aspnet_PersonalizationAllUsers AllUsers, #PageIndex PageIndex
               WHERE AllUsers.PathId = PageIndex.ItemId
                     AND PageIndex.IndexId >= @PageLowerBound AND PageIndex.IndexId <= @PageUpperBound
              ) AS SharedDataPerPath
              FULL OUTER JOIN
              (SELECT PageIndex.ItemId AS PathId,
                      SUM(DATALENGTH(PerUser.PageSettings)) AS UserDataLength,
                      COUNT(*) AS UserCount
               FROM aspnet_PersonalizationPerUser PerUser, #PageIndex PageIndex
               WHERE PerUser.PathId = PageIndex.ItemId
                     AND PageIndex.IndexId >= @PageLowerBound AND PageIndex.IndexId <= @PageUpperBound
               GROUP BY PageIndex.ItemId
              ) AS UserDataPerPath
              ON SharedDataPerPath.PathId = UserDataPerPath.PathId
             )
        WHERE Paths.PathId = SharedDataPerPath.PathId OR Paths.PathId = UserDataPerPath.PathId
        ORDER BY Paths.Path ASC
    END
    ELSE
    BEGIN
        -- Insert into our temp table
        INSERT INTO #PageIndex (ItemId)
        SELECT PerUser.Id
        FROM dbo.aspnet_PersonalizationPerUser PerUser, dbo.aspnet_Users Users, dbo.aspnet_Paths Paths
        WHERE Paths.ApplicationId = @ApplicationId
              AND PerUser.UserId = Users.UserId
              AND PerUser.PathId = Paths.PathId
              AND (@Path IS NULL OR Paths.LoweredPath LIKE LOWER(@Path))
              AND (@UserName IS NULL OR Users.LoweredUserName LIKE LOWER(@UserName))
              AND (@InactiveSinceDate IS NULL OR Users.LastActivityDate <= @InactiveSinceDate)
        ORDER BY Paths.Path ASC, Users.UserName ASC

        SELECT @TotalRecords = @@ROWCOUNT

        SELECT Paths.Path, PerUser.LastUpdatedDate, DATALENGTH(PerUser.PageSettings), Users.UserName, Users.LastActivityDate
        FROM dbo.aspnet_PersonalizationPerUser PerUser, dbo.aspnet_Users Users, dbo.aspnet_Paths Paths, #PageIndex PageIndex
        WHERE PerUser.Id = PageIndex.ItemId
              AND PerUser.UserId = Users.UserId
              AND PerUser.PathId = Paths.PathId
              AND PageIndex.IndexId >= @PageLowerBound AND PageIndex.IndexId <= @PageUpperBound
        ORDER BY Paths.Path ASC, Users.UserName ASC
    END

    RETURN @TotalRecords
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationAdministration_GetCountOfState]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_PersonalizationAdministration_GetCountOfState] (
    @Count int OUT,
    @AllUsersScope bit,
    @ApplicationName NVARCHAR(256),
    @Path NVARCHAR(256) = NULL,
    @UserName NVARCHAR(256) = NULL,
    @InactiveSinceDate DATETIME = NULL)
AS
BEGIN

    DECLARE @ApplicationId UNIQUEIDENTIFIER
    EXEC dbo.aspnet_Personalization_GetApplicationId @ApplicationName, @ApplicationId OUTPUT
    IF (@ApplicationId IS NULL)
        SELECT @Count = 0
    ELSE
        IF (@AllUsersScope = 1)
            SELECT @Count = COUNT(*)
            FROM dbo.aspnet_PersonalizationAllUsers AllUsers, dbo.aspnet_Paths Paths
            WHERE Paths.ApplicationId = @ApplicationId
                  AND AllUsers.PathId = Paths.PathId
                  AND (@Path IS NULL OR Paths.LoweredPath LIKE LOWER(@Path))
        ELSE
            SELECT @Count = COUNT(*)
            FROM dbo.aspnet_PersonalizationPerUser PerUser, dbo.aspnet_Users Users, dbo.aspnet_Paths Paths
            WHERE Paths.ApplicationId = @ApplicationId
                  AND PerUser.UserId = Users.UserId
                  AND PerUser.PathId = Paths.PathId
                  AND (@Path IS NULL OR Paths.LoweredPath LIKE LOWER(@Path))
                  AND (@UserName IS NULL OR Users.LoweredUserName LIKE LOWER(@UserName))
                  AND (@InactiveSinceDate IS NULL OR Users.LastActivityDate <= @InactiveSinceDate)
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationAdministration_ResetSharedState]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_PersonalizationAdministration_ResetSharedState] (
    @Count int OUT,
    @ApplicationName NVARCHAR(256),
    @Path NVARCHAR(256))
AS
BEGIN
    DECLARE @ApplicationId UNIQUEIDENTIFIER
    EXEC dbo.aspnet_Personalization_GetApplicationId @ApplicationName, @ApplicationId OUTPUT
    IF (@ApplicationId IS NULL)
        SELECT @Count = 0
    ELSE
    BEGIN
        DELETE FROM dbo.aspnet_PersonalizationAllUsers
        WHERE PathId IN
            (SELECT AllUsers.PathId
             FROM dbo.aspnet_PersonalizationAllUsers AllUsers, dbo.aspnet_Paths Paths
             WHERE Paths.ApplicationId = @ApplicationId
                   AND AllUsers.PathId = Paths.PathId
                   AND Paths.LoweredPath = LOWER(@Path))

        SELECT @Count = @@ROWCOUNT
    END
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationAdministration_ResetUserState]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_PersonalizationAdministration_ResetUserState] (
    @Count                  int                 OUT,
    @ApplicationName        NVARCHAR(256),
    @InactiveSinceDate      DATETIME            = NULL,
    @UserName               NVARCHAR(256)       = NULL,
    @Path                   NVARCHAR(256)       = NULL)
AS
BEGIN
    DECLARE @ApplicationId UNIQUEIDENTIFIER
    EXEC dbo.aspnet_Personalization_GetApplicationId @ApplicationName, @ApplicationId OUTPUT
    IF (@ApplicationId IS NULL)
        SELECT @Count = 0
    ELSE
    BEGIN
        DELETE FROM dbo.aspnet_PersonalizationPerUser
        WHERE Id IN (SELECT PerUser.Id
                     FROM dbo.aspnet_PersonalizationPerUser PerUser, dbo.aspnet_Users Users, dbo.aspnet_Paths Paths
                     WHERE Paths.ApplicationId = @ApplicationId
                           AND PerUser.UserId = Users.UserId
                           AND PerUser.PathId = Paths.PathId
                           AND (@InactiveSinceDate IS NULL OR Users.LastActivityDate <= @InactiveSinceDate)
                           AND (@UserName IS NULL OR Users.LoweredUserName = LOWER(@UserName))
                           AND (@Path IS NULL OR Paths.LoweredPath = LOWER(@Path)))

        SELECT @Count = @@ROWCOUNT
    END
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationAllUsers_GetPageSettings]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_PersonalizationAllUsers_GetPageSettings] (
    @ApplicationName  NVARCHAR(256),
    @Path              NVARCHAR(256))
AS
BEGIN
    DECLARE @ApplicationId UNIQUEIDENTIFIER
    DECLARE @PathId UNIQUEIDENTIFIER

    SELECT @ApplicationId = NULL
    SELECT @PathId = NULL

    EXEC dbo.aspnet_Personalization_GetApplicationId @ApplicationName, @ApplicationId OUTPUT
    IF (@ApplicationId IS NULL)
    BEGIN
        RETURN
    END

    SELECT @PathId = u.PathId FROM dbo.aspnet_Paths u WHERE u.ApplicationId = @ApplicationId AND u.LoweredPath = LOWER(@Path)
    IF (@PathId IS NULL)
    BEGIN
        RETURN
    END

    SELECT p.PageSettings FROM dbo.aspnet_PersonalizationAllUsers p WHERE p.PathId = @PathId
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationAllUsers_ResetPageSettings]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_PersonalizationAllUsers_ResetPageSettings] (
    @ApplicationName  NVARCHAR(256),
    @Path              NVARCHAR(256))
AS
BEGIN
    DECLARE @ApplicationId UNIQUEIDENTIFIER
    DECLARE @PathId UNIQUEIDENTIFIER

    SELECT @ApplicationId = NULL
    SELECT @PathId = NULL

    EXEC dbo.aspnet_Personalization_GetApplicationId @ApplicationName, @ApplicationId OUTPUT
    IF (@ApplicationId IS NULL)
    BEGIN
        RETURN
    END

    SELECT @PathId = u.PathId FROM dbo.aspnet_Paths u WHERE u.ApplicationId = @ApplicationId AND u.LoweredPath = LOWER(@Path)
    IF (@PathId IS NULL)
    BEGIN
        RETURN
    END

    DELETE FROM dbo.aspnet_PersonalizationAllUsers WHERE PathId = @PathId
    RETURN 0
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationAllUsers_SetPageSettings]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_PersonalizationAllUsers_SetPageSettings] (
    @ApplicationName  NVARCHAR(256),
    @Path             NVARCHAR(256),
    @PageSettings     IMAGE,
    @CurrentTimeUtc   DATETIME)
AS
BEGIN
    DECLARE @ApplicationId UNIQUEIDENTIFIER
    DECLARE @PathId UNIQUEIDENTIFIER

    SELECT @ApplicationId = NULL
    SELECT @PathId = NULL

    EXEC dbo.aspnet_Applications_CreateApplication @ApplicationName, @ApplicationId OUTPUT

    SELECT @PathId = u.PathId FROM dbo.aspnet_Paths u WHERE u.ApplicationId = @ApplicationId AND u.LoweredPath = LOWER(@Path)
    IF (@PathId IS NULL)
    BEGIN
        EXEC dbo.aspnet_Paths_CreatePath @ApplicationId, @Path, @PathId OUTPUT
    END

    IF (EXISTS(SELECT PathId FROM dbo.aspnet_PersonalizationAllUsers WHERE PathId = @PathId))
        UPDATE dbo.aspnet_PersonalizationAllUsers SET PageSettings = @PageSettings, LastUpdatedDate = @CurrentTimeUtc WHERE PathId = @PathId
    ELSE
        INSERT INTO dbo.aspnet_PersonalizationAllUsers(PathId, PageSettings, LastUpdatedDate) VALUES (@PathId, @PageSettings, @CurrentTimeUtc)
    RETURN 0
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationPerUser_GetPageSettings]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_PersonalizationPerUser_GetPageSettings] (
    @ApplicationName  NVARCHAR(256),
    @UserName         NVARCHAR(256),
    @Path             NVARCHAR(256),
    @CurrentTimeUtc   DATETIME)
AS
BEGIN
    DECLARE @ApplicationId UNIQUEIDENTIFIER
    DECLARE @PathId UNIQUEIDENTIFIER
    DECLARE @UserId UNIQUEIDENTIFIER

    SELECT @ApplicationId = NULL
    SELECT @PathId = NULL
    SELECT @UserId = NULL

    EXEC dbo.aspnet_Personalization_GetApplicationId @ApplicationName, @ApplicationId OUTPUT
    IF (@ApplicationId IS NULL)
    BEGIN
        RETURN
    END

    SELECT @PathId = u.PathId FROM dbo.aspnet_Paths u WHERE u.ApplicationId = @ApplicationId AND u.LoweredPath = LOWER(@Path)
    IF (@PathId IS NULL)
    BEGIN
        RETURN
    END

    SELECT @UserId = u.UserId FROM dbo.aspnet_Users u WHERE u.ApplicationId = @ApplicationId AND u.LoweredUserName = LOWER(@UserName)
    IF (@UserId IS NULL)
    BEGIN
        RETURN
    END

    UPDATE   dbo.aspnet_Users WITH (ROWLOCK)
    SET      LastActivityDate = @CurrentTimeUtc
    WHERE    UserId = @UserId
    IF (@@ROWCOUNT = 0) -- Username not found
        RETURN

    SELECT p.PageSettings FROM dbo.aspnet_PersonalizationPerUser p WHERE p.PathId = @PathId AND p.UserId = @UserId
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationPerUser_ResetPageSettings]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_PersonalizationPerUser_ResetPageSettings] (
    @ApplicationName  NVARCHAR(256),
    @UserName         NVARCHAR(256),
    @Path             NVARCHAR(256),
    @CurrentTimeUtc   DATETIME)
AS
BEGIN
    DECLARE @ApplicationId UNIQUEIDENTIFIER
    DECLARE @PathId UNIQUEIDENTIFIER
    DECLARE @UserId UNIQUEIDENTIFIER

    SELECT @ApplicationId = NULL
    SELECT @PathId = NULL
    SELECT @UserId = NULL

    EXEC dbo.aspnet_Personalization_GetApplicationId @ApplicationName, @ApplicationId OUTPUT
    IF (@ApplicationId IS NULL)
    BEGIN
        RETURN
    END

    SELECT @PathId = u.PathId FROM dbo.aspnet_Paths u WHERE u.ApplicationId = @ApplicationId AND u.LoweredPath = LOWER(@Path)
    IF (@PathId IS NULL)
    BEGIN
        RETURN
    END

    SELECT @UserId = u.UserId FROM dbo.aspnet_Users u WHERE u.ApplicationId = @ApplicationId AND u.LoweredUserName = LOWER(@UserName)
    IF (@UserId IS NULL)
    BEGIN
        RETURN
    END

    UPDATE   dbo.aspnet_Users WITH (ROWLOCK)
    SET      LastActivityDate = @CurrentTimeUtc
    WHERE    UserId = @UserId
    IF (@@ROWCOUNT = 0) -- Username not found
        RETURN

    DELETE FROM dbo.aspnet_PersonalizationPerUser WHERE PathId = @PathId AND UserId = @UserId
    RETURN 0
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationPerUser_SetPageSettings]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_PersonalizationPerUser_SetPageSettings] (
    @ApplicationName  NVARCHAR(256),
    @UserName         NVARCHAR(256),
    @Path             NVARCHAR(256),
    @PageSettings     IMAGE,
    @CurrentTimeUtc   DATETIME)
AS
BEGIN
    DECLARE @ApplicationId UNIQUEIDENTIFIER
    DECLARE @PathId UNIQUEIDENTIFIER
    DECLARE @UserId UNIQUEIDENTIFIER

    SELECT @ApplicationId = NULL
    SELECT @PathId = NULL
    SELECT @UserId = NULL

    EXEC dbo.aspnet_Applications_CreateApplication @ApplicationName, @ApplicationId OUTPUT

    SELECT @PathId = u.PathId FROM dbo.aspnet_Paths u WHERE u.ApplicationId = @ApplicationId AND u.LoweredPath = LOWER(@Path)
    IF (@PathId IS NULL)
    BEGIN
        EXEC dbo.aspnet_Paths_CreatePath @ApplicationId, @Path, @PathId OUTPUT
    END

    SELECT @UserId = u.UserId FROM dbo.aspnet_Users u WHERE u.ApplicationId = @ApplicationId AND u.LoweredUserName = LOWER(@UserName)
    IF (@UserId IS NULL)
    BEGIN
        EXEC dbo.aspnet_Users_CreateUser @ApplicationId, @UserName, 0, @CurrentTimeUtc, @UserId OUTPUT
    END

    UPDATE   dbo.aspnet_Users WITH (ROWLOCK)
    SET      LastActivityDate = @CurrentTimeUtc
    WHERE    UserId = @UserId
    IF (@@ROWCOUNT = 0) -- Username not found
        RETURN

    IF (EXISTS(SELECT PathId FROM dbo.aspnet_PersonalizationPerUser WHERE UserId = @UserId AND PathId = @PathId))
        UPDATE dbo.aspnet_PersonalizationPerUser SET PageSettings = @PageSettings, LastUpdatedDate = @CurrentTimeUtc WHERE UserId = @UserId AND PathId = @PathId
    ELSE
        INSERT INTO dbo.aspnet_PersonalizationPerUser(UserId, PathId, PageSettings, LastUpdatedDate) VALUES (@UserId, @PathId, @PageSettings, @CurrentTimeUtc)
    RETURN 0
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Profile_DeleteInactiveProfiles]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Profile_DeleteInactiveProfiles]
    @ApplicationName        nvarchar(256),
    @ProfileAuthOptions     int,
    @InactiveSinceDate      datetime
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
    BEGIN
        SELECT  0
        RETURN
    END

    DELETE
    FROM    dbo.aspnet_Profile
    WHERE   UserId IN
            (   SELECT  UserId
                FROM    dbo.aspnet_Users u
                WHERE   ApplicationId = @ApplicationId
                        AND (LastActivityDate <= @InactiveSinceDate)
                        AND (
                                (@ProfileAuthOptions = 2)
                             OR (@ProfileAuthOptions = 0 AND IsAnonymous = 1)
                             OR (@ProfileAuthOptions = 1 AND IsAnonymous = 0)
                            )
            )

    SELECT  @@ROWCOUNT
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Profile_DeleteProfiles]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Profile_DeleteProfiles]
    @ApplicationName        nvarchar(256),
    @UserNames              nvarchar(4000)
AS
BEGIN
    DECLARE @UserName     nvarchar(256)
    DECLARE @CurrentPos   int
    DECLARE @NextPos      int
    DECLARE @NumDeleted   int
    DECLARE @DeletedUser  int
    DECLARE @TranStarted  bit
    DECLARE @ErrorCode    int

    SET @ErrorCode = 0
    SET @CurrentPos = 1
    SET @NumDeleted = 0
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
        BEGIN TRANSACTION
        SET @TranStarted = 1
    END
    ELSE
    	SET @TranStarted = 0

    WHILE (@CurrentPos <= LEN(@UserNames))
    BEGIN
        SELECT @NextPos = CHARINDEX(N',', @UserNames,  @CurrentPos)
        IF (@NextPos = 0 OR @NextPos IS NULL)
            SELECT @NextPos = LEN(@UserNames) + 1

        SELECT @UserName = SUBSTRING(@UserNames, @CurrentPos, @NextPos - @CurrentPos)
        SELECT @CurrentPos = @NextPos+1

        IF (LEN(@UserName) > 0)
        BEGIN
            SELECT @DeletedUser = 0
            EXEC dbo.aspnet_Users_DeleteUser @ApplicationName, @UserName, 4, @DeletedUser OUTPUT
            IF( @@ERROR <> 0 )
            BEGIN
                SET @ErrorCode = -1
                GOTO Cleanup
            END
            IF (@DeletedUser <> 0)
                SELECT @NumDeleted = @NumDeleted + 1
        END
    END
    SELECT @NumDeleted
    IF (@TranStarted = 1)
    BEGIN
    	SET @TranStarted = 0
    	COMMIT TRANSACTION
    END
    SET @TranStarted = 0

    RETURN 0

Cleanup:
    IF (@TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
    	ROLLBACK TRANSACTION
    END
    RETURN @ErrorCode
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Profile_GetNumberOfInactiveProfiles]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Profile_GetNumberOfInactiveProfiles]
    @ApplicationName        nvarchar(256),
    @ProfileAuthOptions     int,
    @InactiveSinceDate      datetime
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
    BEGIN
        SELECT 0
        RETURN
    END

    SELECT  COUNT(*)
    FROM    dbo.aspnet_Users u, dbo.aspnet_Profile p
    WHERE   ApplicationId = @ApplicationId
        AND u.UserId = p.UserId
        AND (LastActivityDate <= @InactiveSinceDate)
        AND (
                (@ProfileAuthOptions = 2)
                OR (@ProfileAuthOptions = 0 AND IsAnonymous = 1)
                OR (@ProfileAuthOptions = 1 AND IsAnonymous = 0)
            )
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Profile_GetProfiles]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Profile_GetProfiles]
    @ApplicationName        nvarchar(256),
    @ProfileAuthOptions     int,
    @PageIndex              int,
    @PageSize               int,
    @UserNameToMatch        nvarchar(256) = NULL,
    @InactiveSinceDate      datetime      = NULL
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN

    -- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    DECLARE @TotalRecords   int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize - 1 + @PageLowerBound

    -- Create a temp table TO store the select results
    CREATE TABLE #PageIndexForUsers
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        UserId uniqueidentifier
    )

    -- Insert into our temp table
    INSERT INTO #PageIndexForUsers (UserId)
        SELECT  u.UserId
        FROM    dbo.aspnet_Users u, dbo.aspnet_Profile p
        WHERE   ApplicationId = @ApplicationId
            AND u.UserId = p.UserId
            AND (@InactiveSinceDate IS NULL OR LastActivityDate <= @InactiveSinceDate)
            AND (     (@ProfileAuthOptions = 2)
                   OR (@ProfileAuthOptions = 0 AND IsAnonymous = 1)
                   OR (@ProfileAuthOptions = 1 AND IsAnonymous = 0)
                 )
            AND (@UserNameToMatch IS NULL OR LoweredUserName LIKE LOWER(@UserNameToMatch))
        ORDER BY UserName

    SELECT  u.UserName, u.IsAnonymous, u.LastActivityDate, p.LastUpdatedDate,
            DATALENGTH(p.PropertyNames) + DATALENGTH(p.PropertyValuesString) + DATALENGTH(p.PropertyValuesBinary)
    FROM    dbo.aspnet_Users u, dbo.aspnet_Profile p, #PageIndexForUsers i
    WHERE   u.UserId = p.UserId AND p.UserId = i.UserId AND i.IndexId >= @PageLowerBound AND i.IndexId <= @PageUpperBound

    SELECT COUNT(*)
    FROM   #PageIndexForUsers

    DROP TABLE #PageIndexForUsers
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Profile_GetProperties]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Profile_GetProperties]
    @ApplicationName      nvarchar(256),
    @UserName             nvarchar(256),
    @CurrentTimeUtc       datetime
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM dbo.aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN

    DECLARE @UserId uniqueidentifier
    SELECT  @UserId = NULL

    SELECT @UserId = UserId
    FROM   dbo.aspnet_Users
    WHERE  ApplicationId = @ApplicationId AND LoweredUserName = LOWER(@UserName)

    IF (@UserId IS NULL)
        RETURN
    SELECT TOP 1 PropertyNames, PropertyValuesString, PropertyValuesBinary
    FROM         dbo.aspnet_Profile
    WHERE        UserId = @UserId

    IF (@@ROWCOUNT > 0)
    BEGIN
        UPDATE dbo.aspnet_Users
        SET    LastActivityDate=@CurrentTimeUtc
        WHERE  UserId = @UserId
    END
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Profile_SetProperties]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Profile_SetProperties]
    @ApplicationName        nvarchar(256),
    @PropertyNames          ntext,
    @PropertyValuesString   ntext,
    @PropertyValuesBinary   image,
    @UserName               nvarchar(256),
    @IsUserAnonymous        bit,
    @CurrentTimeUtc         datetime
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL

    DECLARE @ErrorCode     int
    SET @ErrorCode = 0

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
       BEGIN TRANSACTION
       SET @TranStarted = 1
    END
    ELSE
    	SET @TranStarted = 0

    EXEC dbo.aspnet_Applications_CreateApplication @ApplicationName, @ApplicationId OUTPUT

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    DECLARE @UserId uniqueidentifier
    DECLARE @LastActivityDate datetime
    SELECT  @UserId = NULL
    SELECT  @LastActivityDate = @CurrentTimeUtc

    SELECT @UserId = UserId
    FROM   dbo.aspnet_Users
    WHERE  ApplicationId = @ApplicationId AND LoweredUserName = LOWER(@UserName)
    IF (@UserId IS NULL)
        EXEC dbo.aspnet_Users_CreateUser @ApplicationId, @UserName, @IsUserAnonymous, @LastActivityDate, @UserId OUTPUT

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    UPDATE dbo.aspnet_Users
    SET    LastActivityDate=@CurrentTimeUtc
    WHERE  UserId = @UserId

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    IF (EXISTS( SELECT *
               FROM   dbo.aspnet_Profile
               WHERE  UserId = @UserId))
        UPDATE dbo.aspnet_Profile
        SET    PropertyNames=@PropertyNames, PropertyValuesString = @PropertyValuesString,
               PropertyValuesBinary = @PropertyValuesBinary, LastUpdatedDate=@CurrentTimeUtc
        WHERE  UserId = @UserId
    ELSE
        INSERT INTO dbo.aspnet_Profile(UserId, PropertyNames, PropertyValuesString, PropertyValuesBinary, LastUpdatedDate)
             VALUES (@UserId, @PropertyNames, @PropertyValuesString, @PropertyValuesBinary, @CurrentTimeUtc)

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    IF( @TranStarted = 1 )
    BEGIN
    	SET @TranStarted = 0
    	COMMIT TRANSACTION
    END

    RETURN 0

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
    	ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode

END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_RegisterSchemaVersion]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_RegisterSchemaVersion]
    @Feature                   nvarchar(128),
    @CompatibleSchemaVersion   nvarchar(128),
    @IsCurrentVersion          bit,
    @RemoveIncompatibleSchema  bit
AS
BEGIN
    IF( @RemoveIncompatibleSchema = 1 )
    BEGIN
        DELETE FROM dbo.aspnet_SchemaVersions WHERE Feature = LOWER( @Feature )
    END
    ELSE
    BEGIN
        IF( @IsCurrentVersion = 1 )
        BEGIN
            UPDATE dbo.aspnet_SchemaVersions
            SET IsCurrentVersion = 0
            WHERE Feature = LOWER( @Feature )
        END
    END

    INSERT  dbo.aspnet_SchemaVersions( Feature, CompatibleSchemaVersion, IsCurrentVersion )
    VALUES( LOWER( @Feature ), @CompatibleSchemaVersion, @IsCurrentVersion )
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Roles_CreateRole]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Roles_CreateRole]
    @ApplicationName  nvarchar(256),
    @RoleName         nvarchar(256)
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL

    DECLARE @ErrorCode     int
    SET @ErrorCode = 0

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
        BEGIN TRANSACTION
        SET @TranStarted = 1
    END
    ELSE
        SET @TranStarted = 0

    EXEC dbo.aspnet_Applications_CreateApplication @ApplicationName, @ApplicationId OUTPUT

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    IF (EXISTS(SELECT RoleId FROM dbo.aspnet_Roles WHERE LoweredRoleName = LOWER(@RoleName) AND ApplicationId = @ApplicationId))
    BEGIN
        SET @ErrorCode = 1
        GOTO Cleanup
    END

    INSERT INTO dbo.aspnet_Roles
                (ApplicationId, RoleName, LoweredRoleName)
         VALUES (@ApplicationId, @RoleName, LOWER(@RoleName))

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
        COMMIT TRANSACTION
    END

    RETURN(0)

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
        ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode

END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Roles_DeleteRole]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Roles_DeleteRole]
    @ApplicationName            nvarchar(256),
    @RoleName                   nvarchar(256),
    @DeleteOnlyIfRoleIsEmpty    bit
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN(1)

    DECLARE @ErrorCode     int
    SET @ErrorCode = 0

    DECLARE @TranStarted   bit
    SET @TranStarted = 0

    IF( @@TRANCOUNT = 0 )
    BEGIN
        BEGIN TRANSACTION
        SET @TranStarted = 1
    END
    ELSE
        SET @TranStarted = 0

    DECLARE @RoleId   uniqueidentifier
    SELECT  @RoleId = NULL
    SELECT  @RoleId = RoleId FROM dbo.aspnet_Roles WHERE LoweredRoleName = LOWER(@RoleName) AND ApplicationId = @ApplicationId

    IF (@RoleId IS NULL)
    BEGIN
        SELECT @ErrorCode = 1
        GOTO Cleanup
    END
    IF (@DeleteOnlyIfRoleIsEmpty <> 0)
    BEGIN
        IF (EXISTS (SELECT RoleId FROM dbo.aspnet_UsersInRoles  WHERE @RoleId = RoleId))
        BEGIN
            SELECT @ErrorCode = 2
            GOTO Cleanup
        END
    END


    DELETE FROM dbo.aspnet_UsersInRoles  WHERE @RoleId = RoleId

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    DELETE FROM dbo.aspnet_Roles WHERE @RoleId = RoleId  AND ApplicationId = @ApplicationId

    IF( @@ERROR <> 0 )
    BEGIN
        SET @ErrorCode = -1
        GOTO Cleanup
    END

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
        COMMIT TRANSACTION
    END

    RETURN(0)

Cleanup:

    IF( @TranStarted = 1 )
    BEGIN
        SET @TranStarted = 0
        ROLLBACK TRANSACTION
    END

    RETURN @ErrorCode
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Roles_GetAllRoles]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Roles_GetAllRoles] (
    @ApplicationName           nvarchar(256))
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN
    SELECT RoleName
    FROM   dbo.aspnet_Roles WHERE ApplicationId = @ApplicationId
    ORDER BY RoleName
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Roles_RoleExists]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Roles_RoleExists]
    @ApplicationName  nvarchar(256),
    @RoleName         nvarchar(256)
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN(0)
    IF (EXISTS (SELECT RoleName FROM dbo.aspnet_Roles WHERE LOWER(@RoleName) = LoweredRoleName AND ApplicationId = @ApplicationId ))
        RETURN(1)
    ELSE
        RETURN(0)
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Setup_RemoveAllRoleMembers]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Setup_RemoveAllRoleMembers]
    @name   sysname
AS
BEGIN
    CREATE TABLE #aspnet_RoleMembers
    (
        Group_name      sysname,
        Group_id        smallint,
        Users_in_group  sysname,
        User_id         smallint
    )

    INSERT INTO #aspnet_RoleMembers
    EXEC sp_helpuser @name

    DECLARE @user_id smallint
    DECLARE @cmd nvarchar(500)
    DECLARE c1 cursor FORWARD_ONLY FOR
        SELECT User_id FROM #aspnet_RoleMembers

    OPEN c1

    FETCH c1 INTO @user_id
    WHILE (@@fetch_status = 0)
    BEGIN
        SET @cmd = 'EXEC sp_droprolemember ' + '''' + @name + ''', ''' + USER_NAME(@user_id) + ''''
        EXEC (@cmd)
        FETCH c1 INTO @user_id
    END

    CLOSE c1
    DEALLOCATE c1
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_Setup_RestorePermissions]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Setup_RestorePermissions]
    @name   sysname
AS
BEGIN
    DECLARE @object sysname
    DECLARE @protectType char(10)
    DECLARE @action varchar(60)
    DECLARE @grantee sysname
    DECLARE @cmd nvarchar(500)
    DECLARE c1 cursor FORWARD_ONLY FOR
        SELECT Object, ProtectType, [Action], Grantee FROM #aspnet_Permissions where Object = @name

    OPEN c1

    FETCH c1 INTO @object, @protectType, @action, @grantee
    WHILE (@@fetch_status = 0)
    BEGIN
        SET @cmd = @protectType + ' ' + @action + ' on ' + @object + ' TO [' + @grantee + ']'
        EXEC (@cmd)
        FETCH c1 INTO @object, @protectType, @action, @grantee
    END

    CLOSE c1
    DEALLOCATE c1
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_UnRegisterSchemaVersion]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_UnRegisterSchemaVersion]
    @Feature                   nvarchar(128),
    @CompatibleSchemaVersion   nvarchar(128)
AS
BEGIN
    DELETE FROM dbo.aspnet_SchemaVersions
        WHERE   Feature = LOWER(@Feature) AND @CompatibleSchemaVersion = CompatibleSchemaVersion
END

GO

/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRoles_AddUsersToRoles]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_UsersInRoles_AddUsersToRoles]
	@ApplicationName  nvarchar(256),
	@UserNames		  nvarchar(4000),
	@RoleNames		  nvarchar(4000),
	@CurrentTimeUtc   datetime
AS
BEGIN
	DECLARE @AppId uniqueidentifier
	SELECT  @AppId = NULL
	SELECT  @AppId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
	IF (@AppId IS NULL)
		RETURN(2)
	DECLARE @TranStarted   bit
	SET @TranStarted = 0

	IF( @@TRANCOUNT = 0 )
	BEGIN
		BEGIN TRANSACTION
		SET @TranStarted = 1
	END

	DECLARE @tbNames	table(Name nvarchar(256) NOT NULL PRIMARY KEY)
	DECLARE @tbRoles	table(RoleId uniqueidentifier NOT NULL PRIMARY KEY)
	DECLARE @tbUsers	table(UserId uniqueidentifier NOT NULL PRIMARY KEY)
	DECLARE @Num		int
	DECLARE @Pos		int
	DECLARE @NextPos	int
	DECLARE @Name		nvarchar(256)

	SET @Num = 0
	SET @Pos = 1
	WHILE(@Pos <= LEN(@RoleNames))
	BEGIN
		SELECT @NextPos = CHARINDEX(N',', @RoleNames,  @Pos)
		IF (@NextPos = 0 OR @NextPos IS NULL)
			SELECT @NextPos = LEN(@RoleNames) + 1
		SELECT @Name = RTRIM(LTRIM(SUBSTRING(@RoleNames, @Pos, @NextPos - @Pos)))
		SELECT @Pos = @NextPos+1

		INSERT INTO @tbNames VALUES (@Name)
		SET @Num = @Num + 1
	END

	INSERT INTO @tbRoles
	  SELECT RoleId
	  FROM   dbo.aspnet_Roles ar, @tbNames t
	  WHERE  LOWER(t.Name) = ar.LoweredRoleName AND ar.ApplicationId = @AppId

	IF (@@ROWCOUNT <> @Num)
	BEGIN
		SELECT TOP 1 Name
		FROM   @tbNames
		WHERE  LOWER(Name) NOT IN (SELECT ar.LoweredRoleName FROM dbo.aspnet_Roles ar,  @tbRoles r WHERE r.RoleId = ar.RoleId)
		IF( @TranStarted = 1 )
			ROLLBACK TRANSACTION
		RETURN(2)
	END

	DELETE FROM @tbNames WHERE 1=1
	SET @Num = 0
	SET @Pos = 1

	WHILE(@Pos <= LEN(@UserNames))
	BEGIN
		SELECT @NextPos = CHARINDEX(N',', @UserNames,  @Pos)
		IF (@NextPos = 0 OR @NextPos IS NULL)
			SELECT @NextPos = LEN(@UserNames) + 1
		SELECT @Name = RTRIM(LTRIM(SUBSTRING(@UserNames, @Pos, @NextPos - @Pos)))
		SELECT @Pos = @NextPos+1

		INSERT INTO @tbNames VALUES (@Name)
		SET @Num = @Num + 1
	END

	INSERT INTO @tbUsers
	  SELECT UserId
	  FROM   dbo.aspnet_Users ar, @tbNames t
	  WHERE  LOWER(t.Name) = ar.LoweredUserName AND ar.ApplicationId = @AppId

	IF (@@ROWCOUNT <> @Num)
	BEGIN
		DELETE FROM @tbNames
		WHERE LOWER(Name) IN (SELECT LoweredUserName FROM dbo.aspnet_Users au,  @tbUsers u WHERE au.UserId = u.UserId)

		INSERT dbo.aspnet_Users (ApplicationId, UserId, UserName, LoweredUserName, IsAnonymous, LastActivityDate)
		  SELECT @AppId, NEWID(), Name, LOWER(Name), 0, @CurrentTimeUtc
		  FROM   @tbNames

		INSERT INTO @tbUsers
		  SELECT  UserId
		  FROM	dbo.aspnet_Users au, @tbNames t
		  WHERE   LOWER(t.Name) = au.LoweredUserName AND au.ApplicationId = @AppId
	END

	IF (EXISTS (SELECT * FROM dbo.aspnet_UsersInRoles ur, @tbUsers tu, @tbRoles tr WHERE tu.UserId = ur.UserId AND tr.RoleId = ur.RoleId))
	BEGIN
		SELECT TOP 1 UserName, RoleName
		FROM		 dbo.aspnet_UsersInRoles ur, @tbUsers tu, @tbRoles tr, aspnet_Users u, aspnet_Roles r
		WHERE		u.UserId = tu.UserId AND r.RoleId = tr.RoleId AND tu.UserId = ur.UserId AND tr.RoleId = ur.RoleId

		IF( @TranStarted = 1 )
			ROLLBACK TRANSACTION
		RETURN(3)
	END

	INSERT INTO dbo.aspnet_UsersInRoles (UserId, RoleId)
	SELECT UserId, RoleId
	FROM @tbUsers, @tbRoles

	IF( @TranStarted = 1 )
		COMMIT TRANSACTION
	RETURN(0)
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRoles_FindUsersInRole]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_UsersInRoles_FindUsersInRole]
    @ApplicationName  nvarchar(256),
    @RoleName         nvarchar(256),
    @UserNameToMatch  nvarchar(256)
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN(1)
     DECLARE @RoleId uniqueidentifier
     SELECT  @RoleId = NULL

     SELECT  @RoleId = RoleId
     FROM    dbo.aspnet_Roles
     WHERE   LOWER(@RoleName) = LoweredRoleName AND ApplicationId = @ApplicationId

     IF (@RoleId IS NULL)
         RETURN(1)

    SELECT u.UserName
    FROM   dbo.aspnet_Users u, dbo.aspnet_UsersInRoles ur
    WHERE  u.UserId = ur.UserId AND @RoleId = ur.RoleId AND u.ApplicationId = @ApplicationId AND LoweredUserName LIKE LOWER(@UserNameToMatch)
    ORDER BY u.UserName
    RETURN(0)
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRoles_GetRolesForUser]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_UsersInRoles_GetRolesForUser]
    @ApplicationName  nvarchar(256),
    @UserName         nvarchar(256)
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN(1)
    DECLARE @UserId uniqueidentifier
    SELECT  @UserId = NULL

    SELECT  @UserId = UserId
    FROM    dbo.aspnet_Users
    WHERE   LoweredUserName = LOWER(@UserName) AND ApplicationId = @ApplicationId

    IF (@UserId IS NULL)
        RETURN(1)

    SELECT r.RoleName
    FROM   dbo.aspnet_Roles r, dbo.aspnet_UsersInRoles ur
    WHERE  r.RoleId = ur.RoleId AND r.ApplicationId = @ApplicationId AND ur.UserId = @UserId
    ORDER BY r.RoleName
    RETURN (0)
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRoles_GetUsersInRoles]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_UsersInRoles_GetUsersInRoles]
    @ApplicationName  nvarchar(256),
    @RoleName         nvarchar(256)
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN(1)
     DECLARE @RoleId uniqueidentifier
     SELECT  @RoleId = NULL

     SELECT  @RoleId = RoleId
     FROM    dbo.aspnet_Roles
     WHERE   LOWER(@RoleName) = LoweredRoleName AND ApplicationId = @ApplicationId

     IF (@RoleId IS NULL)
         RETURN(1)

    SELECT u.UserName
    FROM   dbo.aspnet_Users u, dbo.aspnet_UsersInRoles ur
    WHERE  u.UserId = ur.UserId AND @RoleId = ur.RoleId AND u.ApplicationId = @ApplicationId
    ORDER BY u.UserName
    RETURN(0)
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRoles_IsUserInRole]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_UsersInRoles_IsUserInRole]
    @ApplicationName  nvarchar(256),
    @UserName         nvarchar(256),
    @RoleName         nvarchar(256)
AS
BEGIN
    DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN(2)
    DECLARE @UserId uniqueidentifier
    SELECT  @UserId = NULL
    DECLARE @RoleId uniqueidentifier
    SELECT  @RoleId = NULL

    SELECT  @UserId = UserId
    FROM    dbo.aspnet_Users
    WHERE   LoweredUserName = LOWER(@UserName) AND ApplicationId = @ApplicationId

    IF (@UserId IS NULL)
        RETURN(2)

    SELECT  @RoleId = RoleId
    FROM    dbo.aspnet_Roles
    WHERE   LoweredRoleName = LOWER(@RoleName) AND ApplicationId = @ApplicationId

    IF (@RoleId IS NULL)
        RETURN(3)

    IF (EXISTS( SELECT * FROM dbo.aspnet_UsersInRoles WHERE  UserId = @UserId AND RoleId = @RoleId))
        RETURN(1)
    ELSE
        RETURN(0)
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRoles_RemoveUsersFromRoles]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_UsersInRoles_RemoveUsersFromRoles]
	@ApplicationName  nvarchar(256),
	@UserNames		  nvarchar(4000),
	@RoleNames		  nvarchar(4000)
AS
BEGIN
	DECLARE @AppId uniqueidentifier
	SELECT  @AppId = NULL
	SELECT  @AppId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
	IF (@AppId IS NULL)
		RETURN(2)


	DECLARE @TranStarted   bit
	SET @TranStarted = 0

	IF( @@TRANCOUNT = 0 )
	BEGIN
		BEGIN TRANSACTION
		SET @TranStarted = 1
	END

	DECLARE @tbNames  table(Name nvarchar(256) NOT NULL PRIMARY KEY)
	DECLARE @tbRoles  table(RoleId uniqueidentifier NOT NULL PRIMARY KEY)
	DECLARE @tbUsers  table(UserId uniqueidentifier NOT NULL PRIMARY KEY)
	DECLARE @Num	  int
	DECLARE @Pos	  int
	DECLARE @NextPos  int
	DECLARE @Name	  nvarchar(256)
	DECLARE @CountAll int
	DECLARE @CountU	  int
	DECLARE @CountR	  int


	SET @Num = 0
	SET @Pos = 1
	WHILE(@Pos <= LEN(@RoleNames))
	BEGIN
		SELECT @NextPos = CHARINDEX(N',', @RoleNames,  @Pos)
		IF (@NextPos = 0 OR @NextPos IS NULL)
			SELECT @NextPos = LEN(@RoleNames) + 1
		SELECT @Name = RTRIM(LTRIM(SUBSTRING(@RoleNames, @Pos, @NextPos - @Pos)))
		SELECT @Pos = @NextPos+1

		INSERT INTO @tbNames VALUES (@Name)
		SET @Num = @Num + 1
	END

	INSERT INTO @tbRoles
	  SELECT RoleId
	  FROM   dbo.aspnet_Roles ar, @tbNames t
	  WHERE  LOWER(t.Name) = ar.LoweredRoleName AND ar.ApplicationId = @AppId
	SELECT @CountR = @@ROWCOUNT

	IF (@CountR <> @Num)
	BEGIN
		SELECT TOP 1 N'', Name
		FROM   @tbNames
		WHERE  LOWER(Name) NOT IN (SELECT ar.LoweredRoleName FROM dbo.aspnet_Roles ar,  @tbRoles r WHERE r.RoleId = ar.RoleId)
		IF( @TranStarted = 1 )
			ROLLBACK TRANSACTION
		RETURN(2)
	END


	DELETE FROM @tbNames WHERE 1=1
	SET @Num = 0
	SET @Pos = 1


	WHILE(@Pos <= LEN(@UserNames))
	BEGIN
		SELECT @NextPos = CHARINDEX(N',', @UserNames,  @Pos)
		IF (@NextPos = 0 OR @NextPos IS NULL)
			SELECT @NextPos = LEN(@UserNames) + 1
		SELECT @Name = RTRIM(LTRIM(SUBSTRING(@UserNames, @Pos, @NextPos - @Pos)))
		SELECT @Pos = @NextPos+1

		INSERT INTO @tbNames VALUES (@Name)
		SET @Num = @Num + 1
	END

	INSERT INTO @tbUsers
	  SELECT UserId
	  FROM   dbo.aspnet_Users ar, @tbNames t
	  WHERE  LOWER(t.Name) = ar.LoweredUserName AND ar.ApplicationId = @AppId

	SELECT @CountU = @@ROWCOUNT
	IF (@CountU <> @Num)
	BEGIN
		SELECT TOP 1 Name, N''
		FROM   @tbNames
		WHERE  LOWER(Name) NOT IN (SELECT au.LoweredUserName FROM dbo.aspnet_Users au,  @tbUsers u WHERE u.UserId = au.UserId)

		IF( @TranStarted = 1 )
			ROLLBACK TRANSACTION
		RETURN(1)
	END

	SELECT  @CountAll = COUNT(*)
	FROM	dbo.aspnet_UsersInRoles ur, @tbUsers u, @tbRoles r
	WHERE   ur.UserId = u.UserId AND ur.RoleId = r.RoleId

	IF (@CountAll <> @CountU * @CountR)
	BEGIN
		SELECT TOP 1 UserName, RoleName
		FROM		 @tbUsers tu, @tbRoles tr, dbo.aspnet_Users u, dbo.aspnet_Roles r
		WHERE		 u.UserId = tu.UserId AND r.RoleId = tr.RoleId AND
					 tu.UserId NOT IN (SELECT ur.UserId FROM dbo.aspnet_UsersInRoles ur WHERE ur.RoleId = tr.RoleId) AND
					 tr.RoleId NOT IN (SELECT ur.RoleId FROM dbo.aspnet_UsersInRoles ur WHERE ur.UserId = tu.UserId)
		IF( @TranStarted = 1 )
			ROLLBACK TRANSACTION
		RETURN(3)
	END

	DELETE FROM dbo.aspnet_UsersInRoles
	WHERE UserId IN (SELECT UserId FROM @tbUsers)
	  AND RoleId IN (SELECT RoleId FROM @tbRoles)
	IF( @TranStarted = 1 )
		COMMIT TRANSACTION
	RETURN(0)
END

GO
/****** Object:  StoredProcedure [dbo].[aspnet_WebEvent_LogEvent]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_WebEvent_LogEvent]
        @EventId         char(32),
        @EventTimeUtc    datetime,
        @EventTime       datetime,
        @EventType       nvarchar(256),
        @EventSequence   decimal(19,0),
        @EventOccurrence decimal(19,0),
        @EventCode       int,
        @EventDetailCode int,
        @Message         nvarchar(1024),
        @ApplicationPath nvarchar(256),
        @ApplicationVirtualPath nvarchar(256),
        @MachineName    nvarchar(256),
        @RequestUrl      nvarchar(1024),
        @ExceptionType   nvarchar(256),
        @Details         ntext
AS
BEGIN
    INSERT
        dbo.aspnet_WebEvent_Events
        (
            EventId,
            EventTimeUtc,
            EventTime,
            EventType,
            EventSequence,
            EventOccurrence,
            EventCode,
            EventDetailCode,
            Message,
            ApplicationPath,
            ApplicationVirtualPath,
            MachineName,
            RequestUrl,
            ExceptionType,
            Details
        )
    VALUES
    (
        @EventId,
        @EventTimeUtc,
        @EventTime,
        @EventType,
        @EventSequence,
        @EventOccurrence,
        @EventCode,
        @EventDetailCode,
        @Message,
        @ApplicationPath,
        @ApplicationVirtualPath,
        @MachineName,
        @RequestUrl,
        @ExceptionType,
        @Details
    )
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_htLanguagesDelete]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_htLanguagesDelete]
(
	@IDLanguage tinyint
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Ciemesus_htLanguages]
	WHERE
		[IDLanguage] = @IDLanguage
	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_htLanguagesInsert]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_htLanguagesInsert]
(
	@IDLanguage tinyint,
	@Title nvarchar(100),
	@Code nvarchar(50),
	@IsRTL bit,
	@IsActive bit,
	@IsDefault bit,
	@Priority int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Ciemesus_htLanguages]
	(
		[IDLanguage],
		[Title],
		[Code],
		[IsRTL],
		[IsActive],
		[IsDefault],
		[Priority]
	)
	VALUES
	(
		@IDLanguage,
		@Title,
		@Code,
		@IsRTL,
		@IsActive,
		@IsDefault,
		@Priority
	)

	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_htLanguagesLoadAll]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_htLanguagesLoadAll]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID tinyint
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDLanguage
	FROM [Ciemesus_htLanguages]

    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDLanguage],
		[Title],
		[Code],
		[IsRTL],
		[IsActive],
		[IsDefault],
		[Priority]
	FROM [Ciemesus_htLanguages]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_htLanguages].IDLanguage = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_htLanguages]
                  ON [Ciemesus_htLanguages].IDLanguage = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDLanguage],
		[Title],
		[Code],
		[IsRTL],
		[IsActive],
		[IsDefault],
		[Priority]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_htLanguages]
                      ON [Ciemesus_htLanguages].IDLanguage = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_htLanguagesLoadByPrimaryKey]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_htLanguagesLoadByPrimaryKey]
(
	@IDLanguage tinyint
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[IDLanguage],
		[Title],
		[Code],
		[IsRTL],
		[IsActive],
		[IsDefault],
		[Priority]
	FROM [Ciemesus_htLanguages]
	WHERE
		([IDLanguage] = @IDLanguage)

	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_htLanguagesSearch]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_htLanguagesSearch]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @IDLanguage tinyint = NULL,
	  @Title nvarchar(100) = NULL,
	  @Code nvarchar(50) = NULL,
	  @IsRTL bit = NULL,
	  @IsActive bit = NULL,
	  @IsDefault bit = NULL,
	  @Priority int = NULL,
@SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID tinyint
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDLanguage
	FROM [Ciemesus_htLanguages]
	WHERE
		(@IDLanguage IS NULL OR IDLanguage = @IDLanguage)AND
		(@Title IS NULL OR Title LIKE '%' + @Title + '%')AND
		(@Code IS NULL OR Code LIKE '%' + @Code + '%')AND
		(@IsRTL IS NULL OR IsRTL = @IsRTL)AND
		(@IsActive IS NULL OR IsActive = @IsActive)AND
		(@IsDefault IS NULL OR IsDefault = @IsDefault)AND
		(@Priority IS NULL OR Priority = @Priority)
    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDLanguage],
		[Title],
		[Code],
		[IsRTL],
		[IsActive],
		[IsDefault],
		[Priority]
	FROM [Ciemesus_htLanguages]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_htLanguages].IDLanguage = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_htLanguages]
                  ON [Ciemesus_htLanguages].IDLanguage = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDLanguage],
		[Title],
		[Code],
		[IsRTL],
		[IsActive],
		[IsDefault],
		[Priority]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_htLanguages]
                      ON [Ciemesus_htLanguages].IDLanguage = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_htLanguagesUpdate]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_htLanguagesUpdate]
(
	@IDLanguage tinyint,
	@Title nvarchar(100),
	@Code nvarchar(50),
	@IsRTL bit,
	@IsActive bit,
	@IsDefault bit,
	@Priority int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Ciemesus_htLanguages]
	SET
		[Title] = @Title,
		[Code] = @Code,
		[IsRTL] = @IsRTL,
		[IsActive] = @IsActive,
		[IsDefault] = @IsDefault,
		[Priority] = @Priority
	WHERE
		[IDLanguage] = @IDLanguage


	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_htMediaSubjectTypesDelete]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_htMediaSubjectTypesDelete]
(
	@IDMediaSubjectType tinyint
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Ciemesus_htMediaSubjectTypes]
	WHERE
		[IDMediaSubjectType] = @IDMediaSubjectType
	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_htMediaSubjectTypesInsert]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_htMediaSubjectTypesInsert]
(
	@IDMediaSubjectType tinyint,
	@Title nvarchar(50)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Ciemesus_htMediaSubjectTypes]
	(
		[IDMediaSubjectType],
		[Title]
	)
	VALUES
	(
		@IDMediaSubjectType,
		@Title
	)

	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_htMediaSubjectTypesLoadAll]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_htMediaSubjectTypesLoadAll]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID tinyint
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDMediaSubjectType
	FROM [Ciemesus_htMediaSubjectTypes]

    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDMediaSubjectType],
		[Title]
	FROM [Ciemesus_htMediaSubjectTypes]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_htMediaSubjectTypes].IDMediaSubjectType = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_htMediaSubjectTypes]
                  ON [Ciemesus_htMediaSubjectTypes].IDMediaSubjectType = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDMediaSubjectType],
		[Title]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_htMediaSubjectTypes]
                      ON [Ciemesus_htMediaSubjectTypes].IDMediaSubjectType = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_htMediaSubjectTypesLoadByPrimaryKey]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_htMediaSubjectTypesLoadByPrimaryKey]
(
	@IDMediaSubjectType tinyint
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[IDMediaSubjectType],
		[Title]
	FROM [Ciemesus_htMediaSubjectTypes]
	WHERE
		([IDMediaSubjectType] = @IDMediaSubjectType)

	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_htMediaSubjectTypesSearch]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_htMediaSubjectTypesSearch]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @IDMediaSubjectType tinyint = NULL,
	  @Title nvarchar(50) = NULL,
@SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID tinyint
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDMediaSubjectType
	FROM [Ciemesus_htMediaSubjectTypes]
	WHERE
		(@IDMediaSubjectType IS NULL OR IDMediaSubjectType = @IDMediaSubjectType)AND
		(@Title IS NULL OR Title LIKE '%' + @Title + '%')
    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDMediaSubjectType],
		[Title]
	FROM [Ciemesus_htMediaSubjectTypes]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_htMediaSubjectTypes].IDMediaSubjectType = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_htMediaSubjectTypes]
                  ON [Ciemesus_htMediaSubjectTypes].IDMediaSubjectType = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDMediaSubjectType],
		[Title]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_htMediaSubjectTypes]
                      ON [Ciemesus_htMediaSubjectTypes].IDMediaSubjectType = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_htMediaSubjectTypesUpdate]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_htMediaSubjectTypesUpdate]
(
	@IDMediaSubjectType tinyint,
	@Title nvarchar(50)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Ciemesus_htMediaSubjectTypes]
	SET
		[Title] = @Title
	WHERE
		[IDMediaSubjectType] = @IDMediaSubjectType


	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_htPropertyTypesDelete]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Ciemesus_htPropertyTypesDelete]
(
	@IDType tinyint
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Ciemesus_htPropertyTypes]
	WHERE
		[IDType] = @IDType
	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_htPropertyTypesInsert]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Ciemesus_htPropertyTypesInsert]
(
	@IDType tinyint = NULL output,
	@Name nvarchar(50)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Ciemesus_htPropertyTypes]
	(
		[Name]
	)
	VALUES
	(
		@Name
	)

	SET @Err = @@Error

	SELECT @IDType = SCOPE_IDENTITY()

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_htPropertyTypesLoadAll]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Ciemesus_htPropertyTypesLoadAll]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID tinyint
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDType
	FROM [Ciemesus_htPropertyTypes]

    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDType],
		[Name]
	FROM [Ciemesus_htPropertyTypes]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_htPropertyTypes].IDType = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_htPropertyTypes]
                  ON [Ciemesus_htPropertyTypes].IDType = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDType],
		[Name]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_htPropertyTypes]
                      ON [Ciemesus_htPropertyTypes].IDType = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_htPropertyTypesLoadByPrimaryKey]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Ciemesus_htPropertyTypesLoadByPrimaryKey]
(
	@IDType tinyint
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[IDType],
		[Name]
	FROM [Ciemesus_htPropertyTypes]
	WHERE
		([IDType] = @IDType)

	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_htPropertyTypesSearch]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Ciemesus_htPropertyTypesSearch]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @IDType tinyint = NULL,
	  @Name nvarchar(50) = NULL,
@SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID tinyint
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDType
	FROM [Ciemesus_htPropertyTypes]
	WHERE
		(@IDType IS NULL OR IDType = @IDType)AND
		(@Name IS NULL OR Name LIKE '%' + @Name + '%')
    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDType],
		[Name]
	FROM [Ciemesus_htPropertyTypes]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_htPropertyTypes].IDType = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_htPropertyTypes]
                  ON [Ciemesus_htPropertyTypes].IDType = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDType],
		[Name]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_htPropertyTypes]
                      ON [Ciemesus_htPropertyTypes].IDType = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_htPropertyTypesUpdate]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Ciemesus_htPropertyTypesUpdate]
(
	@IDType tinyint,
	@Name nvarchar(50)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Ciemesus_htPropertyTypes]
	SET
		[Name] = @Name
	WHERE
		[IDType] = @IDType


	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_htSubjectTypesDelete]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_htSubjectTypesDelete]
(
	@IDSubjectType tinyint
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Ciemesus_htSubjectTypes]
	WHERE
		[IDSubjectType] = @IDSubjectType
	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_htSubjectTypesInsert]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_htSubjectTypesInsert]
(
	@IDSubjectType tinyint,
	@Title nvarchar(50),
	@Priority int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Ciemesus_htSubjectTypes]
	(
		[IDSubjectType],
		[Title],
		[Priority]
	)
	VALUES
	(
		@IDSubjectType,
		@Title,
		@Priority
	)

	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_htSubjectTypesLoadAll]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_htSubjectTypesLoadAll]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID tinyint
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDSubjectType
	FROM [Ciemesus_htSubjectTypes]

    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDSubjectType],
		[Title],
		[Priority]
	FROM [Ciemesus_htSubjectTypes]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_htSubjectTypes].IDSubjectType = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_htSubjectTypes]
                  ON [Ciemesus_htSubjectTypes].IDSubjectType = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDSubjectType],
		[Title],
		[Priority]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_htSubjectTypes]
                      ON [Ciemesus_htSubjectTypes].IDSubjectType = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_htSubjectTypesLoadByPrimaryKey]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_htSubjectTypesLoadByPrimaryKey]
(
	@IDSubjectType tinyint
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[IDSubjectType],
		[Title],
		[Priority]
	FROM [Ciemesus_htSubjectTypes]
	WHERE
		([IDSubjectType] = @IDSubjectType)

	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_htSubjectTypesSearch]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_htSubjectTypesSearch]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @IDSubjectType tinyint = NULL,
	  @Title nvarchar(50) = NULL,
	  @Priority int = NULL,
@SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID tinyint
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDSubjectType
	FROM [Ciemesus_htSubjectTypes]
	WHERE
		(@IDSubjectType IS NULL OR IDSubjectType = @IDSubjectType)AND
		(@Title IS NULL OR Title LIKE '%' + @Title + '%')AND
		(@Priority IS NULL OR Priority = @Priority)
    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDSubjectType],
		[Title],
		[Priority]
	FROM [Ciemesus_htSubjectTypes]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_htSubjectTypes].IDSubjectType = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_htSubjectTypes]
                  ON [Ciemesus_htSubjectTypes].IDSubjectType = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDSubjectType],
		[Title],
		[Priority]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_htSubjectTypes]
                      ON [Ciemesus_htSubjectTypes].IDSubjectType = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_htSubjectTypesUpdate]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_htSubjectTypesUpdate]
(
	@IDSubjectType tinyint,
	@Title nvarchar(50),
	@Priority int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Ciemesus_htSubjectTypes]
	SET
		[Title] = @Title,
		[Priority] = @Priority
	WHERE
		[IDSubjectType] = @IDSubjectType


	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tGalleryPluginsDelete]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tGalleryPluginsDelete]
(
	@IDSubject uniqueidentifier,
	@IDPlugin int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Ciemesus_tGalleryPlugins]
	WHERE
		[IDSubject] = @IDSubject AND
		[IDPlugin] = @IDPlugin
	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tGalleryPluginsInsert]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tGalleryPluginsInsert]
(
	@IDSubject uniqueidentifier,
	@IDPlugin int,
	@Options nvarchar(MAX) = NULL,
	@CSS nvarchar(MAX) = NULL,
	@DateFormat nvarchar(50) = NULL,
	@GenerateTitle bit = NULL,
	@GenerateDesc bit = NULL,
	@GenerateDate bit = NULL,
	@GenerateAnchor bit = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int
	IF @IDSubject IS NULL
		 SET @IDSubject = NEWID()

	SET @Err = @@Error

	IF (@Err <> 0)
	    RETURN @Err

	INSERT
	INTO [Ciemesus_tGalleryPlugins]
	(
		[IDSubject],
		[IDPlugin],
		[Options],
		[CSS],
		[DateFormat],
		[GenerateTitle],
		[GenerateDesc],
		[GenerateDate],
		[GenerateAnchor]
	)
	VALUES
	(
		@IDSubject,
		@IDPlugin,
		@Options,
		@CSS,
		@DateFormat,
		@GenerateTitle,
		@GenerateDesc,
		@GenerateDate,
		@GenerateAnchor
	)

	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tGalleryPluginsLoadAll]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Ciemesus_tGalleryPluginsLoadAll]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID uniqueidentifier
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDSubject
	FROM [Ciemesus_tGalleryPlugins]

    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDSubject],
		[IDPlugin],
		[Options],
		[CSS],
		[DateFormat],
		[GenerateTitle],
		[GenerateDesc],
		[GenerateDate],
		[GenerateAnchor]
	FROM [Ciemesus_tGalleryPlugins]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tGalleryPlugins].IDSubject = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tGalleryPlugins]
                  ON [Ciemesus_tGalleryPlugins].IDSubject = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDSubject],
		[IDPlugin],
		[Options],
		[CSS],
		[DateFormat],
		[GenerateTitle],
		[GenerateDesc],
		[GenerateDate],
		[GenerateAnchor]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tGalleryPlugins]
                      ON [Ciemesus_tGalleryPlugins].IDSubject = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tGalleryPluginsLoadByPrimaryKey]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tGalleryPluginsLoadByPrimaryKey]
(
	@IDSubject uniqueidentifier
,	@IDPlugin int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[IDSubject],
		[IDPlugin],
		[Options],
		[CSS],
		[DateFormat],
		[GenerateTitle],
		[GenerateDesc],
		[GenerateDate],
		[GenerateAnchor]
	FROM [Ciemesus_tGalleryPlugins]
	WHERE
		([IDSubject] = @IDSubject)
 AND
		([IDPlugin] = @IDPlugin)

	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tGalleryPluginsSearch]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tGalleryPluginsSearch]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @IDSubject uniqueidentifier = NULL,
	  @IDPlugin int = NULL,
	  @Options nvarchar(MAX) = NULL,
	  @CSS nvarchar(MAX) = NULL,
	  @DateFormat nvarchar(50) = NULL,
	  @GenerateTitle bit = NULL,
	  @GenerateDesc bit = NULL,
	  @GenerateDate bit = NULL,
	  @GenerateAnchor bit = NULL,
@SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID uniqueidentifier
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDSubject
	FROM [Ciemesus_tGalleryPlugins]
	WHERE
		(@IDSubject IS NULL OR IDSubject = @IDSubject)AND
		(@IDPlugin IS NULL OR IDPlugin = @IDPlugin)AND
		(@Options IS NULL OR Options LIKE '%' + @Options + '%')AND
		(@CSS IS NULL OR CSS LIKE '%' + @CSS + '%')AND
		(@DateFormat IS NULL OR DateFormat LIKE '%' + @DateFormat + '%')AND
		(@GenerateTitle IS NULL OR GenerateTitle = @GenerateTitle)AND
		(@GenerateDesc IS NULL OR GenerateDesc = @GenerateDesc)AND
		(@GenerateDate IS NULL OR GenerateDate = @GenerateDate)AND
		(@GenerateAnchor IS NULL OR GenerateAnchor = @GenerateAnchor)
    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDSubject],
		[IDPlugin],
		[Options],
		[CSS],
		[DateFormat],
		[GenerateTitle],
		[GenerateDesc],
		[GenerateDate],
		[GenerateAnchor]
	FROM [Ciemesus_tGalleryPlugins]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tGalleryPlugins].IDSubject = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tGalleryPlugins]
                  ON [Ciemesus_tGalleryPlugins].IDSubject = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDSubject],
		[IDPlugin],
		[Options],
		[CSS],
		[DateFormat],
		[GenerateTitle],
		[GenerateDesc],
		[GenerateDate],
		[GenerateAnchor]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tGalleryPlugins]
                      ON [Ciemesus_tGalleryPlugins].IDSubject = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tGalleryPluginsUpdate]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tGalleryPluginsUpdate]
(
	@IDSubject uniqueidentifier,
	@IDPlugin int,
	@Options nvarchar(MAX) = NULL,
	@CSS nvarchar(MAX) = NULL,
	@DateFormat nvarchar(50) = NULL,
	@GenerateTitle bit = NULL,
	@GenerateDesc bit = NULL,
	@GenerateDate bit = NULL,
	@GenerateAnchor bit = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Ciemesus_tGalleryPlugins]
	SET
		[Options] = @Options,
		[CSS] = @CSS,
		[DateFormat] = @DateFormat,
		[GenerateTitle] = @GenerateTitle,
		[GenerateDesc] = @GenerateDesc,
		[GenerateDate] = @GenerateDate,
		[GenerateAnchor] = @GenerateAnchor
	WHERE
		[IDSubject] = @IDSubject	AND	[IDPlugin] = @IDPlugin


	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tLogsDelete]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tLogsDelete]
(
	@IDLog bigint
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Ciemesus_tLogs]
	WHERE
		[IDLog] = @IDLog
	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tLogsInsert]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tLogsInsert]
(
	@IDLog bigint,
	@ModuleName nvarchar(128) = NULL,
	@XML xml,
	@CreationDate datetime,
	@UserID uniqueidentifier,
	@UserFullName nvarchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Ciemesus_tLogs]
	(
		[IDLog],
		[ModuleName],
		[XML],
		[CreationDate],
		[UserID],
		[UserFullName]
	)
	VALUES
	(
		@IDLog,
		@ModuleName,
		@XML,
		@CreationDate,
		@UserID,
		@UserFullName
	)

	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tLogsLoadAll]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tLogsLoadAll]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID bigint
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDLog
	FROM [Ciemesus_tLogs]

    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDLog],
		[ModuleName],
		[XML],
		[CreationDate],
		[UserID],
		[UserFullName]
	FROM [Ciemesus_tLogs]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tLogs].IDLog = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tLogs]
                  ON [Ciemesus_tLogs].IDLog = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDLog],
		[ModuleName],
		[XML],
		[CreationDate],
		[UserID],
		[UserFullName]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tLogs]
                      ON [Ciemesus_tLogs].IDLog = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tLogsLoadByPrimaryKey]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tLogsLoadByPrimaryKey]
(
	@IDLog bigint
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[IDLog],
		[ModuleName],
		[XML],
		[CreationDate],
		[UserID],
		[UserFullName]
	FROM [Ciemesus_tLogs]
	WHERE
		([IDLog] = @IDLog)

	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tLogsSearch]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tLogsSearch]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @IDLog bigint = NULL,
	  @ModuleName nvarchar(128) = NULL,
	  @CreationDateFrom datetime = NULL,	  
	  @CreationDateTo datetime = NULL,
	  @UserID uniqueidentifier = NULL,
	  @UserFullName nvarchar(50) = NULL,
	  @SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID bigint
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDLog
	FROM [Ciemesus_tLogs]
	WHERE
		(@IDLog IS NULL OR IDLog = @IDLog)AND
		(@ModuleName IS NULL OR ModuleName LIKE '%' + @ModuleName + '%')AND
		(@CreationDateFrom IS NULL OR CreationDate >= @CreationDateFrom)AND
		(@CreationDateTo IS NULL OR CreationDate <= @CreationDateTo)AND
		(@UserID IS NULL OR UserID = @UserID)AND
		(@UserFullName IS NULL OR UserFullName LIKE '%' + @UserFullName + '%')
    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDLog],
		[ModuleName],
		[CreationDate],
		[UserID],
		[UserFullName]
	FROM [Ciemesus_tLogs]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tLogs].IDLog = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tLogs]
                  ON [Ciemesus_tLogs].IDLog = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDLog],
		[ModuleName],
		[CreationDate],
		[UserID],
		[UserFullName]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tLogs]
                      ON [Ciemesus_tLogs].IDLog = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tLogsUpdate]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tLogsUpdate]
(
	@IDLog bigint,
	@ModuleName nvarchar(128) = NULL,
	@XML xml,
	@CreationDate datetime,
	@UserID uniqueidentifier,
	@UserFullName nvarchar(50) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Ciemesus_tLogs]
	SET
		[ModuleName] = @ModuleName,
		[XML] = @XML,
		[CreationDate] = @CreationDate,
		[UserID] = @UserID,
		[UserFullName] = @UserFullName
	WHERE
		[IDLog] = @IDLog


	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tMediasDelete]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tMediasDelete]
(
	@IDMedia int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Ciemesus_tMedias]
	WHERE
		[IDMedia] = @IDMedia
	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tMediasInsert]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tMediasInsert]
(
	@IDMedia int = NULL output,
	@FileName nvarchar(128),
	@FileExtention nvarchar(50),
	@Description nvarchar(512) = NULL,
	@Date datetime,
	@Url nvarchar(256) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Ciemesus_tMedias]
	(
		[FileName],
		[FileExtention],
		[Description],
		[Date],
		[Url]
	)
	VALUES
	(
		@FileName,
		@FileExtention,
		@Description,
		@Date,
		@Url
	)

	SET @Err = @@Error

	SELECT @IDMedia = SCOPE_IDENTITY()

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tMediasLoadAll]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tMediasLoadAll]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID int
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDMedia
	FROM [Ciemesus_tMedias]

    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDMedia],
		[FileName],
		[FileExtention],
		[Description],
		[Date],
		[Url]
	FROM [Ciemesus_tMedias]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tMedias].IDMedia = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tMedias]
                  ON [Ciemesus_tMedias].IDMedia = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDMedia],
		[FileName],
		[FileExtention],
		[Description],
		[Date],
		[Url]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tMedias]
                      ON [Ciemesus_tMedias].IDMedia = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tMediasLoadAllImages]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tMediasLoadAllImages]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID int
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDMedia
	FROM [Ciemesus_tMedias]
	WHERE [FileExtention] IN ('.jpg', '.png', '.gif', '.svg', '.bmp')

    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDMedia],
		[FileName],
		[FileExtention],
		[Description],
		[Date],
		[Url]
	FROM [Ciemesus_tMedias]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tMedias].IDMedia = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tMedias]
                  ON [Ciemesus_tMedias].IDMedia = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDMedia],
		[FileName],
		[FileExtention],
		[Description],
		[Date],
		[Url]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tMedias]
                      ON [Ciemesus_tMedias].IDMedia = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tMediasLoadByPrimaryKey]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tMediasLoadByPrimaryKey]
(
	@IDMedia int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[IDMedia],
		[FileName],
		[FileExtention],
		[Description],
		[Date],
		[Url]
	FROM [Ciemesus_tMedias]
	WHERE
		([IDMedia] = @IDMedia)

	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tMediasSearch]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tMediasSearch]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @IDMedia int = NULL,
	  @FileName nvarchar(128) = NULL,
	  @FileExtention nvarchar(50) = NULL,
	  @Description nvarchar(512) = NULL,
	  @DateFrom datetime = NULL,	  
	  @DateTo datetime = NULL,
	  @Url nvarchar(256) = NULL,
@SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID int
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDMedia
	FROM [Ciemesus_tMedias]
	WHERE
		(@IDMedia IS NULL OR IDMedia = @IDMedia)AND
		(@FileName IS NULL OR FileName LIKE '%' + @FileName + '%')AND
		(@FileExtention IS NULL OR FileExtention LIKE '%' + @FileExtention + '%')AND
		(@Description IS NULL OR Description LIKE '%' + @Description + '%')AND
		(@DateFrom IS NULL OR Date >= @DateFrom)AND
		(@DateTo IS NULL OR Date <= @DateTo)AND
		(@Url IS NULL OR Url LIKE '%' + @Url + '%')
    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDMedia],
		[FileName],
		[FileExtention],
		[Description],
		[Date],
		[Url]
	FROM [Ciemesus_tMedias]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tMedias].IDMedia = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tMedias]
                  ON [Ciemesus_tMedias].IDMedia = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDMedia],
		[FileName],
		[FileExtention],
		[Description],
		[Date],
		[Url]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tMedias]
                      ON [Ciemesus_tMedias].IDMedia = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tMediaSubjectsDelete]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tMediaSubjectsDelete]
(
	@IDMedia int,
	@IDSubject uniqueidentifier,
	@IDMediaSubjectType tinyint
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Ciemesus_tMediaSubjects]
	WHERE
		[IDMedia] = @IDMedia AND
		[IDSubject] = @IDSubject AND
		[IDMediaSubjectType] = @IDMediaSubjectType
	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tMediaSubjectsInsert]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tMediaSubjectsInsert]
(
	@IDMedia int,
	@IDSubject uniqueidentifier,
	@IDMediaSubjectType tinyint,
	@Priority int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int
	IF @IDSubject IS NULL
		 SET @IDSubject = NEWID()

	SET @Err = @@Error

	IF (@Err <> 0)
	    RETURN @Err


	INSERT
	INTO [Ciemesus_tMediaSubjects]
	(
		[IDMedia],
		[IDSubject],
		[IDMediaSubjectType],
		[Priority]
	)
	VALUES
	(
		@IDMedia,
		@IDSubject,
		@IDMediaSubjectType,
		@Priority
	)

	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tMediaSubjectsLoadAll]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tMediaSubjectsLoadAll]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID int
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDMedia
	FROM [Ciemesus_tMediaSubjects]

    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDMedia],
		[IDSubject],
		[IDMediaSubjectType],
		[Priority]
	FROM [Ciemesus_tMediaSubjects]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tMediaSubjects].IDMedia = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tMediaSubjects]
                  ON [Ciemesus_tMediaSubjects].IDMedia = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDMedia],
		[IDSubject],
		[IDMediaSubjectType],
		[Priority]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tMediaSubjects]
                      ON [Ciemesus_tMediaSubjects].IDMedia = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tMediaSubjectsLoadByPrimaryKey]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tMediaSubjectsLoadByPrimaryKey]
(
	@IDMedia int
,	@IDSubject uniqueidentifier
,	@IDMediaSubjectType tinyint
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[IDMedia],
		[IDSubject],
		[IDMediaSubjectType],
		[Priority]
	FROM [Ciemesus_tMediaSubjects]
	WHERE
		([IDMedia] = @IDMedia)
 AND
		([IDSubject] = @IDSubject)
 AND
		([IDMediaSubjectType] = @IDMediaSubjectType)

	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tMediaSubjectsSearch]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tMediaSubjectsSearch]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @IDMedia int = NULL,
	  @IDSubject uniqueidentifier = NULL,
	  @IDMediaSubjectType tinyint = NULL,
	  @Priority int = NULL,
@SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID int
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDMedia
	FROM [Ciemesus_tMediaSubjects]
	WHERE
		(@IDMedia IS NULL OR IDMedia = @IDMedia)AND
		(@IDSubject IS NULL OR IDSubject = @IDSubject)AND
		(@IDMediaSubjectType IS NULL OR IDMediaSubjectType = @IDMediaSubjectType)AND
		(@Priority IS NULL OR Priority = @Priority)
    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDMedia],
		[IDSubject],
		[IDMediaSubjectType],
		[Priority]
	FROM [Ciemesus_tMediaSubjects]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tMediaSubjects].IDMedia = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tMediaSubjects]
                  ON [Ciemesus_tMediaSubjects].IDMedia = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDMedia],
		[IDSubject],
		[IDMediaSubjectType],
		[Priority]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tMediaSubjects]
                      ON [Ciemesus_tMediaSubjects].IDMedia = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tMediaSubjectsUpdate]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tMediaSubjectsUpdate]
(
	@IDMedia int,
	@IDSubject uniqueidentifier,
	@IDMediaSubjectType tinyint,
	@Priority int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Ciemesus_tMediaSubjects]
	SET
		[Priority] = @Priority
	WHERE
		[IDMedia] = @IDMedia	AND	[IDSubject] = @IDSubject	AND	[IDMediaSubjectType] = @IDMediaSubjectType


	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tMediasUpdate]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tMediasUpdate]
(
	@IDMedia int,
	@FileName nvarchar(128),
	@FileExtention nvarchar(50),
	@Description nvarchar(512) = NULL,
	@Date datetime,
	@Url nvarchar(256) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Ciemesus_tMedias]
	SET
		[FileName] = @FileName,
		[FileExtention] = @FileExtention,
		[Description] = @Description,
		[Date] = @Date,
		[Url] = @Url
	WHERE
		[IDMedia] = @IDMedia


	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tMembersDelete]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tMembersDelete]
(
	@IDMember uniqueidentifier
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Ciemesus_tMembers]
	WHERE
		[IDMember] = @IDMember
	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tMembersInsert]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tMembersInsert]
(
	@IDMember uniqueidentifier,
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int
	IF @IDMember IS NULL
		 SET @IDMember = NEWID()

	SET @Err = @@Error

	IF (@Err <> 0)
	    RETURN @Err


	INSERT
	INTO [Ciemesus_tMembers]
	(
		[IDMember],
		[FirstName],
		[LastName]
	)
	VALUES
	(
		@IDMember,
		@FirstName,
		@LastName
	)

	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tMembersLoadAll]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tMembersLoadAll]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID uniqueidentifier
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDMember
	FROM [Ciemesus_tMembers]

    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDMember],
		[FirstName],
		[LastName]
	FROM [Ciemesus_tMembers]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tMembers].IDMember = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tMembers]
                  ON [Ciemesus_tMembers].IDMember = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDMember],
		[FirstName],
		[LastName]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tMembers]
                      ON [Ciemesus_tMembers].IDMember = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tMembersLoadByPrimaryKey]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tMembersLoadByPrimaryKey]
(
	@IDMember uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[IDMember],
		[FirstName],
		[LastName]
	FROM [Ciemesus_tMembers]
	WHERE
		([IDMember] = @IDMember)

	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tMembersSearch]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tMembersSearch]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @IDMember uniqueidentifier = NULL,
	  @FirstName nvarchar(50) = NULL,
	  @LastName nvarchar(50) = NULL,
@SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID uniqueidentifier
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDMember
	FROM [Ciemesus_tMembers]
	WHERE
		(@IDMember IS NULL OR IDMember = @IDMember)AND
		(@FirstName IS NULL OR FirstName LIKE '%' + @FirstName + '%')AND
		(@LastName IS NULL OR LastName LIKE '%' + @LastName + '%')
    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDMember],
		[FirstName],
		[LastName]
	FROM [Ciemesus_tMembers]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tMembers].IDMember = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tMembers]
                  ON [Ciemesus_tMembers].IDMember = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDMember],
		[FirstName],
		[LastName]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tMembers]
                      ON [Ciemesus_tMembers].IDMember = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tMembersUpdate]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tMembersUpdate]
(
	@IDMember uniqueidentifier,
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Ciemesus_tMembers]
	SET
		[FirstName] = @FirstName,
		[LastName] = @LastName
	WHERE
		[IDMember] = @IDMember


	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tPluginsDelete]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tPluginsDelete]
(
	@IDPlugin int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Ciemesus_tPlugins]
	WHERE
		[IDPlugin] = @IDPlugin
	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tPluginsInsert]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tPluginsInsert]
(
	@IDPlugin int = NULL output,
	@Name nvarchar(128),
	@JSfileName nvarchar(256),
	@Version nvarchar(128) = NULL,
	@Description nvarchar(MAX) = NULL,
	@Settings nvarchar(MAX) = NULL,
	@Css nvarchar(MAX) = NULL,
	@JSinit nvarchar(MAX) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Ciemesus_tPlugins]
	(
		[Name],
		[JSfileName],
		[Version],
		[Description],
		[Settings],
		[Css],
		[JSinit]
	)
	VALUES
	(
		@Name,
		@JSfileName,
		@Version,
		@Description,
		@Settings,
		@Css,
		@JSinit
	)

	SET @Err = @@Error

	SELECT @IDPlugin = SCOPE_IDENTITY()

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tPluginsLoadAll]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tPluginsLoadAll]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID int
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDPlugin
	FROM [Ciemesus_tPlugins]

    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDPlugin],
		[Name],
		[JSfileName],
		[Version],
		[Description],
		[Settings],
		[Css],
		[JSinit]
	FROM [Ciemesus_tPlugins]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tPlugins].IDPlugin = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tPlugins]
                  ON [Ciemesus_tPlugins].IDPlugin = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDPlugin],
		[Name],
		[JSfileName],
		[Version],
		[Description],
		[Settings],
		[Css],
		[JSinit]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tPlugins]
                      ON [Ciemesus_tPlugins].IDPlugin = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tPluginsLoadByPrimaryKey]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tPluginsLoadByPrimaryKey]
(
	@IDPlugin int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[IDPlugin],
		[Name],
		[JSfileName],
		[Version],
		[Description],
		[Settings],
		[Css],
		[JSinit]
	FROM [Ciemesus_tPlugins]
	WHERE
		([IDPlugin] = @IDPlugin)

	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tPluginsSearch]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tPluginsSearch]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @IDPlugin int = NULL,
	  @Name nvarchar(128) = NULL,
	  @JSfileName nvarchar(256) = NULL,
	  @Version nvarchar(128) = NULL,
	  @Description nvarchar(MAX) = NULL,
	  @Settings nvarchar(MAX) = NULL,
	  @Css nvarchar(MAX) = NULL,
	  @JSinit nvarchar(MAX) = NULL,
@SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID int
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDPlugin
	FROM [Ciemesus_tPlugins]
	WHERE
		(@IDPlugin IS NULL OR IDPlugin = @IDPlugin)AND
		(@Name IS NULL OR Name LIKE '%' + @Name + '%')AND
		(@JSfileName IS NULL OR JSfileName LIKE '%' + @JSfileName + '%')AND
		(@Version IS NULL OR Version LIKE '%' + @Version + '%')AND
		(@Description IS NULL OR Description LIKE '%' + @Description + '%')AND
		(@Settings IS NULL OR Settings LIKE '%' + @Settings + '%')AND
		(@Css IS NULL OR Css LIKE '%' + @Css + '%')AND
		(@JSinit IS NULL OR JSinit LIKE '%' + @JSinit + '%')
    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDPlugin],
		[Name],
		[JSfileName],
		[Version],
		[Description],
		[Settings],
		[Css],
		[JSinit]
	FROM [Ciemesus_tPlugins]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tPlugins].IDPlugin = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tPlugins]
                  ON [Ciemesus_tPlugins].IDPlugin = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDPlugin],
		[Name],
		[JSfileName],
		[Version],
		[Description],
		[Settings],
		[Css],
		[JSinit]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tPlugins]
                      ON [Ciemesus_tPlugins].IDPlugin = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tPluginsUpdate]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tPluginsUpdate]
(
	@IDPlugin int,
	@Name nvarchar(128),
	@JSfileName nvarchar(256),
	@Version nvarchar(128) = NULL,
	@Description nvarchar(MAX) = NULL,
	@Settings nvarchar(MAX) = NULL,
	@Css nvarchar(MAX) = NULL,
	@JSinit nvarchar(MAX) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Ciemesus_tPlugins]
	SET
		[Name] = @Name,
		[JSfileName] = @JSfileName,
		[Version] = @Version,
		[Description] = @Description,
		[Settings] = @Settings,
		[Css] = @Css,
		[JSinit] = @JSinit
	WHERE
		[IDPlugin] = @IDPlugin


	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tPropertiesDelete]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Ciemesus_tPropertiesDelete]
(
	@IDProperty int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Ciemesus_tProperties]
	WHERE
		[IDProperty] = @IDProperty
	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tPropertiesInsert]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[Ciemesus_tPropertiesInsert]
(
	@IDProperty int = NULL output,
	@IDLanguage tinyint,
	@IDType tinyint,
	@Name nvarchar(50)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Ciemesus_tProperties]
	(
		[IDLanguage],
		[IDType],
		[Name]
	)
	VALUES
	(
		@IDLanguage,
		@IDType,
		@Name
	)

	SET @Err = @@Error

	SELECT @IDProperty = SCOPE_IDENTITY()

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tPropertiesLoadAll]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Ciemesus_tPropertiesLoadAll]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID int
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDProperty
	FROM [Ciemesus_tProperties]

    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDProperty],
		[IDLanguage],
		[IDType],
		[Name]
	FROM [Ciemesus_tProperties]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tProperties].IDProperty = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tProperties]
                  ON [Ciemesus_tProperties].IDProperty = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDProperty],
		[IDLanguage],
		[IDType],
		[Name]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tProperties]
                      ON [Ciemesus_tProperties].IDProperty = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tPropertiesLoadByPrimaryKey]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Ciemesus_tPropertiesLoadByPrimaryKey]
(
	@IDProperty int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[IDProperty],
		[IDLanguage],
		[IDType],
		[Name]
	FROM [Ciemesus_tProperties]
	WHERE
		([IDProperty] = @IDProperty)

	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tPropertiesSearch]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Ciemesus_tPropertiesSearch]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @IDProperty int = NULL,
	  @IDLanguage tinyint = NULL,
	  @IDType tinyint = NULL,
	  @Name nvarchar(50) = NULL,
@SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID int
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDProperty
	FROM [Ciemesus_tProperties]
	WHERE
		(@IDProperty IS NULL OR IDProperty = @IDProperty)AND
		(@IDLanguage IS NULL OR IDLanguage = @IDLanguage)AND
		(@IDType IS NULL OR IDType = @IDType)AND
		(@Name IS NULL OR Name LIKE '%' + @Name + '%')
    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDProperty],
		[IDLanguage],
		[IDType],
		[Name]
	FROM [Ciemesus_tProperties]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tProperties].IDProperty = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tProperties]
                  ON [Ciemesus_tProperties].IDProperty = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDProperty],
		[IDLanguage],
		[IDType],
		[Name]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tProperties]
                      ON [Ciemesus_tProperties].IDProperty = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tPropertiesUpdate]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Ciemesus_tPropertiesUpdate]
(
	@IDProperty int,
	@IDLanguage tinyint,
	@IDType tinyint,
	@Name nvarchar(50)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Ciemesus_tProperties]
	SET
		[IDLanguage] = @IDLanguage,
		[IDType] = @IDType,
		[Name] = @Name
	WHERE
		[IDProperty] = @IDProperty


	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tPropertyItemsDelete]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Ciemesus_tPropertyItemsDelete]
(
	@IDPropertyItem int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Ciemesus_tPropertyItems]
	WHERE
		[IDPropertyItem] = @IDPropertyItem
	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tPropertyItemsInsert]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Ciemesus_tPropertyItemsInsert]
(
	@IDPropertyItem int = NULL output,
	@IDProperty int,
	@Title nvarchar(50)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	INSERT
	INTO [Ciemesus_tPropertyItems]
	(
		[IDProperty],
		[Title]
	)
	VALUES
	(
		@IDProperty,
		@Title
	)

	SET @Err = @@Error

	SELECT @IDPropertyItem = SCOPE_IDENTITY()

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tPropertyItemsLoadAll]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Ciemesus_tPropertyItemsLoadAll]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID int
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDPropertyItem
	FROM [Ciemesus_tPropertyItems]

    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDPropertyItem],
		[IDProperty],
		[Title]
	FROM [Ciemesus_tPropertyItems]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tPropertyItems].IDPropertyItem = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tPropertyItems]
                  ON [Ciemesus_tPropertyItems].IDPropertyItem = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDPropertyItem],
		[IDProperty],
		[Title]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tPropertyItems]
                      ON [Ciemesus_tPropertyItems].IDPropertyItem = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tPropertyItemsLoadByPrimaryKey]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Ciemesus_tPropertyItemsLoadByPrimaryKey]
(
	@IDPropertyItem int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[IDPropertyItem],
		[IDProperty],
		[Title]
	FROM [Ciemesus_tPropertyItems]
	WHERE
		([IDPropertyItem] = @IDPropertyItem)

	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tPropertyItemsSearch]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Ciemesus_tPropertyItemsSearch]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @IDPropertyItem int = NULL,
	  @IDProperty int = NULL,
	  @Title nvarchar(50) = NULL,
@SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID int
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDPropertyItem
	FROM [Ciemesus_tPropertyItems]
	WHERE
		(@IDPropertyItem IS NULL OR IDPropertyItem = @IDPropertyItem)AND
		(@IDProperty IS NULL OR IDProperty = @IDProperty)AND
		(@Title IS NULL OR Title LIKE '%' + @Title + '%')
    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDPropertyItem],
		[IDProperty],
		[Title]
	FROM [Ciemesus_tPropertyItems]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tPropertyItems].IDPropertyItem = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tPropertyItems]
                  ON [Ciemesus_tPropertyItems].IDPropertyItem = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDPropertyItem],
		[IDProperty],
		[Title]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tPropertyItems]
                      ON [Ciemesus_tPropertyItems].IDPropertyItem = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tPropertyItemsUpdate]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Ciemesus_tPropertyItemsUpdate]
(
	@IDPropertyItem int,
	@IDProperty int,
	@Title nvarchar(50)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Ciemesus_tPropertyItems]
	SET
		[IDProperty] = @IDProperty,
		[Title] = @Title
	WHERE
		[IDPropertyItem] = @IDPropertyItem


	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSearchSite]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tSearchSite]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @IDSubject uniqueidentifier = NULL,
	  @IDSubjectType tinyint = NULL,
	  @IDParent uniqueidentifier = NULL,
	  @IDLanguage tinyint = NULL,
	  @IDGallery uniqueidentifier = NULL,
	  @Title nvarchar(255) = NULL,
	  @Body nvarchar(MAX) = NULL,
	  @Alias nvarchar(128) = NULL,
	  @DateFrom datetime = NULL,	  
	  @DateTo datetime = NULL,
	  @IsActive bit = NULL,
	  @BannerType nvarchar(50) = NULL,
	  @Priority int = NULL,
@SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID uniqueidentifier
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDSubject
	FROM [Ciemesus_tSubjects]
	WHERE
		(@IDSubject IS NULL OR IDSubject = @IDSubject)AND
		(@IDSubjectType IS NULL OR IDSubjectType = @IDSubjectType)AND
		(@IDParent IS NULL OR IDParent = @IDParent)AND
		(@IDLanguage IS NULL OR IDLanguage = @IDLanguage)AND
		(@IDGallery IS NULL OR IDGallery = @IDGallery)AND
		(@Title IS NULL OR Title LIKE '%' + @Title + '%') OR
		(@Body IS NULL OR Body LIKE '%' + @Body + '%')AND
		(@Alias IS NULL OR Alias LIKE '%' + @Alias + '%')AND
		(@DateFrom IS NULL OR Date >= @DateFrom)AND
		(@DateTo IS NULL OR Date <= @DateTo)AND
		(@IsActive IS NULL OR IsActive = @IsActive)AND
		(@BannerType IS NULL OR BannerType LIKE '%' + @BannerType + '%')AND
		(@Priority IS NULL OR Priority = @Priority)
    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDSubject],
		[IDSubjectType],
		[IDParent],
		[IDLanguage],
		[IDGallery],
		[Title],
		[Body],
		[Alias],
		[Date],
		[IsActive],
		[BannerType],
		[Priority]
	FROM [Ciemesus_tSubjects]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tSubjects].IDSubject = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID uniqueidentifier
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tSubjects]
                  ON [Ciemesus_tSubjects].IDSubject = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDSubject],
		[IDSubjectType],
		[IDParent],
		[IDLanguage],
		[IDGallery],
		[Title],
		[Body],
		[Alias],
		[Date],
		[IsActive],
		[BannerType],
		[Priority]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tSubjects]
                      ON [Ciemesus_tSubjects].IDSubject = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSubjectPluginsDelete]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tSubjectPluginsDelete]
(
	@IDSubject uniqueidentifier,
	@IDPlugin int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Ciemesus_tSubjectPlugins]
	WHERE
		[IDSubject] = @IDSubject AND
		[IDPlugin] = @IDPlugin
	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSubjectPluginsInsert]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tSubjectPluginsInsert]
(
	@IDSubject uniqueidentifier,
	@IDPlugin int,
	@Options nvarchar(MAX) = NULL,
	@CSS nvarchar(MAX) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int
	IF @IDSubject IS NULL
		 SET @IDSubject = NEWID()

	SET @Err = @@Error

	IF (@Err <> 0)
	    RETURN @Err


	INSERT
	INTO [Ciemesus_tSubjectPlugins]
	(
		[IDSubject],
		[IDPlugin],
		[Options],
		[CSS]
	)
	VALUES
	(
		@IDSubject,
		@IDPlugin,
		@Options,
		@CSS
	)

	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSubjectPluginsLoadAll]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tSubjectPluginsLoadAll]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID uniqueidentifier
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDSubject
	FROM [Ciemesus_tSubjectPlugins]

    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDSubject],
		[IDPlugin],
		[Options],
		[CSS]
	FROM [Ciemesus_tSubjectPlugins]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tSubjectPlugins].IDSubject = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tSubjectPlugins]
                  ON [Ciemesus_tSubjectPlugins].IDSubject = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDSubject],
		[IDPlugin],
		[Options],
		[CSS]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tSubjectPlugins]
                      ON [Ciemesus_tSubjectPlugins].IDSubject = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSubjectPluginsLoadByPrimaryKey]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tSubjectPluginsLoadByPrimaryKey]
(
	@IDSubject uniqueidentifier
,	@IDPlugin int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[IDSubject],
		[IDPlugin],
		[Options],
		[CSS]
	FROM [Ciemesus_tSubjectPlugins]
	WHERE
		([IDSubject] = @IDSubject)
 AND
		([IDPlugin] = @IDPlugin)

	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSubjectPluginsSearch]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tSubjectPluginsSearch]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @IDSubject uniqueidentifier = NULL,
	  @IDPlugin int = NULL,
	  @Options nvarchar(MAX) = NULL,
	  @CSS nvarchar(MAX) = NULL,
@SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID uniqueidentifier
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDSubject
	FROM [Ciemesus_tSubjectPlugins]
	WHERE
		(@IDSubject IS NULL OR IDSubject = @IDSubject)AND
		(@IDPlugin IS NULL OR IDPlugin = @IDPlugin)AND
		(@Options IS NULL OR Options LIKE '%' + @Options + '%')AND
		(@CSS IS NULL OR CSS LIKE '%' + @CSS + '%')
    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDSubject],
		[IDPlugin],
		[Options],
		[CSS]
	FROM [Ciemesus_tSubjectPlugins]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tSubjectPlugins].IDSubject = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tSubjectPlugins]
                  ON [Ciemesus_tSubjectPlugins].IDSubject = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDSubject],
		[IDPlugin],
		[Options],
		[CSS]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tSubjectPlugins]
                      ON [Ciemesus_tSubjectPlugins].IDSubject = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSubjectPluginsUpdate]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tSubjectPluginsUpdate]
(
	@IDSubject uniqueidentifier,
	@IDPlugin int,
	@Options nvarchar(MAX) = NULL,
	@CSS nvarchar(MAX) = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Ciemesus_tSubjectPlugins]
	SET
		[Options] = @Options,
		[CSS] = @CSS
	WHERE
		[IDSubject] = @IDSubject	AND	[IDPlugin] = @IDPlugin


	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSubjectPropertiesDelete]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Ciemesus_tSubjectPropertiesDelete]
(
	@IDSubject uniqueidentifier,
	@IDProperty int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Ciemesus_tSubjectProperties]
	WHERE
		[IDSubject] = @IDSubject AND
		[IDProperty] = @IDProperty
	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSubjectPropertiesInsert]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Ciemesus_tSubjectPropertiesInsert]
(
	@IDSubject uniqueidentifier,
	@IDProperty int,
	@IsSearchable bit
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int
	IF @IDSubject IS NULL
		 SET @IDSubject = NEWID()

	SET @Err = @@Error

	IF (@Err <> 0)
	    RETURN @Err


	INSERT
	INTO [Ciemesus_tSubjectProperties]
	(
		[IDSubject],
		[IDProperty],
		[IsSearchable]
	)
	VALUES
	(
		@IDSubject,
		@IDProperty,
		@IsSearchable
	)

	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSubjectPropertiesLoadAll]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Ciemesus_tSubjectPropertiesLoadAll]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID uniqueidentifier
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDSubject
	FROM [Ciemesus_tSubjectProperties]

    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDSubject],
		[IDProperty],
		[IsSearchable]
	FROM [Ciemesus_tSubjectProperties]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tSubjectProperties].IDSubject = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tSubjectProperties]
                  ON [Ciemesus_tSubjectProperties].IDSubject = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDSubject],
		[IDProperty],
		[IsSearchable]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tSubjectProperties]
                      ON [Ciemesus_tSubjectProperties].IDSubject = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSubjectPropertiesLoadByPrimaryKey]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Ciemesus_tSubjectPropertiesLoadByPrimaryKey]
(
	@IDSubject uniqueidentifier
,	@IDProperty int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[IDSubject],
		[IDProperty],
		[IsSearchable]
	FROM [Ciemesus_tSubjectProperties]
	WHERE
		([IDSubject] = @IDSubject)
 AND
		([IDProperty] = @IDProperty)

	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSubjectPropertiesSearch]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Ciemesus_tSubjectPropertiesSearch]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @IDSubject uniqueidentifier = NULL,
	  @IDProperty int = NULL,
	  @IsSearchable bit = NULL,
@SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID uniqueidentifier
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDSubject
	FROM [Ciemesus_tSubjectProperties]
	WHERE
		(@IDSubject IS NULL OR IDSubject = @IDSubject)AND
		(@IDProperty IS NULL OR IDProperty = @IDProperty)AND
		(@IsSearchable IS NULL OR IsSearchable = @IsSearchable)
    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDSubject],
		[IDProperty],
		[IsSearchable]
	FROM [Ciemesus_tSubjectProperties]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tSubjectProperties].IDSubject = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tSubjectProperties]
                  ON [Ciemesus_tSubjectProperties].IDSubject = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDSubject],
		[IDProperty],
		[IsSearchable]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tSubjectProperties]
                      ON [Ciemesus_tSubjectProperties].IDSubject = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSubjectPropertiesUpdate]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Ciemesus_tSubjectPropertiesUpdate]
(
	@IDSubject uniqueidentifier,
	@IDProperty int,
	@IsSearchable bit
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Ciemesus_tSubjectProperties]
	SET
		[IsSearchable] = @IsSearchable
	WHERE
		[IDSubject] = @IDSubject	AND	[IDProperty] = @IDProperty


	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSubjectPropertyValuesDelete]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Ciemesus_tSubjectPropertyValuesDelete]
(
	@IDSubject uniqueidentifier,
	@IDProperty int
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Ciemesus_tSubjectPropertyValues]
	WHERE
		[IDSubject] = @IDSubject AND
		[IDProperty] = @IDProperty
	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSubjectPropertyValuesInsert]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Ciemesus_tSubjectPropertyValuesInsert]
(
	@IDSubject uniqueidentifier,
	@IDProperty int,
	@Value nvarchar(50)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int
	IF @IDSubject IS NULL
		 SET @IDSubject = NEWID()

	SET @Err = @@Error

	IF (@Err <> 0)
	    RETURN @Err


	INSERT
	INTO [Ciemesus_tSubjectPropertyValues]
	(
		[IDSubject],
		[IDProperty],
		[Value]
	)
	VALUES
	(
		@IDSubject,
		@IDProperty,
		@Value
	)

	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSubjectPropertyValuesLoadAll]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Ciemesus_tSubjectPropertyValuesLoadAll]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID uniqueidentifier
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDSubject
	FROM [Ciemesus_tSubjectPropertyValues]

    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDSubject],
		[IDProperty],
		[Value]
	FROM [Ciemesus_tSubjectPropertyValues]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tSubjectPropertyValues].IDSubject = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tSubjectPropertyValues]
                  ON [Ciemesus_tSubjectPropertyValues].IDSubject = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDSubject],
		[IDProperty],
		[Value]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tSubjectPropertyValues]
                      ON [Ciemesus_tSubjectPropertyValues].IDSubject = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSubjectPropertyValuesLoadByPrimaryKey]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Ciemesus_tSubjectPropertyValuesLoadByPrimaryKey]
(
	@IDSubject uniqueidentifier
,	@IDProperty int
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[IDSubject],
		[IDProperty],
		[Value]
	FROM [Ciemesus_tSubjectPropertyValues]
	WHERE
		([IDSubject] = @IDSubject)
 AND
		([IDProperty] = @IDProperty)

	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSubjectPropertyValuesSearch]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Ciemesus_tSubjectPropertyValuesSearch]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @IDSubject uniqueidentifier = NULL,
	  @IDProperty int = NULL,
	  @Value nvarchar(50) = NULL,
@SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID uniqueidentifier
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDSubject
	FROM [Ciemesus_tSubjectPropertyValues]
	WHERE
		(@IDSubject IS NULL OR IDSubject = @IDSubject)AND
		(@IDProperty IS NULL OR IDProperty = @IDProperty)AND
		(@Value IS NULL OR Value LIKE '%' + @Value + '%')
    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDSubject],
		[IDProperty],
		[Value]
	FROM [Ciemesus_tSubjectPropertyValues]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tSubjectPropertyValues].IDSubject = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tSubjectPropertyValues]
                  ON [Ciemesus_tSubjectPropertyValues].IDSubject = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDSubject],
		[IDProperty],
		[Value]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tSubjectPropertyValues]
                      ON [Ciemesus_tSubjectPropertyValues].IDSubject = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSubjectPropertyValuesUpdate]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Ciemesus_tSubjectPropertyValuesUpdate]
(
	@IDSubject uniqueidentifier,
	@IDProperty int,
	@Value nvarchar(50)
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Ciemesus_tSubjectPropertyValues]
	SET
		[Value] = @Value
	WHERE
		[IDSubject] = @IDSubject	AND	[IDProperty] = @IDProperty


	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSubjectsDelete]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tSubjectsDelete]
(
	@IDSubject uniqueidentifier
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	DELETE
	FROM [Ciemesus_tSubjects]
	WHERE
		[IDSubject] = @IDSubject
	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSubjectsInsert]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tSubjectsInsert]
(
	@IDSubject uniqueidentifier,
	@IDSubjectType tinyint,
	@IDParent uniqueidentifier = NULL,
	@IDLanguage tinyint = NULL,
	@IDGallery uniqueidentifier = NULL,
	@Title nvarchar(255) = NULL,
	@Body nvarchar(MAX) = NULL,
	@Alias nvarchar(128) = NULL,
	@Date datetime = NULL,
	@IsActive bit = NULL,
	@BannerType nvarchar(50) = NULL,
	@Priority int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int
	IF @IDSubject IS NULL
		 SET @IDSubject = NEWID()

	SET @Err = @@Error

	IF (@Err <> 0)
	    RETURN @Err


	INSERT
	INTO [Ciemesus_tSubjects]
	(
		[IDSubject],
		[IDSubjectType],
		[IDParent],
		[IDLanguage],
		[IDGallery],
		[Title],
		[Body],
		[Alias],
		[Date],
		[IsActive],
		[BannerType],
		[Priority]
	)
	VALUES
	(
		@IDSubject,
		@IDSubjectType,
		@IDParent,
		@IDLanguage,
		@IDGallery,
		@Title,
		@Body,
		@Alias,
		@Date,
		@IsActive,
		@BannerType,
		@Priority
	)

	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSubjectsLoadAll]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tSubjectsLoadAll]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID uniqueidentifier
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDSubject
	FROM [Ciemesus_tSubjects]

    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDSubject],
		[IDSubjectType],
		[IDParent],
		[IDLanguage],
		[IDGallery],
		[Title],
		[Body],
		[Alias],
		[Date],
		[IsActive],
		[BannerType],
		[Priority]
	FROM [Ciemesus_tSubjects]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tSubjects].IDSubject = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID smallint
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tSubjects]
                  ON [Ciemesus_tSubjects].IDSubject = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDSubject],
		[IDSubjectType],
		[IDParent],
		[IDLanguage],
		[IDGallery],
		[Title],
		[Body],
		[Alias],
		[Date],
		[IsActive],
		[BannerType],
		[Priority]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tSubjects]
                      ON [Ciemesus_tSubjects].IDSubject = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSubjectsLoadAllLists]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tSubjectsLoadAllLists]

    @PageIndex int = 0,
    @PageSize int = 0,
	@TotalRecords int = NULL output,
	@IDLanguage tinyint,
	@SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID uniqueidentifier
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDSubject
	FROM [Ciemesus_tSubjects]
	WHERE IDSubjectType = 3 AND IDLanguage = @IDLanguage

    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDSubject],
		[IDSubjectType],
		[IDParent],
		[IDLanguage],
		[IDGallery],
		[Title],
		[Body],
		[Alias],
		[Date],
		[IsActive],
		[BannerType],
		[Priority]
	FROM [Ciemesus_tSubjects]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tSubjects].IDSubject = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID uniqueidentifier
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tSubjects]
                  ON [Ciemesus_tSubjects].IDSubject = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDSubject],
		[IDSubjectType],
		[IDParent],
		[IDLanguage],
		[IDGallery],
		[Title],
		[Body],
		[Alias],
		[Date],
		[IsActive],
		[BannerType],
		[Priority]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tSubjects]
                      ON [Ciemesus_tSubjects].IDSubject = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSubjectsLoadByPrimaryKey]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tSubjectsLoadByPrimaryKey]
(
	@IDSubject uniqueidentifier
)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Err int

	SELECT
		[IDSubject],
		[IDSubjectType],
		[IDParent],
		[IDLanguage],
		[IDGallery],
		[Title],
		[Body],
		[Alias],
		[Date],
		[IsActive],
		[BannerType],
		[Priority]
	FROM [Ciemesus_tSubjects]
	WHERE
		([IDSubject] = @IDSubject)

	SET @Err = @@Error

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSubjectsSearch]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tSubjectsSearch]

    @PageIndex int = 0,
    @PageSize int = 0,
	  @TotalRecords int = NULL output,
	  @IDSubject uniqueidentifier = NULL,
	  @IDSubjectType tinyint = NULL,
	  @IDParent uniqueidentifier = NULL,
	  @IDLanguage tinyint = NULL,
	  @IDGallery uniqueidentifier = NULL,
	  @Title nvarchar(255) = NULL,
	  @Body nvarchar(MAX) = NULL,
	  @Alias nvarchar(128) = NULL,
	  @DateFrom datetime = NULL,	  
	  @DateTo datetime = NULL,
	  @IsActive bit = NULL,
	  @BannerType nvarchar(50) = NULL,
	  @Priority int = NULL,
@SortExpression nvarchar(1000) = NULL
AS
BEGIN

	--SET NOCOUNT ON
	DECLARE @Err int

	-- Set the page bounds
    DECLARE @PageLowerBound int
    DECLARE @PageUpperBound int
    SET @PageLowerBound = @PageSize * @PageIndex
    SET @PageUpperBound = @PageSize  + @PageLowerBound

	-- Create a temp table to store the select results
    CREATE TABLE #IndexedTable
    (
        IndexId int IDENTITY (0, 1) NOT NULL,
        PrimaryID uniqueidentifier
    )

	    -- Insert into our temp table
    INSERT INTO #IndexedTable (PrimaryID)
		SELECT IDSubject
	FROM [Ciemesus_tSubjects]
	WHERE
		(@IDSubject IS NULL OR IDSubject = @IDSubject)AND
		(@IDSubjectType IS NULL OR IDSubjectType = @IDSubjectType)AND
		(@IDParent IS NULL OR IDParent = @IDParent)AND
		(@IDLanguage IS NULL OR IDLanguage = @IDLanguage)AND
		(@IDGallery IS NULL OR IDGallery = @IDGallery)AND
		(@Title IS NULL OR Title LIKE '%' + @Title + '%')AND
		(@Body IS NULL OR Body LIKE '%' + @Body + '%')AND
		(@Alias IS NULL OR Alias LIKE '%' + @Alias + '%')AND
		(@DateFrom IS NULL OR Date >= @DateFrom)AND
		(@DateTo IS NULL OR Date <= @DateTo)AND
		(@IsActive IS NULL OR IsActive = @IsActive)AND
		(@BannerType IS NULL OR BannerType LIKE '%' + @BannerType + '%')AND
		(@Priority IS NULL OR Priority = @Priority)
    SELECT @TotalRecords = @@ROWCOUNT

IF(@PageSize IS NULL OR @PageSize = 0)
 BEGIN
  SET @PageUpperBound= @TotalRecords
 END
	SET NOCOUNT ON
IF(@SortExpression IS NULL OR @SortExpression = '')
BEGIN

	SELECT

		[IDSubject],
		[IDSubjectType],
		[IDParent],
		[IDLanguage],
		[IDGallery],
		[Title],
		[Body],
		[Alias],
		[Date],
		[IsActive],
		[BannerType],
		[Priority]
	FROM [Ciemesus_tSubjects]
	INNER JOIN #IndexedTable as IndexedTable
	ON [Ciemesus_tSubjects].IDSubject = IndexedTable.PrimaryID
	
	Where IndexedTable.IndexId >= @PageLowerBound AND IndexedTable.IndexId < @PageUpperBound

	SET @Err = @@Error
END
ELSE
BEGIN
	DECLARE @DynamicQuery nvarchar(max)

	-- Create a temp table to store sorted results
	CREATE TABLE #IndexedTableSorted
	(
	    IndexId bigint IDENTITY (0, 1) NOT NULL,
	    PrimaryID uniqueidentifier
	)
SET @DynamicQuery = ' INSERT INTO #IndexedTableSorted (PrimaryID)
SELECT PrimaryID FROM #IndexedTable INNER JOIN [Ciemesus_tSubjects]
                  ON [Ciemesus_tSubjects].IDSubject = PrimaryID ORDER BY ' + @SortExpression

EXECUTE (@DynamicQuery)

DROP TABLE #IndexedTable
SET @DynamicQuery= ''
	SET @DynamicQuery= 'SELECT 
		[IDSubject],
		[IDSubjectType],
		[IDParent],
		[IDLanguage],
		[IDGallery],
		[Title],
		[Body],
		[Alias],
		[Date],
		[IsActive],
		[BannerType],
		[Priority]        FROM  #IndexedTableSorted AS IndexedTable 
                      INNER JOIN [Ciemesus_tSubjects]
                      ON [Ciemesus_tSubjects].IDSubject = IndexedTable.PrimaryID
                      WHERE IndexedTable.IndexId >='+ str(@PageLowerBound) +' AND IndexedTable.IndexId <'+  str(@PageUpperBound)

EXECUTE (@DynamicQuery)

SET @Err = @@Error

DROP TABLE #IndexedTableSorted
END

	RETURN @Err
END

GO
/****** Object:  StoredProcedure [dbo].[Ciemesus_tSubjectsUpdate]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Ciemesus_tSubjectsUpdate]
(
	@IDSubject uniqueidentifier,
	@IDSubjectType tinyint,
	@IDParent uniqueidentifier = NULL,
	@IDLanguage tinyint = NULL,
	@IDGallery uniqueidentifier = NULL,
	@Title nvarchar(255) = NULL,
	@Body nvarchar(MAX) = NULL,
	@Alias nvarchar(128) = NULL,
	@Date datetime = NULL,
	@IsActive bit = NULL,
	@BannerType nvarchar(50) = NULL,
	@Priority int = NULL
)
AS
BEGIN

	SET NOCOUNT OFF
	DECLARE @Err int

	UPDATE [Ciemesus_tSubjects]
	SET
		[IDSubjectType] = @IDSubjectType,
		[IDParent] = @IDParent,
		[IDLanguage] = @IDLanguage,
		[IDGallery] = @IDGallery,
		[Title] = @Title,
		[Body] = @Body,
		[Alias] = @Alias,
		[Date] = @Date,
		[IsActive] = @IsActive,
		[BannerType] = @BannerType,
		[Priority] = @Priority
	WHERE
		[IDSubject] = @IDSubject


	SET @Err = @@Error


	RETURN @Err
END

GO
/****** Object:  View [dbo].[Ciemesus_vwMediaSubjects]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Ciemesus_vwMediaSubjects]
AS
SELECT     dbo.Ciemesus_tMediaSubjects.IDSubject, dbo.Ciemesus_tMediaSubjects.IDMediaSubjectType, dbo.Ciemesus_tMediaSubjects.IDMedia, 
                      dbo.Ciemesus_tMediaSubjects.Priority, dbo.Ciemesus_tMedias.FileName, dbo.Ciemesus_tMedias.FileExtention, dbo.Ciemesus_tMedias.Description, 
                      dbo.Ciemesus_tMedias.Date, dbo.Ciemesus_tMedias.Url, dbo.Ciemesus_htMediaSubjectTypes.Title
FROM         dbo.Ciemesus_tMedias INNER JOIN
                      dbo.Ciemesus_tMediaSubjects ON dbo.Ciemesus_tMedias.IDMedia = dbo.Ciemesus_tMediaSubjects.IDMedia INNER JOIN
                      dbo.Ciemesus_htMediaSubjectTypes ON dbo.Ciemesus_tMediaSubjects.IDMediaSubjectType = dbo.Ciemesus_htMediaSubjectTypes.IDMediaSubjectType

GO
/****** Object:  View [dbo].[Ciemesus_vwSubjectPropertyValues]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Ciemesus_vwSubjectPropertyValues]
AS
SELECT        dbo.Ciemesus_tSubjects.*, dbo.Ciemesus_tProperties.IDProperty, dbo.Ciemesus_tProperties.IDType, dbo.Ciemesus_tProperties.Name, 
                         dbo.Ciemesus_tSubjectPropertyValues.Value, dbo.Ciemesus_tSubjectProperties.IsSearchable
FROM            dbo.Ciemesus_tSubjectPropertyValues INNER JOIN
                         dbo.Ciemesus_tProperties INNER JOIN
                         dbo.Ciemesus_tSubjects INNER JOIN
                         dbo.Ciemesus_tSubjectProperties ON dbo.Ciemesus_tSubjects.IDSubject = dbo.Ciemesus_tSubjectProperties.IDSubject ON 
                         dbo.Ciemesus_tProperties.IDProperty = dbo.Ciemesus_tSubjectProperties.IDProperty ON 
                         dbo.Ciemesus_tSubjectPropertyValues.IDProperty = dbo.Ciemesus_tProperties.IDProperty

GO
/****** Object:  View [dbo].[vw_aspnet_Applications]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_Applications]
  AS SELECT [dbo].[aspnet_Applications].[ApplicationName], [dbo].[aspnet_Applications].[LoweredApplicationName], [dbo].[aspnet_Applications].[ApplicationId], [dbo].[aspnet_Applications].[Description]
  FROM [dbo].[aspnet_Applications]

GO
/****** Object:  View [dbo].[vw_aspnet_MembershipUsers]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_MembershipUsers]
  AS SELECT [dbo].[aspnet_Membership].[UserId],
            [dbo].[aspnet_Membership].[PasswordFormat],
            [dbo].[aspnet_Membership].[MobilePIN],
            [dbo].[aspnet_Membership].[Email],
            [dbo].[aspnet_Membership].[LoweredEmail],
            [dbo].[aspnet_Membership].[PasswordQuestion],
            [dbo].[aspnet_Membership].[PasswordAnswer],
            [dbo].[aspnet_Membership].[IsApproved],
            [dbo].[aspnet_Membership].[IsLockedOut],
            [dbo].[aspnet_Membership].[CreateDate],
            [dbo].[aspnet_Membership].[LastLoginDate],
            [dbo].[aspnet_Membership].[LastPasswordChangedDate],
            [dbo].[aspnet_Membership].[LastLockoutDate],
            [dbo].[aspnet_Membership].[FailedPasswordAttemptCount],
            [dbo].[aspnet_Membership].[FailedPasswordAttemptWindowStart],
            [dbo].[aspnet_Membership].[FailedPasswordAnswerAttemptCount],
            [dbo].[aspnet_Membership].[FailedPasswordAnswerAttemptWindowStart],
            [dbo].[aspnet_Membership].[Comment],
            [dbo].[aspnet_Users].[ApplicationId],
            [dbo].[aspnet_Users].[UserName],
            [dbo].[aspnet_Users].[MobileAlias],
            [dbo].[aspnet_Users].[IsAnonymous],
            [dbo].[aspnet_Users].[LastActivityDate]
  FROM [dbo].[aspnet_Membership] INNER JOIN [dbo].[aspnet_Users]
      ON [dbo].[aspnet_Membership].[UserId] = [dbo].[aspnet_Users].[UserId]

GO
/****** Object:  View [dbo].[vw_aspnet_Profiles]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_Profiles]
  AS SELECT [dbo].[aspnet_Profile].[UserId], [dbo].[aspnet_Profile].[LastUpdatedDate],
      [DataSize]=  DATALENGTH([dbo].[aspnet_Profile].[PropertyNames])
                 + DATALENGTH([dbo].[aspnet_Profile].[PropertyValuesString])
                 + DATALENGTH([dbo].[aspnet_Profile].[PropertyValuesBinary])
  FROM [dbo].[aspnet_Profile]

GO
/****** Object:  View [dbo].[vw_aspnet_Roles]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_Roles]
  AS SELECT [dbo].[aspnet_Roles].[ApplicationId], [dbo].[aspnet_Roles].[RoleId], [dbo].[aspnet_Roles].[RoleName], [dbo].[aspnet_Roles].[LoweredRoleName], [dbo].[aspnet_Roles].[Description]
  FROM [dbo].[aspnet_Roles]

GO
/****** Object:  View [dbo].[vw_aspnet_Users]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_Users]
  AS SELECT [dbo].[aspnet_Users].[ApplicationId], [dbo].[aspnet_Users].[UserId], [dbo].[aspnet_Users].[UserName], [dbo].[aspnet_Users].[LoweredUserName], [dbo].[aspnet_Users].[MobileAlias], [dbo].[aspnet_Users].[IsAnonymous], [dbo].[aspnet_Users].[LastActivityDate]
  FROM [dbo].[aspnet_Users]

GO
/****** Object:  View [dbo].[vw_aspnet_UsersInRoles]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_UsersInRoles]
  AS SELECT [dbo].[aspnet_UsersInRoles].[UserId], [dbo].[aspnet_UsersInRoles].[RoleId]
  FROM [dbo].[aspnet_UsersInRoles]

GO
/****** Object:  View [dbo].[vw_aspnet_WebPartState_Paths]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_WebPartState_Paths]
  AS SELECT [dbo].[aspnet_Paths].[ApplicationId], [dbo].[aspnet_Paths].[PathId], [dbo].[aspnet_Paths].[Path], [dbo].[aspnet_Paths].[LoweredPath]
  FROM [dbo].[aspnet_Paths]

GO
/****** Object:  View [dbo].[vw_aspnet_WebPartState_Shared]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_WebPartState_Shared]
  AS SELECT [dbo].[aspnet_PersonalizationAllUsers].[PathId], [DataSize]=DATALENGTH([dbo].[aspnet_PersonalizationAllUsers].[PageSettings]), [dbo].[aspnet_PersonalizationAllUsers].[LastUpdatedDate]
  FROM [dbo].[aspnet_PersonalizationAllUsers]

GO
/****** Object:  View [dbo].[vw_aspnet_WebPartState_User]    Script Date: 4/6/2014 4:59:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE VIEW [dbo].[vw_aspnet_WebPartState_User]
  AS SELECT [dbo].[aspnet_PersonalizationPerUser].[PathId], [dbo].[aspnet_PersonalizationPerUser].[UserId], [DataSize]=DATALENGTH([dbo].[aspnet_PersonalizationPerUser].[PageSettings]), [dbo].[aspnet_PersonalizationPerUser].[LastUpdatedDate]
  FROM [dbo].[aspnet_PersonalizationPerUser]

GO
ALTER TABLE [dbo].[aspnet_Applications] ADD  CONSTRAINT [DF__aspnet_Ap__Appli__2C3393D0]  DEFAULT (newid()) FOR [ApplicationId]
GO
ALTER TABLE [dbo].[aspnet_Membership] ADD  CONSTRAINT [DF__aspnet_Me__Passw__46E78A0C]  DEFAULT ((0)) FOR [PasswordFormat]
GO
ALTER TABLE [dbo].[aspnet_Paths] ADD  CONSTRAINT [DF__aspnet_Pa__PathI__7F2BE32F]  DEFAULT (newid()) FOR [PathId]
GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] ADD  CONSTRAINT [DF__aspnet_Perso__Id__0A9D95DB]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[aspnet_Roles] ADD  CONSTRAINT [DF__aspnet_Ro__RoleI__68487DD7]  DEFAULT (newid()) FOR [RoleId]
GO
ALTER TABLE [dbo].[aspnet_Users] ADD  CONSTRAINT [DF__aspnet_Us__UserI__31EC6D26]  DEFAULT (newid()) FOR [UserId]
GO
ALTER TABLE [dbo].[aspnet_Users] ADD  CONSTRAINT [DF__aspnet_Us__Mobil__32E0915F]  DEFAULT (NULL) FOR [MobileAlias]
GO
ALTER TABLE [dbo].[aspnet_Users] ADD  CONSTRAINT [DF__aspnet_Us__IsAno__33D4B598]  DEFAULT ((0)) FOR [IsAnonymous]
GO
ALTER TABLE [dbo].[Ciemesus_htLanguages] ADD  CONSTRAINT [DF_Ciemesus_htLanguages_IsRTL]  DEFAULT ((0)) FOR [IsRTL]
GO
ALTER TABLE [dbo].[Ciemesus_htLanguages] ADD  CONSTRAINT [DF_Ciemesus_htLanguages_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Ciemesus_tGalleryPlugins] ADD  CONSTRAINT [DF_Ciemesus_tSubjectPlugins_GenerateTitle]  DEFAULT ((0)) FOR [GenerateTitle]
GO
ALTER TABLE [dbo].[Ciemesus_tGalleryPlugins] ADD  CONSTRAINT [DF_Ciemesus_tSubjectPlugins_GenerateDesc]  DEFAULT ((0)) FOR [GenerateDesc]
GO
ALTER TABLE [dbo].[Ciemesus_tGalleryPlugins] ADD  CONSTRAINT [DF_Ciemesus_tSubjectPlugins_GenerateDate]  DEFAULT ((0)) FOR [GenerateDate]
GO
ALTER TABLE [dbo].[Ciemesus_tGalleryPlugins] ADD  CONSTRAINT [DF_Ciemesus_tSubjectPlugins_GenerateAncher]  DEFAULT ((0)) FOR [GenerateAnchor]
GO
ALTER TABLE [dbo].[Ciemesus_tSubjects] ADD  CONSTRAINT [DF_Ciemesus_tSubjects_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[aspnet_Membership]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Me__Appli__44FF419A] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[aspnet_Membership] CHECK CONSTRAINT [FK__aspnet_Me__Appli__44FF419A]
GO
ALTER TABLE [dbo].[aspnet_Membership]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Me__UserI__45F365D3] FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
ALTER TABLE [dbo].[aspnet_Membership] CHECK CONSTRAINT [FK__aspnet_Me__UserI__45F365D3]
GO
ALTER TABLE [dbo].[aspnet_Paths]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Pa__Appli__7E37BEF6] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[aspnet_Paths] CHECK CONSTRAINT [FK__aspnet_Pa__Appli__7E37BEF6]
GO
ALTER TABLE [dbo].[aspnet_PersonalizationAllUsers]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Pe__PathI__05D8E0BE] FOREIGN KEY([PathId])
REFERENCES [dbo].[aspnet_Paths] ([PathId])
GO
ALTER TABLE [dbo].[aspnet_PersonalizationAllUsers] CHECK CONSTRAINT [FK__aspnet_Pe__PathI__05D8E0BE]
GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Pe__PathI__0B91BA14] FOREIGN KEY([PathId])
REFERENCES [dbo].[aspnet_Paths] ([PathId])
GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] CHECK CONSTRAINT [FK__aspnet_Pe__PathI__0B91BA14]
GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Pe__UserI__0C85DE4D] FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] CHECK CONSTRAINT [FK__aspnet_Pe__UserI__0C85DE4D]
GO
ALTER TABLE [dbo].[aspnet_Profile]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Pr__UserI__5BE2A6F2] FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
ALTER TABLE [dbo].[aspnet_Profile] CHECK CONSTRAINT [FK__aspnet_Pr__UserI__5BE2A6F2]
GO
ALTER TABLE [dbo].[aspnet_Roles]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Ro__Appli__6754599E] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[aspnet_Roles] CHECK CONSTRAINT [FK__aspnet_Ro__Appli__6754599E]
GO
ALTER TABLE [dbo].[aspnet_Users]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Us__Appli__30F848ED] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[aspnet_Users] CHECK CONSTRAINT [FK__aspnet_Us__Appli__30F848ED]
GO
ALTER TABLE [dbo].[aspnet_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Us__RoleI__6E01572D] FOREIGN KEY([RoleId])
REFERENCES [dbo].[aspnet_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[aspnet_UsersInRoles] CHECK CONSTRAINT [FK__aspnet_Us__RoleI__6E01572D]
GO
ALTER TABLE [dbo].[aspnet_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK__aspnet_Us__UserI__6D0D32F4] FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
ALTER TABLE [dbo].[aspnet_UsersInRoles] CHECK CONSTRAINT [FK__aspnet_Us__UserI__6D0D32F4]
GO
ALTER TABLE [dbo].[Ciemesus_tGalleryPlugins]  WITH CHECK ADD  CONSTRAINT [FK_Ciemesus_tSubjectPlugins_Ciemesus_tPlugins] FOREIGN KEY([IDPlugin])
REFERENCES [dbo].[Ciemesus_tPlugins] ([IDPlugin])
GO
ALTER TABLE [dbo].[Ciemesus_tGalleryPlugins] CHECK CONSTRAINT [FK_Ciemesus_tSubjectPlugins_Ciemesus_tPlugins]
GO
ALTER TABLE [dbo].[Ciemesus_tGalleryPlugins]  WITH CHECK ADD  CONSTRAINT [FK_Ciemesus_tSubjectPlugins_Ciemesus_tSubjects] FOREIGN KEY([IDSubject])
REFERENCES [dbo].[Ciemesus_tSubjects] ([IDSubject])
GO
ALTER TABLE [dbo].[Ciemesus_tGalleryPlugins] CHECK CONSTRAINT [FK_Ciemesus_tSubjectPlugins_Ciemesus_tSubjects]
GO
ALTER TABLE [dbo].[Ciemesus_tMediaSubjects]  WITH CHECK ADD  CONSTRAINT [FK_Ciemesus_tMediaSubjects_Ciemesus_htMediaSubjectTypes] FOREIGN KEY([IDMediaSubjectType])
REFERENCES [dbo].[Ciemesus_htMediaSubjectTypes] ([IDMediaSubjectType])
GO
ALTER TABLE [dbo].[Ciemesus_tMediaSubjects] CHECK CONSTRAINT [FK_Ciemesus_tMediaSubjects_Ciemesus_htMediaSubjectTypes]
GO
ALTER TABLE [dbo].[Ciemesus_tMediaSubjects]  WITH CHECK ADD  CONSTRAINT [FK_Ciemesus_tMediaSubjects_Ciemesus_tMedias] FOREIGN KEY([IDMedia])
REFERENCES [dbo].[Ciemesus_tMedias] ([IDMedia])
GO
ALTER TABLE [dbo].[Ciemesus_tMediaSubjects] CHECK CONSTRAINT [FK_Ciemesus_tMediaSubjects_Ciemesus_tMedias]
GO
ALTER TABLE [dbo].[Ciemesus_tMediaSubjects]  WITH CHECK ADD  CONSTRAINT [FK_Ciemesus_tMediaSubjects_Ciemesus_tSubjects] FOREIGN KEY([IDSubject])
REFERENCES [dbo].[Ciemesus_tSubjects] ([IDSubject])
GO
ALTER TABLE [dbo].[Ciemesus_tMediaSubjects] CHECK CONSTRAINT [FK_Ciemesus_tMediaSubjects_Ciemesus_tSubjects]
GO
ALTER TABLE [dbo].[Ciemesus_tMembers]  WITH CHECK ADD  CONSTRAINT [FK_Ciemesus_tMembers_aspnet_Users] FOREIGN KEY([IDMember])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
ALTER TABLE [dbo].[Ciemesus_tMembers] CHECK CONSTRAINT [FK_Ciemesus_tMembers_aspnet_Users]
GO
ALTER TABLE [dbo].[Ciemesus_tProperties]  WITH CHECK ADD  CONSTRAINT [FK_Ciemesus_tProperties_Ciemesus_htLanguages] FOREIGN KEY([IDLanguage])
REFERENCES [dbo].[Ciemesus_htLanguages] ([IDLanguage])
GO
ALTER TABLE [dbo].[Ciemesus_tProperties] CHECK CONSTRAINT [FK_Ciemesus_tProperties_Ciemesus_htLanguages]
GO
ALTER TABLE [dbo].[Ciemesus_tProperties]  WITH CHECK ADD  CONSTRAINT [FK_Ciemesus_tProperties_Ciemesus_htPropertyTypes] FOREIGN KEY([IDType])
REFERENCES [dbo].[Ciemesus_htPropertyTypes] ([IDType])
GO
ALTER TABLE [dbo].[Ciemesus_tProperties] CHECK CONSTRAINT [FK_Ciemesus_tProperties_Ciemesus_htPropertyTypes]
GO
ALTER TABLE [dbo].[Ciemesus_tPropertyItems]  WITH CHECK ADD  CONSTRAINT [FK_Ciemesus_tPropertyItem_Ciemesus_tProperties] FOREIGN KEY([IDProperty])
REFERENCES [dbo].[Ciemesus_tProperties] ([IDProperty])
GO
ALTER TABLE [dbo].[Ciemesus_tPropertyItems] CHECK CONSTRAINT [FK_Ciemesus_tPropertyItem_Ciemesus_tProperties]
GO
ALTER TABLE [dbo].[Ciemesus_tSubjectPlugins]  WITH CHECK ADD  CONSTRAINT [FK_Ciemesus_tSubjectPlugins_Ciemesus_tPlugins1] FOREIGN KEY([IDPlugin])
REFERENCES [dbo].[Ciemesus_tPlugins] ([IDPlugin])
GO
ALTER TABLE [dbo].[Ciemesus_tSubjectPlugins] CHECK CONSTRAINT [FK_Ciemesus_tSubjectPlugins_Ciemesus_tPlugins1]
GO
ALTER TABLE [dbo].[Ciemesus_tSubjectPlugins]  WITH CHECK ADD  CONSTRAINT [FK_Ciemesus_tSubjectPlugins_Ciemesus_tSubjects1] FOREIGN KEY([IDSubject])
REFERENCES [dbo].[Ciemesus_tSubjects] ([IDSubject])
GO
ALTER TABLE [dbo].[Ciemesus_tSubjectPlugins] CHECK CONSTRAINT [FK_Ciemesus_tSubjectPlugins_Ciemesus_tSubjects1]
GO
ALTER TABLE [dbo].[Ciemesus_tSubjectProperties]  WITH CHECK ADD  CONSTRAINT [FK_Ciemesus_tSubjectProperties_Ciemesus_tProperties] FOREIGN KEY([IDProperty])
REFERENCES [dbo].[Ciemesus_tProperties] ([IDProperty])
GO
ALTER TABLE [dbo].[Ciemesus_tSubjectProperties] CHECK CONSTRAINT [FK_Ciemesus_tSubjectProperties_Ciemesus_tProperties]
GO
ALTER TABLE [dbo].[Ciemesus_tSubjectProperties]  WITH CHECK ADD  CONSTRAINT [FK_Ciemesus_tSubjectProperties_Ciemesus_tSubjects] FOREIGN KEY([IDSubject])
REFERENCES [dbo].[Ciemesus_tSubjects] ([IDSubject])
GO
ALTER TABLE [dbo].[Ciemesus_tSubjectProperties] CHECK CONSTRAINT [FK_Ciemesus_tSubjectProperties_Ciemesus_tSubjects]
GO
ALTER TABLE [dbo].[Ciemesus_tSubjectPropertyValues]  WITH CHECK ADD  CONSTRAINT [FK_Ciemesus_tSubjectPropertyValue_Ciemesus_tProperties] FOREIGN KEY([IDProperty])
REFERENCES [dbo].[Ciemesus_tProperties] ([IDProperty])
GO
ALTER TABLE [dbo].[Ciemesus_tSubjectPropertyValues] CHECK CONSTRAINT [FK_Ciemesus_tSubjectPropertyValue_Ciemesus_tProperties]
GO
ALTER TABLE [dbo].[Ciemesus_tSubjectPropertyValues]  WITH CHECK ADD  CONSTRAINT [FK_Ciemesus_tSubjectPropertyValue_Ciemesus_tSubjects] FOREIGN KEY([IDSubject])
REFERENCES [dbo].[Ciemesus_tSubjects] ([IDSubject])
GO
ALTER TABLE [dbo].[Ciemesus_tSubjectPropertyValues] CHECK CONSTRAINT [FK_Ciemesus_tSubjectPropertyValue_Ciemesus_tSubjects]
GO
ALTER TABLE [dbo].[Ciemesus_tSubjects]  WITH CHECK ADD  CONSTRAINT [FK_Ciemesus_tSubjects_Ciemesus_htLanguages] FOREIGN KEY([IDLanguage])
REFERENCES [dbo].[Ciemesus_htLanguages] ([IDLanguage])
GO
ALTER TABLE [dbo].[Ciemesus_tSubjects] CHECK CONSTRAINT [FK_Ciemesus_tSubjects_Ciemesus_htLanguages]
GO
ALTER TABLE [dbo].[Ciemesus_tSubjects]  WITH CHECK ADD  CONSTRAINT [FK_Ciemesus_tSubjects_Ciemesus_htSubjectTypes] FOREIGN KEY([IDSubjectType])
REFERENCES [dbo].[Ciemesus_htSubjectTypes] ([IDSubjectType])
GO
ALTER TABLE [dbo].[Ciemesus_tSubjects] CHECK CONSTRAINT [FK_Ciemesus_tSubjects_Ciemesus_htSubjectTypes]
GO
ALTER TABLE [dbo].[Ciemesus_tSubjects]  WITH CHECK ADD  CONSTRAINT [FK_Ciemesus_tSubjects_Ciemesus_tSubjects] FOREIGN KEY([IDGallery])
REFERENCES [dbo].[Ciemesus_tSubjects] ([IDSubject])
GO
ALTER TABLE [dbo].[Ciemesus_tSubjects] CHECK CONSTRAINT [FK_Ciemesus_tSubjects_Ciemesus_tSubjects]
GO
ALTER TABLE [dbo].[Ciemesus_tSubjects]  WITH CHECK ADD  CONSTRAINT [FK_Ciemesus_tSubjects_Ciemesus_tSubjects1] FOREIGN KEY([IDParent])
REFERENCES [dbo].[Ciemesus_tSubjects] ([IDSubject])
GO
ALTER TABLE [dbo].[Ciemesus_tSubjects] CHECK CONSTRAINT [FK_Ciemesus_tSubjects_Ciemesus_tSubjects1]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'<Root>
    <IDSubject />
    <IDLanguage />
    <Title />
    <Body />
    <IsActive />
</Root>' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Ciemesus_tLogs', @level2type=N'COLUMN',@level2name=N'XML'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[33] 2[10] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Ciemesus_tMedias"
            Begin Extent = 
               Top = 25
               Left = 222
               Bottom = 188
               Right = 382
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Ciemesus_tMediaSubjects"
            Begin Extent = 
               Top = 21
               Left = 478
               Bottom = 158
               Right = 638
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Ciemesus_htMediaSubjectTypes"
            Begin Extent = 
               Top = 52
               Left = 723
               Bottom = 158
               Right = 911
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 10
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 3270
         Alias = 900
         Table = 4155
         Output = 1470
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Ciemesus_vwMediaSubjects'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Ciemesus_vwMediaSubjects'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[44] 4[19] 2[18] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Ciemesus_tProperties"
            Begin Extent = 
               Top = 22
               Left = 635
               Bottom = 155
               Right = 813
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Ciemesus_tSubjectProperties"
            Begin Extent = 
               Top = 6
               Left = 331
               Bottom = 137
               Right = 558
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Ciemesus_tSubjectPropertyValues"
            Begin Extent = 
               Top = 5
               Left = 909
               Bottom = 143
               Right = 1061
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Ciemesus_tSubjects"
            Begin Extent = 
               Top = 6
               Left = 12
               Bottom = 277
               Right = 258
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 2895
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Ciemesus_vwSubjectPropertyValues'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Ciemesus_vwSubjectPropertyValues'
GO
