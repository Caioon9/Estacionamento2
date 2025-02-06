using Estacionamento2.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Estacionamento2.Forms
{
    public partial class AdicionarVeiculoForm : Form
    {
        Carro AcesarCarrosClasse = new Carro();
        ConexaoSQL AcesarConexaoSql = new ConexaoSQL();
        public AdicionarVeiculoForm()
        {
            InitializeComponent();
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                Carro carro = new Carro();
                carro = carro.Adicionar(
                    textBoxPlaca.Text,
                    textBoxModelo.Text,
                    comboBoxCor.Text,
                    comboBoxMarca.Text,
                    textBoxAno.Text,
                    Convert.ToInt32(comboBoxVaga.Text)
                    );

                if (VerificarInformacoes(carro) == true)
                {
                    AcesarConexaoSql.InserirVeiculo(carro);
                }
                else
                {
                    MessageBox.Show("Erro ao adicionar veículo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar veículo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool VerificarInformacoes(Carro carro)
        {
            try
            {
                if (carro.Placa.Length != 7)
                {
                    MessageBox.Show("Placa inválida");
                    return false;
                }
                else if (!Char.IsDigit(carro.Placa[3]) || !Char.IsDigit(carro.Placa[5]) || !Char.IsDigit(carro.Placa[6]))
                {
                    MessageBox.Show("Placa inválida");
                    return false;
                }
                for (int i = 0; i < 3; i++)
                {
                    if (!Char.IsLetter(carro.Placa[i]))
                    {
                        MessageBox.Show("Placa inválida");
                        return false;
                    }
                }

                if (carro.Vaga < 0 || carro.Vaga > 31)
                {
                    MessageBox.Show("Vaga inválida");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar veículo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
    }
}
