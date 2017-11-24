USE BDHoteles
go

-- usuarios

-- hace el cambio de clave de cualquier usuario
create procedure cambioPassword
	@ci bigint,
	@clave varchar(50),
	@nuevaClave varchar(50)
as
begin
	IF (NOT EXISTS (SELECT * 
					FROM usuario 
					WHERE @ci=cedula and @clave=password))
		return 0
	ELSE
		update usuario set password=@nuevaClave where @ci=cedula
		if @@error=0
			return 1
		else
			return -1
end
go

---- administrador ----

-- Ve si un administrador ingreso bien la password
create proc claveCorrectaAdministrador
	@ci bigint,
	@clave varchar(15)
as
begin
	IF EXISTS (	SELECT * 
				FROM usuario inner join administrador
				ON Usuario.cedula=Administrador.cedula
				WHERE usuario.cedula=@ci and password=@clave) 
		return 1
	ELSE
		return 0
end
go

-- Es el cambio de clave de un administrador
create proc CambioClaveAdministrador
	@ci bigint,
	@clave varchar(15),
	@nuevaClave varchar(15)
as
begin
	if not exists (	select * 
					from usuario inner join administrador on Usuario.cedula=Administrador.cedula
					where usuario.cedula=@ci and password=@clave) 
		return 0
	update usuario set Password=@nuevaClave where @ci=cedula
	if @@error=0
		return 1
	return -1
end
go

-- Ve si la cedula ingresada es de un administrador
create proc EsAdministrador
	@ci bigint
as
begin
	if exists (select * from administrador where @ci=cedula)
		return 1
	else
		return 0
end
go

-- Da el nombre del administrador
create proc NombreAdministrador
	@ci bigint
as
begin
	select nombre from usuario where @ci=cedula
end
go

-- Agrega un administrador y me devuelve 1 si lo puede agregar, 0 si existe un usuario con esa ci, y -1 si no lo puede agregar
-- asumimos que la password que se va a ingresar es 123456 de primer momento, y el usario va a tener que cambiar luego la misma
create procedure AltaAdministrador
	@ci bigint,
	@nombre varchar(50),
	@cargo varchar(50)
as
begin
	IF (EXISTS (SELECT * 
				FROM usuario 
				WHERE @ci=cedula))
		return 0
	ELSE
		begin
			declare @error int
			begin tran
				insert usuario (cedula,nombre,password) values (@ci,@nombre,'123456')
				set @error=@@error
				insert administrador (cedula,cargo) values (@ci,@cargo)
				set @error=@@error+@error
				if (@error=0)
					begin
						commit tran
						return 1
					end
				else
					begin
						commit tran
						return -1
					end
			end
end
go

-- Da de baja un administrador y me devuelve 1 si lo puede hacer, 0 si no existe un administrador con esa ci, y -1 si no lo puede hacer
create procedure BajaAdministrador
	@ci bigint
as
begin
	if (not exists (select * from  administrador where @ci=cedula))
		return 0
	else
		begin
			declare @error int
			begin tran
				delete from administrador where cedula=@ci
				set @error=@@error
				delete from usuario where cedula=@ci
				set @error=@@error+@error
				if (@error=0)
					begin
						commit tran
						return 1
					end
				else
					begin
						rollback tran
						return -1
					end
			end
end
go

-- modificacionAdministrador lo que hace es modificar ya sea el cargo o el nombre,la cedula es imposible hacerlo
-- modifica los datos de un administrador y me devuelve 1 si lo puede hacer, 0 si no existe un administrador con esa ci, y -1 si no lo puede hacer
create procedure ModificacionAdministrador
	@ci bigint,
	@nombre varchar(50),
	@cargo varchar(50)
as
begin
	if (not exists (select * from administrador where @ci=cedula))
		return 0
	else
	begin
			declare @error int
			begin tran
				update usuario set nombre=@nombre where @ci=cedula
				set @error=@@error
				update administrador set cargo=@cargo where @ci=cedula
				set @error=@@error+@error
				if (@error=0)
					begin
						commit tran
						return 1
					end
				else
					begin
						rollback tran
						return -1
					end
		end	
end
go

--listado de los datos de administradores
create procedure ListarAdministrador
as
begin
	select u.Cedula,nombre,cargo,password 
	from usuario as u inner join administrador on u.cedula=administrador.cedula
end
go

-- busca los datos de un administrador
create procedure BuscarAdministrador
	@ci bigint
as
begin
	select usuario.Cedula,nombre,cargo,password 
	from usuario inner join administrador on usuario.cedula=administrador.cedula
	where @ci=usuario.cedula
end
go

---- Registrado ----

