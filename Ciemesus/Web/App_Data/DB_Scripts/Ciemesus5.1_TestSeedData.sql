/****** Object:  Table [dbo].[Ciemesus_htSubjectTypes]    Script Date: 11/06/2012 17:13:35 ******/
USE [Ciemesus-DB]
GO
INSERT [dbo].[aspnet_Applications] ([ApplicationName], [LoweredApplicationName], [ApplicationId], [Description]) VALUES (N'Ciemesus5', N'ciemesus5', N'1569c980-f701-45c2-ac8f-75f38f221ade', NULL)
GO

INSERT [dbo].[aspnet_Users] ([ApplicationId], [UserId], [UserName], [LoweredUserName], [MobileAlias], [IsAnonymous], [LastActivityDate]) VALUES (N'1569c980-f701-45c2-ac8f-75f38f221ade', N'cac3660a-b48a-40a3-a737-4d88bc4b4c67', N'Admin', N'admin', NULL, 0, CAST(N'2021-03-15T18:59:41.360' AS DateTime))
GO

INSERT [dbo].[aspnet_Membership] ([ApplicationId], [UserId], [Password], [PasswordFormat], [PasswordSalt], [MobilePIN], [Email], [LoweredEmail], [PasswordQuestion], [PasswordAnswer], [IsApproved], [IsLockedOut], [CreateDate], [LastLoginDate], [LastPasswordChangedDate], [LastLockoutDate], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowStart], [Comment]) VALUES (N'1569c980-f701-45c2-ac8f-75f38f221ade', N'cac3660a-b48a-40a3-a737-4d88bc4b4c67', N's35SUAL6KJlgNnkVXbXiPff3if4=', 1, N'jQNcrKcZfQicjHA+sNtKCA==', NULL, N'info@ciemesus.com', N'info@ciemesus.com', NULL, NULL, 1, 0, CAST(N'2021-03-15T18:02:52.000' AS DateTime), CAST(N'2021-03-15T18:59:41.360' AS DateTime), CAST(N'2021-03-15T18:02:52.000' AS DateTime), CAST(N'1754-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1754-01-01T00:00:00.000' AS DateTime), 0, CAST(N'1754-01-01T00:00:00.000' AS DateTime), NULL)
GO

INSERT [dbo].[aspnet_Roles] ([ApplicationId], [RoleId], [RoleName], [LoweredRoleName], [Description]) VALUES (N'1569c980-f701-45c2-ac8f-75f38f221ade', N'8a304b18-43d0-4955-84e4-132e0e2c2eff', N'SuperAdmin', N'superadmin', N'Ciemesus Super Admin')
GO
INSERT [dbo].[aspnet_Roles] ([ApplicationId], [RoleId], [RoleName], [LoweredRoleName], [Description]) VALUES (N'1569c980-f701-45c2-ac8f-75f38f221ade', N'e351df67-50ee-4d0f-aad3-4dd12fe3fce8', N'Administrator', N'administrator', N'Ciemesus Admin')
GO

INSERT [dbo].[aspnet_UsersInRoles] ([UserId], [RoleId]) VALUES (N'cac3660a-b48a-40a3-a737-4d88bc4b4c67', N'8a304b18-43d0-4955-84e4-132e0e2c2eff')
GO
INSERT [dbo].[aspnet_UsersInRoles] ([UserId], [RoleId]) VALUES (N'cac3660a-b48a-40a3-a737-4d88bc4b4c67', N'e351df67-50ee-4d0f-aad3-4dd12fe3fce8')
GO

INSERT [dbo].[aspnet_Profile] ([UserId], [PropertyNames], [PropertyValuesString], [PropertyValuesBinary], [LastUpdatedDate]) VALUES (N'cac3660a-b48a-40a3-a737-4d88bc4b4c67', N'Tel:S:0:12:FirstName:S:12:5:DateOfBirth:S:17:81:Address:S:98:6:Gender:S:104:5:LastName:S:109:5:', N'+46735335150Super<?xml version="1.0" encoding="utf-16"?>
<dateTime>2021-01-01T21:32:52</dateTime>SwedenFalseAdmin', 0x, CAST(N'2021-03-15T18:02:52.437' AS DateTime))
GO


INSERT [dbo].[Ciemesus_tSubjects] ([IDSubject], [IDSubjectType], [IDParent], [IDLanguage], [IDGallery], [Title], [Body], [Alias], [Date], [IsActive], [BannerType], [Priority]) VALUES (N'4bda847b-a626-4881-9c7d-70a9becce554', 1, NULL, 1, NULL, N'Welcome to Ciemesus', N'<p>Ciemesus is another multi lingual CMS with focusing on left to right languages.</p>', NULL, CAST(N'2021-03-15T21:55:14.580' AS DateTime), 1, NULL, NULL)
GO
INSERT [dbo].[Ciemesus_tSubjects] ([IDSubject], [IDSubjectType], [IDParent], [IDLanguage], [IDGallery], [Title], [Body], [Alias], [Date], [IsActive], [BannerType], [Priority]) VALUES (N'2b68e6c2-deab-4114-8402-d01999b29fad', 1, NULL, 2, NULL, N'خانه', NULL, NULL, CAST(N'2021-03-15T22:09:42.267' AS DateTime), 1, NULL, NULL)
GO
