-- mudando o delimiter para $$, para poder usar ';' na criação dos procedures. 
DELIMITER $$

use Loja$$

-- caso a procedure exista, apagamos a atual e criamos uma nova --
drop procedure if exists sp_AlterarClientes$$

-- Criando procedure Alterar Cliente  --
create procedure sp_alterarClientes (
in codigo int,
in nome varchar(100), 
in email varchar(100), 
in telefone varchar(100) )

BEGIN

update Clientes 
set 
nome = @nome, 
email = @email, 
telefone = @telefone
where
codigo = @codigo;


END $$

DELIMITER ;
