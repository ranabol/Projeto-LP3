using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Loja.BLL;

namespace Loja.UIWindows
{
    public partial class ClientesForm : Form
    {
        public ClientesForm()
        {
            InitializeComponent();
        }
        public void AtualizaGrid()
        {
            // Comunicação com a Camada BLL
            ClientesBLL obj = new ClientesBLL();
            clientesDataGridView.DataSource = obj.Listagem();
            // Atualizando os objetos TextBox
            codigoTextBox.Text = clientesDataGridView[0,
            clientesDataGridView.CurrentRow.Index].Value.ToString();
            nomeTextBox.Text = clientesDataGridView[1,
            clientesDataGridView.CurrentRow.Index].Value.ToString();
            emailTextBox.Text = clientesDataGridView[2,
            clientesDataGridView.CurrentRow.Index].Value.ToString();
            telefoneTextBox.Text = clientesDataGridView[3,
            clientesDataGridView.CurrentRow.Index].Value.ToString();
        }
        private void ClientesForm_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
            nomeTextBox.Focus();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            codigoTextBox.Text = "";
            nomeTextBox.Text = "";
            emailTextBox.Text = "";
            telefoneTextBox.Text = "";
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
        {
            ClienteInformation cliente = new ClienteInformation();
cliente.Nome = nomeTextBox.Text;
cliente.Email = emailTextBox.Text;
cliente.Telefone = telefoneTextBox.Text;
ClientesBLL obj = new ClientesBLL();
obj.Incluir(cliente);
MessageBox.Show("O cliente foi incluído com sucesso!");
codigoTextBox.Text = Convert.ToString(cliente.Codigo);
AtualizaGrid();
}
catch (Exception ex)
{
MessageBox.Show("Erro: " + ex.Message);
}
- Dê um duplo clique no botão Alterar para codificarmos o evento click;
- Dentro do evento clique do botão Alterar, copie e cole o código abaixo:
if (codigoTextBox.Text.Length == 0)
{
MessageBox.Show("Um cliente deve ser selecionado para alteração.");
}
else
try
{
ClienteInformation cliente = new ClienteInformation();
cliente.Codigo = int.Parse(codigoTextBox.Text);
cliente.Nome = nomeTextBox.Text;
cliente.Email = emailTextBox.Text;
cliente.Telefone = telefoneTextBox.Text;
ClientesBLL obj = new ClientesBLL();
obj.Alterar(cliente);
MessageBox.Show("O cliente foi alterado com sucesso!");
AtualizaGrid();
}
catch (Exception ex)
{
MessageBox.Show("Erro: " + ex.Message);
}
        }
    }
}