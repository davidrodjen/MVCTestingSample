﻿using Microsoft.AspNetCore.Components.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCTestingSample.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MVCTestingSample.Models.Tests
{
    // Data Driven Tests are Best
    [TestClass()]
    public class ValidationHelperTests
    {
        [TestMethod()]
        [DataRow("9.99")]
        [DataRow("$20.00")] // Works with US currency only
        [DataRow(".99")]
        [DataRow("0.99")]
        [DataRow("0")]
        [DataRow("100000000")]
        public void IsValidPrice_ValidPrice_ReturnsTrue(string input)
        {
            bool result = ValidationHelper.IsValidPrice(input);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("Five")]
        [DataRow("3 and 5 cents")]
        [DataRow("5 dollars")]
        [DataRow("5.00.01")]
        [DataRow("5,00.00")]
        public void IsValidPrice_InvalidPrice_ReturnsFalse(string input)
        {
            bool result = ValidationHelper.IsValidPrice(input);
            Assert.IsFalse(result);
        }
    }
}