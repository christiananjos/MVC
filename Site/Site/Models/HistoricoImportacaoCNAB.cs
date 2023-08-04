using Site.Enums;

namespace Site.Models
{
    public class HistoricoImportacaoCNAB : Base
    {
        //public HistoricoImportacaoCNAB(string cNABImportado, string usuario)
        //{
        //    CNABImportado = cNABImportado;
        //    Usuario = usuario;
        //}

        public string NomeArquivo { get; set; }
        public string Usuario { get; set; }
        public EnumStatusCNAB Status { get; set; }
    }
}
