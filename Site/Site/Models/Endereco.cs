using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Site.Models
{
    public class Endereco : Base
    {
        //public Endereco(Guid clienteId, string logradouro, int numero, string complemento, int cep, char uf, string estado)
        //{
        //    ClienteId = clienteId;
        //    Logradouro = logradouro;
        //    Numero = numero;
        //    Complemento = complemento;
        //    CEP = cep;
        //    UF = uf;
        //    Estado = estado;
        //}

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "ClienteId")]
        public Guid ClienteId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Numero")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "CEP")]
        public int CEP { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "UF")]
        public char UF { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Estado")]
        public string Estado { get; set; }
    }
}
