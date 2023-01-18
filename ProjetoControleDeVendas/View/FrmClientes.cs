using ProjetoControleDeVendas.DAO;
using ProjetoControleDeVendas.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleDeVendas.View {
    public partial class FrmCliente : Form {
        public FrmCliente() {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void btnSalvar_Click(object sender, EventArgs e) {

            var cliente = new Cliente();
            
            cliente.Nome = txtNome.Text;
            cliente.RG = txtRG.Text;
            cliente.CPF = txtCPF.Text;
            cliente.Email = txtEmail.Text;
            cliente.Telefone = txtTelefone.Text;
            cliente.Celular = txtCelular.Text;
            cliente.Endereco = txtEndereco.Text;
            cliente.Numero = int.Parse(txtNumero.Text);
            cliente.Complemento = txtComplemento.Text;
            cliente.Bairro = txtBairro.Text;
            cliente.Cidade = txtCidade.Text;
            cliente.Estado = comboUF.Text;
            cliente.CEP = txtCEP.Text;

            ClienteDAO dao = new ClienteDAO();
            dao.CadastrarCliente(cliente);
            tabelaCliente.DataSource = dao.ListarClientes();

        }

        private void FrmClientes_Load(object sender, EventArgs e) {

            ClienteDAO dao = new ClienteDAO();

            tabelaCliente.DataSource = dao.ListarClientes();
        }

        private void tabelaCliente_CellClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void tabelaCliente_DoubleClick(object sender, EventArgs e) {
            
            var campos = txtCodigo.Text = tabelaCliente.CurrentRow.Cells[0].Value.ToString();

                txtNome.Text = tabelaCliente.CurrentRow.Cells[1].Value.ToString();
                txtRG.Text = tabelaCliente.CurrentRow.Cells[2].Value.ToString();
                txtCPF.Text = tabelaCliente.CurrentRow.Cells[3].Value.ToString();
                txtEmail.Text = tabelaCliente.CurrentRow.Cells[4].Value.ToString();
                txtTelefone.Text= tabelaCliente.CurrentRow.Cells[5].Value.ToString();
                txtCelular.Text = tabelaCliente.CurrentRow.Cells[6].Value.ToString();
                txtCEP.Text = tabelaCliente.CurrentRow.Cells[7].Value.ToString();
                txtEndereco.Text = tabelaCliente.CurrentRow.Cells[8].Value.ToString();
                txtNumero.Text = tabelaCliente.CurrentRow.Cells[9].Value.ToString();
                txtComplemento.Text = tabelaCliente.CurrentRow.Cells[10].Value.ToString();
                txtBairro.Text = tabelaCliente.CurrentRow.Cells[11].Value.ToString();
                txtCidade.Text = tabelaCliente.CurrentRow.Cells[12].Value.ToString();
                comboUF.Text = tabelaCliente.CurrentRow.Cells[13].Value.ToString();

            tabClientes.SelectedTab = tabPage1;
        }

        private void btnExcluir_Click(object sender, EventArgs e) {

            Cliente cliente = new Cliente();
            cliente.Codigo = int.Parse(txtCodigo.Text);

            ClienteDAO clienteDAO = new ClienteDAO();
            clienteDAO.ExcluirCliente(cliente);

            tabelaCliente.DataSource = clienteDAO.ListarClientes();
        }

        private void btnEditar_Click(object sender, EventArgs e) {
            
            var cliente = new Cliente();

            cliente.Nome = txtNome.Text;
            cliente.RG = txtRG.Text;
            cliente.CPF = txtCPF.Text;
            cliente.Email = txtEmail.Text;
            cliente.Telefone = txtTelefone.Text;
            cliente.Celular = txtCelular.Text;
            cliente.Endereco = txtEndereco.Text;
            cliente.Numero = int.Parse(txtNumero.Text);
            cliente.Complemento = txtComplemento.Text;
            cliente.Bairro = txtBairro.Text;
            cliente.Cidade = txtCidade.Text;
            cliente.Estado = comboUF.Text;
            cliente.CEP = txtCEP.Text;
            cliente.Codigo = int.Parse(txtCodigo.Text);

            ClienteDAO dao = new ClienteDAO();
            dao.AlterarCliente(cliente);
            tabelaCliente.DataSource = dao.ListarClientes();
        }

        private void btnPesquisar_Click(object sender, EventArgs e) {

            var nome = txtPesquisa.Text;

            ClienteDAO dao = new ClienteDAO();

            tabelaCliente.DataSource = dao.BuscarClientesPorNome(nome);

            if (tabelaCliente.Rows.Count == 0) {
                tabelaCliente.DataSource = dao.ListarClientes();
            }
        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e) {
            
            string nome = "%" + txtPesquisa.Text + "%";

            ClienteDAO dao = new ClienteDAO();

            tabelaCliente.DataSource = dao.ListarClientesPorNome(nome);

        }

        private void btnConsultar_Click(object sender, EventArgs e) {

            try {
                string cep = txtCEP.Text;

                var xml = $"https://viacep.com.br/ws/{cep}/xml/";

                DataSet dados = new DataSet();
                dados.ReadXml(xml);

                txtEndereco.Text = dados.Tables[0].Rows[0]["logradouro"].ToString();
                txtBairro.Text = dados.Tables[0].Rows[0]["bairro"].ToString();
                txtComplemento.Text = dados.Tables[0].Rows[0]["complemento"].ToString();
                txtCidade.Text = dados.Tables[0].Rows[0]["localidade"].ToString();
                comboUF.Text = dados.Tables[0].Rows[0]["UF"].ToString();
            } 
            catch (Exception) {
                MessageBox.Show("Cep não encontrado");
            }
        }

        private void btnNovo_Click(object sender, EventArgs e) {
            new Helpers().LimparTela(this); 
        }

        private void tabelaCliente_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }
    }
}
