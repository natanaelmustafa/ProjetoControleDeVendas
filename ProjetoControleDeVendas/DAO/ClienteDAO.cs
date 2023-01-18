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
    internal class ClienteDAO {

        private MySqlConnection conexao;
        public ClienteDAO() {
            conexao = new ConnectionFactory().GetConnection();
        }

        public void CadastrarCliente(Cliente cliente) {
            try {
                string sql = @"insert into tb_clientes (nome,rg,cpf,email,telefone,celular,cep,endereco,numero,complemento,bairro,cidade,estado)
                       values(@nome, @rg, @cpf, @email, @telefone, @celular, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @estado)";
            
                var executaCmd = new MySqlCommand(sql, conexao);

                executaCmd.Parameters.AddWithValue("@nome", cliente.Nome);
                executaCmd.Parameters.AddWithValue("@rg", cliente.RG);
                executaCmd.Parameters.AddWithValue("@cpf", cliente.CPF);
                executaCmd.Parameters.AddWithValue("@email", cliente.Email);
                executaCmd.Parameters.AddWithValue("@telefone", cliente.Telefone);
                executaCmd.Parameters.AddWithValue("@celular", cliente.Celular);
                executaCmd.Parameters.AddWithValue("@cep", cliente.CEP);
                executaCmd.Parameters.AddWithValue("@endereco", cliente.Endereco);
                executaCmd.Parameters.AddWithValue("@numero", cliente.Numero);
                executaCmd.Parameters.AddWithValue("@complemento", cliente.Complemento);
                executaCmd.Parameters.AddWithValue("@bairro", cliente.Bairro);
                executaCmd.Parameters.AddWithValue("@cidade", cliente.Cidade);
                executaCmd.Parameters.AddWithValue("@estado", cliente.Estado);

                conexao.Open();
                executaCmd.ExecuteNonQuery();

                MessageBox.Show("Cliente cadastrado com sucesso!");
                conexao.Close();

            } catch (Exception ex) {

                MessageBox.Show($"Erro {ex}");
            }
        }

        public DataTable ListarClientes() {

            try {
                DataTable tableCliente = new DataTable();
                string sql = "select * from tb_clientes";
            
                MySqlCommand executaCmd = new MySqlCommand(sql, conexao);

                conexao.Open();
                executaCmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executaCmd);
                da.Fill(tableCliente);

                conexao.Close();
                return tableCliente;

            } catch (Exception ex) {
                MessageBox.Show($"Erro {ex}");
                return null;
            }
        }

        public void AlterarCliente(Cliente cliente) {
            try {
                string sql = @"update tb_clientes set nome=@nome,rg=@rg,cpf=@cpf,email=@email,telefone=@telefone,celular=@celular,cep=@cep,endereco=@endereco,numero=@numero,complemento=@complemento,bairro=@bairro,cidade=@cidade,estado=@estado
                            where id=@id";
            
                var executaCmd = new MySqlCommand(sql, conexao);

                executaCmd.Parameters.AddWithValue("@nome", cliente.Nome);
                executaCmd.Parameters.AddWithValue("@rg", cliente.RG);
                executaCmd.Parameters.AddWithValue("@cpf", cliente.CPF);
                executaCmd.Parameters.AddWithValue("@email", cliente.Email);
                executaCmd.Parameters.AddWithValue("@telefone", cliente.Telefone);
                executaCmd.Parameters.AddWithValue("@celular", cliente.Celular);
                executaCmd.Parameters.AddWithValue("@cep", cliente.CEP);
                executaCmd.Parameters.AddWithValue("@endereco", cliente.Endereco);
                executaCmd.Parameters.AddWithValue("@numero", cliente.Numero);
                executaCmd.Parameters.AddWithValue("@complemento", cliente.Complemento);
                executaCmd.Parameters.AddWithValue("@bairro", cliente.Bairro);
                executaCmd.Parameters.AddWithValue("@cidade", cliente.Cidade);
                executaCmd.Parameters.AddWithValue("@estado", cliente.Estado);
                executaCmd.Parameters.AddWithValue("@id", cliente.Codigo);

                conexao.Open();
                executaCmd.ExecuteNonQuery();

                MessageBox.Show("Cliente alterado com sucesso!");
                conexao.Close();

            } catch (Exception ex) {

                MessageBox.Show($"Erro {ex}");
            }
        }

        public void ExcluirCliente(Cliente cliente) {
            try {
                string sql = @"delete from tb_clientes where id=@id";

                var executaCmd = new MySqlCommand(sql, conexao);

                executaCmd.Parameters.AddWithValue("@id", cliente.Codigo);

                conexao.Open();
                executaCmd.ExecuteNonQuery();

                MessageBox.Show("Cliente excluído com sucesso!");

                conexao.Close();
            } catch (Exception ex) {

                MessageBox.Show($"Erro {ex}");
            }
        }

        public DataTable BuscarClientesPorNome(string nome) {

            try {
                DataTable tableCliente = new DataTable();
                string sql = "select * from tb_clientes where nome=@nome";

                MySqlCommand executaCmd = new MySqlCommand(sql, conexao);
                executaCmd.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                executaCmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executaCmd);
                da.Fill(tableCliente);

                conexao.Close();
                return tableCliente;

            } catch (Exception ex) {
                MessageBox.Show($"Erro {ex}");
                return null;
            }
        }

        public DataTable ListarClientesPorNome(string nome) {

            try {
                DataTable tableCliente = new DataTable();
                string sql = "select * from tb_clientes where nome like @nome";

                MySqlCommand executaCmd = new MySqlCommand(sql, conexao);
                executaCmd.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                executaCmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executaCmd);
                da.Fill(tableCliente);

                conexao.Close();
                return tableCliente;

            } catch (Exception ex) {
                MessageBox.Show($"Erro {ex}");
                return null;
            }
        }

        public Cliente RetornaClientePorCpf(string cpf) {

            try {
                Cliente cliente = new Cliente();
                string sql = @"select * from tb_clientes where cpf=@cpf";

                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@cpf", cpf);
                
                conexao.Open();
                MySqlDataReader rs = cmd.ExecuteReader();

                if (rs.Read()) {
                    cliente.Codigo = rs.GetInt32("id");
                    cliente.Nome = rs.GetString("nome");

                    conexao.Close();
                    return cliente;
                }
                else {
                    MessageBox.Show("Cliente não encontrado");
                    conexao.Close();
                    return null;
                }
                                
            }
            catch (Exception ex) {
                MessageBox.Show($"Erro: {ex}");
                return null;
            }
        }

    }
}
