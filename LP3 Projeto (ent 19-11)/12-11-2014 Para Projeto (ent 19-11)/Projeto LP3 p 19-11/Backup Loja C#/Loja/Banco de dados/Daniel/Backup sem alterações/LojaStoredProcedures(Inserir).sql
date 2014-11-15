-- mudando o delimiter para $$, para poder usar ';' na criação dos procedures. 
DELIMITER $$

use Loja$$

-- caso a procedure exista, apagamos a atual e criamos uma nova --
drop procedure if exists sp_inserirClientes$$


-- Criando procedure Inserir Cliente  --

create procedure sp_inserirClientes (
in codigo int,
in nome varchar(100), 
in email varchar(100), 
in telefone varchar(100) )

BEGIN
-- inicio do corpo da procedure --

set codigo = (select codigo 
			  from Clientes 
              where codigo = codigo);

if codigo is null then set codigo = 1;
insert into Clientes (nome, email, telefone)
values (@nome, @email, @telefone);

else
set codigo = codigo + 1;
insert into Clientes (nome, email, telefone)
values (@nome, @email, @telefone);
end if;

END $$

DELIMITER ;