USE MASTER
GO
CREATE DATABASE BDBotica
GO
USE BDBotica
GO

CREATE TABLE Cargo(
IDCargo int primary key IDENTITY(1,1),
NomCargo VARCHAR(30) NOT NULL)

CREATE TABLE Categoria(
IDCategoria int primary key IDENTITY(1,1),
NomCategoria varchar(30) not null)

CREATE TABLE Cliente(
IDCliente int primary key IDENTITY(1,1),
DNI char(8) unique not null,
Nombres varchar(50) not null,
Apellidos Varchar(50) not null,
FechaNacimiento Date not null,
Direccion varchar(80),
Telefono char(9),
Correo varchar(30),
Alergias varchar(150))

CREATE TABLE Empleado(
IDEmpleado int primary key IDENTITY(1,1),
DNI char(8) unique not null,
Nombres varchar(50) not null,
Apellidos varchar(50) not null,
Sexo char(1) check(Sexo IN ('F','M')),
FechaNacimiento Date not null,
FechaIngreso Date not null,
Direccion varchar(80),
Telefono char(9),
Estado bit not null,
IDCargo int REFERENCES Cargo(IDCargo))

SELECT name
FROM sys.check_constraints
WHERE parent_object_id = OBJECT_ID('dbo.Empleado');

ALTER TABLE Empleado
DROP CONSTRAINT CK__Empleado__Sexo__2C3393D0;

ALTER TABLE Empleado
ADD CONSTRAINT CK_Empleado_Sexo CHECK (Sexo IN ('F', 'M'));

CREATE TABLE Usuario(
IDUsuario INT PRIMARY KEY IDENTITY(1,1),
Usuario varchar(20) NOT NULL,
Password VARCHAR(20) NOT NULL,
IDEmpleado INT FOREIGN KEY REFERENCES Empleado(IDEmpleado),
Activo BIT NOT NULL)

CREATE TABLE Laboratorio(
IDLaboratorio int primary key IDENTITY(1,1),
NomLaboratorio varchar(80) not null)

CREATE TABLE Lote(
IDLote int primary key IDENTITY(1,1),
Codigo varchar(20) not null,
Descripcion varchar(50) not null,
FechaVencimiento Date not null)

CREATE TABLE Presentacion(
IDPresentacion int primary key IDENTITY(1,1),
NomPresentacion varchar(50) not null)

CREATE TABLE Producto(
IDProducto int primary key IDENTITY(1,1),
CodigoBarras varchar(20) not null,
Descripcion varchar(50) not null,
PrecioCompra decimal(6,2) not null,
PrecioVenta decimal(6,2) not null,
Stock int not null,
IDCategoria INT FOREIGN KEY REFERENCES Categoria(IDCategoria),
IDPresentacion INT FOREIGN KEY REFERENCES Presentacion(IDPresentacion),
IDLaboratorio INT FOREIGN KEY REFERENCES Laboratorio(IDLaboratorio),
IDLote INT FOREIGN KEY REFERENCES Lote(IDLote))

CREATE TABLE Inventario (
InventarioID INT PRIMARY KEY IDENTITY(1,1),
ProductoID INT FOREIGN KEY REFERENCES Producto(IDProducto),
LoteID INT FOREIGN KEY REFERENCES Lote(IDLote),
CantidadActual INT
)

CREATE TABLE Proveedor(
IDProveedor INT PRIMARY KEY IDENTITY(1,1),
RUC CHAR(11) NOT NULL,
RazonSocial VARCHAR(50) NOT NULL,
Direccion VARCHAR(50),
Telefono VARCHAR(9),
Correo VARCHAR(30))

CREATE TABLE Compra(
IDCompra INT PRIMARY KEY IDENTITY(1,1),
Fecha DATETIME NOT NULL,
IDProveedor INT FOREIGN KEY REFERENCES Proveedor(IDProveedor),
Total decimal(9,2) NOT NULL)

CREATE TABLE DetalleCompra(
IDDetalleCompra INT PRIMARY KEY IDENTITY(1,1),
IDCompra INT FOREIGN KEY REFERENCES Compra(IDCompra),
IDProducto INT FOREIGN KEY REFERENCES Producto(IDProducto),
Cantidad INT NOT NULL,
PrecioUnitario decimal(6,2),
Subtotal decimal(6,2))

