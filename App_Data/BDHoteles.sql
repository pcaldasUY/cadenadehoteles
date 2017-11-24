USE master
go

IF exists (SELECT * FROM sysdatabases WHERE NAME='BDHoteles')
BEGIN
	DROP DATABASE BDHoteles
END
go

CREATE DATABASE BDHoteles
ON
(
	NAME=BDHoteles,
	FILENAME='C:\Users\pc\BDHoteles.mdf'
)
go

USE BDHoteles
go

CREATE TABLE Hotel(
	rut BIGINT PRIMARY KEY,
	nombre VARCHAR(50),
	direccion VARCHAR(50),
	ciudad VARCHAR(50),
	desayuno VARCHAR(50),
	piscinaClimatizada BIT,
	piscinaExterna BIT,
	solarium BIT
)
go

CREATE TABLE Telefonos(
	rut BIGINT,
	nroTelefono BIGINT,
	PRIMARY KEY(rut, nroTelefono),
	FOREIGN KEY (rut) REFERENCES Hotel(rut)
)
go

CREATE TABLE Fotos(
	rut BIGINT,
	imagen VARCHAR(100),
	FOREIGN KEY (rut) REFERENCES Hotel(rut)
)
go

CREATE TABLE Usuario(
	cedula BIGINT PRIMARY KEY,
	nombre VARCHAR(50),
	password VARCHAR(15)
)
go

CREATE TABLE Administrador(
	cedula BIGINT PRIMARY KEY,
	cargo VARCHAR(50),
	FOREIGN KEY (cedula) REFERENCES Usuario(cedula)
)
go

CREATE TABLE Registrado(
	cedula BIGINT PRIMARY KEY,
	sexo BIT,
	tarjeta BIGINT,
	FOREIGN KEY (cedula) REFERENCES Usuario(cedula)
)
go

CREATE TABLE Tipos(
	codigo int identity (1,1) not null primary key,
	tipo varchar(50),
	minima int,
	maxima int
)
go

CREATE TABLE Habitacion(
	rut BIGINT,	
	numero INT,
	piso INT,
	balcon BIT,
	precio FLOAT,
	codigo INT,
	disponible BIT,
	PRIMARY KEY (rut, numero),
	FOREIGN KEY (rut) REFERENCES Hotel(rut),
	FOREIGN KEY (codigo) REFERENCES Tipos(codigo)
)
go

CREATE TABLE Promociones(
	nro int identity (1,1) not null primary key,
	fechaInicio datetime,
	fechaFin datetime,
	dias int,
	pasajeros int,
	titulo varchar(50),
	comentario varchar(50),
	precio float,
	rut bigint,
	codigo int,
	foreign key (rut) references hotel(rut),
	foreign key (codigo) references tipos(codigo)
)
go

create table Cotizacion(
	fecha datetime not null primary key,
	dolar float,
	euro float
)
go

CREATE TABLE Reserva(
	id INT IDENTITY (1,1) Not null,
	fechaInicio DATETIME,
	fechaFin DATETIME,
	precio FLOAT,
	moneda VARCHAR(50),
	cancelada BIT,
	cedula BIGINT,
	rut BIGINT,
	numero INT,
	PRIMARY KEY (id, rut, numero),
	FOREIGN KEY (cedula) REFERENCES Registrado (cedula),
	FOREIGN KEY (rut, numero) REFERENCES Habitacion (rut, numero)
)
go

INSERT INTO Hotel VALUES (214000111,'Grand Hotel Bristol','Via Aurelia Orientale, 369','Repallo (Italia)','Incluido',1,1,1)
INSERT INTO Hotel VALUES (214000112,'NH Gran Hotel Provincial','Av Peralta Ramos 2502','Mar del Plata (Argentina)','Incluido',1,0,0)
INSERT INTO Hotel VALUES (214000113,'Hotel Almenara','Avenida Almenara, s/n','Sotogrande-Cádiz (España)','No incluido',0,0,1)
go

insert into tipos values ('doble twin',1,2)
insert into tipos values ('doble matrimonial',2,4)
go

INSERT INTO Habitacion VALUES (214000111,1,1,1,214,1,1)
INSERT INTO Habitacion VALUES (214000111,2,1,1,214,2,1)
INSERT INTO Habitacion VALUES (214000111,3,1,0,124,1,1)
INSERT INTO Habitacion VALUES (214000112,1,1,1,265,2,1)
INSERT INTO Habitacion VALUES (214000112,2,1,0,214,1,0)

go

INSERT INTO Usuario VALUES (1566588,'Juan Acosta','111ab')
INSERT INTO Usuario VALUES (3894777,'Pablo Ramirez','rg894')
INSERT INTO Usuario VALUES (4899547,'Diego Perez','wt564')
INSERT INTO Usuario VALUES (8765124,'Ana Lopez','69rf')
INSERT INTO Usuario VALUES (7586912,'Maria Rodriguez','222mr')
INSERT INTO Usuario VALUES (7412586,'Jose Fernandez','741jf')
go

insert into Administrador values (7586912,'Jefe de personal')
insert into Administrador values (7412586,'auxiliar')
go

insert into Registrado values (1566588,1,1111)
insert into Registrado values (3894777,1,1122)
insert into Registrado values (4899547,1,2222)
insert into Registrado values (8765124,0,2285)
go

INSERT INTO Telefonos (rut,nroTelefono) VALUES (214000111,2195869)
INSERT INTO Telefonos (rut,nroTelefono) VALUES (214000111,2407070)
INSERT INTO Telefonos (rut,nroTelefono) VALUES (214000112,5117956)
INSERT INTO Telefonos (rut,nroTelefono) VALUES (214000113,2184817)
go

INSERT INTO Fotos (rut,imagen) VALUES (214000111,'~/imagenes/bristol01.jpg')
INSERT INTO Fotos (rut,imagen) VALUES (214000111,'~/imagenes/bristol02.jpg')
INSERT INTO Fotos (rut,imagen) VALUES (214000111,'~/imagenes/bristol03.jpg')
INSERT INTO Fotos (rut,imagen) VALUES (214000112,'~/imagenes/provincial01.jpg')
INSERT INTO Fotos (rut,imagen) VALUES (214000112,'~/imagenes/provincial02.jpg')
go

insert into promociones values ('20/02/09','25/02/09',4,2,'semana de carnaval','Disfrute la semana de carnaval en el Bristol',500,214000111,2)
insert into promociones values ('03/04/09','12/04/09',4,3,'semana de turismo', 'Disfrute la seman de turismo en el Bristol',600,214000111,2)
go

insert into cotizacion (fecha, dolar, euro) values ('02/03/09',24.20,30.43)
insert into cotizacion (fecha, dolar, euro) values ('03/03/09',24.35,30.58)
insert into cotizacion (fecha, dolar, euro) values ('04/03/09',24.45,30.81)
go

INSERT INTO Reserva (fechaInicio,fechaFin,precio,moneda,cancelada,cedula,rut,numero) VALUES ('15/08/08','20/08/08',156,'dolar',1,1566588,214000111,2)
INSERT INTO Reserva (fechaInicio,fechaFin,precio,moneda,cancelada,cedula,rut,numero) VALUES ('20/09/08','30/09/08',196,'dolar',1,3894777,214000111,1)
INSERT INTO Reserva (fechaInicio,fechaFin,precio,moneda,cancelada,cedula,rut,numero) VALUES ('20/10/08','15/11/08',250,'dolar',0,3894777,214000111,1)
go




			

