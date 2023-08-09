using Site.Models;
using Site.Models.Extrato;

namespace Site.Services.Interfaces
{
    public interface ITransacaoService : IBaseService<Transacao>
    {
        Task<IEnumerable<Transacao>> GetTransacoesByNomeLoja(string nome);
        Task<TransacaoSaldo> CalculaTransacoes(string nome);
    }
}
