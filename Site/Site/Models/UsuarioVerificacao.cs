namespace Site.Models
{
    public class UsuarioVerificacao : Base
    {
        public Guid UsuarioId { get; set; }
        public string Code { get; set; }
    }
}
