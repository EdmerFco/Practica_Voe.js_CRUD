create database CRUD_Vue

use CRUD_Vue


---Crear la base de datos 
Create table Usuario
(
idUsuario int primary key not null, 
Nombre varchar(60) not null,
ApellidoP varchar(60) not null,
ApellidoM varchar(60) not null,
FNacimiento date  not null,
Curp Char(18) not null,
Correo Varchar(60) not null,
Telefono nchar(10) NOT null
);


---Crear usuario 
Create procedure Agregar 
(
@idUsuario int, 
@Nombre varchar(60) ,
@ApellidoP varchar(60) ,
@ApellidoM varchar(60) ,
@FNacimiento date  ,
@Curp Char(18) ,
@Correo Varchar(60) ,
@Telefono nchar(10)
)
AS
BEGIN 
Insert Into [db].[Usuario] 
(
Nombre,
ApellidoP,
ApellidoM,
FNacimiento,
Curp,
Correo,
Telefono
)
Values 
(
@Nombre,
@ApellidoP,
@ApellidoM,
@FNacimiento,
@Curp,
@Correo,
@Telefono
)
end 
go 

----Actualizar 
Create procedure Actualizar 
(
@idUsuario int, 
@Nombre varchar(60) ,
@ApellidoP varchar(60) ,
@ApellidoM varchar(60) ,
@FNacimiento date  ,
@Curp Char(18) ,
@Correo Varchar(60) ,
@Telefono nchar(10)
)
AS
BEGIN 
update [db].[Usuario] set

Nombre        = @Nombre,
ApellidoP	  = @ApellidoP,
ApellidoM	  = @ApellidoM,
FNacimiento	  = @FNacimiento,
Curp		  = @Curp,
Correo		  = @Correo,
Telefono	  = @Telefono,
where idUsuario = @idUsuario
SELECT @@ROWCOUNT
end 
go 


---Consultar todos

Create procedure Consultar
as
begin 
Select * from Usuario
end
go 

---Consultar uno 
create procedure ConsultarUno
(
@id int 
)
as 
begin 
Select * from Usuario
where idUsuario = @id
end 
go 

--Eliminar 

Create procedure Eliminar 
(
@id int
)
as
begin
Delete from Usuario
where idUsuario = @id
end 
go 
