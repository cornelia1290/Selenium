using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTest.Pages
{
    public class SignInPage
    {
        public IWebDriver driver { get; set; }

        [FindsBy(How = How.ClassName, Using = "login")]
        public IWebElement SignIn { get; set; }

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Name, Using = "passwd")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Name, Using = "SubmitLogin")]
        public IWebElement SignInButton { get; set; }


        public SignInPage(IWebDriver webDriver)
        {
            driver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }

        public void Navigate()
        {
            driver.Manage().Window.Maximize();
            driver.Url = "http://automationpractice.com/index.php?controller=authentication&back=my-account";
        }

        public void ClickOnSignInButton()
        {
            SignIn.Click();
            Email.SendKeys("corneliacucu12@gmail.com");
            Password.SendKeys("12345678");
            SignInButton.Click();  
        }
    }
}
