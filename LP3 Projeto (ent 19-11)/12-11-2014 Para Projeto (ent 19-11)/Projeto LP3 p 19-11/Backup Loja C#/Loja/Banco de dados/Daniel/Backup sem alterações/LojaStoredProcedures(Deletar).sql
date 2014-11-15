-- mudando o delimiter para $$, para poder usar ';' na criação dos procedures. 
DELIMITER $$

use Loja$$

-- caso a procedure exista, apagamos a atual e criamos uma nova --
drop procedure if exists sp_excluirClientes$$

-- Criando procedure Alterar Cliente  --
create procedure sp_excluirClientes (
in codigo int )
BEGIN

delete from Clientes where codigo = @codigo;


END $$
     
DELIMITER ;