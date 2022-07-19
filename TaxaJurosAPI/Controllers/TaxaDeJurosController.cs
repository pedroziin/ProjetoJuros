using Microsoft.AspNetCore.Mvc;
using TaxaJurosAPI.Models;

namespace TaxaJurosAPI.Controllers
{

    [ApiController]
    public class TaxaDeJurosController : ControllerBase
    {
        [HttpGet("taxaJuros")]
        public ActionResult ObterTaxaDeJuros()
        {
            return Ok(new TaxaJuros().valor);
        }
    }
}
