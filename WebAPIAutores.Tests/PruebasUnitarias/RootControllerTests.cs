using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAPIAutores.Controllers.V1;
using WebAPIAutores.Tests.Mocks;

namespace WebAPIAutores.Tests.PruebasUnitarias
{
    [TestClass]
    public class RootControllerTests
    {
        [TestMethod]
        public async Task SiUsuarioEsAdmin_Obtener4Links()
        {
            // Preparación
            var authorizationService = new AuthorizationServiceMock();
            authorizationService.Resultado = AuthorizationResult.Success();
            var rootController = new RootController(authorizationService);
            rootController.Url = new URLHelperMock();

            // Ejecución
            var resultado = await rootController.Get();

            // Verificación
            Assert.AreEqual(4, resultado?.Value?.Count());
        }

        [TestMethod]
        public async Task SiUsuarioNoEsAdmin_Obtener2Links()
        {
            // Preparación
            var authorizationService = new AuthorizationServiceMock();
            authorizationService.Resultado = AuthorizationResult.Failed();
            var rootController = new RootController(authorizationService);
            rootController.Url = new URLHelperMock();

            // Ejecución
            var resultado = await rootController.Get();

            // Verificación
            Assert.AreEqual(2, resultado?.Value?.Count());
        }

        
    }
}
