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
    internal class VendaDAO {

        MySqlConnection conexao;

        public VendaDAO() { 
            this.conexao = new ConnectionFactory().GetConnection(); 
        }

        public void CadastrarVenda(Venda venda) {
            try {
                string sql = @"insert into tb_vendas(cliente_id, data_venda, total_venda, observacoes)
                             values(@cliente_id, @data_venda, @total_venda, @obs)";
                
                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@cliente_id", venda.ClienteId);
                cmd.Parameters.AddWithValue("@data_venda", venda.DataVenda);
                cmd.Parameters.AddWithValue("@total_venda", venda.TotalVenda);
                cmd.Parameters.AddWithValue("@obs", venda.Obs);

                conexao.Open();
                cmd.ExecuteNonQuery();
                conexao.Close();

            } 
            catch (Exception ex) {
                MessageBox.Show($"Erro: {ex}");
            }
        }

        public int RetornaIdUltimaVenda() {
            try {
                int idVenda = 0;

                string sql = @"select max(id) id from tb_vendas";

                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                conexao.Open();
                
                MySqlDataReader sr = cmd.ExecuteReader();

                if (sr.Read()) {
                    idVenda = sr.GetInt32("id");
                }
                    
                conexao.Close();
                return idVenda;
            } 
            catch (Exception ex) {
                MessageBox.Show($"Erro: {ex}");
                return 0;
            }
        }

        public DataTable ListarVendas() {
            try {
                DataTable historico = new DataTable();
                string sql = @"select v.id as 'Código', 
                                v.data_venda as 'Data da Venda',
                                c.nome as 'Cliente',
                                v.total_venda as 'Total',
                                v.observacoes as 'Obs'
                             from tb_vendas as v join tb_clientes as c on (v.cliente_id = c.id)";

                MySqlCommand cmd = new MySqlCommand(@sql, conexao);

                conexao.Open();

                cmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(historico);

                conexao.Close();
                return historico;
            } 
            catch (Exception ex) {
                MessageBox.Show($"Erro: {ex}");
                return null;
            }
            

        }

        public DataTable ListarVendasPorPeriodo(DateTime dataInicio, DateTime dataFim) {
            try {
                DataTable historico = new DataTable();
                string sql = @"SELECT v.id as 'Código',
	                            v.data_venda as 'Data da Venda',
                                c.nome as 'Cliente',
                                v.total_venda as 'Total',
                                v.observacoes as 'Obs'
                            FROM tb_vendas as v join tb_clientes as c on (v.cliente_id = c.id)
                            where v.data_venda between @dataInicio and @dataFim";

                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@dataInicio", dataInicio);
                cmd.Parameters.AddWithValue("@dataFim", dataFim);

                conexao.Open();
                cmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(historico);
                conexao.Close();
                return historico;
            } 
            catch (Exception ex) {
                MessageBox.Show($"Erro: {ex}");
                return null;
            }
        }
    }
}