CREATE TABLE Venta(
IDVenta INT PRIMARY KEY IDENTITY(1,1),
Fecha DATETIME NOT NULL,
IDCliente INT FOREIGN KEY REFERENCES Cliente(IDCliente),
IDEmpleado INT FOREIGN KEY REFERENCES Empleado(IDEmpleado),
Total decimal(9,2) NOT NULL)

CREATE TABLE DetalleVenta(
IDDetalleVenta INT PRIMARY KEY IDENTITY(1,1),
IDVenta INT FOREIGN KEY REFERENCES Venta(IDVenta),
IDProducto INT FOREIGN KEY REFERENCES Producto(IDProducto),
Cantidad INT NOT NULL,
PrecioVenta decimal(6,2),
Descuento decimal(6,2),
Subtotal decimal(6,2))

---------------------------STORED PROCEDURES---------------------------

-------------CATEGORIA----------------
--------------------------------------
CREATE PROC SpInsertarCategoria
@NomCategoria VARCHAR(50)
AS
BEGIN
INSERT INTO Categoria (NomCategoria)
VALUES (@NomCategoria);
END

CREATE PROC SpActualizarCategoria
@IDCategoria INT,
@NomCategoria VARCHAR(50)
AS
BEGIN
UPDATE Categoria
SET NomCategoria = @NomCategoria
WHERE IDCategoria  = @IDCategoria;
END

CREATE PROC SpEliminarCategoria
@IDCategoria INT
AS
BEGIN
DELETE FROM Categoria
WHERE IDCategoria = @IDCategoria;
END

CREATE PROC SpListarCategoria
AS 
BEGIN
SELECT NomCategoria AS 'Categoria'
FROM Categoria
END

CREATE PROC SpBuscarCategoriaDesc
@Descripcion VARCHAR(50)
AS
BEGIN
SELECT NomCategoria AS 'Categoria'
FROM Categoria
WHERE NomCategoria LIKE '%' + @Descripcion + '%'
END

EXEC SpInsertarCategoria  @NomCategoria = 'Medicamentos';
EXEC SpInsertarCategoria  @NomCategoria = 'Higiene Personal';
EXEC SpInsertarCategoria  @NomCategoria = 'Higiene Bucal';
EXEC SpInsertarCategoria  @NomCategoria = 'Infantil';

---------------CARGO------------------
--------------------------------------
CREATE PROCEDURE SpInsertarCargo
@NomCargo VARCHAR(50)
AS
BEGIN
INSERT INTO Cargo(NomCargo)
VALUES (@NomCargo);
END

CREATE PROCEDURE SpActualizarCargo
@IDCargo INT,
@NomCargo VARCHAR(50)
AS
BEGIN
UPDATE Cargo
SET NomCargo = @NomCargo
WHERE IDCargo = @IDCargo;
END

CREATE PROCEDURE SpEliminarCargo
@IDCargo INT
AS
BEGIN
DELETE FROM Cargo
WHERE IDCargo = @IDCargo;
END

CREATE PROCEDURE SpListadoCargo
AS
BEGIN
SELECT NomCargo as 'Cargo'
FROM Cargo;
END

CREATE PROCEDURE SpBusquedaCargo
@Descripcion VARCHAR(50)
AS
BEGIN
SELECT NomCargo as 'Cargo'
FROM CARGO
WHERE NomCargo LIKE '%'+@Descripcion+'%';
END

EXEC SpInsertarCargo  @NomCargo = 'Administrador';
EXEC SpInsertarCargo  @NomCargo = 'Usuario';

--------------EMPLEADO----------------
--------------------------------------

CREATE PROCEDURE SpInsertarEmpleado
@Dni CHAR(8),
@Nombres VARCHAR(50),
@Apellidos VARCHAR(50),
@Sexo CHAR(1),
@FechaNacimiento DATE,
@FechaIngreso DATE,
@Direccion VARCHAR(80),
@Telefono CHAR(9),
@Estado BIT,
@IDCargo INT
AS
BEGIN
INSERT INTO Empleado (DNI,Nombres,Apellidos,Sexo,FechaNacimiento,FechaIngreso,Direccion,Telefono,Estado,IDCargo)
VALUES (@Dni,@Nombres,@Apellidos,@Sexo,@FechaNacimiento,@FechaIngreso,@Direccion,@Telefono,@Estado,@IDCargo);
END

