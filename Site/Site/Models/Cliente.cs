namespace Site.Models
{
    public class Cliente : IBase
    {
        public Cliente(string nome, string email, string avatarPath)
        {
            Nome = nome;
            Email = email;
            AvatarPath = avatarPath;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string AvatarPath { get; set; }
        public List<Endereco> Enderecos { get; set; }

    }
}
