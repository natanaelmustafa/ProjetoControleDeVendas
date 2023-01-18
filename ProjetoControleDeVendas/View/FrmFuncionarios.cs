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
    public partial class FrmFuncionarios : Form {
        public FrmFuncionarios() {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e) {

            Funcionario funcionario = new Funcionario();

            funcionario.Nome = txtNome.Text;
            funcionario.Telefone = txtTelefone.Text;
            funcionario.Celular = txtCelular.Text;
            funcionario.Endereco = txtEndereco.Text;
            funcionario.Complemento = txtComplemento.Text;
            funcionario.Bairro = txtBairro.Text;
            funcionario.Email = txtEmail.Text;
            funcionario.RG = txtRG.Text;
            funcionario.CPF = txtCPF.Text;
            funcionario.CEP = txtCEP.Text;
            funcionario.Numero = int.Parse(txtNumero.Text);
            funcionario.Cidade = txtCidade.Text;
            funcionario.Estado = comboUF.Text;
            funcionario.Senha = txtSenha.Text;
            funcionario.Cargo = cbCargo.Text;
            funcionario.Acesso = cbAcesso.Text;

            FuncionarioDAO dao = new FuncionarioDAO();
            dao.CadastrarFuncionario(funcionario);
            
            tabelaFuncionario.DataSource = dao.ListarFuncionarios();

        }

        private void btnEditar_Click(object sender, EventArgs e) {
           
            Funcionario funcionario = new Funcionario();

            funcionario.Nome = txtNome.Text;
            funcionario.Telefone = txtTelefone.Text;
            funcionario.Celular = txtCelular.Text;
            funcionario.Endereco = txtEndereco.Text;
            funcionario.Complemento = txtComplemento.Text;
            funcionario.Bairro = txtBairro.Text;
            funcionario.Email = txtEmail.Text;
            funcionario.RG = txtRG.Text;
            funcionario.CPF = txtCPF.Text;
            funcionario.CEP = txtCEP.Text;
            funcionario.Numero = int.Parse(txtNumero.Text);
            funcionario.Cidade = txtCidade.Text;
            funcionario.Estado = comboUF.Text;
            funcionario.Senha = txtSenha.Text;
            funcionario.Cargo = cbCargo.Text;
            funcionario.Acesso = cbAcesso.Text;
            funcionario.Codigo= int.Parse(txtCodigo.Text);

            FuncionarioDAO dao = new FuncionarioDAO();
            dao.AlterarFuncionario(funcionario);

            tabelaFuncionario.DataSource = dao.ListarFuncionarios();
        }

        private void btnExcluir_Click(object sender, EventArgs e) {

            if (txtCodigo.Text != null) {
            Funcionario funcionario = new Funcionario();
            funcionario.Codigo = int.Parse(txtCodigo.Text);

            FuncionarioDAO dao = new FuncionarioDAO();
            dao.DeletarFuncionario(funcionario);

            tabelaFuncionario.DataSource = dao.ListarFuncionarios();

            }
        }

        private void btnNovo_Click(object sender, EventArgs e) {
            new Helpers().LimparTela(this);
        }

        private void FrmFuncionarios_Load(object sender, EventArgs e) {

            FuncionarioDAO dao = new FuncionarioDAO();
            tabelaFuncionario.DataSource = dao.ListarFuncionarios();
        }

        private void tabelaFuncionario_DoubleClick(object sender, EventArgs e) {

            txtCodigo.Text = tabelaFuncionario.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = tabelaFuncionario.CurrentRow.Cells[1].Value.ToString();
            txtRG.Text = tabelaFuncionario.CurrentRow.Cells[2].Value.ToString();
            txtCPF.Text = tabelaFuncionario.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = tabelaFuncionario.CurrentRow.Cells[4].Value.ToString();
            txtSenha.Text = tabelaFuncionario.CurrentRow.Cells[5].Value.ToString();
            cbCargo.Text = tabelaFuncionario.CurrentRow.Cells[6].Value.ToString();
            cbAcesso.Text = tabelaFuncionario.CurrentRow.Cells[7].Value.ToString();
            txtTelefone.Text = tabelaFuncionario.CurrentRow.Cells[8].Value.ToString();
            txtCelular.Text = tabelaFuncionario.CurrentRow.Cells[9].Value.ToString();
            txtCEP.Text = tabelaFuncionario.CurrentRow.Cells[10].Value.ToString();
            txtEndereco.Text = tabelaFuncionario.CurrentRow.Cells[11].Value.ToString();
            txtNumero.Text = tabelaFuncionario.CurrentRow.Cells[12].Value.ToString();
            txtComplemento.Text = tabelaFuncionario.CurrentRow.Cells[13].Value.ToString();
            txtBairro.Text = tabelaFuncionario.CurrentRow.Cells[14].Value.ToString();
            txtCidade.Text = tabelaFuncionario.CurrentRow.Cells[15].Value.ToString();
            comboUF.Text = tabelaFuncionario.CurrentRow.Cells[16].Value.ToString();

            tabFuncionarios.SelectedTab = tabPage1;
        }

        private void btnPesquisar_Click(object sender, EventArgs e) {

            var nome = txtPesquisa.Text;

            FuncionarioDAO funcionario = new FuncionarioDAO();
            tabelaFuncionario.DataSource = funcionario.BuscarFuncionariosPorNome(nome);

            if (tabelaFuncionario.Rows.Count == 0) {

                MessageBox.Show("Funcionário não encontrado");
                tabelaFuncionario.DataSource = funcionario.ListarFuncionarios();
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e) {

            string nome = $"%{txtPesquisa.Text}%";

            FuncionarioDAO funcionario = new FuncionarioDAO();
            tabelaFuncionario.DataSource = funcionario.ListarFuncionariosPorNome(nome);
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
    }
}
