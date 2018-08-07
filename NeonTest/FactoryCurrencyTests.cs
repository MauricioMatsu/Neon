using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neon.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeonTest
{
    [TestClass]
    public class FactoryCurrencyTests
    {
        [TestMethod]
        public void CreateUSDTest()
        {
            //Act
            var classeCriada = FactoryCurrency.Create("USD");

            //Assert
            Assert.IsInstanceOfType(classeCriada, typeof(USDCurrency));
        }

        [TestMethod]
        public void CreateDefaultTest()
        {
            //Act
            var classeCriada = FactoryCurrency.Create("AUS");

            //Assert
            Assert.IsInstanceOfType(classeCriada, typeof(DefaultCurrency));
        }
    }
}
