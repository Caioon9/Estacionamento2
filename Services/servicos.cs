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

    }
}
