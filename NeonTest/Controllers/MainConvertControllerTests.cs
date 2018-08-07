using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Neon.Controllers;
using Neon.External;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace NeonTest.Controllers
{
    public abstract class MainConvertControllerTests
    {
        public abstract MainConvertController GetConvert();
        [TestMethod]
        public void GetBadRequestMoedaTest()
        {
            //Arrange
            var convert = GetConvert();
            //Act
            var action = convert.Get("AAAA", 100);
            //Assert
            Assert.IsInstanceOfType(action, typeof(BadRequestObjectResult));

        }

        [TestMethod]
        public void GetBadRequestValorTest()
        {
            //Arrange
            var convert = GetConvert();
            //Act
            var action = convert.Get("EUR", -100);
            //Assert
            Assert.IsInstanceOfType(action, typeof(BadRequestObjectResult));

        }

        [TestMethod]
        public void GetBadRequestMoedaDesconhecidaTest()
        {
            //Arrange
            var convert = GetConvert();
            Dictionary<string, object> retorno = new Dictionary<string, object>()
            {
                { "USDBRL",2.0 },{"USDEUR",3.0}
            };
            var mockAPI = new Mock<APIExternalController>();
            mockAPI.Setup(p => p.Live(It.IsAny<string[]>())).Returns(retorno);
            convert.SetAPIController(mockAPI.Object);
            //Act
            var action = convert.Get("EUA", 100);
            //Assert
            Assert.IsInstanceOfType(action, typeof(BadRequestObjectResult));

        }

        [TestMethod]
        public void GetInternalErroTest()
        {
            //Arrange
            var convert = GetConvert();
            Dictionary<string, object> retorno = null;
            var mockAPI = new Mock<APIExternalController>();
            mockAPI.Setup(p => p.Live(It.IsAny<string[]>())).Returns(retorno);
            convert.SetAPIController(mockAPI.Object);
            //Act
            var action = convert.Get("EUA", 100);
            //Assert
            Assert.IsInstanceOfType(action, typeof(ObjectResult));
            var objectResult = action as ObjectResult;
            Assert.AreEqual(objectResult.StatusCode, (int)HttpStatusCode.InternalServerError);

        }
    }
}
