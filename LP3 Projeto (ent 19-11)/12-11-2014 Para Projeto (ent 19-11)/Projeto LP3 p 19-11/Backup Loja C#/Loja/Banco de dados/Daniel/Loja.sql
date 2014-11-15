drop database if exists Loja;
create database if not exists Loja;

use Loja;
-- criando a Tabela de CLIENTES  --

create table Clientes (
codigo int not null auto_increment,
nome varchar (100),
email varchar (100),
telefone varchar (80),

primary key (codigo)
);



-- criando a Tabela de PRODUTOS --
create table Produtos (
codigo int auto_increment not null,
nome varchar (100),
preco decimal (10,2),
estoque int,
primary key (codigo)

);



-- criando a Tabela de VENDAS --
create table Vendas (
codigoVendas int auto_increment not null,
dataVenda datetime,
quantidade int,
faturado bit,
codigoCliente int,
codigoProdutos int,

primary key (codigoVendas),

foreign key (codigoCliente) references Clientes (codigo),
foreign key (codigoProdutos) references Produtos (codigo)
);




-- Clientes
insert into Clientes (nome,email,telefone) values ('Francisco','franco@gmail.com','998765876');
insert into Clientes (nome,email,telefone) values ('Gabriela','gaby@gmail.com','998325556');
insert into Clientes (nome,email,telefone) values ('Jonas','john@hotmail.com','237777669');
insert into Clientes (nome,email,telefone) values ('Natalia','nat@hotmail.com','97899089');
insert into Clientes (nome,email,telefone) values ('Bruna','bruu@hotmail.com','955563389');
insert into Clientes (nome,email,telefone) values ('Joana','jonna@hotmail.com','999088089');


-- Prodtos

insert into produtos (nome,preco,estoque) values (	'Impressora Deskjet HP'	,	499.99	,	200	);
insert into produtos (nome,preco,estoque) values (	'Notebook Asus'	,	1099.99	,	100	);
insert into produtos (nome,preco,estoque) values (	'Mouse USB'	,	49.99	,	2500	);
insert into produtos (nome,preco,estoque) values (	'Pen drive 8GB'	,	49.99	,	800	);
insert into produtos (nome,preco,estoque) values (	'Teclado USB'	,	69.99	,	1000	);
insert into produtos (nome,preco,estoque) values (	'Multifuncional HP'	,	499.99	,	300	);







