using MySql.Data.MySqlClient;
using ProjetoControleDeVendas.Conexao;
using ProjetoControleDeVendas.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleDeVendas.DAO {
    internal class ItemVendaDAO {

        MySqlConnection conexao;
        internal ItemVendaDAO() {
            this.conexao = new ConnectionFactory().GetConnection();
        }

        public void CadastrarItem(ItemVenda itemVenda) {
            try {
                string sql = @"insert into tb_itensvendas(venda_id, produto_id, qtd, subtotal)
                             values(@venda_id, @produto_id, @qtd, @subtotal)";

                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@venda_id", itemVenda.VendaId);
                cmd.Parameters.AddWithValue("@produto_id", itemVenda.ProdutoId);
                cmd.Parameters.AddWithValue("@qtd", itemVenda.Qtd);
                cmd.Parameters.AddWithValue("@subtotal", itemVenda.Subtotal);

                conexao.Open();
                cmd.ExecuteNonQuery();
                conexao.Close();
                
            } 
            catch (Exception ex) {
                MessageBox.Show($"Erro: {ex}");
            }
        }
        public DataTable ListarItensPorVenda(int VendaId) {
            try {
                DataTable tabelaItens = new DataTable();
                string sql = @"select i.id as 'Código',
		                        p.descricao as 'Descrição',
                                i.qtd as 'Quantidade',
                                p.preco as 'Preço',
                                i.subtotal as 'Subtotal'
                                from tb_itensvendas as i join tb_produtos as p on (i.produto_id = p.id) 
                                where venda_id = @venda_id";

                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@venda_id", VendaId);

                conexao.Open();
                cmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tabelaItens);
                conexao.Close();
                return tabelaItens;
            } catch (Exception ex) {
                MessageBox.Show($"Erro: {ex}");
                return null;
            }
        }


    }
}
