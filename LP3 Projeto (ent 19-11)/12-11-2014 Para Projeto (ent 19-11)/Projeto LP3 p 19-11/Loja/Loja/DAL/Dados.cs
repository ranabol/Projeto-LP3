using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Loja.DAL
{
    /// <summary>
    /// COMPLETAR CLASSE - EXEMPLO EM Aula 8 - Classe Conexão - Obs: Modificado para Classe Pública
    /// </summary>
    public class Dados
    {
        //Tirado aspas simples de localhost,loja,root,valor do pwd
        public static string StringDeConexao = "Server=localhost;Database=loja;Uid=root;Pwd=";
        public MySqlConnection c = new MySqlConnection(StringDeConexao);
        public string Status = "";

        public void Conectar()
        {
            //string s = "Server='localhost';Database='loja';Uid='root';Pwd=''";
            c.ConnectionString = StringDeConexao;
            c.Open();
            Status = "Conexão aberta!!";
        }

        public void Desconectar()
        {
            c.Close();
            Status = "Conexão Fechada!!";
        }
    }
}

/*       //static = Não precisará instanciar a string em outras classes
       public static string StringDeConexao

   {

get

{

//return "server=Raul-HP\\SQLEXPRESS;database=Loja;user=Raul-HP\\Raul" ;
    
   return "server=localhost;database=Loja;user=root";

}

}

   }
}
 * */
/*
namespace AcessaDados
{
    class Conexao
    {
        public MySqlConnection c = new MySqlConnection();
        public string Status = "";

        public void Conectar()
        {
            string s = "Server='localhost';Database='loja';Uid='root';Pwd=''";
            c.ConnectionString = s;
            c.Open();
            Status = "Conexão aberta!!";
        }

        public void Desconectar()
        {
            c.Close();
            Status = "Conexão Fechada!!";
        }
    }
}

*/