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
    public partial class FrmMenu : Form {

        public FrmMenu() {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e) {
            txtData.Text = DateTime.Now.ToShortDateString();
            txtHora.Text = DateTime.Now.Hour.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            txtHora.Text = DateTime.Now.ToShortTimeString();
        }

        private void menuCadastroCliente_Click(object sender, EventArgs e) {
            
            FrmCliente tela = new FrmCliente();
            tela.ShowDialog();
        
        }

        private void menuConsultaClientes_Click(object sender, EventArgs e) {

            FrmCliente tela = new FrmCliente();
            tela.tabClientes.SelectedTab = tela.tabPage2;
            tela.ShowDialog();
        }

        private void menuCadastroFuncionarios_Click(object sender, EventArgs e) {

            FrmFuncionarios tela = new FrmFuncionarios();
            tela.ShowDialog();
            
        }

        private void menuConsultaFuncionarios_Click(object sender, EventArgs e) {

            FrmFuncionarios tela = new FrmFuncionarios();
            tela.tabFuncionarios.SelectedTab = tela.tabPage2;
            tela.ShowDialog();

        }
        private void menuFornecedores_Click(object sender, EventArgs e) {

        }

        private void menuCadastroFornecedores_Click(object sender, EventArgs e) {
            FrmFornecedor tela = new FrmFornecedor();
            tela.ShowDialog();
        }

        private void menuConsultaFornecedores_Click(object sender, EventArgs e) {
            
            FrmFornecedor tela = new FrmFornecedor();
            tela.tabFornecedor.SelectedTab = tela.tabPage2;
            tela.ShowDialog();
        }

        private void menuCadastroProdutos_Click(object sender, EventArgs e) {

            FrmProdutos tela = new FrmProdutos();
            tela.ShowDialog();
        }

        private void menuConsultaProdutos_Click(object sender, EventArgs e) {

            FrmProdutos tela = new FrmProdutos();
            tela.tabProdutos.SelectedTab = tela.tabPage2;
            tela.ShowDialog();

        }

        private void menuNovaVenda_Click(object sender, EventArgs e) {

            FrmVendas tela = new FrmVendas();
            tela.ShowDialog();
        }

        private void menuHistoricoVenda_Click(object sender, EventArgs e) {

            FrmHistorico tela = new FrmHistorico();
            tela.ShowDialog();
        }

        private void menuTrocarUsuario_Click(object sender, EventArgs e) {

            FrmLogin tela = new FrmLogin();
            this.Dispose();
            tela.ShowDialog();
        }

        private void menuSairSistema_Click(object sender, EventArgs e) {

            DialogResult result = MessageBox.Show("Deseja mesmo sair?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


            if (result == DialogResult.Yes) { 
                Application.Exit();
            }
        }
    }
}
