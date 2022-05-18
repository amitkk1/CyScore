USE [master]
GO

/****** Object:  Database [CyscoreDB]    Script Date: 15/05/2022 16:21:39 ******/
CREATE DATABASE [CyscoreDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CyscoreDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CyscoreDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CyscoreDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CyscoreDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CyscoreDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [CyscoreDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [CyscoreDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [CyscoreDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [CyscoreDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [CyscoreDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [CyscoreDB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [CyscoreDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [CyscoreDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [CyscoreDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [CyscoreDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [CyscoreDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [CyscoreDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [CyscoreDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [CyscoreDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [CyscoreDB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [CyscoreDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [CyscoreDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [CyscoreDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [CyscoreDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [CyscoreDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [CyscoreDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [CyscoreDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [CyscoreDB] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [CyscoreDB] SET  MULTI_USER 
GO

ALTER DATABASE [CyscoreDB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [CyscoreDB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [CyscoreDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [CyscoreDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [CyscoreDB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [CyscoreDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [CyscoreDB] SET QUERY_STORE = OFF
GO

ALTER DATABASE [CyscoreDB] SET  READ_WRITE 
GO
