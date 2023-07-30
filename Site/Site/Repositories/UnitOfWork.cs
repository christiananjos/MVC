using Site.Data;
using Site.Interfaces;
using Site.Repositories.Interfaces;

namespace Site.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _dbContext;
        public IUsuarioRepository Usuarios { get; }
        public IClienteRepository Clientes { get; }
        public IEnderecoRepository Enderecos { get; }
        public ILogRepository Logs { get; }

        public UnitOfWork(Context dbContext, IClienteRepository clienteRepository, IUsuarioRepository usuarioRepository, IEnderecoRepository enderecoRepository, ILogRepository logs)
        {
            _dbContext = dbContext;
            Clientes = clienteRepository;
            Usuarios = usuarioRepository;
            Enderecos = enderecoRepository;
            Logs = logs;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
