namespace Site.Models.Extrato
{
    public class TransacaoSaldo
    {
        public TransacaoSaldo(IEnumerable<Transacao> transacoes, double saldo)
        {
            Transacoes = transacoes;
            Saldo = saldo;
        }

        public IEnumerable<Transacao> Transacoes { get; set; }
        public double Saldo { get; set; }
    }
}