-- Ve si un registrado ingreso bien la password
create proc claveCorrectaRegistrado
	@ci bigint,
	@clave varchar(15)
as
begin
	if exists (	select * 
				from usuario inner join registrado on Usuario.cedula=Registrado.cedula
				where usuario.cedula=@ci and password=@clave) 
		return 1
	else 
		return 0
end
go

-- Es el cambio de clave de un registrado
create proc CambioClaveRegistrado
	@ci bigint,
	@clave varchar(15),
	@nuevaClave varchar(15)
as
begin
	if not exists (	select * 
					from usuario inner join registrado on Usuario.cedula=Registrado.cedula
					where usuario.cedula=@ci and password=@clave) 
		return 0
	update usuario set Password=@nuevaClave where @ci=cedula
	if @@error=0
		return 1
	return -1
end
go

-- Ve si la cedula ingresada es de un registrado
create proc EsRegistrado
@ci bigint
as
begin
	if exists (select * from Registrado where @ci=cedula)
		return 1
	else
		return 0
end
go

-- Da el nombre del registrado 
create proc NombreRegistrado
	@ci bigint
as
begin
	select nombre from usuario where @ci=cedula
end
go

-- Alta de un registrado
create proc AltaRegistrado
	@ci bigint,
	@nombre varchar(50),
	@password varchar(50),
	@sexo bit,
	@tarjeta bigint
as
begin
	IF (EXISTS (SELECT cedula 
				FROM usuario 
				WHERE @ci=cedula))
		begin
			return 0
		end
	else
		begin
			declare @error int
			begin tran
				insert into usuario (cedula, nombre, password) values (@ci,@nombre,@password)
				set @error=@@error
				insert into registrado (cedula, sexo, tarjeta) values (@ci,@sexo,@tarjeta)
				set @error=@@error+@error
				if (@error=0)
					begin
						commit tran
						return 1
					end
				else
					begin
						rollback tran;
						return -1;
					end
			
		end	
end
go

--listado de los datos de usuarios registrados
create procedure ListarRegistrados
as
begin
	select u.Cedula,nombre,tarjeta,sexo,password 
	from usuario as u inner join registrado on u.cedula=registrado.cedula
end
go

-- Da de baja un registrado, me devuelve 1 si lo puede hacer, 0 si no existe ese registrado con esa ci, y -1 si no lo puede hacer
create procedure BajaRegistrado
	@ci bigint
as
begin
	IF (NOT EXISTS (SELECT * 
					FROM registrado 
					WHERE @ci=cedula))
		return 0
	else
		begin
			declare @error int
			begin tran
				delete from registrado where cedula=@ci
				set @error=@@error
				delete from usuario where cedula=@ci
				set @error=@@error+@error
				if (@error=0)
					begin
						commit tran
						return 1
					end
				else
					begin
						rollback tran
						return -1
					end
			end
end
go

-- modificacionRegistrado lo que hace es modificar ya sea sexo, tarjeta o el nombre,la cedula es imposible hacerlo
-- modifica los datos de un registrado y me devuelve 1 si lo puede hacer, 0 si no existe un registrardo con esa ci, y -1 si no lo puede hacer
create procedure ModificacionRegistrado
	@ci bigint,
	@nombre varchar(50),
	@sexo bit,
	@tarjeta bigint
as
begin
	if (not exists (select * from registrado where @ci=cedula))
		return 0
	else
	begin
			declare @error int
			begin tran
				update usuario set nombre=@nombre where @ci=cedula
				set @error=@@error
				update registrado set sexo=@sexo, tarjeta=@tarjeta where @ci=cedula
				set @error=@@error+@error
				if (@error=0)
					begin
						commit tran
						return 1
					end
				else
					begin
						rollback tran
						return -1
					end
		end	
end
go

-- busca los datos de un registrado
create procedure BuscarRegistrado
	@ci bigint
as
begin
	select usuario.Cedula,nombre,tarjeta,sexo,password 
	from usuario inner join registrado on usuario.cedula=registrado.cedula
	where @ci=usuario.cedula
end
go

-- Hotel

-- carga las fotos del hotel
CREATE PROC CargarFotosHotel
	@rut BIGINT,
	@imagenes VARCHAR(100)
AS
BEGIN
	IF EXISTS(	SELECT rut,imagen
				FROM Fotos
	    		WHERE rut=@rut AND imagen=@imagenes)
	BEGIN
		RETURN 0
	END
	ELSE
	BEGIN
		INSERT INTO Fotos (rut,imagen)VALUES(@rut,@imagenes)
	END
	IF @@ERROR=0
		RETURN 1
	ELSE 
		RETURN -1
END
go

