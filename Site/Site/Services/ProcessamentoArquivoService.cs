using Site.Services.Interfaces;
using System.Text.RegularExpressions;

namespace Site.Services
{
    public class ProcessamentoArquivoService : IProcessamentoArquivoService
    {
        private readonly ICNAB_IOService _IOService;

        public ProcessamentoArquivoService(ICNAB_IOService iOService)
        {
            _IOService = iOService;
        }

        public async Task<Dictionary<bool, string>> ProcessaArquivoPorCNABId(IEnumerable<string> linhasCNAB)
        {
            //Salvar as transações no banco
            //Atualizar o historico de CNAB com o mesmo ID : Se sucesso > Enum Processado, Se Erro > Enum Erro

            throw new NotImplementedException();
        }

        public async Task<string> ValidaArquivo(IEnumerable<string> linhasCNAB)
        {
            string msg = string.Empty;
            int linhaValidada = 1;
            string msgErro = "Erro Linha " + linhaValidada + " :";
            var validacao = new Dictionary<bool, string>();


            foreach (var linha in linhasCNAB)
            {
                //Tamanho da linha = 80
                if (linha.Length != 80)
                    return msg = string.Concat(msgErro, " Tamanho de caracters invalido no arquivo");


                //0 até 34 tem que ser somente numeros
                var somenteNumeros = new Regex("[0-9]").Match(linha.Substring(0, 34));
                if (somenteNumeros.Success == false)
                {
                    return msg = string.Concat(msgErro, " Posição 1 até 35 pode ser somente numeros");
                }

                //Posicao 0:  tem que ser um numero de 0 a 9
                var somenteUmAte9 = new Regex("([1-9]|10)").Match(linha.Substring(0, 1));
                if (somenteUmAte9.Success == false)
                    return msg = string.Concat(msgErro, " Tipo de transação invalido");

                //Posicao 1 a 8: Data Valida
                var dataTransacao = linha.Substring(1, 8);
                var ano = Convert.ToInt32(dataTransacao.Substring(0, 4));
                var mes = Convert.ToInt32(dataTransacao.Substring(4, 2));
                var dia = Convert.ToInt32(dataTransacao.Substring(6, 2));

                var dataValida = new DateTime(ano, mes, dia);

                //Posicao19 a 29: CPF valido
                if (!IsCpf(linha.Substring(19, 11)))
                    return msg = string.Concat(msgErro, " CPF invalido");




                //30 a 41: Somente numeros
                var somenteNumeros2 = new Regex("[0-9]").Match(linha.Substring(38, 10));
                if (somenteNumeros2.Success == false)
                    return msg = string.Concat(msgErro, " Posição 31 até 42 é permitido somente numeros");


                //42 a 48 hora valida
                var horaValida = linha.Substring(42, 6);
                var hora = string.Concat(horaValida.Substring(0, 2), ":", horaValida.Substring(2, 2), ":", horaValida.Substring(4, 2));

                //34 a 38 : 3 Asterisco
                if (linha.Substring(34, 3) != "***")
                    return msg = string.Concat(msgErro, " Posição 34 até 38 permitido somente ***");


                linhaValidada++;
            }


            return msg;
        }

        public static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
