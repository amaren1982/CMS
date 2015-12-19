
/****** Object:  Table [dbo].[Category]    Script Date: 05/02/2015 09:48:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ChildCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](500) NULL,
	[Name] [nvarchar](max) NULL,
	[SubCategoryId] [int] NULL,
 CONSTRAINT [PK_ChildCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ChildCategory]  WITH CHECK ADD FOREIGN KEY([SubCategoryId])
REFERENCES [dbo].[Category] ([Id])
GO

DROP TABLE SelectionCriteria

CREATE TABLE [dbo].[SelectionCriteria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[SubCategoryId] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_SelectionCriteria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SelectionCriteria]  WITH CHECK ADD FOREIGN KEY([SubCategoryId])
REFERENCES [dbo].[ChildCategory] ([Id])
GO


