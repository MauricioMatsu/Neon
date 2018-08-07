using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Neon.Controllers;
using Neon.External;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeonTest.Controllers
{
    [TestClass]
    public class ConvertFromControllerTests : MainConvertControllerTests
    {
        public override MainConvertController GetConvert()
        {
            return new ConvertFromController();
        }

        [TestMethod]
        public void GetTaxaUSD()
        {
            //Arrange
            var convert = GetConvert();
            Dictionary<string, object> retorno = new Dictionary<string, object>()
            {
                { "USDBRL",2.0 }
            };
            var mockAPI = new Mock<APIExternalController>();
            mockAPI.Setup(p => p.Live(It.IsAny<string[]>())).Returns(retorno);
            convert.SetAPIController(mockAPI.Object);
            //Act
            var action = convert.Get("USD", 100);
            //Assert
            Assert.IsInstanceOfType(action, typeof(OkObjectResult));
            var okObject = action as OkObjectResult;
            Assert.AreEqual(okObject.Value, 200);
        }

        [TestMethod]
        public void GetTaxaEUR()
        {
            //Arrange
            var convert = GetConvert();
            Dictionary<string, object> retorno = new Dictionary<string, object>()
            {
                { "USDBRL",2.0 },{"USDEUR",4.0}
            };
            var mockAPI = new Mock<APIExternalController>();
            mockAPI.Setup(p => p.Live(It.IsAny<string[]>())).Returns(retorno);
            convert.SetAPIController(mockAPI.Object);
            //Act
            var action = convert.Get("EUR", 100);
            //Assert
            Assert.IsInstanceOfType(action, typeof(OkObjectResult));
            var okObject = action as OkObjectResult;
            Assert.AreEqual(okObject.Value, 50);
        }
    }
}
