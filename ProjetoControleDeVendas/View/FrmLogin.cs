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
    public partial class FrmLogin : Form {
        public FrmLogin() {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e) {

            string email = txtEmail.Text;
            string senha = txtSenha.Text;
            
            FuncionarioDAO fDao = new FuncionarioDAO();
            bool login = fDao.Login(email, senha);

            if (login) { 
                this.Hide();
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e) {

            if (e.KeyChar == 13) {
                string email = txtEmail.Text;
                string senha = txtSenha.Text;

                FuncionarioDAO fDao = new FuncionarioDAO();
                bool login = fDao.Login(email, senha);

                if (login) {
                    this.Hide();
                }
            }
        }
    }
}
