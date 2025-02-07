using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento2.Services
{

    public class Cliente()
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }


        public Cliente Adicionar(string nome, string cpf, string telefone, string email)
        {
            return new Cliente
            {
                Nome = nome.ToUpper(),
                CPF = cpf,
                Telefone = telefone,
                Email = email
            };
        }
    }
}
