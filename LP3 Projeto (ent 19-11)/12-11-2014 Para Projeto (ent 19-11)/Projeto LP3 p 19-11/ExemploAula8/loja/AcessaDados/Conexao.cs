using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

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
