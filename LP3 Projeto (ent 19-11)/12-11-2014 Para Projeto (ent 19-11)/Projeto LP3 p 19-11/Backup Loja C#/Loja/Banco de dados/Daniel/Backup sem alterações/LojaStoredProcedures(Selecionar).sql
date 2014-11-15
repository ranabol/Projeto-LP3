-- mudando o delimiter para $$, para poder usar ';' na criação dos procedures. 
DELIMITER $$

use Loja$$

-- caso a procedure exista, apagamos a atual e criamos uma nova --
drop procedure if exists sp_SelecionarClientes$$

-- Criando procedure Selecionar Cliente  --
create procedure sp_selecionarClientes (
in nome varchar(100)
)

BEGIN

select * from Clientes 
limit nome;

END $$
DELIMITER ;