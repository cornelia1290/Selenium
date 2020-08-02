using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTest.Pages
{
    public class DressesPage
    {
        public IWebDriver driver { get; set; }
        public string loginUrl = "http://automationpractice.com/index.php";

        [FindsBy(How = How.CssSelector, Using = "a[title='Dresses']")]
        private IWebElement Dresses { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[title='List']")]
        private IWebElement List { get; set; }


        public DressesPage(IWebDriver webDriver)
        {
            driver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }

        public void Navigate()
        {
            driver.Manage().Window.Maximize();
            driver.Url = "http://automationpractice.com/index.php?id_category=8&controller=category";
        }

        public void GoToDressesSection()
        {
            //Hover 
            Actions actions = new Actions(driver);
            actions.MoveToElement(Dresses).Perform();
            List.Click();
        }
    }
}
