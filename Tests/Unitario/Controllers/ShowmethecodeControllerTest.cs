using CalculoJurosAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Net;

namespace Unitario.Controllers
{
    class ShowmethecodeControllerTest : ControlerBaseTest
    {
        private ShowmethecodeController _controller;

        [SetUp]
        public void SetUp()
        {
            _controller = new ShowmethecodeController(_iconfiguration.Build());
        }

        [Test]
        public void DeveObterSucesso()
        {
            var response = (OkObjectResult)_controller.ObtemLinkRepositorioGitHub();
            Assert.NotNull(response);
            Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode);
        }
    }
}
