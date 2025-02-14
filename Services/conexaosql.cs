using System;
using System.Data;
using System.Numerics;
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

        //Select
        public (DateTime? horaEntrada, DateTime? horaSaida, decimal valorHora) ConsultarHorario(string placa)
        {
            string query = @"
        SELECT v.HoraEntrada, v.HoraSaida, e.ValorHora 
        FROM veiculos v 
        CROSS JOIN estacionamento e 
        WHERE v.Placa = @Placa AND e.id = 1";

            return ExecutarConsulta(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@Placa", placa);
                using (SqlDataReader reader = cmd.ExecuteReader()) // erro aqui!!!!!!!!!!!!!!!!!!
                {
                    if (reader.Read())
                    {
                        return (
                            reader["HoraEntrada"] as DateTime?,
                            reader["HoraSaida"] as DateTime?,
                            reader.GetDecimal(reader.GetOrdinal("ValorHora"))
                        );
                    }
                }
                return (null, null, 0); // Retorna 0 como valor padrão para ValorHora se não encontrar nada
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
        public (decimal valorHora, int numVagas) ConsultarValorEVaga()
        {
            string query = "SELECT valor_hora, num_vagas FROM estacionamento WHERE id = 1";

            return ExecutarConsulta(query, cmd =>
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        decimal valorHora = reader.GetDecimal(reader.GetOrdinal("valor_hora"));
                        int numVagas = reader.GetInt32(reader.GetOrdinal("num_vagas"));
                        return (valorHora, numVagas);
                    }
                }
                return (0, 0); // Caso não encontre nenhum dado
            });
        }

        // Update 
        public void AtualizarHoraSaida(string placa)
        {
            string query = "UPDATE veiculos SET HoraSaida = @HoraSaida WHERE Placa = @Placa";

            ExecutarComando(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@HoraSaida", DateTime.Now);
                cmd.Parameters.AddWithValue("@Placa", placa);
            });
        }
        public void AtualizarValorEVagas(double valor, int vaga)
        {
            string query = "UPDATE estacionamento SET valor_hora = @Valor_Hora, num_vagas = @Num_Vagas WHERE id = 1";

            ExecutarComando(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@Valor_Hora", valor);
                cmd.Parameters.AddWithValue("@Num_Vagas", vaga);
            });
        }
        public void AtualizarValorEstadia(string placa, decimal valorEstadia)
        {
            // Atualiza o banco de dados
            string query = "UPDATE veiculos SET Valor = @Valor WHERE Placa = @Placa";

            ExecutarComando(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@Valor", valorEstadia);
                cmd.Parameters.AddWithValue("@Placa", placa);
            });
        }


        //DataTable
        public DataTable GridConsultarVeiculosNaoPagos()
        {
            string query = @"
        SELECT v.Placa, v.Modelo, c.Telefone, v.HoraEntrada, v.HoraSaida, v.Valor
        FROM Veiculos v
        INNER JOIN Clientes c ON v.ClienteID = c.ClienteID
        WHERE v.Pago = 0 OR v.Pago IS NULL";

            return ExecutarConsulta(query, cmd =>
            {
                DataTable dt = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
                return dt;
            });
        }



    }
}
