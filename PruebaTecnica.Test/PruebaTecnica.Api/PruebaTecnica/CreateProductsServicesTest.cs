using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PruebaTecnica.Aplication.DTOs;
using PruebaTecnica.Aplication.Services;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Domain.Interfaces.Repositories;
using Domain.Common.Response;
using System.Threading.Tasks;
using System;

namespace PruebaTecnica.Test.PruebaTecnica.Aplication.Services
{
    
    [TestClass]
    public class CreateProductsServicesTest
    {
        [TestMethod]
        public async Task Create_ReturnsOk_WhenProductIsCreatedSuccessfully()
        {
            // Arrange
            var mockRepo = new Mock<IProductRepository>();
            var request = new CreateProductsRequest
            {
                Name = "Producto Nuevo",
                Description = "Descripción de prueba",
                Price = 99.99m
            };
            mockRepo.Setup(r => r.GetToProduct(request.Name)).ReturnsAsync((Product)null!);
            mockRepo.Setup(r => r.AddAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);
            mockRepo.Setup(r => r.SaveChangesAsync()).ReturnsAsync(1);

            var service = new CreateProductsServices(mockRepo.Object);

            // Act
            var result = await service.Create(request);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual(1, result.Data);
            Assert.AreEqual("Creacion exitosa", result.Message);
        }

        [TestMethod]
        public async Task Create_ReturnsBadRequest_WhenRequestIsNull()
        {
            // Arrange
            var mockRepo = new Mock<IProductRepository>();
            var service = new CreateProductsServices(mockRepo.Object);

            // Act
            var result = await service.Create(null!);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Error en los datos enviado", result.Message);
        }

        [TestMethod]
        public async Task Create_ReturnsBadRequest_WhenProductAlreadyExists()
        {
            // Arrange
            var mockRepo = new Mock<IProductRepository>();
            var request = new CreateProductsRequest
            {
                Name = "Producto Existente",
                Description = "Ya existe",
                Price = 50.00m
            };
            mockRepo.Setup(r => r.GetToProduct(request.Name)).ReturnsAsync(new Product { Name = request.Name });

            var service = new CreateProductsServices(mockRepo.Object);

            // Act
            var result = await service.Create(request);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("El producto enviado ya existe", result.Message);
        }

        [TestMethod]
        public async Task Create_ReturnsBadRequest_WhenSaveChangesReturnsZero()
        {
            // Arrange
            var mockRepo = new Mock<IProductRepository>();
            var request = new CreateProductsRequest
            {
                Name = "Producto Sin Guardar",
                Description = "No se guarda",
                Price = 10.00m
            };
            mockRepo.Setup(r => r.GetToProduct(request.Name)).ReturnsAsync((Product)null!);
            mockRepo.Setup(r => r.AddAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);
            mockRepo.Setup(r => r.SaveChangesAsync()).ReturnsAsync(0);

            var service = new CreateProductsServices(mockRepo.Object);

            // Act
            var result = await service.Create(request);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual($"{request.Name} no se puede guardar", result.Message);
        }

        [TestMethod]
        public async Task Create_ReturnsBadRequest_WhenExceptionIsThrown()
        {
            // Arrange
            var mockRepo = new Mock<IProductRepository>();
            var request = new CreateProductsRequest
            {
                Name = "Producto Error",
                Description = "Error",
                Price = 5.00m
            };
            mockRepo.Setup(r => r.GetToProduct(request.Name)).ThrowsAsync(new Exception("Excepción de prueba"));

            var service = new CreateProductsServices(mockRepo.Object);

            // Act
            var result = await service.Create(request);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Excepción de prueba", result.Message);
        }
    }
}