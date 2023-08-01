using Site.Enums;

namespace Site.Models
{
    public class Transacao : Base
    {
        //public Transacao(EnumTipoTransacao tipoTransacao, DateTime dtOcorrencia, double valor, string cpfBeneficiario, string numeroCartao, TimeOnly horaTransacao, string donoLoja, string nomeLoja)
        //{
        //    TipoTransacao = tipoTransacao;
        //    DtOcorrencia = dtOcorrencia;
        //    Valor = valor;
        //    CpfBeneficiario = cpfBeneficiario;
        //    NumeroCartao = numeroCartao;
        //    HoraTransacao = horaTransacao;
        //    DonoLoja = donoLoja;
        //    NomeLoja = nomeLoja;
        //}

        public EnumTipoTransacao TipoTransacao { get; set; }
        public DateTime DtOcorrencia { get; set; }
        public double Valor { get; set; }
        public string CpfBeneficiario{ get; set; }
        public string NumeroCartao { get; set; }
        public TimeSpan HoraTransacao { get; set; }
        public string DonoLoja { get; set; }
        public string NomeLoja { get; set; }
    }
}
