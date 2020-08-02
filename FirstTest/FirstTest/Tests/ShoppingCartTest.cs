using FirstTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTest.Tests
{
    [TestFixture]
    public class ShoppingCartTest
    {
        public IWebDriver driver { get; set; }

        [SetUp]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void VerifyShoppingCart()
        {
            var dressPage = new DressesPage(driver);
            dressPage.Navigate();

            var cart = new ShoppingCartPage(driver);
            cart.VerifyShoppingCart();

            //Assert
            Assert.IsTrue(driver.PageSource.Contains("Product successfully added to your shopping cart"));
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
