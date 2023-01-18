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
    public partial class FrmFornecedor : Form {
        public FrmFornecedor() {
            InitializeComponent();
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
            } catch (Exception) {
                MessageBox.Show("Cep não encontrado");
            }
        }

        private void btnNovo_Click(object sender, EventArgs e) {
            new Helpers().LimparTela(this);
        }

        private void btnSalvar_Click(object sender, EventArgs e) {

            Fornecedor obj = new Fornecedor();

            obj.Nome = txtNome.Text;
            obj.CPNJ = txtCNPJ.Text;
            obj.Email = txtEmail.Text;
            obj.Telefone = txtTelefone.Text;
            obj.Celular = txtCelular.Text;
            obj.CEP = txtCEP.Text;
            obj.Endereco = txtEndereco.Text;
            obj.Numero = int.Parse(txtNumero.Text);
            obj.Complemento = txtComplemento.Text;
            obj.Bairro = txtBairro.Text;
            obj.Cidade = txtCidade.Text;
            obj.Estado = comboUF.Text;

            FornecedorDAO dao = new FornecedorDAO();
            dao.CadastrarFornecedor(obj);

            tabelaFornecedores.DataSource = dao.ListarFornecedores();
        }

        private void FrmFornecedor_Load(object sender, EventArgs e) {

            FornecedorDAO dao = new FornecedorDAO();
            tabelaFornecedores.DataSource = dao.ListarFornecedores();
        }

        private void tabelaFornecedores_DoubleClick(object sender, EventArgs e) {
            
            txtCodigo.Text = tabelaFornecedores.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = tabelaFornecedores.CurrentRow.Cells[1].Value.ToString();
            txtCNPJ.Text = tabelaFornecedores.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = tabelaFornecedores.CurrentRow.Cells[3].Value.ToString();
            txtTelefone.Text = tabelaFornecedores.CurrentRow.Cells[4].Value.ToString();
            txtCelular.Text = tabelaFornecedores.CurrentRow.Cells[5].Value.ToString();
            txtCEP.Text = tabelaFornecedores.CurrentRow.Cells[6].Value.ToString();
            txtEndereco.Text = tabelaFornecedores.CurrentRow.Cells[7].Value.ToString();
            txtNumero.Text = tabelaFornecedores.CurrentRow.Cells[8].Value.ToString();
            txtComplemento.Text = tabelaFornecedores.CurrentRow.Cells[9].Value.ToString();
            txtBairro.Text = tabelaFornecedores.CurrentRow.Cells[10].Value.ToString();
            txtCidade.Text = tabelaFornecedores.CurrentRow.Cells[11].Value.ToString();
            comboUF.Text = tabelaFornecedores.CurrentRow.Cells[12].Value.ToString();

            tabFornecedor.SelectedTab = tabPage1;
        }

        private void btnEditar_Click(object sender, EventArgs e) {
             Fornecedor fornecedor = new Fornecedor();

            fornecedor.Nome = txtNome.Text;
            fornecedor.CPNJ = txtCNPJ.Text;
            fornecedor.Email = txtEmail.Text;
            fornecedor.Telefone = txtTelefone.Text;
            fornecedor.Celular = txtCelular.Text;
            fornecedor.Endereco = txtEndereco.Text;
            fornecedor.Numero = int.Parse(txtNumero.Text);
            fornecedor.Complemento = txtComplemento.Text;
            fornecedor.Bairro = txtBairro.Text;
            fornecedor.Cidade = txtCidade.Text;
            fornecedor.Estado = comboUF.Text;
            fornecedor.CEP = txtCEP.Text;
            fornecedor.Codigo = int.Parse(txtCodigo.Text);

            FornecedorDAO dao = new FornecedorDAO();
            dao.AlterarFornecedor(fornecedor);
            tabelaFornecedores.DataSource = dao.ListarFornecedores();
        }

        private void btnExcluir_Click(object sender, EventArgs e) {
            Fornecedor fornecedor = new Fornecedor();

            fornecedor.Codigo = int.Parse(txtCodigo.Text);

            FornecedorDAO dao = new FornecedorDAO();
            dao.ExcluirFornecedor(fornecedor);
            tabelaFornecedores.DataSource = dao.ListarFornecedores();
        }

        private void tabelaFornecedores_CellClick(object sender, DataGridViewCellEventArgs e) {
            txtCodigo.Text = tabelaFornecedores.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = tabelaFornecedores.CurrentRow.Cells[1].Value.ToString();
            txtCNPJ.Text = tabelaFornecedores.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = tabelaFornecedores.CurrentRow.Cells[3].Value.ToString();
            txtTelefone.Text = tabelaFornecedores.CurrentRow.Cells[4].Value.ToString();
            txtCelular.Text = tabelaFornecedores.CurrentRow.Cells[5].Value.ToString();
            txtCEP.Text = tabelaFornecedores.CurrentRow.Cells[6].Value.ToString();
            txtEndereco.Text = tabelaFornecedores.CurrentRow.Cells[7].Value.ToString();
            txtNumero.Text = tabelaFornecedores.CurrentRow.Cells[8].Value.ToString();
            txtComplemento.Text = tabelaFornecedores.CurrentRow.Cells[9].Value.ToString();
            txtBairro.Text = tabelaFornecedores.CurrentRow.Cells[10].Value.ToString();
            txtCidade.Text = tabelaFornecedores.CurrentRow.Cells[11].Value.ToString();
            comboUF.Text = tabelaFornecedores.CurrentRow.Cells[12].Value.ToString();
        }

        private void btnPesquisar_Click(object sender, EventArgs e) {

            var nome = txtPesquisa.Text;

            FornecedorDAO dao = new FornecedorDAO();

            tabelaFornecedores.DataSource = dao.BuscarFornecedorPorNome(nome);

            if (tabelaFornecedores.Rows.Count == 0) {
                tabelaFornecedores.DataSource = dao.ListarFornecedores();
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e) {
            
            var nome = $"%{txtPesquisa.Text}%";

            FornecedorDAO dao = new FornecedorDAO();
            tabelaFornecedores.DataSource = dao.ListarFornecedoresPorNome(nome);
        }
    }
}
