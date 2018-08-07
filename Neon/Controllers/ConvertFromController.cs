using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Neon.Controllers
{
    [Produces("application/json")]
    [Route("api/ConvertFrom")]
    public class ConvertFromController : MainConvertController
    {
        protected override int CalcularRetorno(int valorEmCentavos, double taxaUSD, double taxaMoeda)
        {
            return Convert.ToInt32(valorEmCentavos * taxaUSD / taxaMoeda);
        }
    }
}