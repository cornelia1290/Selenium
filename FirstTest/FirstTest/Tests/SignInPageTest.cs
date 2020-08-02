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
    public class SignInPageTest
    {
        public IWebDriver driver { get; set; }

        [SetUp]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void ClickOnSignInButton()
        {
            var signIn = new SignInPage(driver);
            signIn.Navigate();
            signIn.ClickOnSignInButton();

            //Assert
            Assert.IsTrue(driver.PageSource.Contains("Authentication failed"));
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
