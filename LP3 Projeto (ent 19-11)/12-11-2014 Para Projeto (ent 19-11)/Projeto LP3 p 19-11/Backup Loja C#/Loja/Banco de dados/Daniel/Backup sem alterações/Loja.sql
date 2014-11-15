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
codigoProduto int,

primary key (codigoVendas),

foreign key (codigoCliente) references Clientes (codigo),
foreign key (codigoProduto) references Produtos (codigo)
);



