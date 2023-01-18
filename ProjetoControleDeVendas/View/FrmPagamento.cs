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
    public partial class FrmPagamento : Form {

        Cliente cliente = new Cliente();
        DataTable carrinho = new DataTable();
        DateTime currentDate;
        internal FrmPagamento(Cliente cliente, DataTable carrinho, DateTime currentDate) {
            
            this.cliente = cliente;
            this.carrinho = carrinho;
            this.currentDate = currentDate;
            InitializeComponent();
        }

        private void txtPreco_TextChanged(object sender, EventArgs e) {

        }

        private void FrmPagamento_Load(object sender, EventArgs e) {

            txtDinheiro.Text = "0,00";
            txtCartao.Text = "0,00";
            txtTroco.Text = "0,00";
        }

        private void btnFinalizar_Click(object sender, EventArgs e) {
            try {
                
                decimal dinheiro, cartao, troco, totalPago, total;
                ProdutoDAO pDao = new ProdutoDAO();
                int qtdEstoque, qtdCompra, estoqueAtualizado;

                dinheiro = decimal.Parse(txtDinheiro.Text);
                cartao = decimal.Parse(txtCartao.Text);
                totalPago = dinheiro + cartao;
                total = decimal.Parse(txtTotal.Text);

                if (totalPago < total) {
                    MessageBox.Show("Valor insuficiente");
                } 
                else {
                    troco = totalPago - total;

                    Venda venda = new Venda();
                    venda.ClienteId = cliente.Codigo;
                    venda.DataVenda = currentDate;
                    venda.TotalVenda = total;
                    venda.Obs = txtObs.Text;

                    txtTroco.Text = troco.ToString();

                    VendaDAO vDAO = new VendaDAO();
                    vDAO.CadastrarVenda(venda);

                    foreach (DataRow linha in carrinho.Rows) {

                        ItemVenda item = new ItemVenda();
                        item.VendaId = vDAO.RetornaIdUltimaVenda();
                        item.ProdutoId = int.Parse(linha["Codigo"].ToString());
                        item.Qtd = int.Parse(linha["Qtd"].ToString());
                        item.Subtotal = decimal.Parse(linha["Subtotal"].ToString());

                        qtdEstoque = pDao.RetornaEstoqueAtual(item.ProdutoId);
                        qtdCompra = item.Qtd;
                        estoqueAtualizado = qtdEstoque - qtdCompra;

                        pDao.BaixaEstoque(item.ProdutoId, estoqueAtualizado);

                        ItemVendaDAO dao = new ItemVendaDAO();
                        dao.CadastrarItem(item);

                    }
                    MessageBox.Show("Venda realizada");
                    this.Dispose();
                }
            } catch (Exception ex) {
                MessageBox.Show($"Erro: {ex}");
            }
        }
    }
}
