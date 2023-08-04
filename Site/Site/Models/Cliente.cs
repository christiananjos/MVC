using System.ComponentModel.DataAnnotations;

namespace Site.Models
{
    public class Cliente : Base
    {
        public Cliente(string nome, string email, string cpfCnpj, string avatarPath)
        {
            Nome = nome;
            Email = email;
            CpfCnpj = cpfCnpj;
            AvatarPath = avatarPath;
        }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "CpfCnpj")]
        public string CpfCnpj { get; set; }

        [Display(Name = "Avatar")]
        public string AvatarPath { get; set; }

        [Display(Name = "Endereco")]
        public List<Endereco> Enderecos { get; set; }

    }
}
