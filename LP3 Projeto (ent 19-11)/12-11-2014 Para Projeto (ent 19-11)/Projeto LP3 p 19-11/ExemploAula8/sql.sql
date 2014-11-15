DELIMITER $$

CREATE PROCEDURE inserir(in Cliente varchar(100), Telefone varchar(25), Endereco varchar(100))
begin
	INSERT INTO cliente(cliente,telefone,endereco)VALUES(Cliente,Telefone,Endereco);
end $$

DELIMITER ;

DELIMITER $$

CREATE PROCEDURE deletar(in Id int)
begin
	DELETE FROM cliente WHERE idcliente = Id;
end $$

DELIMITER ;

DELIMITER $$

CREATE PROCEDURE alterar(in Cliente varchar(100), Telefone varchar(25), Endereco varchar(100), Id int)
begin
	update cliente set cliente = Cliente, telefone = Telefone, endereco = Endereco where idcliente = Id;
end $$

DELIMITER ;

select  * from cliente