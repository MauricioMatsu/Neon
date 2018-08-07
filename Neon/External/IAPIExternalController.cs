using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neon.External
{
    public interface IAPIExternalController
    {
        void SetUrlBase(string urlBase);
        Dictionary<string, object> Live(params string[] moedas);
    }
}
