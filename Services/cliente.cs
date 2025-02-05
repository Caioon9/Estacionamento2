using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento2.Services
{
    internal class cliente
    {
        public class Cliente() 
        {
            public string Nome { get; set; }
            public string CPF { get; set; }
            public string Telefone { get; set; }
            public string Email { get; set; }
            public string Endereco { get; set; }
        }
    }
}
