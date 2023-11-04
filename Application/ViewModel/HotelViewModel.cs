using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class HotelViewModel
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Descrition { get; set; }
        public string CNPJ { get; set; }
        public string CEP { get; set; }
        public string Address { get; set; }

        public bool VerifyInputValid()
        {
            if (string.IsNullOrEmpty(Name) ||
                string.IsNullOrEmpty(Descrition) ||
                string.IsNullOrEmpty(CEP) ||
                string.IsNullOrEmpty(CNPJ) ||
                string.IsNullOrEmpty(Address)) return false;
            return true;
        }

        public bool VerifyCEPValid()
        {
            string padraoCEP = @"^\d{5}-\d{3}$";

            // Verifica se o CEP corresponde ao padrão
            return Regex.IsMatch(CEP, padraoCEP);
        }

        public bool VerifyCNPJ()
        {
            if (CNPJ.Count() == 18) return true;
            return false;
            //// O padrão da expressão regular para CNPJ é "^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$"
            //string padraoCNPJ = @"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$";

            //// Remove caracteres não numéricos
            //string cnpjNumeros = Regex.Replace(CNPJ, @"[^\d]", "");

            //// Verifica se o CNPJ corresponde ao padrão
            //return Regex.IsMatch(cnpjNumeros, padraoCNPJ);
        }
    }
}
