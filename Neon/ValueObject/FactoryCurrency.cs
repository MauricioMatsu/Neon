using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neon.ValueObject
{
    public static class FactoryCurrency
    {

        public static ICurrency Create(string moeda)
        {
            if (moeda == "USD")
            {
                return new USDCurrency();
            }
            return new DefaultCurrency(moeda);
        }

    }

}
