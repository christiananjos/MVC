using Microsoft.EntityFrameworkCore;
using Site.Models;

namespace Site.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options): base(options)
        { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<HistoricoImportacaoCNAB> HistoricoImportacaoCNABs { get; set; }
        public DbSet<UsuarioVerificacao> UsuarioVerificacoes { get; set; }

    }
}
