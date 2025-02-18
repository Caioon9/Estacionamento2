using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento2.Services
{
    internal class servicos
    {
        ConexaoSQL AcessarConexaoSQL = new ConexaoSQL();

        public void MudarValorEVagas(double valor, int vaga)
        {
            if (vaga > 0 && valor > 0)
            {
                AcessarConexaoSQL.AtualizarValorEVagas(valor, vaga);
            }
        }

        public void CalcularValorEstadia(string placa)
        {
            AcessarConexaoSQL.AtualizarHoraSaida(placa);
            var (horaEntrada, horaSaida, valorHora) = AcessarConexaoSQL.ConsultarHorario(placa);

            // Se algum dos valores for nulo, retorna 0
            if (!horaEntrada.HasValue || !horaSaida.HasValue)
            {
                AcessarConexaoSQL.AtualizarValorEstadia(placa, 0);
                return;
            }

            // Calcula a duração da estadia
            TimeSpan duracao = horaSaida.Value - horaEntrada.Value;
            double totalHoras = duracao.TotalHours;

            // Se o tempo for menor que 15 minutos, não cobra nada
            if (duracao.TotalMinutes < 15)
            {
                AcessarConexaoSQL.AtualizarValorEstadia(placa, 0);
            }
            // Se for entre 15 e 30 minutos, cobra metade do valor da hora
            else if (duracao.TotalMinutes <= 30)
            {
                AcessarConexaoSQL.AtualizarValorEstadia(placa, valorHora / 2);
            }
            // Se for até 1 hora, cobra o valor cheio
            else if (totalHoras <= 1)
            {
                AcessarConexaoSQL.AtualizarValorEstadia(placa, valorHora);
            }
            else
            {
                // Cobra a primeira hora normalmente
                decimal totalPagar = valorHora;
                totalHoras -= 1; // Remove a primeira hora já cobrada

                if (totalHoras > 0)
                {
                    // Se o tempo restante for até 30 minutos depois da primeira hora, cobra 1/4 do valor
                    if (totalHoras <= 0.5)
                    {
                        totalPagar += valorHora / 4;
                    }
                    else
                    {
                        // Cobra metade do valor da hora para cada hora extra completa
                        totalPagar += (decimal)Math.Floor(totalHoras) * (valorHora / 2);

                        // Se sobrar até 30 minutos após as horas cheias, cobra 1/4 do valor
                        if (totalHoras % 1 > 0.5)
                        {
                            totalPagar += valorHora / 4;
                        }
                    }
                }

                AcessarConexaoSQL.AtualizarValorEstadia(placa, totalPagar);
            }


        }



    }
}
