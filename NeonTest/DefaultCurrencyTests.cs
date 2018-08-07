using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neon.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeonTest
{
    [TestClass]
    public class DefaultCurrencyTests
    {
        [TestMethod]
        public void ConstructorTest01()
        {
            //Arrange
            ICurrency currency;
            //Act
            currency = new DefaultCurrency("EUR");
            //Assert
            Assert.IsNotNull(currency);
        }

        [TestMethod]
        public void GetMoedasDefaultTest()
        {
            //Arrange
            ICurrency currency = new DefaultCurrency("EUR");
            //Act
            var moedas = currency.GetMoedas();
            //Assert
            Assert.IsTrue(moedas.Contains("EUR"));
        }

        [TestMethod]
        public void GetMoedasBRLTest()
        {
            //Arrange
            ICurrency currency = new DefaultCurrency("EUR");
            //Act
            var moedas = currency.GetMoedas();
            //Assert
            Assert.IsTrue(moedas.Contains("BRL"));
        }

        [TestMethod]
        public void GetTaxaMoedaReturn0Test()
        {
            //Arrange
            ICurrency currency = new DefaultCurrency("EUR");
            Dictionary<string, object> dictionary = new Dictionary<string, object>
            {
                { "USDBRL", 1 },
                { "USDAUD", 2 }
            };
            //Act
            var moedas = currency.GetTaxaMoeda(dictionary);
            //Assert
            Assert.AreEqual(0, moedas);
        }

        [TestMethod]
        public void GetTaxaMoedaTest()
        {
            //Arrange
            ICurrency currency = new DefaultCurrency("EUR");
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("USDBRL", 1.0);
            dictionary.Add("USDEUR", 2.0);
            //Act
            var moedas = currency.GetTaxaMoeda(dictionary);
            //Assert
            Assert.AreEqual(2.0, moedas);
        }

        [TestMethod]
        public void GetTaxaUSDTest()
        {
            //Arrange
            ICurrency currency = new DefaultCurrency("EUR");
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("USDBRL", 1.0);
            dictionary.Add("USDEUR", 2.0);
            //Act
            var moedas = currency.GetTaxaUSD(dictionary);
            //Assert
            Assert.AreEqual(1.0, moedas);
        }

        [TestMethod]
        public void IsValidTrueTest()
        {
            //Arrange
            ICurrency currency = new DefaultCurrency("EUR");
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("USDBRL", 1.0);
            dictionary.Add("USDEUR", 2.0);
            //Act
            var valid = currency.IsValid(dictionary);
            //Assert
            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void IsValidFalseTest()
        {
            //Arrange
            ICurrency currency = new DefaultCurrency("EUR");
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("USDBRL", 1.0);
            dictionary.Add("USDAUS", 2.0);
            //Act
            var valid = currency.IsValid(dictionary);
            //Assert
            Assert.IsFalse(valid);
        }
    }
}
