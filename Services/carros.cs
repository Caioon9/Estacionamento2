namespace Estacionamento2.Services
{
    public class Carro
    {
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
    }
}
