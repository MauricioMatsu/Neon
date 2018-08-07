using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neon.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeonTest
{
    [TestClass]
    public class USDCurrencyTests
    {

        [TestMethod]
        public void ConstructorUSDCurrencyTest01()
        {
            //Arrange
            ICurrency currency;
            //Act
            currency = new USDCurrency();
            //Assert
            Assert.IsNotNull(currency);
        }

        [TestMethod]
        public void GetMoedasTest()
        {
            //Arrange
            ICurrency currency = new USDCurrency();
            //Act
            var moedas = currency.GetMoedas();
            //Assert
            Assert.IsTrue(moedas.Contains("BRL"));
        }

        [TestMethod]
        public void GetTaxaMoedaTest()
        {
            //Arrange
            ICurrency currency = new USDCurrency();
            Dictionary<string, object> dictionary = new Dictionary<string, object>
            {
                { "USDBRL", 1 },
                { "USDAUD", 2 }
            };
            //Act
            var moedas = currency.GetTaxaMoeda(dictionary);
            //Assert
            Assert.AreEqual(1.0, moedas);
        }

        [TestMethod]
        public void GetTaxaUSDTest()
        {
            //Arrange
            ICurrency currency = new USDCurrency();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("USDBRL", 1.5);
            dictionary.Add("USDEUR", 2.0);
            //Act
            var moedas = currency.GetTaxaUSD(dictionary);
            //Assert
            Assert.AreEqual(1.5, moedas);
        }

        [TestMethod]
        public void IsValidTrueTest()
        {
            //Arrange
            ICurrency currency = new USDCurrency();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("USDBRL", 1.0);
            dictionary.Add("USDEUR", 2.0);
            //Act
            var valid = currency.IsValid(dictionary);
            //Assert
            Assert.IsTrue(valid);
        }

    }
}
