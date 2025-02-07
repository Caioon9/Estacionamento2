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

        // Método para inserir cliente e veículo ao mesmo tempo
        public void InserirClienteEVeiculo(Cliente cliente, Carro carro)
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
                  OUTPUT INSERTED.ClienteID 
                  VALUES (@Nome, @CPF, @Telefone, @Email)", conexao, transaction))
                    {
                        cmdCliente.Parameters.AddWithValue("@Nome", cliente.Nome);
                        cmdCliente.Parameters.AddWithValue("@CPF", cliente.CPF);
                        cmdCliente.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                        cmdCliente.Parameters.AddWithValue("@Email", cliente.Email);

                        clienteId = (int)cmdCliente.ExecuteScalar(); // Obtém o ID do cliente recém-inserido
                    }

                    // Inserir Veículo com o ID do Cliente
                    using (SqlCommand cmdVeiculo = new SqlCommand(
                        @"INSERT INTO Veiculos (ClienteID, Placa, Modelo, Cor, Marca, Ano, Vaga, HoraEntrada, HoraSaida) 
                  VALUES (@ClienteID, @Placa, @Modelo, @Cor, @Marca, @Ano, @Vaga, @HoraEntrada, NULL)", conexao, transaction))
                    {
                        cmdVeiculo.Parameters.AddWithValue("@ClienteID", clienteId);
                        cmdVeiculo.Parameters.AddWithValue("@Placa", carro.Placa);
                        cmdVeiculo.Parameters.AddWithValue("@Modelo", carro.Modelo);
                        cmdVeiculo.Parameters.AddWithValue("@Cor", (object)carro.Cor ?? DBNull.Value);
                        cmdVeiculo.Parameters.AddWithValue("@Marca", (object)carro.Marca ?? DBNull.Value);
                        cmdVeiculo.Parameters.AddWithValue("@Ano", (object)carro.Ano ?? DBNull.Value);
                        cmdVeiculo.Parameters.AddWithValue("@Vaga", carro.Vaga);
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
            string query = "SELECT HoraEntrada, HoraSaida FROM veiculos WHERE Placa = @Placa";

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

        public List<int> ConsultarVagasOcupadas()
        {
            string query = "SELECT Vaga FROM veiculos WHERE Pago = 0 OR Pago IS NULL";


            return ExecutarConsulta(query, cmd =>
            {
                List<int> vagas = new List<int>();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vagas.Add(reader.GetInt32(reader.GetOrdinal("Vaga")));
                    }
                }
                return vagas;
            });
        }



        // Atualizar hora de saída de um veículo
        public void AtualizarHoraSaida(string placa)
        {
            string query = "UPDATE veiculos SET HoraSaida = @HoraSaida WHERE Placa = @Placa";

            ExecutarComando(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@HoraSaida", DateTime.Now);
                cmd.Parameters.AddWithValue("@Placa", placa);
            });
        }
    }
}
