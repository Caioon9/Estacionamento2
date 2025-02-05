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
    public partial class AdicionarVeiculoForm : Form
    {
        ConexaoSQL AcesarConexaoSql = new ConexaoSQL();
        // carros AcesarCarrosClasse = new carros(); Ainda não fiz tudo por aqui
        public AdicionarVeiculoForm()
        {
            InitializeComponent();
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
           // AcesarConexaoSql.InserirCliente(); fazer ele adicionar apartir da classe
        }
    }
}
