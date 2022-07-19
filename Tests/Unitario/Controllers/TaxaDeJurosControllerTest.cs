using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Net;
using TaxaJurosAPI.Controllers;

namespace Unitario.Controllers
{
    class TaxaDeJurosControllerTest
    {
        private TaxaDeJurosController _controller;

        [SetUp]
        public void SetUp()
        {
            _controller = new TaxaDeJurosController();
        }

        [Test]
        public void DeveObterSucesso()
        {
            var response = (OkObjectResult)_controller.ObterTaxaDeJuros();
            Assert.NotNull(response);
            Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode);
        }


    }
}
