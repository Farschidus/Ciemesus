/****** Object:  Table [dbo].[Ciemesus_htSubjectTypes]    Script Date: 11/06/2012 17:13:35 ******/
USE [Ciemesus-DB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
INSERT [dbo].[Ciemesus_htSubjectTypes] ([IDSubjectType], [Title], [Priority]) VALUES (1, N'Home', 1)
INSERT [dbo].[Ciemesus_htSubjectTypes] ([IDSubjectType], [Title], [Priority]) VALUES (2, N'Page', 2)
INSERT [dbo].[Ciemesus_htSubjectTypes] ([IDSubjectType], [Title], [Priority]) VALUES (3, N'List', 3)
INSERT [dbo].[Ciemesus_htSubjectTypes] ([IDSubjectType], [Title], [Priority]) VALUES (4, N'ImageGallery', 4)
INSERT [dbo].[Ciemesus_htSubjectTypes] ([IDSubjectType], [Title], [Priority]) VALUES (5, N'VideoGallery', 5)
INSERT [dbo].[Ciemesus_htSubjectTypes] ([IDSubjectType], [Title], [Priority]) VALUES (6, N'AudioGallery', 6)
INSERT [dbo].[Ciemesus_htSubjectTypes] ([IDSubjectType], [Title], [Priority]) VALUES (7, N'ListItem', 7)
INSERT [dbo].[Ciemesus_htSubjectTypes] ([IDSubjectType], [Title], [Priority]) VALUES (8, N'Category', 8)
INSERT [dbo].[Ciemesus_htSubjectTypes] ([IDSubjectType], [Title], [Priority]) VALUES (9, N'UserPage', 9)
INSERT [dbo].[Ciemesus_htSubjectTypes] ([IDSubjectType], [Title], [Priority]) VALUES (10, N'Form', 10)
INSERT [dbo].[Ciemesus_htSubjectTypes] ([IDSubjectType], [Title], [Priority]) VALUES (11, N'Contact', 11)
GO
/****** Object:  Table [dbo].[Ciemesus_htMediaSubjectTypes]    Script Date: 11/06/2012 17:13:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
INSERT [dbo].[Ciemesus_htMediaSubjectTypes] ([IDMediaSubjectType], [Title]) VALUES (1, N'Attachment')
INSERT [dbo].[Ciemesus_htMediaSubjectTypes] ([IDMediaSubjectType], [Title]) VALUES (2, N'HeaderImage')
INSERT [dbo].[Ciemesus_htMediaSubjectTypes] ([IDMediaSubjectType], [Title]) VALUES (3, N'ImageAttachment')
INSERT [dbo].[Ciemesus_htMediaSubjectTypes] ([IDMediaSubjectType], [Title]) VALUES (4, N'Thumbnail')
GO
/****** Object:  Table [dbo].[Ciemesus_htPropertyTypes]    Script Date: 02/01/2013 20:22:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
INSERT [dbo].[Ciemesus_htPropertyTypes] ([IDType], [Name]) VALUES (1, N'Text')
INSERT [dbo].[Ciemesus_htPropertyTypes] ([IDType], [Name]) VALUES (2, N'Integer')
INSERT [dbo].[Ciemesus_htPropertyTypes] ([IDType], [Name]) VALUES (3, N'Float')
INSERT [dbo].[Ciemesus_htPropertyTypes] ([IDType], [Name]) VALUES (4, N'SingleSelect')
INSERT [dbo].[Ciemesus_htPropertyTypes] ([IDType], [Name]) VALUES (5, N'MultiSelect')
INSERT [dbo].[Ciemesus_htPropertyTypes] ([IDType], [Name]) VALUES (6, N'TrueFalse')
INSERT [dbo].[Ciemesus_htPropertyTypes] ([IDType], [Name]) VALUES (7, N'Date')
INSERT [dbo].[Ciemesus_htPropertyTypes] ([IDType], [Name]) VALUES (8, N'Time')
INSERT [dbo].[Ciemesus_htPropertyTypes] ([IDType], [Name]) VALUES (9, N'DateTime')
INSERT [dbo].[Ciemesus_htPropertyTypes] ([IDType], [Name]) VALUES (10, N'MultilineText')
GO
/****** Object:  Table [dbo].[Ciemesus_htLanguages]    Script Date: 11/06/2012 17:13:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
INSERT [dbo].[Ciemesus_htLanguages] ([IDLanguage], [Title], [Code], [IsRTL], [IsActive], [IsDefault], [Priority]) VALUES (1, N'English', N'en_US', 0, 1, 1, 1)
INSERT [dbo].[Ciemesus_htLanguages] ([IDLanguage], [Title], [Code], [IsRTL], [IsActive], [IsDefault], [Priority]) VALUES (2, N'فارسی', N'fa_IR', 1, 0, 0, 2)
INSERT [dbo].[Ciemesus_htLanguages] ([IDLanguage], [Title], [Code], [IsRTL], [IsActive], [IsDefault], [Priority]) VALUES (3, N'عربی', N'ar_AR', 1, 0, 0, 3)
INSERT [dbo].[Ciemesus_htLanguages] ([IDLanguage], [Title], [Code], [IsRTL], [IsActive], [IsDefault], [Priority]) VALUES (4, N'Germany', N'de_DE', 0, 0, 0, 7)
INSERT [dbo].[Ciemesus_htLanguages] ([IDLanguage], [Title], [Code], [IsRTL], [IsActive], [IsDefault], [Priority]) VALUES (5, N'Spanish', N'es_ES', 0, 0, 0, 5)
INSERT [dbo].[Ciemesus_htLanguages] ([IDLanguage], [Title], [Code], [IsRTL], [IsActive], [IsDefault], [Priority]) VALUES (6, N'Russian', N'ru_RU', 0, 0, 0, 9)
INSERT [dbo].[Ciemesus_htLanguages] ([IDLanguage], [Title], [Code], [IsRTL], [IsActive], [IsDefault], [Priority]) VALUES (7, N'Italian', N'it_IT', 0, 0, 0, 6)
INSERT [dbo].[Ciemesus_htLanguages] ([IDLanguage], [Title], [Code], [IsRTL], [IsActive], [IsDefault], [Priority]) VALUES (8, N'French', N'fr_CA', 0, 0, 0, 4)
INSERT [dbo].[Ciemesus_htLanguages] ([IDLanguage], [Title], [Code], [IsRTL], [IsActive], [IsDefault], [Priority]) VALUES (9, N'Japanese', N'ja_JP', 0, 0, 0, 8)
INSERT [dbo].[Ciemesus_htLanguages] ([IDLanguage], [Title], [Code], [IsRTL], [IsActive], [IsDefault], [Priority]) VALUES (10, N'Portuguese', N'pt_PT', 0, 0, 0, 10)
INSERT [dbo].[Ciemesus_htLanguages] ([IDLanguage], [Title], [Code], [IsRTL], [IsActive], [IsDefault], [Priority]) VALUES (11, N'Swedish', N'sv_SV', 0, 0, 0, 12)
INSERT [dbo].[Ciemesus_htLanguages] ([IDLanguage], [Title], [Code], [IsRTL], [IsActive], [IsDefault], [Priority]) VALUES (12, N'Turkish', N'tr_TR', 0, 0, 0, 13)
INSERT [dbo].[Ciemesus_htLanguages] ([IDLanguage], [Title], [Code], [IsRTL], [IsActive], [IsDefault], [Priority]) VALUES (13, N'Norwegian', N'no_NO', 0, 0, 0, 14)
INSERT [dbo].[Ciemesus_htLanguages] ([IDLanguage], [Title], [Code], [IsRTL], [IsActive], [IsDefault], [Priority]) VALUES (14, N'Greek', N'gr_GR', 0, 0, 0, 17)
INSERT [dbo].[Ciemesus_htLanguages] ([IDLanguage], [Title], [Code], [IsRTL], [IsActive], [IsDefault], [Priority]) VALUES (15, N'Finnish', N'fi_FI', 0, 0, 0, 15)
INSERT [dbo].[Ciemesus_htLanguages] ([IDLanguage], [Title], [Code], [IsRTL], [IsActive], [IsDefault], [Priority]) VALUES (16, N'Dutch', N'nl_NL', 0, 0, 0, 11)
INSERT [dbo].[Ciemesus_htLanguages] ([IDLanguage], [Title], [Code], [IsRTL], [IsActive], [IsDefault], [Priority]) VALUES (17, N'Danish', N'da_DK', 0, 0, 0, 16)
INSERT [dbo].[Ciemesus_htLanguages] ([IDLanguage], [Title], [Code], [IsRTL], [IsActive], [IsDefault], [Priority]) VALUES (18, N'Czech', N'cs_CZ', 0, 0, 0, 18)
INSERT [dbo].[Ciemesus_htLanguages] ([IDLanguage], [Title], [Code], [IsRTL], [IsActive], [IsDefault], [Priority]) VALUES (19, N'Chinese', N'zh_CN', 0, 0, 0, 19)
GO
/****** Object:  Table [dbo].[aspnet_SchemaVersions]    Script Date: 02/01/2013 20:22:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
INSERT [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'common', N'1', 1)
INSERT [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'health monitoring', N'1', 1)
INSERT [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'membership', N'1', 1)
INSERT [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'personalization', N'1', 1)
INSERT [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'profile', N'1', 1)
INSERT [dbo].[aspnet_SchemaVersions] ([Feature], [CompatibleSchemaVersion], [IsCurrentVersion]) VALUES (N'role manager', N'1', 1)
GO