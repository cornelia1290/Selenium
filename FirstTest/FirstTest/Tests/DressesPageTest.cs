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
    public class DressesPageTest
    {
        public IWebDriver driver { get; set; }

        [SetUp]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void GoToDressesSection()
        {
            var dressPage = new DressesPage(driver);
            dressPage.Navigate();
            dressPage.GoToDressesSection();

            //Assert
            Assert.IsTrue(driver.PageSource.Contains("Printed evening dress"));
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
