using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebaTecnica.Domain.Entities;
using System;

namespace PruebaTecnica.Test.PruebaTecnica.Domain.Entities
{
    
    [TestClass]
    public class ProductTest
    {
       
        [TestMethod]
        public void Product_PropertyAssignment_WorksCorrectly()
        {
            // Arrange
            var now = DateTime.Now;
            var product = new Product
            {
                Id = 1,
                Name = "Producto de prueba",
                Description = "Descripción de prueba",
                Price = 99.99m,
                CreatedAt = now,
                Isactive = true,
                Observation = "Observación de prueba"
            };

            // Assert
            Assert.AreEqual(1, product.Id);
            Assert.AreEqual("Producto de prueba", product.Name);
            Assert.AreEqual("Descripción de prueba", product.Description);
            Assert.AreEqual(99.99m, product.Price);
            Assert.AreEqual(now, product.CreatedAt);
            Assert.IsTrue(product.Isactive);
            Assert.AreEqual("Observación de prueba", product.Observation);
        }

       
        [TestMethod]
        public void Product_OptionalProperties_CanBeNull()
        {
            // Arrange
            var product = new Product
            {
                Id = 2,
                Name = "Producto sin descripción",
                Description = null,
                Price = 10.00m,
                CreatedAt = DateTime.UtcNow,
                Isactive = false,
                Observation = null
            };

            // Assert
            Assert.IsNull(product.Description);
            Assert.IsNull(product.Observation);
        }
    }
}