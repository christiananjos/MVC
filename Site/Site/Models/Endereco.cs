namespace Site.Models
{
    public class Endereco : IBase
    {
        public Endereco(Guid clienteId, string logradouro, int numero, string complemento, int cep, char uf, string estado)
        {
            ClienteId = clienteId;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            CEP = cep;
            UF = uf;
            Estado = estado;
        }

        public Guid Id { get; set; }
        //public Cliente Cliente { get; set; }
        public Guid ClienteId { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public int CEP { get; set; }
        public char UF { get; set; }
        public string Estado { get; set; }
    }
}
