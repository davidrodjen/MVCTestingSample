using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCTestingSample.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCTestingSample.Controllers.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void Index_ReturnsNonNullViewResult()
        {
            // Create a new instance of controller
            HomeController myController = new HomeController();

            IActionResult result = myController.Index();

            // Make sure it returns a view of some kind
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult), "Index should return a ViewResult");
        }
    }

}