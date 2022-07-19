using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CalculoJurosAPI.Controllers
{
    [ApiController]
    public class ShowmethecodeController : Controller
    {
        private readonly IConfiguration _configuration;
        public ShowmethecodeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("showmethecode")]
        public ActionResult ObtemLinkRepositorioGitHub()
        {
            var teste = _configuration.GetValue<string>("Endpoints:UrlGithub");
            return Ok(_configuration.GetValue<string>("Endpoints:UrlGithub"));
        }
    }
}
