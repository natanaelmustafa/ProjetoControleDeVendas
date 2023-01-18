using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleDeVendas.Model {
    internal class Helpers {

        public void LimparTela(Form tela) {

            foreach (Control ctrPai in tela.Controls) {

                foreach (Control ctr1 in ctrPai.Controls) {

                    if (ctr1 is TabPage) {

                        foreach (Control ctr2 in ctr1.Controls) {

                            if (ctr2 is TextBox) {
                                (ctr2 as TextBox).Text = String.Empty;
                            }
                            if (ctr2 is MaskedTextBox) {
                                (ctr2 as MaskedTextBox).Text = String.Empty;
                            }
                            if (ctr2 is ComboBox) {
                                (ctr2 as ComboBox).Text = String.Empty;
                            }
                        }
                    }
                }
            }
        }

        public void LimparTelaVenda(Form tela) {

            foreach (Control ctrPai in tela.Controls) {

                foreach (Control ctr1 in ctrPai.Controls) {

                    if (ctr1 is TextBox) {
                        (ctr1 as TextBox).Text = String.Empty;
                    }
                    if (ctr1 is MaskedTextBox) {
                        (ctr1 as MaskedTextBox).Text = String.Empty;
                    }
                    if (ctr1 is ComboBox) {
                        (ctr1 as ComboBox).Text = String.Empty;
                    }
                }
            }
        }
        public bool Teste(Form tela) {
            bool teste = false;
            foreach (Control ctrPai in tela.Controls) {

                foreach (Control ctr1 in ctrPai.Controls) {

                    if (ctr1 is TextBox) {
                        if ((ctr1 as TextBox).Text == String.Empty) {
                            teste = true;
                        }

                    }
                }
            }
            return teste;
        }
    }
}
