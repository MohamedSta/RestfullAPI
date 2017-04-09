using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using StoneChallenge.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoneChallenge;
using StoneChallenge.Controllers;

namespace StoneChallenge.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            var controller = new ProductController();

            // Act
            IEnumerable<Product> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            var controller = new ProductController();

            // Act
            var result = controller.Get(2);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            var controller = new ProductController();

            // Act
            controller.Post(new Product()
                {
                    Id = 3,
                    Name = "Lumia 900"
                });

            var value = controller.Get(3);
            // Assert
            Assert.IsNotNull(value);
            Assert.IsTrue(value.Id == 3);
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            var controller = new ProductController();

            // Act
            controller.Put(5, new Product(){Id=1, Name="Zoran"});

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            const int PRODUCT_ID = 100;
            var controller = new ProductController();

            // Act
            controller.Post(new Product() {Id = PRODUCT_ID, Name = "Lumia 820"});
            controller.Delete(PRODUCT_ID);
            var value = controller.Get(PRODUCT_ID);
            // Assert
            Assert.IsNull(value);

        }
    }
}
