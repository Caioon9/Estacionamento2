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
                AcessarConexaoSQL.AtualizarValorEstadia(placa, 0);

            // Calcula a duração da estadia
            TimeSpan duracao = horaSaida.Value - horaEntrada.Value;
            double totalHoras = duracao.TotalHours;

            if (totalHoras <= 0.5) // Até 30 minutos cobra metade
            {
                AcessarConexaoSQL.AtualizarValorEstadia(placa, (valorHora / 2));
            }
            else // A partir de 30 minutos, cobra a hora completa
            {
                AcessarConexaoSQL.AtualizarValorEstadia(placa, (valorHora * (decimal)Math.Ceiling(totalHoras)));
            }

        }



    }
}
