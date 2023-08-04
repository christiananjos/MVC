using Site.Repositories.Interfaces;

namespace Site.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IUsuarioRepository Usuarios { get; }
        public IClienteRepository Clientes { get; }
        public IEnderecoRepository Enderecos { get; }
        public ILogRepository Logs { get; }
        public IHistoricoImportacaoCNABRepository HistoricoImportacoes { get; }
        public ITransacaoRepository Transacoes { get; }
        public IUsuarioVerificacaoRepository usuarioVerificacoes { get; }
        int Save();
    }
}
