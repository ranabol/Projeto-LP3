using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelos;
using AcessaDados;
using MySql.Data.MySqlClient;
using System.Data;

namespace RegraNegocio
{
    public class ClientesBLL
    {
        public DataTable Listagem(string filtro)
        {
            ClientesDAL obj = new ClientesDAL();
            return obj.Listagem(filtro);
        }


        public string inserir(string cliente, string telefone, string endereco)
        {
            ClientesDAL obj = new ClientesDAL();
            return obj.inserir(cliente, telefone, endereco);
        }


        public MySqlDataReader SelectId(string sql_query)
        {
            ClientesDAL obj = new ClientesDAL();
            return obj.SelectId(sql_query);
        }

        public MySqlDataReader SelectCampo(string sql_query)
        {
            ClientesDAL obj = new ClientesDAL();
            return obj.SelectCampo(sql_query);
        }

        public string Excluir(int Id)
        {
            ClientesDAL obj = new ClientesDAL();
            return obj.Excluir(Id);
        }

        public string Alterar(string cliente, string telefone, string end, int Id)
        {
            ClientesDAL obj = new ClientesDAL();
            return obj.Alterar(cliente, telefone, end, Id);
        }
    }
}
