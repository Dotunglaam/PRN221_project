USE [ManageInstructor]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/8/2024 1:19:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 3/8/2024 1:19:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Start] [datetime2](7) NULL,
	[End] [datetime2](7) NULL,
	[SubjectId] [uniqueidentifier] NULL,
	[UserId] [uniqueidentifier] NULL,
	[Status] [int] NOT NULL,
	[ThemeColor] [nvarchar](max) NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 3/8/2024 1:19:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 3/8/2024 1:19:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[DateCreate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/8/2024 1:19:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[isActive] [bit] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240306121534_initDb', N'6.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240306123950_update-SubjectEntity', N'6.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240307042058_update-subject', N'6.0.0')
GO
INSERT [dbo].[Events] ([Id], [Name], [Description], [Start], [End], [SubjectId], [UserId], [Status], [ThemeColor]) VALUES (N'f8648690-47b6-41e0-bd0b-43fa93470a5c', N'SWE201c', N'Phong 332', CAST(N'2024-03-13T07:00:00.0000000' AS DateTime2), CAST(N'2024-03-13T16:00:00.0000000' AS DateTime2), N'28f5cea6-4d40-46fb-8c68-3d594ec554e7', N'73c53320-e78c-4a52-94fa-4e20b5b23a12', 1, N'blue')
INSERT [dbo].[Events] ([Id], [Name], [Description], [Start], [End], [SubjectId], [UserId], [Status], [ThemeColor]) VALUES (N'73c53820-e78c-4a52-94fa-4e20b5b23a15', N'IOT102', N'Phòng 114', CAST(N'2024-03-07T16:00:00.0000000' AS DateTime2), CAST(N'2024-03-07T19:00:00.0000000' AS DateTime2), N'8bce69bf-783a-4b5e-a3f0-c7f025ba26d4', N'73c53320-e78c-4a52-94fa-4e20b5b23a12', 1, N'green')
INSERT [dbo].[Events] ([Id], [Name], [Description], [Start], [End], [SubjectId], [UserId], [Status], [ThemeColor]) VALUES (N'b3263b7b-b011-4f1c-b0f1-e31785521fca', N'IOT102', N'123', CAST(N'2024-03-08T07:00:00.0000000' AS DateTime2), CAST(N'2024-03-09T07:00:00.0000000' AS DateTime2), N'4a2c2ad2-6472-4277-8415-4f2def2be343', N'73c53320-e78c-4a52-94fa-4e20b5b23a12', 1, N'black')
GO
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (N'73c53820-e78c-4a52-94fa-3e10b5b23a15', N'Admin')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (N'73c53820-e78c-4a52-94fa-4e20b5b23a12', N'Instructor')
GO
INSERT [dbo].[Subjects] ([Id], [Name], [Description], [Code], [DateCreate]) VALUES (N'28f5cea6-4d40-46fb-8c68-3d594ec554e7', N'C++ Programming Foundation 123', N'123', N'SWE201c', CAST(N'2024-03-08T00:44:22.7906805' AS DateTime2))
INSERT [dbo].[Subjects] ([Id], [Name], [Description], [Code], [DateCreate]) VALUES (N'4a2c2ad2-6472-4277-8415-4f2def2be343', N'.NET programming Foundation With WPF', N'Winform Platform', N'WPF212', CAST(N'2024-03-08T00:43:22.6669006' AS DateTime2))
INSERT [dbo].[Subjects] ([Id], [Name], [Description], [Code], [DateCreate]) VALUES (N'f5751c29-532c-4ebb-9e6d-9f08e1151f6a', N'.NET programming Foundation With WPF', N'Winform Platform', N'WPF212', CAST(N'2024-03-08T00:44:09.7106347' AS DateTime2))
INSERT [dbo].[Subjects] ([Id], [Name], [Description], [Code], [DateCreate]) VALUES (N'8bce69bf-783a-4b5e-a3f0-c7f025ba26d4', N'Internet of Thing', N'This subject have student have a view about IOT world', N'IOT102', CAST(N'2024-06-03T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Subjects] ([Id], [Name], [Description], [Code], [DateCreate]) VALUES (N'8bce69bf-783a-4b5e-a3f0-c7f035ba26d4', N'C++ Programming Foundation', N'Help student have programming foundation', N'PRF192', CAST(N'2024-06-03T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Subjects] ([Id], [Name], [Description], [Code], [DateCreate]) VALUES (N'611679b7-35dc-4f8f-bb61-e1eb82295b9a', N'.NET programming Foundation', N'Help Student Learn .NET', N'PRN221', CAST(N'2024-03-08T00:41:57.6139652' AS DateTime2))
GO
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [isActive], [Created], [RoleId]) VALUES (N'73c53820-e78c-4a52-94fa-4e10b5b23a15', N'Admin', N'admin@gmail.com', N'admin', 1, CAST(N'2024-03-07T00:00:00.0000000' AS DateTime2), N'73c53820-e78c-4a52-94fa-3e10b5b23a15')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [isActive], [Created], [RoleId]) VALUES (N'73c53320-e78c-4a52-94fa-4e20b3b23a12', N'KIEMHH', N'kiemhh@gmail.com', N'123', 1, CAST(N'2024-03-07T00:00:00.0000000' AS DateTime2), N'73c53820-e78c-4a52-94fa-4e20b5b23a12')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Password], [isActive], [Created], [RoleId]) VALUES (N'73c53320-e78c-4a52-94fa-4e20b5b23a12', N'KhanhKT', N'khanhkt@gmail.com', N'123', 1, CAST(N'2024-03-07T00:00:00.0000000' AS DateTime2), N'73c53820-e78c-4a52-94fa-4e20b5b23a12')
GO
ALTER TABLE [dbo].[Events] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Subjects] ADD  DEFAULT (N'') FOR [Code]
GO
ALTER TABLE [dbo].[Subjects] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [DateCreate]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Subjects_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([Id])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Subjects_SubjectId]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Users_UserId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles_RoleId]
GO
