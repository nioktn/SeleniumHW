using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Pages
{
    public class HeaderWrapper
    {
        protected readonly IWebDriver driver;
        protected readonly By _cartSection = By.CssSelector("#cart");
        protected readonly By _cartItemsQty = By.CssSelector("#cart .quantity");
        protected readonly By _cartValue = By.CssSelector("#cart .formatted_value");
        protected readonly By _cartCheckout = By.XPath("//div[@id='cart']/.//a[contains(text(), 'Checkout')]");
        protected readonly By _homeButton = By.CssSelector(".fa-home");

        public IWebElement CartItemsQty { get => driver.FindElement(_cartItemsQty); }
        public IWebElement CartValue { get => driver.FindElement(_cartValue); }
        public IWebElement CartCheckout { get => driver.FindElement(_cartCheckout); }
        public IWebElement HomeButton { get => driver.FindElement(_homeButton); }

        public HeaderWrapper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public MainPage GoToMainPage()
        {
            Wait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(driver, _homeButton));
            HomeButton.Click();
            return new MainPage(driver);
        }

        public CartPage OpenCartPage()
        {
            Wait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(driver, _cartCheckout));
            CartCheckout.Click();
            return new CartPage(driver);
        }
    }
}
