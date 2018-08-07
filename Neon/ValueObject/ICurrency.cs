using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neon.ValueObject
{
    public interface ICurrency
    {
        List<string> GetMoedas();

        double GetTaxaUSD(Dictionary<string, object> dicionarioDeTaxas);
        double GetTaxaMoeda(Dictionary<string, object> dicionarioDeTaxas);
        bool IsValid(Dictionary<string, object> dicionarioDeTaxas);

    }

}
