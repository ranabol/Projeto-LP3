using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Modelos;

namespace AcessaDados
{
    public class ClientesDAL
    {
        Conexao cx = new Conexao();
        //listagem de filtro
        public DataTable Listagem(string filtro)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                cx.Conectar();
                da.SelectCommand = new MySqlCommand();
                da.SelectCommand.CommandText = "filtro";
                da.SelectCommand.Connection = cx.c;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                //parametros stored
                MySqlParameter pfiltro;
                pfiltro = da.SelectCommand.Parameters.Add("filtro", MySqlDbType.Text);
                pfiltro.Value = filtro;

                da.Fill(dt);
                return dt;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
            finally
            {
                cx.Desconectar();
            }
        }


        public string inserir(string cliente, string telefone, string endereco)
        {
            string sucesso;
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                cx.Conectar();
                da.SelectCommand = new MySqlCommand();
                da.SelectCommand.CommandText = "call inserir(" + cliente + "," + telefone + "," + endereco + ")";
                da.SelectCommand.Connection = cx.c;
                da.SelectCommand.ExecuteNonQuery();

                sucesso = "Inserido com sucesso";
                return sucesso;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
            finally
            {
                cx.Desconectar();
            }
        }

        //metodo de leitura para jogar em texbox
        public MySqlDataReader SelectId(string sql_query)
        {

            try
            {
                MySqlCommand command = new MySqlCommand();
                MySqlDataReader dataReader;
                cx.Conectar();

                command.Connection = cx.c;
                command.CommandText = sql_query;
                dataReader = command.ExecuteReader();
                return dataReader;

            }
            catch (Exception msg)
            {
                return null;
            }
        }


        //metodo de leitura para jogar em texbox
        public MySqlDataReader SelectCampo(string sql_query)
        {

            try
            {
                MySqlCommand command = new MySqlCommand();
                MySqlDataReader dataReader;
                cx.Conectar();

                command.Connection = cx.c;
                command.CommandText = sql_query;
                dataReader = command.ExecuteReader();
                return dataReader;

            }
            catch (Exception msg)
            {
                return null;
            }
        }


        public string Excluir(int Id)
        {
            string sucesso;
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                cx.Conectar();
                da.SelectCommand = new MySqlCommand();
                da.SelectCommand.CommandText = "call deletar(" + Id + ")";
                da.SelectCommand.Connection = cx.c;
                da.SelectCommand.ExecuteNonQuery();

                sucesso = "Excluido com sucesso";
                return sucesso;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
            finally
            {
                cx.Desconectar();
            }
        }

        public string Alterar(string cliente, string telefone, string end, int Id)
        {
            string sucesso;
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                cx.Conectar();
                da.SelectCommand = new MySqlCommand();
                da.SelectCommand.CommandText = "call alterar('" + cliente + "','" + telefone + "','" + end + "','" + Id  + "')";
                da.SelectCommand.Connection = cx.c;
                da.SelectCommand.ExecuteNonQuery();

                sucesso = "Excluido com sucesso";
                return sucesso;
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
            finally
            {
                cx.Desconectar();
            }
        }

        //public DataTable Listagem()
        //{
        //    MySqlDataAdapter da = new MySqlDataAdapter();
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        cx.Conectar();
        //        da.SelectCommand = new MySqlCommand();
        //        da.SelectCommand.CommandText = "seleciona";
        //        da.SelectCommand.Connection = cx.c;
        //        da.SelectCommand.CommandType = CommandType.StoredProcedure;

        //        //parametros stored
        //        //MySqlParameter pfiltro;
        //        //pfiltro = da.SelectCommand.Parameters.Add("filtro", MySqlDbType.Text);
        //        //pfiltro.Value = filtro;

        //        da.Fill(dt);
        //        return dt;
        //    }
        //    catch (Exception x)
        //    {
        //        throw new Exception(x.Message);
        //    }
        //    finally
        //    {
        //        cx.Desconectar();
        //    }
        //}
    }
}
