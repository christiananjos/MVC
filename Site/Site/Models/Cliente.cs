using System.ComponentModel.DataAnnotations;

namespace Site.Models
{
    public class Cliente
    {
        public Cliente(string nome, string email, string avatarPath)
        {
            Nome = nome;
            Email = email;
            AvatarPath = avatarPath;
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Nome")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Avatar")]
        public string AvatarPath { get; set; }

        [Display(Name = "Endereco")]
        public List<Endereco> Enderecos { get; set; }

    }
}
