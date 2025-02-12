using Estacionamento2.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estacionamento2.Forms
{
    public partial class OpcoesForm : Form
    {
        servicos AcessarServicos = new servicos();
        ConexaoSQL AcessarConexaoSQL = new ConexaoSQL();

        public OpcoesForm()
        {


            InitializeComponent();
            AdicionarValoresCampos();

        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            if (VerificarCampos(textBoxValor.Text, textBoxVaga.Text))
            {
                double valor = Convert.ToDouble(textBoxValor.Text);
                int vaga = Convert.ToInt32(textBoxVaga.Text);
                AcessarServicos.MudarValorEVagas(valor, vaga);
                AdicionarValoresCampos();
            }
        }

        private void AdicionarValoresCampos()
        {
            var (valorHora, numVagas) = AcessarConexaoSQL.ConsultarValorEVaga();
            textBoxValor.Text = valorHora.ToString();  
            textBoxVaga.Text = numVagas.ToString();
        }

        private bool VerificarCampos(string Valor, string Vaga)
        {
            if (textBoxValor.Text == "" || textBoxVaga.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
                return false;
            }
            else if (Valor.Any(c => char.IsLetter(c) || Vaga.Any(c => char.IsLetter(c))))
            {
                MessageBox.Show("Os campos não podem conter letras!");
                return false;
            }
            return true;
        }
    }
}
