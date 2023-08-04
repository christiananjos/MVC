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
        public IHistoricoImportacaoCNABRepository HistoricoImportacoes { get; }
        public ITransacaoRepository Transacoes { get; }
        public IUsuarioVerificacaoRepository usuarioVerificacoes { get; }

        public UnitOfWork(Context dbContext, IClienteRepository clienteRepository, IUsuarioRepository usuarioRepository, IEnderecoRepository enderecoRepository, ILogRepository logsRepository, IHistoricoImportacaoCNABRepository historicoImportacoesRepository, ITransacaoRepository transacoesRepository, IUsuarioVerificacaoRepository usuarioVerificacoesRepository)
        {
            _dbContext = dbContext;
            Clientes = clienteRepository;
            Usuarios = usuarioRepository;
            Enderecos = enderecoRepository;
            Logs = logsRepository;
            HistoricoImportacoes = historicoImportacoesRepository;
            Transacoes = transacoesRepository;
            usuarioVerificacoes = usuarioVerificacoesRepository;
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
