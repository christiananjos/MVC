using System.ComponentModel.DataAnnotations;

namespace Site.Models
{
    public class Usuario : Base
    {
        public Usuario(string usernaname, string password)
        {
            Usernaname = usernaname;
            Password = password;
        }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Usernaname")]
        [DataType(DataType.EmailAddress)]
        public string Usernaname { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
