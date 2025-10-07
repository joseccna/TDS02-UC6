namespace NovoEstacionamento.Models
{
    internal class Veiculo
    {

        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }

    }
}
