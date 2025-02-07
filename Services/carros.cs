using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Estacionamento2.Services
{
    public class Carro
    {
        ConexaoSQL AcessarConexaoSQL = new ConexaoSQL();
        List<int> VagasOcupadas = new List<int>();

        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Marca { get; set; }
        public string Ano { get; set; }
        public int Vaga { get; set; }

        public Carro Adicionar(string placa, string modelo, string cor, string marca, string ano, int vaga)
        {
            return new Carro
            {
                Placa = placa.ToUpper(),
                Modelo = modelo,
                Cor = cor,
                Marca = marca,
                Ano = ano,
                Vaga = vaga
            };
        }

        public bool VerificarInformacoes(Carro carro)
        {
            try
            {
                if (VerificarPlaca(carro.Placa) == true && VerificarVaga(carro.Vaga) == true)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar veículo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool VerificarPlaca(string Placa)
        {
            if (Placa.Length != 7)
            {
                MessageBox.Show("Placa inválida");
                return false;
            }
            else if (!Char.IsDigit(Placa[3]) || !Char.IsDigit(Placa[5]) || !Char.IsDigit(Placa[6]))
            {
                MessageBox.Show("Placa inválida");
                return false;
            }
            for (int i = 0; i < 3; i++)
            {
                if (!Char.IsLetter(Placa[i]))
                {
                    MessageBox.Show("Placa inválida");
                    return false;
                }
            }
            return true;
        }

        private bool VerificarVaga(int vaga)
        {
            List<int> vagasOcupadas = AcessarConexaoSQL.ConsultarVagasOcupadas();

            if (vaga < 0 || vaga > 31)
            {
                MessageBox.Show("Vaga inválida");
                return false;
            }
            else if (vagasOcupadas.Contains(vaga))
            {
                MessageBox.Show("Vaga ocupada");
                return false;
            }

            return true;
        }
    }
}
