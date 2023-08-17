using System.ComponentModel.DataAnnotations;

namespace Site.Models
{
    public class Endereco : Base
    {
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
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Principal")]
        public bool Principal { get; set; }
    }
}