-- carga los telefonos del hotel
CREATE PROC CargarTelefonosHotel
@rut BIGINT,
@Tel BIGINT
AS
BEGIN
	IF EXISTS(	SELECT rut,nroTelefono
				FROM Telefonos
				WHERE rut=@rut AND nroTelefono=@Tel)
	BEGIN
		RETURN 0
	END
	ELSE
	BEGIN
		INSERT INTO Telefonos (rut,nroTelefono) VALUES (@rut,@Tel)
	END
	IF @@ERROR=0
		RETURN 1
	ELSE
		RETURN -1
END
go

-- Hace el alta de un hotel
CREATE PROC AltaDeHotel
	@rut BIGINT,
	@nombre VARCHAR(50),
	@direccion VARCHAR(50),
	@ciudad VARCHAR(50),
	@desayuno VARCHAR(50),
	@piscinaClimatizada BIT,
	@piscinaExterna BIT,
	@solarium BIT
AS
BEGIN
	IF EXISTS (SELECT rut FROM Hotel WHERE @rut=rut)
	BEGIN
		RETURN 0
	END
	ELSE
	BEGIN
		DECLARE @err INT
		BEGIN TRAN
		INSERT Hotel (rut,nombre,direccion,ciudad,desayuno,piscinaClimatizada,piscinaExterna,solarium)
			VALUES (@rut,@nombre,@direccion,@ciudad,@desayuno,@piscinaClimatizada,@piscinaExterna,@solarium)
		SET @err=@@ERROR
		IF (@err=0)
		BEGIN
			COMMIT TRAN
			RETURN 1
		END
		ELSE
		BEGIN
			ROLLBACK TRAN
			RETURN -1
		END
	END
END
go	

-- hace el listado de todos los hoteles
CREATE PROC ListadoDeHoteles
AS
BEGIN
	SELECT * FROM Hotel
END
go

CREATE PROC ListadoDeTelefonos @rut BIGINT
AS
BEGIN
	SELECT nroTelefono FROM Telefonos
	WHERE rut=@rut
END
go

CREATE PROC ListadoDeImagenes @rut BIGINT
AS
BEGIN
	SELECT imagen FROM Fotos
	WHERE rut=@rut
END
go

-- Modifica los datos del hotel
CREATE PROC ModificarDatosDeHotel
	@rut BIGINT,
	@nombre VARCHAR(50),
	@direccion VARCHAR(50),
	@ciudad VARCHAR(50),
	@desayuno VARCHAR(50),
	@piscinaClimatizada BIT,
	@piscinaExterna BIT,
	@solarium BIT
as
begin
	--primero veo si existe algun afiliado con esa ci
	IF Not Exists (	SELECT * 
					FROM Hotel 
					WHERE @rut=rut)
		RETURN 0
	UPDATE Hotel
	SET rut=@rut,
		nombre=@nombre,
		direccion=@direccion,
		ciudad=@ciudad,
		desayuno=@desayuno,
		piscinaClimatizada=@piscinaClimatizada,
		piscinaExterna=@piscinaExterna,
		solarium=@solarium
	WHERE rut=@rut
	RETURN 1	
END
go	

-- busca los datos del hotel dado un rut
create procedure BuscarHotel
@rut bigint
as
begin
	select * from hotel where @rut=rut
end
go
	
-- Tipos

-- agrega un tipo de habitacion
create procedure AgregarTipo
	@tipo varchar(50),
	@minima int,
	@maxima int
as
begin
	if (EXISTS (SELECT * 
				FROM tipos 
				WHERE @tipo=tipo))
	begin
		return 0
	end
	else
		begin
			insert into tipos values (@tipo,@minima,@maxima)
			if @@error=0
				return 1
			else return -1
		end
end
go

-- Lista todos los tipos de habitaciones existentes
create procedure ListarTipo
as
begin
	select * from tipos
end
go

CREATE PROC HabitacionesPorHotel
	@rut BIGINT
AS
BEGIN
	SELECT numero, piso, balcon, precio, disponible
	FROM Hotel Inner Join Habitacion ON Hotel.rut=Habitacion.rut
	WHERE @rut=Habitacion.rut
END
go



-- Dado un codigo me devuelve los datos del tipo
create procedure BuscarTipo
	@codigo bigint
as
begin
	select * from tipos where @codigo=codigo
end
go

-- elimina un tipo de habitación
create procedure EliminarTipo
	@tipo varchar(50)
as
begin
	--veo si no existe un tipo de habitacion con ese nombre
	if (not exists(select * from tipos where @tipo=tipo))
		return 0
	-- veo si existe una habitacion con ese tipo 
	if (EXISTS (SELECT * 
				FROM habitacion inner join tipos on habitacion.codigo=tipos.codigo and tipo=@tipo))
		return -1
	else
		delete from tipos where @tipo=tipo
		if @@error=0
			return 1
		else
			return -2