CREATE PROCEDURE SpActualizarEmpleado
@Dni CHAR(8),
@Nombres VARCHAR(50),
@Apellidos VARCHAR(50),
@Sexo CHAR(1),
@FechaNacimiento DATE,
@FechaIngreso DATE,
@Direccion VARCHAR(80),
@Telefono CHAR(9),
@Estado BIT,
@IDCargo INT,
@IDEmpleado INT
AS
BEGIN
UPDATE Empleado
SET
Dni = @DNI,
Nombres = @Nombres,
Apellidos = @Apellidos,
Sexo = @Sexo,
FechaNacimiento = @FechaNacimiento,
FechaIngreso = @FechaIngreso,
Direccion = @Direccion,
Telefono = @Telefono,
Estado = @Estado,
IDCargo = @IDCargo
WHERE IDEmpleado = @IDEmpleado;
END

CREATE PROCEDURE SpEliminarEmpleado
@IDEmpleado INT
AS
BEGIN
DELETE FROM Empleado
WHERE IDEmpleado = @IDEmpleado;
END

CREATE PROCEDURE SpListarEmpleado
AS
BEGIN
SELECT IDEmpleado, DNI, Nombres, Apellidos, Sexo, FechaNacimiento, FechaIngreso, Cargo.Nomcargo
FROM Empleado INNER JOIN Cargo
ON Cargo.IDCargo = Empleado.IDCargo
WHERE Estado = 1
END

CREATE PROCEDURE SpListarComboCargo
AS
BEGIN
SELECT NomCargo AS 'Cargo'
FROM Cargo
END

CREATE PROCEDURE SpBuscarEmpNombre
@Nombres VARCHAR(50)
AS
BEGIN
SELECT IDEmpleado, DNI, Nombres, Apellidos, Sexo, FechaNacimiento, FechaIngreso, Cargo.Nomcargo
FROM Empleado INNER JOIN Cargo
ON Cargo.IDCargo = Empleado.IDCargo
WHERE Estado = 1 AND Nombres = @Nombres
END

CREATE PROCEDURE SpBuscarEmpDNI
@Dni VARCHAR(50)
AS
BEGIN
SELECT IDEmpleado, DNI, Nombres, Apellidos, Sexo, FechaNacimiento, FechaIngreso, Cargo.Nomcargo
FROM Empleado INNER JOIN Cargo
ON Cargo.IDCargo = Empleado.IDCargo
WHERE Estado = 1 AND DNI = @Dni
END

EXEC SpInsertarEmpleado @Dni = '47859614',@Nombres='Ana',@Apellidos='Jimenez Leiva',@Sexo='F',@FechaNacimiento='1999-08-02',@FechaIngreso='2024-09-09',@Direccion='Av Las Flores N° 145 Urb Jazmines - Trujillo',@Telefono='986574283',@Estado=1,@IDCargo=1 ;
EXEC SpInsertarEmpleado @Dni = '78451296',@Nombres='Juan',@Apellidos='Perez Mendez',@Sexo='M',@FechaNacimiento='1998-05-12',@FechaIngreso='2024-10-11',@Direccion='Av Ciro Alegria N° 247 Urb La Villa - Trujillo',@Telefono='914587254',@Estado=1,@IDCargo=2 ;

--------------USUARIO----------------
--------------------------------------

CREATE PROCEDURE SpLogin
@Usuario varchar(20),
@Password VARCHAR(20)
AS
BEGIN
SELECT Usuario, Password
FROM Usuario
WHERE Usuario= @Usuario AND Password=@Password
END

CREATE PROCEDURE SpInsertarUsuario
@Usuario VARCHAR(20),
@Password VARCHAR(20),
@IDEmpleado INT,
@Estado BIT
AS
BEGIN
INSERT INTO Usuario(Usuario,Password,IDEmpleado,Estado)
VALUES(@Usuario,@Password,@IDEmpleado,@Estado)
END

