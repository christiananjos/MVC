using Site.Enums;
using System.ComponentModel.DataAnnotations;

namespace Site.Models
{
    public class HistoricoImportacaoCNAB : Base
    {
        //public HistoricoImportacaoCNAB(string cNABImportado, string usuario)
        //{
        //    CNABImportado = cNABImportado;
        //    Usuario = usuario;
        //}

        [Display(Name = "NomeArquivo")]
        public string NomeArquivo { get; set; }

        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Display(Name = "Status")]
        public EnumStatusCNAB Status { get; set; }
    }
}
