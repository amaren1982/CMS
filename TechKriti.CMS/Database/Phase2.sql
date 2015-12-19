

CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](4000) NULL,
	[IsEditable] [bit] not NULL,	
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

insert into Roles (Name,description,iseditable) values ('SystemAdmin','This is system Admin',1)
go

CREATE TABLE [dbo].[Permissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Action] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](4000) NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


--ADD ROLES PERMISSION
INSERT INTO PERMISSIONS VALUES ('ManageRoles','')
INSERT INTO PERMISSIONS VALUES ('AddRole','')
INSERT INTO PERMISSIONS VALUES ('UpdateRole','')
INSERT INTO PERMISSIONS VALUES ('DeleteRole','')

--ADD USERS PERMISSION
INSERT INTO PERMISSIONS VALUES ('ManageUsers','')
INSERT INTO PERMISSIONS VALUES ('AddUser','')
INSERT INTO PERMISSIONS VALUES ('UpdateUser','')
INSERT INTO PERMISSIONS VALUES ('DeleteUser','')

--ADD Testimonials PERMISSION
INSERT INTO PERMISSIONS VALUES ('ManageTestimonials','')
INSERT INTO PERMISSIONS VALUES ('AddTestimonial','')
INSERT INTO PERMISSIONS VALUES ('UpdateTestimonial','')
INSERT INTO PERMISSIONS VALUES ('DeleteTestimonial','')

--ADD Downloads PERMISSION
INSERT INTO PERMISSIONS VALUES ('ManageDownloads','')
INSERT INTO PERMISSIONS VALUES ('AddDownload','')
INSERT INTO PERMISSIONS VALUES ('UpdateDownload','')
INSERT INTO PERMISSIONS VALUES ('DeleteDownload','')

--ADD News PERMISSION
INSERT INTO PERMISSIONS VALUES ('ManageNews','')
INSERT INTO PERMISSIONS VALUES ('AddNews','')
INSERT INTO PERMISSIONS VALUES ('UpdateNews','')
INSERT INTO PERMISSIONS VALUES ('DeleteNews','')

--ADD Sector PERMISSION
INSERT INTO PERMISSIONS VALUES ('ManageSectors','')
INSERT INTO PERMISSIONS VALUES ('AddSector','')
INSERT INTO PERMISSIONS VALUES ('UpdateSector','')
INSERT INTO PERMISSIONS VALUES ('DeleteSector','')

--ADD Qualifications PERMISSION
INSERT INTO PERMISSIONS VALUES ('ManageQualifications','')
INSERT INTO PERMISSIONS VALUES ('AddQualification','')
INSERT INTO PERMISSIONS VALUES ('UpdateQualification','')
INSERT INTO PERMISSIONS VALUES ('DeleteQualification','')

--ADD Photo Gallery PERMISSION
INSERT INTO PERMISSIONS VALUES ('ManagePhotoGallery','')
INSERT INTO PERMISSIONS VALUES ('AddPhotoGallery','')
INSERT INTO PERMISSIONS VALUES ('UpdatePhotoGallery','')
INSERT INTO PERMISSIONS VALUES ('DeletePhotoGallery','')

--ADD Photo Gallery PERMISSION
INSERT INTO PERMISSIONS VALUES ('ManageCurrentOpenings','')
INSERT INTO PERMISSIONS VALUES ('AddCurrentOpening','')
INSERT INTO PERMISSIONS VALUES ('UpdateCurrentOpening','')
INSERT INTO PERMISSIONS VALUES ('DeleteCurrentOpening','')

--ADD Menu PERMISSION
INSERT INTO PERMISSIONS VALUES ('ManageMenus','')
INSERT INTO PERMISSIONS VALUES ('AddMenu','')
INSERT INTO PERMISSIONS VALUES ('UpdateMenu','')
INSERT INTO PERMISSIONS VALUES ('DeleteMenu','')


--ADD Page PERMISSION
INSERT INTO PERMISSIONS VALUES ('ManagePages','')
INSERT INTO PERMISSIONS VALUES ('AddPage','')
INSERT INTO PERMISSIONS VALUES ('UpdatePage','')
INSERT INTO PERMISSIONS VALUES ('DeletePage','')


CREATE TABLE [dbo].[PermissionsInRole](
[Id] [int] IDENTITY(1,1) NOT NULL Primary key,
RoleId [int],
PermissionId [int],
)
GO

ALTER TABLE [dbo].[PermissionsInRole]  WITH CHECK ADD  CONSTRAINT [RoleId_ForeignKey_PermissionsInRole] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])

ALTER TABLE [dbo].[PermissionsInRole]  WITH CHECK ADD  CONSTRAINT [PermissionId_ForeignKey] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permissions] ([Id])

insert into PermissionsInRole (roleid,permissionid)
values (1,1), (1,2), (1,3), (1,4), (1,5), (1,6), (1,7), (1,8), (1,9), (1,10), (1,11), (1,12)
, (1,13), (1,14), (1,15), (1,16), (1,17), (1,18), (1,19), (1,20), (1,21), (1,22), (1,23), (1,24),(1,25)
,(1,26),(1,27),(1,28),(1,29),(1,30),(1,31),(1,32),(1,33),(1,34),(1,35),(1,36),(1,37),(1,38),(1,39),(1,40)
,(1,41),(1,42),(1,43), (1,44)

GO

DROP TABLE Users

CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[LastLogin] [datetime]  NULL,
	[FailtedAttempts] [smallint] NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UC_USERNAME] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [RoleId_ForeignKey] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO

ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [RoleId_ForeignKey]
GO

insert into Users (Username, Password, RoleId) values('admin','21232F297A57A5A743894A0E4A801FC3', 1)
GO



CREATE TABLE [dbo].[Menus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MenuName] [nvarchar](100) NOT NULL,
	[DisplayOrderId] [INT] NOT NULL,
	[ParentMenuId] [INT] NULL,
	[IsActive] [bit] NULL,	
 CONSTRAINT [PK_Menus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Menus]  WITH CHECK ADD  CONSTRAINT [ParentMenuId_ForeignKey] FOREIGN KEY([ParentMenuId])
REFERENCES [dbo].[Menus] ([Id])

CREATE TABLE [dbo].[Pages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[MenuId] [INT] NOT NULL,
	[Content] [Text] NULL,
	[CreatedBy] [int] NOT NULL,	
	[CreatedOn] [DateTime] NOT NULL,
	[Status] [SmallInt] NOT NULL
 CONSTRAINT [PK_Pages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[Pages]  WITH CHECK ADD  CONSTRAINT [MenuId_ForeignKeyMenus] FOREIGN KEY([MenuId])
REFERENCES [dbo].[Menus] ([Id])


ALTER TABLE [dbo].[Pages]  WITH CHECK ADD  CONSTRAINT [UserId_ForeignKeyUsers] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserId])

ALTER TABLE pages add "SeoTitle" nvarchar(1000)

ALTER TABLE pages add "MetaKeys" nvarchar(1000)

ALTER TABLE pages add "Description" nvarchar(1000)

ALTER TABLE pages add "H1" nvarchar(1000)

ALTER TABLE pages add "H2" nvarchar(1000)

