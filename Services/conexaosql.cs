using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Estacionamento2.Services
{
    internal class ConexaoSQL
    {
        private readonly string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\caioo\\EstacionamentoBase.mdf;Integrated Security=True;Connect Timeout=30";

        // Método para executar comandos que não retornam dados (INSERT, UPDATE, DELETE)
        private void ExecutarComando(string query, Action<SqlCommand> parametroAcao)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conexao))
                {
                    parametroAcao(cmd);
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Método para executar consultas que retornam dados (SELECT)
        private T ExecutarConsulta<T>(string query, Func<SqlCommand, T> leituraAcao)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conexao))
                {
                    conexao.Open();
                    return leituraAcao(cmd);
                }
            }
        }

        // Inserir um novo cliente e retornar o ID gerado
        public int InserirCliente(string nome, string cpf, string telefone, string email)
        {
            string query = @"INSERT INTO Clientes (Nome, CPF, Telefone, Email) 
                             OUTPUT INSERTED.ID 
                             VALUES (@Nome, @CPF, @Telefone, @Email)";

            return ExecutarConsulta(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@CPF", cpf);
                cmd.Parameters.AddWithValue("@Telefone", telefone);
                cmd.Parameters.AddWithValue("@Email", email);
                return (int)cmd.ExecuteScalar(); // Retorna o ID gerado
            });
        }

        // Inserir um novo veículo e associá-lo ao cliente pelo ID
        public void InserirVeiculo(int clienteId, string placa, string modelo, string cor, string marca, string ano, int vaga)
        {
            string query = @"INSERT INTO Veiculos (ID, Placa, Modelo, Cor, Marca, Ano, Vaga, HoraEntrada, HoraSaida) 
                             VALUES (@ID, @Placa, @Modelo, @Cor, @Marca, @Ano, @Vaga, @HoraEntrada, NULL)";

            ExecutarComando(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@ID", clienteId);
                cmd.Parameters.AddWithValue("@Placa", placa);
                cmd.Parameters.AddWithValue("@Modelo", modelo);
                cmd.Parameters.AddWithValue("@Cor", cor);
                cmd.Parameters.AddWithValue("@Marca", marca);
                cmd.Parameters.AddWithValue("@Ano", ano);
                cmd.Parameters.AddWithValue("@Vaga", vaga);
                cmd.Parameters.AddWithValue("@HoraEntrada", DateTime.Now);
            });
        }

        // Método para inserir cliente e veículo ao mesmo tempo
        public void InserirClienteEVeiculo(string nome, string cpf, string telefone, string email,
                                           string placa, string modelo, string cor, string marca, string ano, int vaga)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();
                SqlTransaction transaction = conexao.BeginTransaction(); // Inicia uma transação

                try
                {
                    int clienteId;

                    // Inserir Cliente e obter ID gerado
                    using (SqlCommand cmdCliente = new SqlCommand(
                        @"INSERT INTO Clientes (Nome, CPF, Telefone, Email) 
                          OUTPUT INSERTED.ID 
                          VALUES (@Nome, @CPF, @Telefone, @Email)", conexao, transaction))
                    {
                        cmdCliente.Parameters.AddWithValue("@Nome", nome);
                        cmdCliente.Parameters.AddWithValue("@CPF", cpf);
                        cmdCliente.Parameters.AddWithValue("@Telefone", telefone);
                        cmdCliente.Parameters.AddWithValue("@Email", email);

                        clienteId = (int)cmdCliente.ExecuteScalar(); // Obtém o ID do cliente recém-inserido
                    }

                    // Inserir Veículo com o ID do Cliente
                    using (SqlCommand cmdVeiculo = new SqlCommand(
                        @"INSERT INTO Veiculos (ID, Placa, Modelo, Cor, Marca, Ano, Vaga, HoraEntrada, HoraSaida) 
                          VALUES (@ID, @Placa, @Modelo, @Cor, @Marca, @Ano, @Vaga, @HoraEntrada, NULL)", conexao, transaction))
                    {
                        cmdVeiculo.Parameters.AddWithValue("@ID", clienteId);
                        cmdVeiculo.Parameters.AddWithValue("@Placa", placa);
                        cmdVeiculo.Parameters.AddWithValue("@Modelo", modelo);
                        cmdVeiculo.Parameters.AddWithValue("@Cor", cor);
                        cmdVeiculo.Parameters.AddWithValue("@Marca", marca);
                        cmdVeiculo.Parameters.AddWithValue("@Ano", ano);
                        cmdVeiculo.Parameters.AddWithValue("@Vaga", vaga);
                        cmdVeiculo.Parameters.AddWithValue("@HoraEntrada", DateTime.Now);

                        cmdVeiculo.ExecuteNonQuery();
                    }

                    transaction.Commit(); // Confirma a transação se tudo deu certo
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Cancela as alterações em caso de erro
                    Console.WriteLine("Erro ao inserir cliente e veículo: " + ex.Message);
                }
            }
        }

        // Consultar horário de entrada e saída
        public (DateTime? horaEntrada, DateTime? horaSaida) ConsultarHorario(string placa)
        {
            string query = "SELECT HoraEntrada, HoraSaida FROM Veiculos WHERE Placa = @Placa";

            return ExecutarConsulta(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@Placa", placa);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return (reader["HoraEntrada"] as DateTime?, reader["HoraSaida"] as DateTime?);
                    }
                }
                return (null, null);
            });
        }

        // Atualizar hora de saída de um veículo
        public void AtualizarHoraSaida(string placa)
        {
            string query = "UPDATE Veiculos SET HoraSaida = @HoraSaida WHERE Placa = @Placa";

            ExecutarComando(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@HoraSaida", DateTime.Now);
                cmd.Parameters.AddWithValue("@Placa", placa);
            });
        }
    }
}
