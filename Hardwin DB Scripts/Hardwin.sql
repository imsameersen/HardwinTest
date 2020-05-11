USE [master]
GO

/****** Object:  Database [Hardwin]    Script Date: 5/11/2020 12:51:42 AM ******/
CREATE DATABASE [Hardwin]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Hardwin', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Hardwin.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Hardwin_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Hardwin_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Hardwin].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Hardwin] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Hardwin] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Hardwin] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Hardwin] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Hardwin] SET ARITHABORT OFF 
GO

ALTER DATABASE [Hardwin] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Hardwin] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Hardwin] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Hardwin] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Hardwin] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Hardwin] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Hardwin] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Hardwin] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Hardwin] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Hardwin] SET  ENABLE_BROKER 
GO

ALTER DATABASE [Hardwin] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Hardwin] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Hardwin] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Hardwin] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Hardwin] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Hardwin] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Hardwin] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Hardwin] SET RECOVERY FULL 
GO

ALTER DATABASE [Hardwin] SET  MULTI_USER 
GO

ALTER DATABASE [Hardwin] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Hardwin] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Hardwin] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Hardwin] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Hardwin] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Hardwin] SET QUERY_STORE = OFF
GO

ALTER DATABASE [Hardwin] SET  READ_WRITE 
GO
