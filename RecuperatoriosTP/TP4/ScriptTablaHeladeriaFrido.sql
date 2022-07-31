CREATE DATABASE HELADERIA_FRIDO
GO
USE HELADERIA_FRIDO
GO
CREATE TABLE Clientes(
Id int identity primary key,
Nombre varchar(20) not null,
Apellido varchar(20) not null,
Saldo float not null,
Puntos int not null,
)
insert into Clientes (Nombre, Apellido, Saldo, Puntos) values
('Jennifer','Guglielmino',2000,140),
('Juan','Perez',500,4),
('Maria','Flores',600,400),
('Pablo','Ramirez',1000,500),
('Juana','Gomez',1200,20),
('Florencia','Hernandez',3000,140)
GO
CREATE TABLE Productos(
Id int identity primary key,
Nombre varchar(20) not null,
Descripcion varchar(20) not null,
Cantidad int not null,
Precio float not null,
Peso float not null,
Id_TipoProducto int not null,
CantidadDeProductoPorUnidad int not null
Eliminado bit not null
)
insert into Productos(Nombre, Descripcion, Cantidad, Precio, Peso, Id_TipoProducto, CantidadDeProductoPorUnidad) values
('Casatta','Sabor chocolate',100,200,200,1,1, 0),
('Almendrado','Crocante mani',100,200,200,1, 1,0),
('Integral','Supercongelada',300,600,600,3, 8,0),
('Sundae frutal','Mix frutas',200,300,300,2,4,0),
('Super fridito','Leche fortificada',400,300,300,2,3,0),
('Jamon','Precocida',400,500,500,3,8,0),
('Delicia','Sabor crema',200,600, 600,1,10,0),
('Crocantino','Baño de chocolate',200,600, 600,1,10,0)

GO 
CREATE TABLE Ventas(
Id int identity primary key,
Id_Cliente int not null,
Id_Producto int not null,
CantidadProducto int not null,
)

GO 
CREATE TABLE TipoProductos(
Id int identity primary key,
Id_TipoProducto int not null,
Nombre varchar(20) not null
)
insert into TipoProductos(Id_TipoProducto, Nombre) values
(1,'Postre'),
(2,'Helado'),
(3,'Pizza_Congelada')

--No pude agregar las claves foraneas
--Error: Could not create constraint or index. See previous errors.(por si me lo pueden explicar)

--ALTER TABLE Productos
--ADD FOREIGN KEY (Id_TipoProductos) REFERENCES TipoProductos(Id_TipoProducto);

--ALTER TABLE Ventas
--ADD FOREIGN KEY (Id_Producto) REFERENCES Productos(Id);

--ALTER TABLE Ventas
--ADD FOREIGN KEY (Id_Cliente) REFERENCES Clientes(Id);