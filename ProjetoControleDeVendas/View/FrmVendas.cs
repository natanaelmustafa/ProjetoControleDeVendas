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
    public partial class FrmVendas : Form {

        Cliente cliente = new Cliente();
        ClienteDAO cDAO = new ClienteDAO();
        Produto produto = new Produto();
        ProdutoDAO pDAO = new ProdutoDAO();

        int qtd;
        decimal preco;
        decimal subtotal, total;

        DataTable carrinho = new DataTable();
        public FrmVendas() {
            InitializeComponent();

            carrinho.Columns.Add("Codigo", typeof(int));
            carrinho.Columns.Add("Produto", typeof(string));
            carrinho.Columns.Add("Qtd", typeof(int));
            carrinho.Columns.Add("Preço", typeof(decimal));
            carrinho.Columns.Add("Subtotal", typeof(decimal));

            tabelaProdutos.DataSource = carrinho;
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e) {

            if (e.KeyChar == 13) {
                
                cliente = cDAO.RetornaClientePorCpf(txtCPF.Text);

                if (cliente != null) {
                txtNome.Text = cliente.Nome;
                } 
                else {
                    txtCPF.Clear();
                    txtCPF.Focus();
                }
            

            }
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            try {
                qtd = int.Parse(txtQtd.Text);
                preco = decimal.Parse(txtPreco.Text);
                subtotal = preco * qtd;
                total += subtotal;

                carrinho.Rows.Add(int.Parse(txtCodigo.Text), txtDescricao.Text, qtd, preco, subtotal);
                txtTotal.Text = total.ToString();

                txtCodigo.Clear();
                txtDescricao.Clear();
                txtQtd.Clear();
                txtPreco.Clear();

                txtCodigo.Focus();

            } 
            catch (Exception ex) {
                MessageBox.Show($"Preencha todos os campos");
            }            
        }

        private void FrmVendas_Load(object sender, EventArgs e) {
            txtData.Text = DateTime.Now.ToShortDateString();
        }

        private void btnRemove_Click(object sender, EventArgs e) {

            var subtotal = decimal.Parse(tabelaProdutos.CurrentRow.Cells[4].Value.ToString());
            var indice = tabelaProdutos.CurrentRow.Index;
            DataRow linha = carrinho.Rows[indice];

            carrinho.Rows.Remove(linha);
            carrinho.AcceptChanges();

            total -= subtotal;
            txtTotal.Text = total.ToString();
        }

        private void btnPagamento_Click(object sender, EventArgs e) {
            if (total == 0) {
                MessageBox.Show("Por favor preencha todos os campos");
            } else {

            DateTime currentDate = DateTime.Parse(txtData.Text);
            FrmPagamento tela = new FrmPagamento(cliente, carrinho, currentDate);
            tela.txtTotal.Text = total.ToString();
            tela.ShowDialog();
            new Helpers().LimparTelaVenda(this);
            txtData.Text = DateTime.Now.ToShortDateString();
            carrinho.Rows.Clear();
            tabelaProdutos.DataSource = carrinho;
            total = 0;
            }
        }

        private void txtCPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) {

        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e) {

            if (e.KeyChar == 13) {
                produto = pDAO.RetornarProdutoPorCodigo(int.Parse(txtCodigo.Text));

                if (produto != null) {
                txtDescricao.Text = produto.Descricao;
                txtPreco.Text = produto.Preco.ToString();
                } 
                else {
                    txtCodigo.Clear();
                    txtCodigo.Focus();
                }
            }
        }
    }
}
