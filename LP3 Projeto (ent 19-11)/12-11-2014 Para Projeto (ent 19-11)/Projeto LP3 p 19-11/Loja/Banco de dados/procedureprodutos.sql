-- procedure para inserir produtos 
DELIMITER ||
create procedure insere_produto (in nome varchar(100), in preco decimal(10,2), in estoque int)
BEGIN

	insert into produtos( `nome`, `preco`,`estoque`) values (nome, preco, estoque);

END;
||

DELIMITER ;


-- procedure para alterar produto
DELIMITER !!

create procedure altera_produto (in cod int, in nome varchar(100), in preco decimal(10,2), in estoque int)
BEGIN
	
	update produtos set `nome` = nome, `preco` = preco, `estoque`=estoque where codigo = cod;

END;
!!
DELIMITER ;


-- procedure para excluir um produto.
-- drop procedure exclui_produto;
DELIMITER $$

create procedure exclui_produto (in cod INT)
BEGIN
	
	delete from vendas where vendas.codigo=cod;
	delete from produtos where produtos.codigo=cod;
	
END;
$$

DELIMITER ;




-- seleciona produto para vizualização
DELIMITER &&

create procedure seleciona_produto (in filtro varchar(100))
BEGIN
	
	if filtro is null then select * from produtos;
	else select * from produtos where nome like  concat('%',filtro,'%') or codigo like concat('%',filtro,'%');

	end if;
END;
&&

DELIMITER ;



