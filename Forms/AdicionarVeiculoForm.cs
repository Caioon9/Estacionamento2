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
            AdicionarValoresComboBox();
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();
                Carro carro = new Carro();

                cliente = cliente.Adicionar(
                    textBoxNome.Text,
                    textBoxCpf.Text,
                    textBoxTelefone.Text,
                    textBoxEmail.Text
                    );
                carro = carro.Adicionar(
                    textBoxPlaca.Text,
                    textBoxModelo.Text,
                    comboBoxCor.Text,
                    comboBoxMarca.Text,
                    textBoxAno.Text,
                    Convert.ToInt32(comboBoxVaga.Text)
                    );

                if (AcesarCarrosClasse.VerificarInformacoes(carro) == true)
                {
                    AcesarConexaoSql.InserirClienteEVeiculo(cliente, carro);
                    AdicionarValoresComboBox();
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

        private void AdicionarValoresComboBox()
        {
            List<int> vagasOcupadas = AcesarConexaoSql.ConsultarVagasOcupadas();

            for (int i = 1; i < 31; i++)
            {
                if (!vagasOcupadas.Contains(i))
                    comboBoxVaga.Items.Add(i);
            }
        }
    }
}
