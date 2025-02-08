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

        public bool VerificarInformacoes(Cliente cliente)
        {
            try
            {
                if (VerificarCPF(cliente.CPF) == true && cliente.Telefone.Any(char.IsLetter) != true)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool VerificarCPF(string CPF)
        {
            CPF = CPF.Trim().Replace(".", "").Replace("-", "");

            if (CPF.Length != 11 || CPF.Distinct().Count() == 1)
            {
                MessageBox.Show("CPF inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            int primeiroDigito = CalcularDigito(CPF, 10);
            int segundoDigito = CalcularDigito(CPF, 11);

            if (primeiroDigito != CPF[9] - '0' || segundoDigito != CPF[10] - '0')
            {
                MessageBox.Show("CPF inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            return true;
        }
        static int CalcularDigito(string cpf, int pesoInicial)
        {
            int soma = 0;
            for (int i = 0; i < pesoInicial - 1; i++)
            {
                soma += (cpf[i] - '0') * (pesoInicial - i);
            }

            int resto = soma % 11;
            return resto < 2 ? 0 : 11 - resto;
        }
    }
}
