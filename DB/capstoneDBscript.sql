USE [master]
GO
/****** Object:  Database [capstone]    Script Date: 1/24/2019 3:44:50 PM ******/
CREATE DATABASE [capstone]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'capstone', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\capstone.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'capstone_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\capstone_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [capstone] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [capstone].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [capstone] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [capstone] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [capstone] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [capstone] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [capstone] SET ARITHABORT OFF 
GO
ALTER DATABASE [capstone] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [capstone] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [capstone] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [capstone] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [capstone] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [capstone] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [capstone] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [capstone] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [capstone] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [capstone] SET  DISABLE_BROKER 
GO
ALTER DATABASE [capstone] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [capstone] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [capstone] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [capstone] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [capstone] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [capstone] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [capstone] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [capstone] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [capstone] SET  MULTI_USER 
GO
ALTER DATABASE [capstone] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [capstone] SET DB_CHAINING OFF 
GO
ALTER DATABASE [capstone] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [capstone] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [capstone]
GO
/****** Object:  Table [dbo].[Choices]    Script Date: 1/24/2019 3:44:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Choices](
	[EncID] [int] NOT NULL,
	[ID] [int] NOT NULL,
	[QuestionID] [int] NOT NULL,
	[Text] [nvarchar](max) NULL,
	[NextEID] [int] NOT NULL,
 CONSTRAINT [PK_Choices] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Encounter]    Script Date: 1/24/2019 3:44:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Encounter](
	[EncounterID] [int] NOT NULL,
	[EncounterTypeID] [int] NOT NULL,
 CONSTRAINT [PK_Encounter] PRIMARY KEY CLUSTERED 
(
	[EncounterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EncounterType]    Script Date: 1/24/2019 3:44:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EncounterType](
	[ID] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_EncounterType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Questions]    Script Date: 1/24/2019 3:44:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[EncID] [int] NOT NULL,
	[ID] [int] NOT NULL,
	[Text] [nvarchar](max) NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Choices]  WITH CHECK ADD  CONSTRAINT [FK_Choices_EncounterID] FOREIGN KEY([EncID])
REFERENCES [dbo].[Encounter] ([EncounterID])
GO
ALTER TABLE [dbo].[Choices] CHECK CONSTRAINT [FK_Choices_EncounterID]
GO
ALTER TABLE [dbo].[Choices]  WITH CHECK ADD  CONSTRAINT [FK_Choices_NextEID] FOREIGN KEY([NextEID])
REFERENCES [dbo].[Encounter] ([EncounterID])
GO
ALTER TABLE [dbo].[Choices] CHECK CONSTRAINT [FK_Choices_NextEID]
GO
ALTER TABLE [dbo].[Choices]  WITH CHECK ADD  CONSTRAINT [FK_Choices_Questions] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[Questions] ([ID])
GO
ALTER TABLE [dbo].[Choices] CHECK CONSTRAINT [FK_Choices_Questions]
GO
ALTER TABLE [dbo].[Encounter]  WITH CHECK ADD  CONSTRAINT [FK_Encounter_EncounterType] FOREIGN KEY([EncounterTypeID])
REFERENCES [dbo].[EncounterType] ([ID])
GO
ALTER TABLE [dbo].[Encounter] CHECK CONSTRAINT [FK_Encounter_EncounterType]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Encounter] FOREIGN KEY([EncID])
REFERENCES [dbo].[Encounter] ([EncounterID])
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_Encounter]
GO
USE [master]
GO
ALTER DATABASE [capstone] SET  READ_WRITE 
GO
