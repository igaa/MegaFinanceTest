USE [master]
GO
/****** Object:  Database [MegaFinance]    Script Date: 11/14/2023 9:53:38 PM ******/
CREATE DATABASE [MegaFinance]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MegaFinance', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MegaFinance.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MegaFinance_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MegaFinance_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MegaFinance] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MegaFinance].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MegaFinance] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MegaFinance] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MegaFinance] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MegaFinance] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MegaFinance] SET ARITHABORT OFF 
GO
ALTER DATABASE [MegaFinance] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MegaFinance] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MegaFinance] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MegaFinance] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MegaFinance] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MegaFinance] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MegaFinance] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MegaFinance] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MegaFinance] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MegaFinance] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MegaFinance] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MegaFinance] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MegaFinance] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MegaFinance] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MegaFinance] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MegaFinance] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MegaFinance] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MegaFinance] SET RECOVERY FULL 
GO
ALTER DATABASE [MegaFinance] SET  MULTI_USER 
GO
ALTER DATABASE [MegaFinance] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MegaFinance] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MegaFinance] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MegaFinance] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MegaFinance] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MegaFinance] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MegaFinance', N'ON'
GO
ALTER DATABASE [MegaFinance] SET QUERY_STORE = ON
GO
ALTER DATABASE [MegaFinance] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MegaFinance]
GO
/****** Object:  Table [dbo].[ms_storage_location]    Script Date: 11/14/2023 9:53:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ms_storage_location](
	[location_id] [int] IDENTITY(1,1) NOT NULL,
	[location_name] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[location_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ms_user]    Script Date: 11/14/2023 9:53:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ms_user](
	[user_id] [bigint] IDENTITY(1,1) NOT NULL,
	[user_name] [varchar](20) NULL,
	[password] [varchar](50) NULL,
	[is_active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tr_bpkb]    Script Date: 11/14/2023 9:53:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tr_bpkb](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[agreement_number] [varchar](100) NULL,
	[bpkb_no] [varchar](100) NULL,
	[branch_id] [varchar](10) NULL,
	[bpkb_date] [datetime] NULL,
	[faktur_no] [varchar](100) NULL,
	[faktur_date] [datetime] NULL,
	[location_id] [int] NULL,
	[police_no] [varchar](20) NULL,
	[bpkb_date_in] [datetime] NULL,
	[created_by] [varchar](20) NULL,
	[created_on] [datetime] NULL,
	[last_updated_by] [varchar](20) NULL,
	[last_updated_on] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ms_storage_location] ON 

INSERT [dbo].[ms_storage_location] ([location_id], [location_name]) VALUES (1, N'Jakarta')
INSERT [dbo].[ms_storage_location] ([location_id], [location_name]) VALUES (2, N'Bekasi')
INSERT [dbo].[ms_storage_location] ([location_id], [location_name]) VALUES (3, N'Bandung')
SET IDENTITY_INSERT [dbo].[ms_storage_location] OFF
GO
SET IDENTITY_INSERT [dbo].[ms_user] ON 

INSERT [dbo].[ms_user] ([user_id], [user_name], [password], [is_active]) VALUES (1, N'jhonUmiro', N'admin1*', 1)
INSERT [dbo].[ms_user] ([user_id], [user_name], [password], [is_active]) VALUES (2, N'trisNatan', N'admin2@', 1)
INSERT [dbo].[ms_user] ([user_id], [user_name], [password], [is_active]) VALUES (3, N'hugoRess', N'admin3#', 1)
SET IDENTITY_INSERT [dbo].[ms_user] OFF
GO
SET IDENTITY_INSERT [dbo].[tr_bpkb] ON 

INSERT [dbo].[tr_bpkb] ([id], [agreement_number], [bpkb_no], [branch_id], [bpkb_date], [faktur_no], [faktur_date], [location_id], [police_no], [bpkb_date_in], [created_by], [created_on], [last_updated_by], [last_updated_on]) VALUES (1, N'3333333333', N'33334', N'4343', CAST(N'2023-11-14T21:38:00.000' AS DateTime), N'3232', CAST(N'2023-11-14T21:38:00.000' AS DateTime), 1, N'ewe', CAST(N'2023-11-14T21:38:00.000' AS DateTime), N'jhonUmiro', CAST(N'2023-11-14T21:38:28.477' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[tr_bpkb] OFF
GO
ALTER TABLE [dbo].[tr_bpkb]  WITH CHECK ADD FOREIGN KEY([location_id])
REFERENCES [dbo].[ms_storage_location] ([location_id])
GO
USE [master]
GO
ALTER DATABASE [MegaFinance] SET  READ_WRITE 
GO
