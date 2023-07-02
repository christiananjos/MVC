using System.ComponentModel.DataAnnotations;

namespace Site.Models
{
    public class Usuario : IBase
    {
        public Usuario(string usernaname, string password, bool ativo)
        {
            Usernaname = usernaname;
            Password = password;
            Ativo = ativo;
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Usernaname")]
        [DataType(DataType.EmailAddress)]
        public string Usernaname { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }
    }
}
