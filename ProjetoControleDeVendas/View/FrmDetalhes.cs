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
    public partial class FrmDetalhes : Form {

        int vendaId;
        public FrmDetalhes(int vendaId) {
            InitializeComponent();
            this.vendaId = vendaId;
        }

        private void groupBox1_Enter(object sender, EventArgs e) {
            
            ItemVendaDAO itemVendaDAO = new ItemVendaDAO();
            tabelaDetalhes.DataSource = itemVendaDAO.ListarItensPorVenda(vendaId);
        }
    }
}
