CREATE DATABASE mvc_capas;

USE [mvc_capas]
GO

CREATE TABLE [dbo].[Permisos](
	[id_permiso] [int] NOT NULL PRIMARY KEY,
	[permiso] [varchar](50) NOT NULL) 

CREATE TABLE [dbo].[Permisos_asociados_roles](
	[id_permiso] [int] NOT NULL,
	[id_rol] [nvarchar](128) NOT NULL,
	PRIMARY KEY(id_permiso, id_rol))

ALTER TABLE [dbo].[Permisos_asociados_roles]  WITH CHECK ADD FOREIGN KEY([id_permiso])
REFERENCES [dbo].[Permisos] ([id_permiso])
GO

ALTER TABLE [dbo].[Permisos_asociados_roles]  WITH CHECK ADD FOREIGN KEY([id_rol])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO

CREATE TABLE [dbo].[Persona](
	[nombre] [varchar](20) NOT NULL,
	[apellido1] [varchar](20) NOT NULL,
	[apellido2] [varchar](20) NULL,
	[cedula] [varchar](11) NOT NULL PRIMARY KEY,
	[id] [nvarchar](128) NULL) 

ALTER TABLE [dbo].[Persona]  WITH CHECK ADD FOREIGN KEY([id])
REFERENCES [dbo].[AspNetUsers] ([Id]) 
GO

CREATE TABLE Cuenta(
numero varchar(20) not null PRIMARY KEY,
cedula varchar(11) FOREIGN KEY REFERENCES Persona(cedula),
tipo varchar(30),
saldo int,
cuentaDefault bit)