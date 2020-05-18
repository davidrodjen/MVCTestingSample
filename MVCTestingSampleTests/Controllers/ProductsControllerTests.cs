using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCTestingSample.Controllers;
using MVCTestingSample.Models;
using MVCTestingSample.Models.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVCTestingSample.Controllers.Tests
{
    [TestClass()]
    public class ProductsControllerTests
    {
        [TestMethod()]
        public async Task Index_ReturnsAViewResult_WithAListOfAllProducts()
        {
            // Arrange
            Mock<IProductRespository> mockRepo = new Mock<IProductRespository>();
            mockRepo.Setup(repo => repo.GetAllProductsAsync()).ReturnsAsync(GetProducts());

            // Created Products Controller
            ProductsController prodController = new ProductsController(mockRepo.Object);

            // Act
            IActionResult result = await prodController.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult)); // Ensure View is returned
            ViewResult viewResult = result as ViewResult;

            // List<Product> passed to view
            var model = viewResult.ViewData.Model;
            Assert.IsInstanceOfType(model, typeof(List<Product>));

            // Ensure all products are passed to the view
            List<Product> productModel = model as List<Product>;
            Assert.AreEqual(3, productModel.Count); // The hardcoded products
        }

        private List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    ProductId = 1, Name = "Computer", Price = "199.99"
                },
                new Product()
                {
                    ProductId = 2, Name = "Webcam", Price = "49.99"
                },
                new Product()
                {
                    ProductId = 3, Name = "Desk", Price = "200"
                }
            };
        }

        [TestMethod()]
        public void Add_ReturnsAViewResult()
        {
            var mockRepo = new Mock<IProductRespository>();
            var controller = new ProductsController(mockRepo.Object);

            var result = controller.Add();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task AddPost_ReturnsARedirectAndAddsProduct_WhenModelStateIsValid()
        {
            var mockRepo = new Mock<IProductRespository>();
            mockRepo.Setup(repo => repo.AddProductAsync(It.IsAny<Product>()))
                .Returns(Task.CompletedTask).Verifiable(); // Make sure it was called at all

            var controller = new ProductsController(mockRepo.Object);
            Product p = new Product()
            {
                Name = "Widget",
                Price = "9.99"
            };
            var result = await controller.Add(p);

            // Ensure user is redirected after successfully adding a product
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult), "Return value should be a RedirectToAction");

            // Ensure Controller name is not specified in the RedirectToAction
            var redirectResult = result as RedirectToActionResult;
            Assert.IsNull(redirectResult.ControllerName, "Controller name should not be specified in the redirect");

            // Ensure the Redirect is to the Index Action
            Assert.AreEqual("Index", redirectResult.ActionName);

            mockRepo.Verify();
        }

        [TestMethod]
        public async Task AddPost_ReturnsViewWithModel_WhenMOdelStateIsValid()
        {
            var mockRepo = new Mock<IProductRespository>();
            var controller = new ProductsController(mockRepo.Object);
            var invalidProduct = new Product()
            {
                Name = string.Empty, // Name is required to be valid
                Price = "9.99",
                ProductId = 1
            };
            // Mark ModelState as Invalid
            controller.ModelState.AddModelError("Name", "Required");
            // Ensure View is returned
            IActionResult result = await controller.Add(invalidProduct);
            Assert.IsInstanceOfType(result, typeof(ViewResult));

            //  Ensure modelbound to Product
            ViewResult viewResult = result as ViewResult;
            Assert.IsInstanceOfType(viewResult.Model, typeof(Product));

            // Ensure Invalid Product is pased back into the view
            Product modelBoundProduct = viewResult.Model as Product;
            Assert.AreEqual(modelBoundProduct, invalidProduct, "Invalid Product should be passed back to View");
        }
    }
}