using System.ComponentModel.DataAnnotations;

namespace Site.Models
{
    public class UsuarioVerificacao : Base
    {
        [Display(Name = "UsuarioId")]
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string Code { get; set; }
    }
}
