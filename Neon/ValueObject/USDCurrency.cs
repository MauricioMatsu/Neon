using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neon.ValueObject
{
    public class USDCurrency : ICurrency
    {
        public List<string> GetMoedas()
        {
            //A API já retorna a moeda USD
            return new List<string>() { "BRL" };
        }

        public double GetTaxaMoeda(Dictionary<string, object> dicionarioDeTaxas)
        {
            return 1;
        }

        public double GetTaxaUSD(Dictionary<string, object> dicionarioDeTaxas)
        {
            return (double)dicionarioDeTaxas["USDBRL"];
        }

        public bool IsValid(Dictionary<string, object> dicionarioDeTaxas)
        {
            return true;
        }
    }

}
