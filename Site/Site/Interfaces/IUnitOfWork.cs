using Site.Repositories.Interfaces;

namespace Site.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository Usuarios { get; }
        IClienteRepository Clientes { get; }
        IEnderecoRepository Enderecos { get; }
        ILogRepository Logs { get; }
        int Save();
    }
}
