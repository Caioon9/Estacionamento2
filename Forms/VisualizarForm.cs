using Estacionamento2.Services;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
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
    public partial class VisualizarForm : Form
    {
        ConexaoSQL AcessarConexaoSQL = new ConexaoSQL();
        servicos AcessarServicos = new servicos();
        public VisualizarForm()
        {
            InitializeComponent();
            ListarVeiculosNaoPagos();
        }

        private void buttonAtualizar_Click(object sender, EventArgs e)
        {
            ListarVeiculosNaoPagos();
        }

        private void buttonCalcular_Click(object sender, EventArgs e)
        {
            if (dataGridViewVisualizar.SelectedRows.Count > 0) // Verifica se há uma linha selecionada
            {
                DataGridViewRow linhaSelecionada = dataGridViewVisualizar.SelectedRows[0]; // Obtém a primeira linha selecionada
                string placa = linhaSelecionada.Cells["Placa"].Value.ToString(); // Obtém o valor da célula "Placa"
                AcessarServicos.CalcularValorEstadia(placa);
                ListarVeiculosNaoPagos();
            }
            else
            {
                MessageBox.Show("Selecione uma linha primeiro.");
            }

        }

        private void buttonProcurar_Click(object sender, EventArgs e)
        {
            listarVeiculoPelaPlaca(textBoxplaca.Text);
        }

        private void buttonFechar_Click(object sender, EventArgs e)
        {
            string Placa = dataGridViewVisualizar.SelectedRows[0].Cells["Placa"].Value.ToString();
            try
            {
                if (AcessarConexaoSQL.VerificarFechamento(Placa))
                {
                    AcessarConexaoSQL.AtualizarStatusPagamento(Placa);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao fechar vaga: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ListarVeiculosNaoPagos()
        {
            dataGridViewVisualizar.DataSource = AcessarConexaoSQL.GridConsultarVeiculosNaoPagos();
        }

        private void listarVeiculoPelaPlaca(string placa)
        {
            dataGridViewVisualizar.DataSource = AcessarConexaoSQL.GridConsultarVeiculoPorPlaca(placa.ToUpper());
        }


    }
}
