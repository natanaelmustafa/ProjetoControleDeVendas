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
    internal class ProdutoDAO {
        
        private MySqlConnection conexao;
        public ProdutoDAO() {
            this.conexao = new ConnectionFactory().GetConnection();
        }

        public void CadastrarProduto(Produto produtos) {
            try {

                string sql = @"insert into tb_produtos (descricao, preco, qtd_estoque, for_id)
                             values (@descricao, @preco, @qtd, @for_id)";

                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@descricao", produtos.Descricao);
                cmd.Parameters.AddWithValue("@preco", produtos.Preco);
                cmd.Parameters.AddWithValue("@qtd", produtos.Qtd);
                cmd.Parameters.AddWithValue("@for_id", produtos.ForId);

                conexao.Open();
                cmd.ExecuteNonQuery();
                conexao.Close();

                MessageBox.Show("Produto cadastrado com sucesso");
            }
            catch (Exception ex) {
                MessageBox.Show($"erro {ex}");
            }
        }

        public DataTable ListarProdutos() {

            try {
                DataTable tableProdutos = new DataTable();
                string sql = @"SELECT tb_produtos.id, 
                                      tb_produtos.descricao as 'descrição',
                                      tb_produtos.preco as 'preço',
                                      tb_produtos.qtd_estoque as 'Em Estoque',
                                      tb_fornecedores.nome as 'fornecedor'  FROM tb_produtos 
                                      join tb_fornecedores on (tb_produtos.for_id = tb_fornecedores.id);";

                MySqlCommand executaCmd = new MySqlCommand(sql, conexao);

                conexao.Open();
                executaCmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executaCmd);
                da.Fill(tableProdutos);

                conexao.Close();
                return tableProdutos;

            } catch (Exception ex) {
                MessageBox.Show($"Erro {ex}");
                return null;
            }
        }

        public void AlterarProduto(Produto produtos) {
            try {

                string sql = @"update tb_produtos set descricao=@descricao, preco=@preco, qtd_estoque=@qtd, for_id=@for_id where id=@id";

                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@descricao", produtos.Descricao);
                cmd.Parameters.AddWithValue("@preco", produtos.Preco);
                cmd.Parameters.AddWithValue("@qtd", produtos.Qtd);
                cmd.Parameters.AddWithValue("@for_id", produtos.ForId);
                cmd.Parameters.AddWithValue("@id", produtos.Id);

                conexao.Open();
                cmd.ExecuteNonQuery();
                conexao.Close();

                MessageBox.Show("Produto alterado com sucesso");
            } catch (Exception ex) {
                MessageBox.Show($"erro {ex}");
            }
        }

        public void ExcluirProduto(Produto produtos) {
            try {

                string sql = @"delete from tb_produtos where id=@id";

                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@id", produtos.Id);

                conexao.Open();
                cmd.ExecuteNonQuery();
                conexao.Close();

                MessageBox.Show("Produto excluído com sucesso");
            } catch (Exception ex) {
                MessageBox.Show($"erro {ex}");
            }
        }

        public DataTable ListarProdutosPorNome(string nome) {

            try {
                DataTable tableProdutos = new DataTable();
                string sql = @"SELECT tb_produtos.id, 
                                      tb_produtos.descricao as 'descrição',
                                      tb_produtos.preco as 'preço',
                                      tb_produtos.qtd_estoque as 'Em Estoque',
                                      tb_fornecedores.nome as 'fornecedor'  FROM tb_produtos 
                                      join tb_fornecedores on (tb_produtos.for_id = tb_fornecedores.id)
                                      where descricao like @nome;";

                MySqlCommand executaCmd = new MySqlCommand(sql, conexao);
                executaCmd.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                executaCmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executaCmd);
                da.Fill(tableProdutos);

                conexao.Close();
                return tableProdutos;

            } catch (Exception ex) {
                MessageBox.Show($"Erro {ex}");
                return null;
            }
        }

        public DataTable BuscarProdutosPorNome(string nome) {

            try {
                DataTable tableProdutos = new DataTable();
                string sql = @"SELECT tb_produtos.id, 
                                      tb_produtos.descricao as 'descrição',
                                      tb_produtos.preco as 'preço',
                                      tb_produtos.qtd_estoque as 'Em Estoque',
                                      tb_fornecedores.nome as 'fornecedor'  FROM tb_produtos 
                                      join tb_fornecedores on (tb_produtos.for_id = tb_fornecedores.id)
                                      where descricao = @nome;";

                MySqlCommand executaCmd = new MySqlCommand(sql, conexao);
                executaCmd.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                executaCmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executaCmd);
                da.Fill(tableProdutos);

                conexao.Close();
                return tableProdutos;

            } catch (Exception ex) {
                MessageBox.Show($"Erro {ex}");
                return null;
            }
        }

        public Produto RetornarProdutoPorCodigo(int codigo) {

            try {
                string sql = @"select * from tb_produtos where id=@id";

                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@id", codigo);
                
                conexao.Open();
                MySqlDataReader rs = cmd.ExecuteReader();
                if (rs.Read()) {
                    Produto produto = new Produto();

                    produto.Id = rs.GetInt32("id");
                    produto.Descricao = rs.GetString("descricao");
                    produto.Preco = rs.GetDecimal("preco");

                    conexao.Close();
                    return produto;
                }
                else {
                    MessageBox.Show("Produto não encontrado");
                    return null;
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Erro: {ex}");
                return null;
            }
        }
        public void BaixaEstoque(int id, int qtd) {
            try {
                string sql = @"update tb_produtos set qtd_estoque=@qtd where id=@id";

                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@qtd", qtd);
                cmd.Parameters.AddWithValue("@id", id);

                conexao.Open();
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
            catch (Exception ex) {
                MessageBox.Show($"Erro: {ex}");
                conexao.Close();
            }
        }

        public int RetornaEstoqueAtual(int id) {
            try {
                string sql = @"select qtd_estoque from tb_produtos where id=@id";
                int qtd = 0;

                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@id", id);

                conexao.Open();
                MySqlDataReader rs = cmd.ExecuteReader();
                
                if (rs.Read()) {
                    qtd = rs.GetInt32("qtd_estoque");
                    conexao.Close();
                }
                return qtd;
            } 
            catch (Exception ex) {
                MessageBox.Show($"Erro: {ex}");
                conexao.Close();
                return 0;
            }
        }
    }
}
