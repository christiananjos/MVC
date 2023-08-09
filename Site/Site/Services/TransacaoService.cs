using Site.Interfaces;
using Site.Models;
using Site.Models.Extrato;
using Site.Services.Interfaces;
using System.Linq;

namespace Site.Services
{
    public class TransacaoService : ITransacaoService
    {
        public IUnitOfWork _unitOfWork;

        public TransacaoService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<bool> Add(Transacao entity)
        {
            if (entity != null)
            {
                entity.CreatedAt = DateTime.Now;

                await _unitOfWork.Transacoes.Add(entity);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> Delete(Guid id)
        {
            if (id.ToString() != null)
            {
                var transacao = await _unitOfWork.Transacoes.GetById(id);

                if (transacao != null)
                {
                    transacao.RemovedAt = DateTime.Now;

                    _unitOfWork.Transacoes.Delete(transacao);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Transacao>> GetAll()
        {
            var transacoes = await _unitOfWork.Transacoes.GetAll();

            return transacoes;
        }

        public async Task<Transacao> GetById(Guid id)
        {
            var transacao = await _unitOfWork.Transacoes.GetById(id);
            return transacao;
        }

        public async Task<IEnumerable<Transacao>> GetTransacoesByNomeLoja(string nome)
        {
            var transacao = await _unitOfWork.Transacoes.GetByConditionAsync(x => x.NomeLoja == nome);
            return transacao;
        }

        public async Task<TransacaoSaldo> CalculaTransacoes(string nome)
        {
            var transacao = await _unitOfWork.Transacoes.GetByConditionAsync(x => x.NomeLoja == nome);

            double saldo = 0;

            int[] rangeEntrada = { 1, 4, 5, 6, 7, 8 };
            int[] rangeSaida = { 2, 3, 9 };

            foreach (var item in transacao)
            {
                if (rangeEntrada.Contains((int)item.TipoTransacao))
                {
                    //Soma
                    saldo += item.Valor;
                }

                if (rangeSaida.Contains((int)item.TipoTransacao))
                {
                    //Subtração
                    saldo -= item.Valor;
                }
            }

            var extrato = new TransacaoSaldo(transacao, saldo);

            return extrato;
        }

        public async Task<bool> Update(Transacao entity)
        {
            if (entity != null)
            {
                var transacao = await _unitOfWork.Transacoes.GetById(entity.Id);

                if (transacao != null)
                {
                    transacao.TipoTransacao = entity.TipoTransacao;
                    transacao.DtOcorrencia = entity.DtOcorrencia;
                    transacao.Valor = entity.Valor;
                    transacao.CpfBeneficiario = entity.CpfBeneficiario;
                    transacao.NumeroCartao = entity.NumeroCartao;
                    transacao.HoraTransacao = entity.HoraTransacao;
                    transacao.DonoLoja = entity.DonoLoja;
                    transacao.NomeLoja = entity.NomeLoja;


                    transacao.UpdateAt = DateTime.Now;

                    _unitOfWork.Transacoes.Update(transacao);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
