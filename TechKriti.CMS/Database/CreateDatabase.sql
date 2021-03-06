USE [master]
GO
/****** Object:  Database [TechKritiCMS]    Script Date: 12/16/2014 22:50:04 ******/
CREATE DATABASE [TechKritiCMS] ON  PRIMARY 
( NAME = N'TechKritiCMS', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\TechKritiCMS.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TechKritiCMS_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\TechKritiCMS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TechKritiCMS] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TechKritiCMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TechKritiCMS] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [TechKritiCMS] SET ANSI_NULLS OFF
GO
ALTER DATABASE [TechKritiCMS] SET ANSI_PADDING OFF
GO
ALTER DATABASE [TechKritiCMS] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [TechKritiCMS] SET ARITHABORT OFF
GO
ALTER DATABASE [TechKritiCMS] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [TechKritiCMS] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [TechKritiCMS] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [TechKritiCMS] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [TechKritiCMS] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [TechKritiCMS] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [TechKritiCMS] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [TechKritiCMS] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [TechKritiCMS] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [TechKritiCMS] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [TechKritiCMS] SET  DISABLE_BROKER
GO
ALTER DATABASE [TechKritiCMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [TechKritiCMS] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [TechKritiCMS] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [TechKritiCMS] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [TechKritiCMS] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [TechKritiCMS] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [TechKritiCMS] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [TechKritiCMS] SET  READ_WRITE
GO
ALTER DATABASE [TechKritiCMS] SET RECOVERY SIMPLE
GO
ALTER DATABASE [TechKritiCMS] SET  MULTI_USER
GO
ALTER DATABASE [TechKritiCMS] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [TechKritiCMS] SET DB_CHAINING OFF
GO
USE [TechKritiCMS]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/16/2014 22:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] NOT NULL,
	[Username] [nchar](255) NOT NULL,
	[Password] [nchar](255) NOT NULL,
	[LastLogin] [datetime] NOT NULL,
	[FailtedAttempts] [smallint] NULL,
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
/****** Object:  Table [dbo].[Testimonials]    Script Date: 12/16/2014 22:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Testimonials](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SectionId] [int] NULL,
	[DisplayName] [nvarchar](4000) NULL,
	[Path] [nvarchar](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Testimonials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sectors]    Script Date: 12/16/2014 22:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sectors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SectionId] [int] NULL,
	[DisplayName] [nvarchar](4000) NULL,
	[Path] [nvarchar](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Sectors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhotoGallery]    Script Date: 12/16/2014 22:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhotoGallery](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SectionId] [int] NULL,
	[DisplayName] [nvarchar](4000) NULL,
	[Path] [nvarchar](max) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_PhotoGallery] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 12/16/2014 22:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[NewsDescription] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Downloads]    Script Date: 12/16/2014 22:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Downloads](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SectionId] [int] NULL,
	[DisplayName] [nvarchar](4000) NULL,
	[DownloadPath] [nvarchar](4000) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Downloads] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CurrentOpenings]    Script Date: 12/16/2014 22:50:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurrentOpenings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Company] [nvarchar](4000) NULL,
	[Position] [nvarchar](4000) NULL,
	[Qualification] [nvarchar](max) NULL,
	[SkillSet] [nvarchar](max) NULL,
	[Email] [nvarchar](1000) NULL,
	[OpenTillDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_CurrentOpenings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
