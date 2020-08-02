using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace FirstTests
{
    [TestFixture]
    public class FirstTests
    {
        public IWebDriver driver { get; set; }

        [SetUp]
        public void TestInitialize()     
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://automationpractice.com/index.php";
        }

        //Search Tests
        [Test]
        public void MyStoreSearch1()
        {
            IWebElement element = driver.FindElement(By.Id("search_query_top"));
            element.SendKeys("denim");
        }

        [Test]
        public void MyStoreSearch2()
        {
            driver.FindElement(By.Id("search_query_top")).SendKeys("Dresses");
            driver.FindElement(By.ClassName("button-search")).Click();
            //driver.FindElement(By.Name("search_query")).SendKeys("Blouses");
            //driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[2]/form/button")).Click();
        }

        //CssSelector 
        [Test]
        public void CssSelector1()
        {
            driver.FindElement(By.CssSelector("#contact-link")).Click();
            driver.FindElement(By.Name("submitMessage")).Click();
            //Assert
            Assert.IsTrue(driver.PageSource.Contains("Invalid email address."));
        }
   
        [Test]
        public void CssSelector2()
        {
            var signInButton = driver.FindElement(By.ClassName("login"));
            signInButton.Click();
            driver.FindElement(By.CssSelector("#email")).SendKeys("corneliacucu12@gmail.com");
            driver.FindElement(By.CssSelector("input[name='passwd']")).SendKeys("12345678");
            driver.FindElement(By.Name("SubmitLogin")).Click();
        }
        
        //Hover
        [Test]
        public void ActionsMovetoElement()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(driver.FindElement(By.ClassName("sf-with-ul"))).Perform();
        }


        //Dropdown Tests
        [Test]
        public void MultiselectDropdown1()
        {
            driver.FindElement(By.ClassName("sf-with-ul")).Click();

            IWebElement element = driver.FindElement(By.Id("selectProductSort"));
            SelectElement selectElement = new SelectElement(element);

            IList<IWebElement> elements = selectElement.Options;
            Console.WriteLine(elements.Count);
            foreach (var item in elements)
            {
                Console.WriteLine(item.Text);
            }
        }

        [Test]
        public void MultiselectDropdown2()
        {
            driver.FindElement(By.ClassName("sf-with-ul")).Click();

            IWebElement element = driver.FindElement(By.Id("selectProductSort"));
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByText("In stock");
        }


        //Shopping Cart Tests
        [Test]
        public void VerifyTheCart()
        {
            var Cartbutton = driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[3]/div/a"));
            Cartbutton.Click();
            //Assert
            Assert.IsTrue(driver.PageSource.Contains("Your shopping cart is empty."));
        }


        [Test]
        public void TestAddToCart()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(driver.FindElement(By.ClassName("product_img_link"))).Perform();
            var cartItem = driver.FindElement(By.ClassName("ajax_add_to_cart_button"));
            cartItem.Click();
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