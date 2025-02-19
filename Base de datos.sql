USE [master]
GO
/****** Object:  Database [Gestion_inventario_libreria]    Script Date: 9/1/2025 22:05:42 ******/
CREATE DATABASE [Gestion_inventario_libreria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Gestion_inventario_libreria', FILENAME = N'C:\Users\HP\Gestion_inventario_libreria.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Gestion_inventario_libreria_log', FILENAME = N'C:\Users\HP\Gestion_inventario_libreria_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Gestion_inventario_libreria] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Gestion_inventario_libreria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Gestion_inventario_libreria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET ARITHABORT OFF 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET  MULTI_USER 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Gestion_inventario_libreria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Gestion_inventario_libreria] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Gestion_inventario_libreria] SET QUERY_STORE = OFF
GO
USE [Gestion_inventario_libreria]
GO
/****** Object:  Table [dbo].[Autores]    Script Date: 9/1/2025 22:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autores](
	[id_autor] [int] NOT NULL,
	[nombre_autor] [nvarchar](255) NOT NULL,
	[apellido_autor] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Autores] PRIMARY KEY CLUSTERED 
(
	[id_autor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 9/1/2025 22:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[id_inventario] [int] NOT NULL,
	[id_libro] [int] NOT NULL,
	[stock_disponible] [int] NOT NULL,
	[precio] [numeric](10, 2) NOT NULL,
 CONSTRAINT [PK_Inventario] PRIMARY KEY CLUSTERED 
(
	[id_inventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libros]    Script Date: 9/1/2025 22:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libros](
	[id_libro] [int] NOT NULL,
	[titulo] [nvarchar](255) NOT NULL,
	[id_autor] [int] NOT NULL,
	[genero] [nvarchar](100) NULL,
 CONSTRAINT [PK_Libros] PRIMARY KEY CLUSTERED 
(
	[id_libro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Autores] ([id_autor], [nombre_autor], [apellido_autor]) VALUES (1, N'Stephen ', N'King')
INSERT [dbo].[Autores] ([id_autor], [nombre_autor], [apellido_autor]) VALUES (2, N'J.K.', N'Rowling')
INSERT [dbo].[Autores] ([id_autor], [nombre_autor], [apellido_autor]) VALUES (3, N'Jane', N'Austen')
INSERT [dbo].[Autores] ([id_autor], [nombre_autor], [apellido_autor]) VALUES (4, N'George', N'Orwell')
GO
INSERT [dbo].[Inventario] ([id_inventario], [id_libro], [stock_disponible], [precio]) VALUES (1, 1, 20, CAST(40.00 AS Numeric(10, 2)))
INSERT [dbo].[Inventario] ([id_inventario], [id_libro], [stock_disponible], [precio]) VALUES (2, 2, 15, CAST(20.00 AS Numeric(10, 2)))
INSERT [dbo].[Inventario] ([id_inventario], [id_libro], [stock_disponible], [precio]) VALUES (3, 3, 10, CAST(15.00 AS Numeric(10, 2)))
INSERT [dbo].[Inventario] ([id_inventario], [id_libro], [stock_disponible], [precio]) VALUES (4, 4, 8, CAST(12.00 AS Numeric(10, 2)))
GO
INSERT [dbo].[Libros] ([id_libro], [titulo], [id_autor], [genero]) VALUES (1, N'Misery', 1, N'Terror')
INSERT [dbo].[Libros] ([id_libro], [titulo], [id_autor], [genero]) VALUES (2, N'Harry Potter y la piedra filosofal', 2, N'Fantasía')
INSERT [dbo].[Libros] ([id_libro], [titulo], [id_autor], [genero]) VALUES (3, N'Orgullo y prejuicio', 3, N'Romance')
INSERT [dbo].[Libros] ([id_libro], [titulo], [id_autor], [genero]) VALUES (4, N'1984', 4, N'Ciencia ficción')
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Libros] FOREIGN KEY([id_libro])
REFERENCES [dbo].[Libros] ([id_libro])
GO
ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Libros]
GO
ALTER TABLE [dbo].[Libros]  WITH CHECK ADD  CONSTRAINT [FK_Libros_Autores] FOREIGN KEY([id_autor])
REFERENCES [dbo].[Autores] ([id_autor])
GO
ALTER TABLE [dbo].[Libros] CHECK CONSTRAINT [FK_Libros_Autores]
GO
USE [master]
GO
ALTER DATABASE [Gestion_inventario_libreria] SET  READ_WRITE 
GO
