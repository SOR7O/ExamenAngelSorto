USE tempdb
GO

IF NOT EXISTS(SELECT * FROM sys.databases WHERE [name] = 'ERP')
	BEGIN
		CREATE DATABASE ERP
	END
GO

USE ERP
GO

CREATE SCHEMA Usuarios
GO

CREATE TABLE Usuarios.usuario(
nombres NVARCHAR(50) NOT NULL,
apellidos NVARCHAR(50),
nombreUsuario NVARCHAR(30)NOT NULL,
contraseña NVARCHAR(30)NOT NULL,
correoElectronico NVARCHAR(30),
fechaCreacion TIMESTAMP ,
ultimaConexion TIMESTAMP NOT NULL,
tipoUsuario NVARCHAR(30),
estado NVARCHAR(30) DEFAULT 'ACTIVO/A' NULL,
)
GO
