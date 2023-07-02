using Microsoft.EntityFrameworkCore;
using Site.Interfaces;
using Site.Models;

namespace Site.Data
{
    public class Context : DbContext, IUnitOfWork
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public void Save()
        {
            base.SaveChanges();
        }
    }
}
