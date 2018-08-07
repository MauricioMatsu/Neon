using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neon.ValueObject
{
    public class DefaultCurrency : ICurrency
    {
        private string _Moeda;
        public DefaultCurrency(string moeda)
        {
            _Moeda = moeda;
        }

        public List<string> GetMoedas()
        {
            return new List<string>() { "BRL", _Moeda };
        }

        public double GetTaxaMoeda(Dictionary<string, object> dicionarioDeTaxas)
        {
            if (dicionarioDeTaxas.ContainsKey("USD" + _Moeda))
            {
                return (double)dicionarioDeTaxas["USD" + _Moeda];
            }
            return 0;
        }

        public double GetTaxaUSD(Dictionary<string, object> dicionarioDeTaxas)
        {
            return (double)dicionarioDeTaxas["USDBRL"];
        }

        public bool IsValid(Dictionary<string, object> dicionarioDeTaxas)
        {
            return dicionarioDeTaxas.ContainsKey("USD" + _Moeda);
        }
    }

}
