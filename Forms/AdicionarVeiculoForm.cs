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
        Carro AcesarCarro = new Carro();
        ConexaoSQL AcesarConexaoSql = new ConexaoSQL();
        // carros AcesarCarrosClasse = new carros(); Ainda não fiz tudo por aqui
        public AdicionarVeiculoForm()
        {
            InitializeComponent();
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
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
            AcesarConexaoSql.InserirVeiculo(carro);

        }
    }
}
