using MySql.Data.MySqlClient;
using ProjetoControleDeVendas.Conexao;
using ProjetoControleDeVendas.Model;
using ProjetoControleDeVendas.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleDeVendas.DAO {
    internal class FuncionarioDAO {

        private MySqlConnection conexao;

        public FuncionarioDAO() {
            this.conexao = new ConnectionFactory().GetConnection();
        }

        public void CadastrarFuncionario(Funcionario funcionario) {
            try {

                string sql = @"insert into tb_funcionarios(nome,rg,cpf,email,senha,cargo,nivel_acesso,telefone,celular,cep,endereco,numero,complemento,bairro,cidade,estado) 
                              values (@nome,@rg,@cpf,@email,@senha,@cargo,@nivel_acesso,@telefone,@celular,@cep,@endereco,@numero,@complemento,@bairro,@cidade,@estado)";

                MySqlCommand executaCmd = new MySqlCommand(sql, conexao);

                executaCmd.Parameters.AddWithValue("@nome", funcionario.Nome);
                executaCmd.Parameters.AddWithValue("@rg", funcionario.RG);
                executaCmd.Parameters.AddWithValue("@cpf", funcionario.CPF);
                executaCmd.Parameters.AddWithValue("@email", funcionario.Email);
                executaCmd.Parameters.AddWithValue("@senha", funcionario.Senha);
                executaCmd.Parameters.AddWithValue("@cargo", funcionario.Cargo);
                executaCmd.Parameters.AddWithValue("@nivel_acesso", funcionario.Acesso);
                executaCmd.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                executaCmd.Parameters.AddWithValue("@celular", funcionario.Celular);
                executaCmd.Parameters.AddWithValue("@cep", funcionario.CEP);
                executaCmd.Parameters.AddWithValue("@endereco", funcionario.Endereco);
                executaCmd.Parameters.AddWithValue("@numero", funcionario.Numero);
                executaCmd.Parameters.AddWithValue("@complemento", funcionario.Complemento);
                executaCmd.Parameters.AddWithValue("@bairro", funcionario.Bairro);
                executaCmd.Parameters.AddWithValue("@cidade", funcionario.Cidade);
                executaCmd.Parameters.AddWithValue("@estado", funcionario.Estado);

                conexao.Open();
                executaCmd.ExecuteNonQuery();

                MessageBox.Show("Funcionário cadastrado com sucesso");
                conexao.Close();
            } 
            catch (Exception ex) {
                MessageBox.Show($"Erro: {ex}");
            }
        }

        public void AlterarFuncionario(Funcionario funcionario) {
            try {

                string sql = @"update tb_funcionarios set nome=@nome,rg=@rg,cpf=@cpf,email=@email,senha=@senha,cargo=@cargo
                ,nivel_acesso=@nivel_acesso,telefone=@telefone,celular=@celular,cep=@cep,endereco=@endereco,numero=@numero
                ,complemento=@complemento,bairro=@bairro,cidade=@cidade,estado=@estado where id=@id";
                MySqlCommand executaCmd = new MySqlCommand(sql, conexao);

                executaCmd.Parameters.AddWithValue("@nome", funcionario.Nome);
                executaCmd.Parameters.AddWithValue("@rg", funcionario.RG);
                executaCmd.Parameters.AddWithValue("@cpf", funcionario.CPF);
                executaCmd.Parameters.AddWithValue("@email", funcionario.Email);
                executaCmd.Parameters.AddWithValue("@senha", funcionario.Senha);
                executaCmd.Parameters.AddWithValue("@cargo", funcionario.Cargo);
                executaCmd.Parameters.AddWithValue("@nivel_acesso", funcionario.Acesso);
                executaCmd.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                executaCmd.Parameters.AddWithValue("@celular", funcionario.Celular);
                executaCmd.Parameters.AddWithValue("@cep", funcionario.CEP);
                executaCmd.Parameters.AddWithValue("@endereco", funcionario.Endereco);
                executaCmd.Parameters.AddWithValue("@numero", funcionario.Numero);
                executaCmd.Parameters.AddWithValue("@complemento", funcionario.Complemento);
                executaCmd.Parameters.AddWithValue("@bairro", funcionario.Bairro);
                executaCmd.Parameters.AddWithValue("@cidade", funcionario.Cidade);
                executaCmd.Parameters.AddWithValue("@estado", funcionario.Estado);
                executaCmd.Parameters.AddWithValue("@id", funcionario.Codigo);

                conexao.Open();
                executaCmd.ExecuteNonQuery();

                MessageBox.Show("Funcionário alterado com sucesso");
                conexao.Close();
            } catch (Exception ex) {
                MessageBox.Show($"Erro: {ex}");
            }
        }

        public void DeletarFuncionario(Funcionario funcionario) {
            try {

                string sql = "delete from tb_funcionarios where id=@codigo";
                MySqlCommand executaCmd = new MySqlCommand(sql, conexao);

                executaCmd.Parameters.AddWithValue("@codigo", funcionario.Codigo);

                conexao.Open();
                executaCmd.ExecuteNonQuery();

                MessageBox.Show("Funcionário excluído com sucesso");
                conexao.Close();
            }
            catch (Exception ex) {
                MessageBox.Show($"Erro: {ex}");
            }
        }

        public DataTable ListarFuncionarios() {

            try {
                DataTable tableFuncionario = new DataTable();
                string sql = "select * from tb_funcionarios";

                MySqlCommand executaCmd = new MySqlCommand(sql, conexao);

                conexao.Open();
                executaCmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executaCmd);
                da.Fill(tableFuncionario);

                conexao.Close();
                return tableFuncionario;

            } catch (Exception ex) {
                MessageBox.Show($"Erro {ex}");
                return null;
            }
        }

        public DataTable BuscarFuncionariosPorNome(string nome) {

            try {
                DataTable tableFuncionario = new DataTable();
                string sql = "select * from tb_funcionarios where nome=@nome";

                MySqlCommand executaCmd = new MySqlCommand(sql, conexao);

                executaCmd.Parameters.AddWithValue("@nome", nome); 

                conexao.Open();
                executaCmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executaCmd);
                da.Fill(tableFuncionario);

                conexao.Close();
                return tableFuncionario;

            } catch (Exception ex) {
                MessageBox.Show($"Erro {ex}");
                return null;
            }
        }

        public DataTable ListarFuncionariosPorNome(string nome) {

            try {
                DataTable tableFuncionario = new DataTable();
                string sql = "select * from tb_funcionarios where nome like @nome";

                MySqlCommand executaCmd = new MySqlCommand(sql, conexao);
                executaCmd.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                executaCmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(executaCmd);
                da.Fill(tableFuncionario);

                conexao.Close();
                return tableFuncionario;

            } catch (Exception ex) {
                MessageBox.Show($"Erro {ex}");
                return null;
            }
        }

        public bool Login(string email, string senha) {
            try {
                string sql = @"SELECT * FROM bdvendas.tb_funcionarios 
                                where email = @email and senha = @senha";

                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@senha", senha);
                
                conexao.Open();
                MySqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read()) {

                    string nivel = rd.GetString("nivel_acesso");
                    string nome = rd.GetString("nome");

                    FrmMenu menu = new FrmMenu();
                    menu.txtUsuario.Text = nome;

                    if (nivel.Equals("Administrativo")) { 
                        
                        menu.Show();

                    } 
                    else {

                        menu.menuProdutos.Visible = false;
                        menu.menuHistoricoVenda.Visible = false;
                        menu.menuFuncionarios.Visible = false;
                        menu.menuFornecedores.Visible = false;
                        menu.Show();

                    }

                    return true;
                } 
                else {
                    MessageBox.Show("Senha ou email incorretos");
                    return false;
                }
            } 
            catch (Exception ex) {
                MessageBox.Show($"Erro: {ex}");
                return false;
            }
        }
    }
}
