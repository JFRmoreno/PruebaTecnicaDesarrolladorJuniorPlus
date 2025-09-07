using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Api.Controllers;
using PruebaTecnica.Aplication.DTOs;
using PruebaTecnica.Aplication.Services.Interface.Services;
using Domain.Common.Response;
using System.Threading.Tasks;

namespace PruebaTecnica.Test.PruebaTecnica.Api.Controller
{
   
    [TestClass]
    public class CreateControllerTest
    {
        
        [TestMethod]
        public async Task Create_ReturnsOk_WhenProductIsCreatedSuccessfully()
        {
            // Arrange
            var mockService = new Mock<ICreateProductsServices>();
            var request = new CreateProductsRequest
            {
                Name = "Producto de prueba",
                Description = "Descripción de prueba",
                Price = 100.50m
            };
            var expectedResponse = BaseResponse<int>.Ok(1, "Creacion exitosa");
            mockService.Setup(s => s.Create(request)).ReturnsAsync(expectedResponse);

            var controller = new CreateController(mockService.Object);

            // Act
            var result = await controller.Create(request);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(expectedResponse, okResult.Value);
        }

        
        [TestMethod]
        public async Task Create_ReturnsOk_WhenRequestIsNull()
        {
            // Arrange
            var mockService = new Mock<ICreateProductsServices>();
            var expectedResponse = BaseResponse<int>.BadRequest("Error en los datos enviado");
            mockService.Setup(s => s.Create(null!)).ReturnsAsync(expectedResponse);

            var controller = new CreateController(mockService.Object);

            // Act
            var result = await controller.Create(null!);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(expectedResponse, okResult.Value);
        }

      
        [TestMethod]
        public async Task Create_ReturnsOk_WhenProductAlreadyExists()
        {
            // Arrange
            var mockService = new Mock<ICreateProductsServices>();
            var request = new CreateProductsRequest
            {
                Name = "Producto existente",
                Description = "Ya existe",
                Price = 50.00m
            };
            var expectedResponse = BaseResponse<int>.BadRequest("El producto enviado ya existe");
            mockService.Setup(s => s.Create(request)).ReturnsAsync(expectedResponse);

            var controller = new CreateController(mockService.Object);

            // Act
            var result = await controller.Create(request);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(expectedResponse, okResult.Value);
        }

        
        [TestMethod]
        public async Task Create_ReturnsOk_WhenServiceThrowsException()
        {
            // Arrange
            var mockService = new Mock<ICreateProductsServices>();
            var request = new CreateProductsRequest
            {
                Name = "Producto error",
                Description = "Error",
                Price = 10.00m
            };
            var expectedResponse = BaseResponse<int>.BadRequest("Excepción de prueba");
            mockService.Setup(s => s.Create(request)).ReturnsAsync(expectedResponse);

            var controller = new CreateController(mockService.Object);

            // Act
            var result = await controller.Create(request);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(expectedResponse, okResult.Value);
        }
    }
}