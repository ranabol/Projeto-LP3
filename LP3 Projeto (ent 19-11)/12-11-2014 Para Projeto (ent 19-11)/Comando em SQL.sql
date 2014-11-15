-- criando banco
drop database if exists loja;
create database loja;

-- utilizando o banco
use loja;

-- criando tabelas
create table clientes 
(
	codigo int auto_increment not null,
	nome varchar(100),
	email varchar(100),
	telefone varchar(80),
	primary key (codigo)
);

create table produtos
(
	codigo int auto_increment not null,
	nome varchar(100),
	preco decimal(10,2),
	estoque int,
	primary key (codigo)
);

create table vendas
(
	codigo int auto_increment not null,
	`data` date,
	quantidade int,
	faturado bit,
	codigocliente int,
	codigoproduto int,
	primary key (codigo),
	foreign key (codigocliente) REFERENCES clientes(codigo),
	foreign key (codigoproduto) REFERENCES Produtos(codigo)
);

-- inserindo dados

-- clientes
insert into clientes(nome, email, telefone) values ('Carlos Camacho','email@provedor.com.br','(11) 9 9999-5555');
insert into clientes(nome, email, telefone) values ('Felipe Reis','felipereiss@outlook.com','(11) 9 5356-5889');
insert into clientes(nome, email, telefone) values ('Aline Uzita','alinete.doidinha@hotmail.com','(11) 9 8659-2359');
insert into clientes(nome, email, telefone) values ('Victor Senna','victinho.arrasador@hotmail.com','(11) 9 8521-4687');
insert into clientes(nome, email, telefone) values ('Giovanne Barios','giovanne.lol@hotmail.com','(11) 9 4685-2165');
insert into clientes(nome, email, telefone) values ('Giovana Rechid','giovana.linda@outlook.com','(11) 9 5641-8291');
insert into clientes(nome, email, telefone) values ('Luciene Prof','luci.prof.foda@bra.edu.br','(11) 9 1234-6579');
-- Produtos
insert into Produtos(nome, preco, estoque) values ('Computador Pentium Dual Core',1500.00,15);
insert into Produtos(nome, preco, estoque) values ('Impressora Deskjet HP',599.90,150);
insert into Produtos(nome, preco, estoque) values ('Notebook Lenovo G400',1379.99,10);
insert into Produtos(nome, preco, estoque) values ('Calculadora HP C2000',150.50,90);
insert into Produtos(nome, preco, estoque) values ('Celular Samsung S5',1700.00,50);
insert into Produtos(nome, preco, estoque) values ('Hiphone S8',2900.00,20);
-- Vendas
insert into Vendas(`data`, quantidade, faturado, codigocliente, codigoproduto) values ('2014-10-29', 25, 1, 1, 1);
insert into Vendas(`data`, quantidade, faturado, codigocliente, codigoproduto) values ('2014-10-30', 20, 0, 2, 3);
insert into Vendas(`data`, quantidade, faturado, codigocliente, codigoproduto) values ('2014-11-09', 15, 1, 3, 2);
insert into Vendas(`data`, quantidade, faturado, codigocliente, codigoproduto) values ('2014-12-29', 10, 0, 4, 4);
insert into Vendas(`data`, quantidade, faturado, codigocliente, codigoproduto) values ('2014-12-02', 5, 1, 5, 5);
insert into Vendas(`data`, quantidade, faturado, codigocliente, codigoproduto) values ('2015-01-09', 1, 0, 6, 6);


-- Procedures

-- Essa procedure irá inserir um cliente na tabela 'clientes', passando por parâmetro os valores de nome, email e telefone.
-- Utilizando 'in' que irá pegar os dados.
DELIMITER ||

create procedure insere_cliente (in nome varchar(100), in email varchar(100), in telefone varchar(80))
BEGIN

	insert into clientes(`nome`, `email`, `telefone`) values (nome, email, telefone);

END;
||

DELIMITER ;

-- Teste
call insere_cliente('aline','bla','40');
select * from clientes;

-- --------------------------------------------------------------------------------------------------------------------------

-- Esta procedure quando chamada altera um cliente na tabela 'Cliente'. Passando por parâmetros os valores a ser atualizados.
DELIMITER !!

create procedure altera_cliente (in cod INT, in nome varchar(100), in email varchar(100), in telefone varchar(80))
BEGIN
	
	update clientes set `nome` = nome, `email` = email, `telefone` = telefone where codigo = cod;

END;
!!
DELIMITER ;

-- Teste
select * from clientes;
call altera_cliente(1,'aline','bla','40');

-- ---------------------------------------------------------------------------------------------------------------------------

-- Nesse procedure irá excluir um cliente da tabela 'Cliente', porém antes irá ser excluido de vendas pois o codigo de cliente é chave estrangeira.
DELIMITER $$

create procedure exclui_cliente (in cod INT)
BEGIN

	delete from vendas where codigo = cod; 
	delete from clientes where codigo = cod;

END;
$$

DELIMITER ;

-- Teste
call exclui_cliente(1);

-- -----------------------------------------------------------------------------------------------------------------------------

-- Nesta procedure quando chamada irá selecionar um cliente, através do nome, email ou pelo telefone, exibindo todos os dados daquele cliente
DELIMITER &&

create procedure seleciona_cliente (in filtro varchar(100))
BEGIN
	
	if filtro is null then select * from clientes;
	else select * from clientes where nome like  concat('%',filtro,'%')  or email like concat('%',filtro,'%') or telefone like concat('%',filtro,'%');

	end if;
END;
&&

DELIMITER ;

-- Teste
call seleciona_cliente('aline');




