USE [master]
GO
/****** Object:  Database [db_ControlGastos]    Script Date: 17/8/2020 17:06:19 ******/
CREATE DATABASE [db_ControlGastos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_ControlGastos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\db_ControlGastos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_ControlGastos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\db_ControlGastos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [db_ControlGastos] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_ControlGastos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_ControlGastos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_ControlGastos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_ControlGastos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_ControlGastos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_ControlGastos] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_ControlGastos] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [db_ControlGastos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_ControlGastos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_ControlGastos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_ControlGastos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_ControlGastos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_ControlGastos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_ControlGastos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_ControlGastos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_ControlGastos] SET  ENABLE_BROKER 
GO
ALTER DATABASE [db_ControlGastos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_ControlGastos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_ControlGastos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_ControlGastos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_ControlGastos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_ControlGastos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_ControlGastos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_ControlGastos] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_ControlGastos] SET  MULTI_USER 
GO
ALTER DATABASE [db_ControlGastos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_ControlGastos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_ControlGastos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_ControlGastos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_ControlGastos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_ControlGastos] SET QUERY_STORE = OFF
GO
USE [db_ControlGastos]
GO
/****** Object:  Table [dbo].[tbl_Concepto]    Script Date: 17/8/2020 17:06:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Concepto](
	[idConcepto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[tipoTransaccion] [bit] NOT NULL,
	[fechaCreacion] [datetime] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[eliminado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idConcepto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Cuenta]    Script Date: 17/8/2020 17:06:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Cuenta](
	[idCuenta] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[fechaCreacion] [datetime] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[eliminado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Transaccion]    Script Date: 17/8/2020 17:06:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Transaccion](
	[idTransaccion] [int] IDENTITY(1,1) NOT NULL,
	[monto] [decimal](8, 2) NOT NULL,
	[fechaTransaccion] [datetime] NOT NULL,
	[idCuenta] [int] NOT NULL,
	[idConcepto] [int] NOT NULL,
	[idTransaccionRef] [bit] NULL,
	[eliminado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idTransaccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Usuario]    Script Date: 17/8/2020 17:06:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nombreCompleto] [varchar](50) NOT NULL,
	[correoElectronico] [varchar](50) NOT NULL,
	[contrasena] [varchar](30) NOT NULL,
	[eliminado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_Concepto] ADD  DEFAULT (getdate()) FOR [fechaCreacion]
GO
ALTER TABLE [dbo].[tbl_Concepto] ADD  DEFAULT ((0)) FOR [eliminado]
GO
ALTER TABLE [dbo].[tbl_Cuenta] ADD  DEFAULT (getdate()) FOR [fechaCreacion]
GO
ALTER TABLE [dbo].[tbl_Cuenta] ADD  DEFAULT ((0)) FOR [eliminado]
GO
ALTER TABLE [dbo].[tbl_Transaccion] ADD  DEFAULT (getdate()) FOR [fechaTransaccion]
GO
ALTER TABLE [dbo].[tbl_Transaccion] ADD  DEFAULT ((0)) FOR [eliminado]
GO
ALTER TABLE [dbo].[tbl_Usuario] ADD  DEFAULT ((0)) FOR [eliminado]
GO
ALTER TABLE [dbo].[tbl_Concepto]  WITH CHECK ADD FOREIGN KEY([idUsuario])
REFERENCES [dbo].[tbl_Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[tbl_Cuenta]  WITH CHECK ADD FOREIGN KEY([idUsuario])
REFERENCES [dbo].[tbl_Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[tbl_Transaccion]  WITH CHECK ADD FOREIGN KEY([idConcepto])
REFERENCES [dbo].[tbl_Concepto] ([idConcepto])
GO
ALTER TABLE [dbo].[tbl_Transaccion]  WITH CHECK ADD FOREIGN KEY([idCuenta])
REFERENCES [dbo].[tbl_Cuenta] ([idCuenta])
GO
USE [master]
GO
ALTER DATABASE [db_ControlGastos] SET  READ_WRITE 
GO
