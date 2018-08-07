using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Neon.External;
using Neon.ValueObject;

namespace Neon.Controllers
{
    public abstract class MainConvertController : Controller
    {

        IAPIExternalController _APIExternalController = new APIExternalController();
        // GET: api/ConvertFrom
        [HttpGet]
        public IActionResult Get(string moeda, int valorEmCentavos)
        {
            //Validar as entradas
            if (valorEmCentavos < 0)
            {
                return BadRequest("Valor em centavos inválido");
            }

            if (moeda == null || moeda.Length != 3)
            {
                return BadRequest("Moeda inválida");
            }

            ICurrency currency = FactoryCurrency.Create(moeda);

            IAPIExternalController apilayer = _APIExternalController;
            var taxas = apilayer.Live(currency.GetMoedas().ToArray());
            if (taxas == null)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Erro interno, verificar logs ou solicitar ajuda ao administrador do sistema");
            }
            if (!currency.IsValid(taxas))
            {
                return BadRequest("Moeda desconhecida");
            }

            double taxaUSD = currency.GetTaxaUSD(taxas);
            double taxaMoeda = currency.GetTaxaMoeda(taxas);

            return base.Ok(CalcularRetorno(valorEmCentavos, taxaUSD, taxaMoeda));
        }

        public void SetAPIController(IAPIExternalController apiExternalController)
        {
            _APIExternalController = apiExternalController;
        }

        protected abstract int CalcularRetorno(int valorEmCentavos, double taxaUSD, double taxaMoeda);

        [HttpGet("{valorEmCentavos}")]
        public IActionResult Get(int valorEmCentavos)
        {
            return Get("USD", valorEmCentavos);
        }
    }
}