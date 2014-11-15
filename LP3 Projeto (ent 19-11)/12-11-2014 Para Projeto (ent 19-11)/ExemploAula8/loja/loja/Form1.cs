using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Modelos;
using AcessaDados;
using RegraNegocio;
using MySql.Data.MySqlClient;

namespace loja
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //caregaform
        private void Form1_Load_1(object sender, EventArgs e)
        {
            btnInserir.Enabled = false;
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            ClientesBLL obj = new ClientesBLL();
            dgvClientes.DataSource = obj.Listagem(txtFiltro.Text);
            try
            {
                txtCod.Text = dgvClientes[0, dgvClientes.CurrentRow.Index].Value.ToString();
                txtCliente.Text = dgvClientes[1, dgvClientes.CurrentRow.Index].Value.ToString();
                txtTel.Text = dgvClientes[2, dgvClientes.CurrentRow.Index].Value.ToString();
                txtEnd.Text = dgvClientes[3, dgvClientes.CurrentRow.Index].Value.ToString();

                format();
            }
            catch
            {
                txtCod.Text = " ";
                txtCliente.Text = " ";
                txtEnd.Text = " ";
                txtTel.Text = " ";
            }
        }


        private void format()
        {
            dgvClientes.Columns[0].Width = 50;
            dgvClientes.Columns[1].Width = 150;
            dgvClientes.Columns[2].Width = 80;
            dgvClientes.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvClientes.ScrollBars = ScrollBars.Vertical;
            dgvClientes.RowHeadersVisible = false;
        }

       

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //botao liberar
        private void btnLiberar_Click_1(object sender, EventArgs e)
        {
            txtCod.Text = " ";
            txtCliente.Text = " ";
            txtEnd.Text = " ";
            txtTel.Text = " ";
            txtFiltro.Text = "";

            btnInserir.Enabled = true;
            txtCod.Enabled = false;

            string sql = "SHOW TABLE STATUS LIKE 'cliente'";

            MySqlDataReader dr;

            ClientesBLL obj = new ClientesBLL();
            int id;

            dr = obj.SelectId(sql);

            if (dr.Read())
            {
                id = Convert.ToInt32(dr["Auto_increment"].ToString());
                txtCod.Text = id.ToString();
            }
            txtCliente.Focus();
        }


        //botao inserir
        private void btnInserir_Click_1(object sender, EventArgs e)
        {
            string cliente;
            string telefone;
            string endereco;

            cliente = "'";
            cliente += txtCliente.Text;
            cliente += "'";

            telefone = "'";
            telefone += txtTel.Text;
            telefone += "'";

            endereco = "'";
            endereco += txtEnd.Text;
            endereco += "'";

            ClientesBLL obj = new ClientesBLL();
            lblStatus.Text = obj.inserir(cliente, telefone, endereco);
            AtualizarGrid();
        }


        //botao filtrar
        private void btnFiltrar_Click_1(object sender, EventArgs e)
        {
            Fitragem();
        }

        public void Fitragem()
        {
            ClientesBLL obj = new ClientesBLL();
            dgvClientes.DataSource = obj.Listagem(txtFiltro.Text);

            try
            {
                txtCod.Text = dgvClientes[0, dgvClientes.CurrentRow.Index].Value.ToString();
                txtCliente.Text = dgvClientes[1, dgvClientes.CurrentRow.Index].Value.ToString();
                txtTel.Text = dgvClientes[2, dgvClientes.CurrentRow.Index].Value.ToString();
                txtEnd.Text = dgvClientes[3, dgvClientes.CurrentRow.Index].Value.ToString();

                format();
            }
            catch
            {
                txtCod.Text = " ";
                txtCliente.Text = " ";
                txtEnd.Text = " ";
                txtTel.Text = " ";
            }

            format();
        }


        //eveto ceel enter
        private void dgvClientes_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MySqlDataReader dr;

            ClientesBLL obj = new ClientesBLL();
            int id;
            string sql = "SELECT * FROM cliente";

            dr = obj.SelectCampo(sql);

            if (dr.Read())
            {
                txtCod.Text = dgvClientes[0, dgvClientes.CurrentRow.Index].Value.ToString();
                txtCliente.Text = dgvClientes[1, dgvClientes.CurrentRow.Index].Value.ToString();
                txtTel.Text = dgvClientes[2, dgvClientes.CurrentRow.Index].Value.ToString();
                txtEnd.Text = dgvClientes[3, dgvClientes.CurrentRow.Index].Value.ToString();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int id;

            id = Convert.ToInt32(txtCod.Text.ToString());

            if (MessageBox.Show("Deseja Realmente Excluir?", "Warning", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                ClientesBLL obj = new ClientesBLL();
                lblStatus.Text = obj.Excluir(id);
                AtualizarGrid();
            }
            else
            {
                MessageBox.Show("Operação cancelada...", "Warning");
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            string cliente;
            string telefone;
            string end;
            int id;

            cliente = txtCliente.Text;
            telefone = txtTel.Text;
            end = txtEnd.Text;
            id = Convert.ToInt32(txtCod.Text);

            ClientesBLL obj = new ClientesBLL();
            lblStatus.Text = obj.Alterar(cliente, telefone, end, id);
            AtualizarGrid();
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            Fitragem();
        }

        
    }
}
