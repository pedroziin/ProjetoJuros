using CalculoJurosAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CalculoJurosAPI.Controllers
{
    [ApiController]
    public class CalculaJurosController : Controller
    {
        private readonly IReqServices _reqServices;
        private readonly IConfiguration _configuration;

        public CalculaJurosController(IReqServices reqServices, IConfiguration configuration)
        {
            _reqServices = reqServices;
            _configuration = configuration;
        }

        [HttpGet("calculajuros")]
        [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ObterCalculoDeJuros([FromQuery] decimal valorInicial, [FromQuery] int meses)
        {
            if (meses <= 0 || valorInicial < 0 || meses.Equals(null) || valorInicial.Equals(null))
                return BadRequest();

            var taxaJuros = await _reqServices.GetTaxaJuros(_configuration.GetValue<string>("Endpoints:UrlTaxaJuros"));

            string valorFinal = ((double)valorInicial * Math.Pow(1 + (double)taxaJuros, meses)).ToString("0.00");

            return Ok(valorFinal);
        }
    }
}
