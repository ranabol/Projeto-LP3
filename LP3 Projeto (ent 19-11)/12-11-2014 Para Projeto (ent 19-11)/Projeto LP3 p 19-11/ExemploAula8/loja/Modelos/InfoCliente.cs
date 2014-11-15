using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelos
{
    public class InfoCliente
    {
        private int idcliente;
        private string cliente;
        private string telefone;
        private string endereco;

        public int Idcliente
        {
            get { return idcliente; }
            set { idcliente = value; }
        }
        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }
    }
}
