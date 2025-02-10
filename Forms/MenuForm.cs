using Estacionamento2.Forms;

namespace Estacionamento2
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            AdicionarVeiculoForm InterfaceVeiculo = new AdicionarVeiculoForm();
            InterfaceVeiculo.Show();
        }

        private void buttonVisualizar_Click(object sender, EventArgs e)
        {

        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {

        }

        private void buttonOpcoes_Click(object sender, EventArgs e)
        {
            OpcoesForm InterfaceOpcoes = new OpcoesForm();
            InterfaceOpcoes.Show();
        }
    }
}