EXEC SpInsertarUsuario @Usuario='anajim', @Password='123456',@IDEmpleado=5,@Estado=1;
SELECT * FROM USUARIO

----------------LABORATORIO---------------------

CREATE PROCEDURE SpInsertarLaboratorio
@NomLab varchar(80)
AS
BEGIN
INSERT INTO Laboratorio(NomLaboratorio)
VALUES(@NomLab)
END

EXEC SpInsertarLaboratorio @NomLab = 'Portugal'
EXEC SpInsertarLaboratorio @NomLab = 'Bago'
EXEC SpInsertarLaboratorio @NomLab = 'La Roche Posay'

CREATE PROCEDURE SpActualizarLaboratorio
@IDLab INT,
@NomLab varchar(80)
AS
BEGIN
UPDATE Laboratorio
SET NomLaboratorio = @NomLab
WHERE IDLaboratorio = @IDLab;
END

CREATE PROCEDURE SpEliminarLaboratorio
@IDLab INT 
AS
BEGIN
DELETE FROM Laboratorio
WHERE IDLaboratorio = @IDLab;
END

CREATE PROCEDURE SpListarLaboratorio
AS
BEGIN
SELECT IDLaboratorio, NomLaboratorio
FROM Laboratorio;
END

CREATE PROCEDURE SpBuscarLaboratorio
@NomLab varchar(80)
AS
BEGIN
SELECT IDLaboratorio, NomLaboratorio
FROM Laboratorio
WHERE NomLaboratorio LIKE '%' + @NomLab + '%';
END

----------------------CLIENTE--------------------------

CREATE PROCEDURE SpInsertarCliente
@DNI char(8),
@Nombres varchar(50),
@Apellidos Varchar(50),
@FechaNacimiento Date,
@Direccion varchar(80),
@Telefono char(9),
@Correo varchar(30),
@Alergias varchar(150)
AS
BEGIN
INSERT INTO Cliente (DNI,Nombres,Apellidos,FechaNacimiento,Direccion,Telefono,Correo,Alergias)
VALUES(@DNI,@Nombres,@Apellidos,@FechaNacimiento,@Direccion,@Telefono,@Correo,@Alergias)
END

EXEC SpInsertarCliente @DNI='71307429',@Nombres = 'Maria',@Apellidos = 'Mendoza Zafra',@FechaNacimiento = '1998-04-22',
@Direccion = 'Calle Las Olas N° 155 Urb La Zona - Trujillo',@Telefono='985632471',@Correo = 'hola@gmail.com',@Alergias = 'Ninguna'

CREATE PROCEDURE SpActualizarCliente
@IDCliente INT,
@DNI char(8),
@Nombres varchar(50),
@Apellidos Varchar(50),
@FechaNacimiento Date,
@Direccion varchar(80),
@Telefono char(9),
@Correo varchar(30),
@Alergias varchar(150)
AS
BEGIN
UPDATE Cliente
SET
DNI = @DNI,
Nombres = @Nombres,
Apellidos = @Apellidos,
FechaNacimiento = @FechaNacimiento,
Direccion = @Direccion,
Telefono = @Telefono,
Correo = @Correo,
Alergias = @Alergias
WHERE IDCliente = @IDCliente;
END

CREATE PROCEDURE SpEliminarCliente
@IDCliente INT
AS
BEGIN
DELETE FROM Cliente
WHERE IDCliente = @IDCliente;
END

CREATE PROCEDURE SpListarCliente
AS
BEGIN
SELECT DNI,Nombres,Apellidos,FechaNacimiento,Direccion,Telefono,Correo,Alergias
FROM Cliente
END

CREATE PROCEDURE SpBuscarCliApellido
@Apellidos VARCHAR(50)
AS
BEGIN
SELECT DNI,Nombres,Apellidos,FechaNacimiento,Direccion,Telefono,Correo,Alergias
FROM Cliente
WHERE Apellidos = @Apellidos;
END

CREATE PROCEDURE SpBuscarCliDni
@DNI CHAR(8)
AS
BEGIN
SELECT DNI,Nombres,Apellidos,FechaNacimiento,Direccion,Telefono,Correo,Alergias
FROM Cliente
WHERE DNI = @DNI;
END