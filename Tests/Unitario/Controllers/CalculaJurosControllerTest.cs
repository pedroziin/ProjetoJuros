using AutoFixture;
using CalculoJurosAPI.Controllers;
using CalculoJurosAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

namespace Unitario.Controllers
{
    public class CalculaJurosControllerTest : ControlerBaseTest
    {
        private CalculaJurosController _controller;
        private Fixture _fixture;
        private Mock<IReqServices> _reqServices;

        [SetUp]
        public void SetUp()
        {
            _reqServices = new Mock<IReqServices>();

            _reqServices.Setup(x => x.GetTaxaJuros(It.IsAny<string>())).ReturnsAsync(0.01m);
            _controller = new CalculaJurosController(_reqServices.Object, _iconfiguration.Build());
            _fixture = new Fixture();
        }

        [Test]
        public async Task DeveObterSucesso()
        {
            var response = (OkObjectResult)await _controller.ObterCalculoDeJuros(_fixture.Create<decimal>(), 5);
            Assert.NotNull(response);
            Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task DeveObterErro()
        {
            var response = (BadRequestResult)await _controller.ObterCalculoDeJuros(_fixture.Create<decimal>(), -15);
            Assert.NotNull(response);
            Assert.AreEqual((int)HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
