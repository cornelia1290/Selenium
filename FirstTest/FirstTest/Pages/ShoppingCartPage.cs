using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstTest.Pages
{
    public class ShoppingCartPage
    {
        public IWebDriver driver { get; set; }

        [FindsBy(How = How.ClassName, Using = "product_img_link")]
        public IWebElement Image { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[title='View']")]
        public IWebElement MoreButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "icon-plus")]
        public IWebElement Quantity { get; set; }

        [FindsBy(How = How.Id, Using = "group_1")]
        public IWebElement Size { get; set; }

        [FindsBy(How = How.Id, Using = "add_to_cart")]
        public IWebElement AddToCartButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "clearfix")]
        public IWebElement ModalWindowClose { get; set; }


        public ShoppingCartPage(IWebDriver webDriver)
        {
            driver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }


        public void VerifyShoppingCart()
        {
            //Hover
            Actions actions = new Actions(driver);
            actions.MoveToElement(Image).Perform();
            MoreButton.Click();
            Quantity.Click();
            //Choose size from dropdown menu
            IWebElement element = Size;
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByText("M");
            AddToCartButton.Click();
            ModalWindowClose.Click();
        }
    }
}