end
go

-- modificarTipo varia solo la cantidad minima o maxima de pasajeros pero no modifica su nombre
create procedure ModificarTipo
	@tipo varchar(50),
	@min int,
	@max int
as
begin
	IF (NOT EXISTS (SELECT * 
					FROM tipos 
					WHERE @tipo=tipo))
		RETURN 0
	update tipos set minima=@min , maxima=@max where @tipo=tipo
	if @@error=0
		return 1
	else
		return -1
end
go 

create procedure BuscarTipoPorNombre
	@tipo varchar(50)
as
begin
	select * from tipos where @tipo=tipo
end
go

-- Habitaciones

-- agrega una habitacion	
create procedure AgregarHabitacion
	@numero int,
	@piso int,
	@balcon bit,
	@precio float,
	@rut bigint,
	@codigo int,
	@disponible BIT
as
begin
	if (exists (select * from habitacion where @numero=numero and @rut=rut))
	begin
		return 0
	end
	else
		begin
			insert into Habitacion values (@rut,@numero,@piso,@balcon,@precio,@codigo,1)
			IF(@@Error=0)
			BEGIN
				RETURN 1
			END
			ELSE
			BEGIN
				RETURN -1;
			END	
		end
end
go

-- lista las habitaciones que tiene un hotel
create procedure ListarHabitacionesDeHotel
	@rut bigint
as
begin
	select * from habitacion where @rut=rut
end
go

CREATE PROC ListarDiponibilidadesPorHotel
	@rut BIGINT
AS
BEGIN
	SELECT nombre, tipo, numero, piso, balcon, precio, disponible
	FROM Hotel Inner Join (Habitacion Inner Join Tipos ON Habitacion.codigo=Tipos.codigo)
	ON Hotel.rut=Habitacion.rut And @rut=Habitacion.rut And disponible=1
END
go

--EXEC ListarDiponibilidadesPorHotel 214000111
--go

-- obtengo el precio de una determinada habitacion
create procedure ObtengoPrecio
	@rut bigint,
	@numero int
as
begin
	select precio from habitacion where @rut=rut and @numero=numero
end
go

-- promociones

-- agrega una promocion
create procedure AgregarPromociones
	@fechaInicio datetime,
	@fechaFin datetime,
	@dias int,
	@pasajeros int,
	@titulo varchar(50),
	@comentario varchar(50),
	@precio float,
	@rut bigint,
	@codigo int
as
begin
	IF (NOT EXISTS (SELECT rut 
					FROM hotel 
					WHERE rut=@rut))
		RETURN -1
	ELSE	
	IF (NOT EXISTS (SELECT codigo 
					FROM tipos 
					WHERE codigo=@codigo))
		RETURN -2
	ELSE
		BEGIN
			INSERT INTO promociones values (@fechaInicio,@fechaFin,@dias,@pasajeros,@titulo,@comentario,@precio,@rut,@codigo)
			IF (@@error=0)
				RETURN 1
			ELSE
				RETURN 0
		END
end
go

-- lista las promociones vigentes, se considera que una promocion esta vigente, si bien pudo haber empezado pero no ha terminado  
create procedure promocionesVigentes
as
begin
	select * from promociones where fechaFin>getdate()
end
go

-- cotizaciones

-- alta cotizacion
create procedure AltaCotizacion
	@fecha datetime,
	@dolar float,
	@euro float
as
BEGIN
	IF (NOT EXISTS (SELECT * 
					FROM cotizacion 
					WHERE @fecha=fecha))
		begin
			insert into cotizacion values (@fecha,@dolar,@euro)
			if (@@error=0)
				begin
					return 1
				end
			else
				begin
					return -1
				end
		end
	ELSE
		BEGIN
			update cotizacion set dolar=@dolar,euro=@euro where fecha=@fecha
			IF (@@error=0)
				RETURN 1
			ELSE
				RETURN -1
		END			
END
go

-- busca los datos de un cotizacion
create procedure BuscarCotizacion
	@fecha datetime
as
begin
	select * 
	from cotizacion
	where @fecha=fecha
end
go
		

--listado de todas las cotizaciones
create procedure ListarCotizacion
as
begin
	select *
	from cotizacion
end
go

--listado de todas las cotizaciones entre fechas
create procedure ListarCotizacionEntreFechas
	@fechaIni datetime,
	@fechaFin datetime
as
begin
	select *
	from cotizacion
	where fecha between @fechaini and @fechafin
end
go


-- busca la cotizacion mas proxima al dia de hoy
create procedure BuscarCotizacionActual
as
begin
	select top 1 * from cotizacion order by fecha desc
end
go

USE master