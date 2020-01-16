create database reportdb;

create table cliente(
	id int identity(1,1) primary key,
	nombre varchar(50),
)

create table factura(
	id int identity(1,1) primary key,
	numero_factura varchar(20) unique,
	id_cliente int references cliente(id),
	fecha datetime default CURRENT_TIMESTAMP,
)

create table producto(
	id int identity(1,1) primary key,
	codigo varchar(20),
	descripcion varchar(30),
	precio money,
)

create table producto_factura(
	id_producto int references producto(id),
	id_factura int references factura(id),
	cantidad int,
)
go

create procedure lineas_factura
@id_factura int
as
begin
	select p.codigo, p.descripcion, pf.cantidad, 
	pf.cantidad *p.precio as total  from producto p
	inner join producto_factura pf on p.id = pf.id_producto
	where pf.id_factura = @id_factura
end
go

create procedure calcular_factura
@id_factura int
as
begin
	select sum(pf.cantidad * p.precio) as subtotal,
	sum(pf.cantidad * p.precio) * 0.15 as iva,
	sum(pf.cantidad * p.precio) * 1.15 as total,
	c.nombre as nombre_cliente, f.fecha, f.numero_factura
	from factura f
	inner join producto_factura pf on pf.id_factura = f.id
	inner join producto p on p.id = pf.id_producto
	inner join cliente c on c.id =f.id_cliente
	where f.id = @id_factura
	group by c.nombre, f.fecha, f.numero_factura
end

insert into cliente values('Juan Perez');
insert into producto values ('0001', 'Item 1', 10.00);
insert into producto values ('0002', 'Item 2', 5.00);
insert into producto values ('0003', 'Item 3', 50.00);
insert into producto values ('0004', 'Item 44', 50.00);
insert into factura(numero_factura, id_cliente) values ('FACT001', 1);
insert into producto_factura values (1, 1, 10);
insert into producto_factura values (2, 1, 5);
insert into producto_factura values (3, 1, 2);
insert into producto_factura values (5, 1, 2);





