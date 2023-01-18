using ProjetoControleDeVendas.DAO;
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
    public partial class FrmHistorico : Form {
        public FrmHistorico() {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e) {

            DateTime dataInicio, dataFim;
            dataInicio = Convert.ToDateTime(dtInicio.Value.ToString("yyyy-MM-dd"));
            dataFim = Convert.ToDateTime(dtFim.Value.ToString("yyyy-MM-dd"));

            VendaDAO dao = new VendaDAO();
            tabelaHistorico.DataSource = dao.ListarVendasPorPeriodo(dataInicio, dataFim);
        }

        private void FrmHistorico_Load(object sender, EventArgs e) {

            VendaDAO vDao = new VendaDAO();
            tabelaHistorico.DataSource = vDao.ListarVendas();
            tabelaHistorico.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void tabelaHistorico_DoubleClick(object sender, EventArgs e) {

            FrmDetalhes tela = new FrmDetalhes((int)tabelaHistorico.CurrentRow.Cells[0].Value);
            DateTime dateTime = Convert.ToDateTime(tabelaHistorico.CurrentRow.Cells[1].Value.ToString());

            tela.txtData.Text = dateTime.ToString("dd/MM/yyyy");
            tela.txtCliente.Text = tabelaHistorico.CurrentRow.Cells[2].Value.ToString();
            tela.txtTotal.Text = tabelaHistorico.CurrentRow.Cells[3].Value.ToString();
            tela.txtObs.Text = tabelaHistorico.CurrentRow.Cells[4].Value.ToString();

            tela.ShowDialog();
        }
    }
}
