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
    public partial class FrmProdutos : Form {
        public FrmProdutos() {
            InitializeComponent();
        }

        private void FrmProdutos_Load(object sender, EventArgs e) {

            FornecedorDAO fDao = new FornecedorDAO();
            cbFornecedor.DataSource = fDao.ListarFornecedores();
            cbFornecedor.DisplayMember = "nome";
            cbFornecedor.ValueMember = "id";

            ProdutoDAO pDao = new ProdutoDAO();
            tabelaProdutos.DataSource = pDao.ListarProdutos();
        }

        private void btnSalvar_Click(object sender, EventArgs e) {

            Produto produto = new Produto();

            produto.Descricao = txtDescricao.Text;
            produto.Preco = decimal.Parse(txtPreco.Text);
            produto.ForId =(int) cbFornecedor.SelectedValue;
            produto.Qtd = int.Parse(txtQtd.Text);

            ProdutoDAO dao = new ProdutoDAO();
            dao.CadastrarProduto(produto);

            Helpers helpers = new Helpers();
            tabelaProdutos.DataSource = dao.ListarProdutos();
            helpers.LimparTela(this);
        }

        private void btnNovo_Click(object sender, EventArgs e) {

            new Helpers().LimparTela(this);
        }

        private void tabelaProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e) {
    
        }

        private void tabelaProdutos_DoubleClick(object sender, EventArgs e) {

            txtCodigo.Text = tabelaProdutos.CurrentRow.Cells[0].Value.ToString();
            txtDescricao.Text = tabelaProdutos.CurrentRow.Cells[1].Value.ToString();
            txtPreco.Text = tabelaProdutos.CurrentRow.Cells[2].Value.ToString();
            txtQtd.Text = tabelaProdutos.CurrentRow.Cells[3].Value.ToString();
            cbFornecedor.Text = tabelaProdutos.CurrentRow.Cells[4].Value.ToString();

            tabProdutos.SelectedTab = tabPage1;
        }

        private void tabelaProdutos_Click(object sender, EventArgs e) {
            txtCodigo.Text = tabelaProdutos.CurrentRow.Cells[0].Value.ToString();
            txtDescricao.Text = tabelaProdutos.CurrentRow.Cells[1].Value.ToString();
            txtPreco.Text = tabelaProdutos.CurrentRow.Cells[2].Value.ToString();
            txtQtd.Text = tabelaProdutos.CurrentRow.Cells[3].Value.ToString();
            cbFornecedor.Text = tabelaProdutos.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e) {

            ProdutoDAO produto = new ProdutoDAO();

            Produto obj = new Produto();
            obj.Descricao = txtDescricao.Text;
            obj.Preco = decimal.Parse(txtPreco.Text);
            obj.Qtd = int.Parse(txtQtd.Text);
            obj.ForId = (int)cbFornecedor.SelectedValue;
            obj.Id = int.Parse(txtCodigo.Text);
            
            produto.AlterarProduto(obj);

            tabelaProdutos.DataSource = produto.ListarProdutos();
            new Helpers().LimparTela(this);
        }

        private void btnExcluir_Click(object sender, EventArgs e) {

            Produto produto = new Produto();
            produto.Id = int.Parse(txtCodigo.Text);

            ProdutoDAO dao = new ProdutoDAO();
            dao.ExcluirProduto(produto);

            tabelaProdutos.DataSource = dao.ListarProdutos();
            new Helpers().LimparTela(this);
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e) {

            string nome = $"%{txtPesquisa.Text}%";

            ProdutoDAO dao = new ProdutoDAO();
            tabelaProdutos.DataSource = dao.ListarProdutosPorNome(nome);
        }

        private void btnPesquisar_Click(object sender, EventArgs e) {

            string nome = txtPesquisa.Text;

            ProdutoDAO dao = new ProdutoDAO();
            tabelaProdutos.DataSource = dao.ListarProdutosPorNome(nome);

            if (tabelaProdutos.Rows.Count == 0) {
                MessageBox.Show("Produto não encontrado");
                tabelaProdutos.DataSource = dao.ListarProdutos();
            }
        }
    }
}
