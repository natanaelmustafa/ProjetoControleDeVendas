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
    internal class FornecedorDAO {

        MySqlConnection conexao;

        public FornecedorDAO() {
            this.conexao = new ConnectionFactory().GetConnection();
        }

        public void CadastrarFornecedor(Fornecedor fornecedor) {
            try {
                string sql = @"insert into tb_fornecedores (nome,cnpj,email,telefone,celular,cep,endereco,numero,complemento,bairro,cidade,estado)
                       values(@nome, @cnpj, @email, @telefone, @celular, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @estado)";

                var executaCmd = new MySqlCommand(sql, conexao);

                executaCmd.Parameters.AddWithValue("@nome", fornecedor.Nome);
                executaCmd.Parameters.AddWithValue("@cnpj", fornecedor.CPNJ);
                executaCmd.Parameters.AddWithValue("@email", fornecedor.Email);
                executaCmd.Parameters.AddWithValue("@telefone", fornecedor.Telefone);
                executaCmd.Parameters.AddWithValue("@celular", fornecedor.Celular);
                executaCmd.Parameters.AddWithValue("@cep", fornecedor.CEP);
                executaCmd.Parameters.AddWithValue("@endereco", fornecedor.Endereco);
                executaCmd.Parameters.AddWithValue("@numero", fornecedor.Numero);
                executaCmd.Parameters.AddWithValue("@complemento", fornecedor.Complemento);
                executaCmd.Parameters.AddWithValue("@bairro", fornecedor.Bairro);
                executaCmd.Parameters.AddWithValue("@cidade", fornecedor.Cidade);
                executaCmd.Parameters.AddWithValue("@estado", fornecedor.Estado);

                conexao.Open();
                executaCmd.ExecuteNonQuery();

                MessageBox.Show("Fornecedor cadastrado com sucesso!");
                conexao.Close();

            } catch (Exception ex) {

                MessageBox.Show($"Erro {ex}");
            }
        }

        public DataTable ListarFornecedores() {
            try {
                DataTable data = new DataTable();
                string sql = "select * from tb_fornecedores";

                MySqlCommand sqlCommand = new MySqlCommand(sql, conexao);

                conexao.Open();
                sqlCommand.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(sqlCommand);
                da.Fill(data);

                conexao.Close();
                return data;
            } 
            catch (Exception ex) {
                MessageBox.Show($"Erro {ex}");
                return null;
            }
        }

        public void AlterarFornecedor(Fornecedor fornecedor) {
            try {
                string sql = @"update tb_fornecedores set nome=@nome,cnpj=@cnpj,email=@email,telefone=@telefone
                       ,celular=@celular,cep=@cep,endereco=@endereco,numero=@numero,complemento=@complemento,bairro=@bairro
                       ,cidade=@cidade,estado=@estado where id=@id";
            
                MySqlCommand executaCmd = new MySqlCommand(sql, conexao);

                executaCmd.Parameters.AddWithValue("@nome", fornecedor.Nome);
                executaCmd.Parameters.AddWithValue("@cnpj", fornecedor.CPNJ);
                executaCmd.Parameters.AddWithValue("@email", fornecedor.Email);
                executaCmd.Parameters.AddWithValue("@telefone", fornecedor.Telefone);
                executaCmd.Parameters.AddWithValue("@celular", fornecedor.Celular);
                executaCmd.Parameters.AddWithValue("@cep", fornecedor.CEP);
                executaCmd.Parameters.AddWithValue("@endereco", fornecedor.Endereco);
                executaCmd.Parameters.AddWithValue("@numero", fornecedor.Numero);
                executaCmd.Parameters.AddWithValue("@complemento", fornecedor.Complemento);
                executaCmd.Parameters.AddWithValue("@bairro", fornecedor.Bairro);
                executaCmd.Parameters.AddWithValue("@cidade", fornecedor.Cidade);
                executaCmd.Parameters.AddWithValue("@estado", fornecedor.Estado);
                executaCmd.Parameters.AddWithValue("@id", fornecedor.Codigo);

                conexao.Open();
                executaCmd.ExecuteNonQuery();
                conexao.Close();

                MessageBox.Show("Dados alterados com sucesso");
            } 
            catch (Exception ex) {
                MessageBox.Show($"Erro {ex}");
            }
        }

        public void ExcluirFornecedor(Fornecedor fornecedor) {
            try {
                string sql = @"delete from tb_fornecedores where id=@id";

                MySqlCommand executarCmd = new MySqlCommand(sql, conexao);

                executarCmd.Parameters.AddWithValue("@id", fornecedor.Codigo);

                conexao.Open();
                executarCmd.ExecuteNonQuery();
                conexao.Close();

                MessageBox.Show("Fornecedor excluído com sucesso");
            } 
            catch (Exception) {

                throw;
            }
        }

        public DataTable ListarFornecedoresPorNome(string nome) {
            try {
                DataTable data = new DataTable();
                string sql = "select * from tb_fornecedores where nome Like @nome";

                MySqlCommand sqlCommand = new MySqlCommand(sql, conexao);
                sqlCommand.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                sqlCommand.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(sqlCommand);
                da.Fill(data);

                conexao.Close();
                return data;
            } 
            catch (Exception ex) {
                MessageBox.Show($"Erro {ex}");
                return null;
            }
        }

        public DataTable BuscarFornecedorPorNome(string nome) {
            try {
                DataTable data = new DataTable();
                string sql = "select * from tb_fornecedores where nome = @nome";

                MySqlCommand sqlCommand = new MySqlCommand(sql, conexao);
                sqlCommand.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                sqlCommand.ExecuteNonQuery();
                conexao.Close();

                MySqlDataAdapter da = new MySqlDataAdapter(sqlCommand);
                da.Fill(data);

                conexao.Close();
                return data;
            } 
            catch (Exception ex) {
                MessageBox.Show($"Erro {ex}");
                return null;
            }
        }



    }
}
