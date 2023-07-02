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
        public string Usernaname { get; set; }
        public string Password { get; set; }
        public bool Ativo { get; set; }
    }
}
