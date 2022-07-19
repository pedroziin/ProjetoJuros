using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Collections.Generic;

namespace Unitario.Controllers
{
    public class ControlerBaseTest
    {
        public ConfigurationBuilder _iconfiguration;

        [SetUp]
        public void SetUp()
        {
            _iconfiguration = new ConfigurationBuilder();

            _iconfiguration.AddInMemoryCollection(new Dictionary<string, string>
                {
                      {"Endpoints:UrlTaxaJuros", "https://localhost:44302/taxaJuros"},
                      {"Endpoints:UrlGithub", "https://github.com/pedroziin/ProjetoJuros.git"},
                });
        }
    }
}
