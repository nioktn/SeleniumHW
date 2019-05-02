using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Pages
{
    public class ProductPage : HeaderWrapper
    {
        private const string _productNameLocator = "//div/h1[@itemprop='name']";
        private readonly By _model = By.CssSelector(".sku[itemprop=sku]");
        private readonly By _manufacturer = By.CssSelector(".manufacturer");
        private readonly By _regularPrice = By.CssSelector(".regular-price");
        private readonly By _campaignPrice = By.CssSelector(".campaign-price");
        private readonly By _price = By.CssSelector(".price");
        private readonly By _stockStatus = By.CssSelector(".stock-available > .value");
        private readonly By _addToCartBtn = By.CssSelector("[name=add_cart_product]");
        private const string _addToCartBtnPath = "//*[@name='add_cart_product']";

        public IWebElement Name { get => WaitForElementIsVisible(_productNameLocator); }
        public IWebElement Model { get => driver.FindElement(_model); }
        public IWebElement Manufacturer { get => driver.FindElement(_manufacturer); }
        public IWebElement RegularPrice { get => driver.FindElement(_regularPrice); }
        public IWebElement CampaignPrice { get => driver.FindElement(_campaignPrice); }
        public IWebElement Price { get => driver.FindElement(_price); }
        public IWebElement StockStatus { get => driver.FindElement(_stockStatus); }
        public IWebElement AddToCartBtn { get => driver.FindElement(_addToCartBtn); }
        public string ProductName => Name.Text.Trim();

        public ProductPage(IWebDriver driver) : base(driver) { }

        public void AddToCart() => WaitForElementIsClickable(_addToCartBtnPath).Click();

        public bool IsProductPageOpened()
        {
            return WaitForBooleanCondition(() => WaitForElementIsVisible(_productNameLocator, 1).Displayed, 1);
        }

        public ProductPage AddProductToCart()
        {
            Wait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(driver, _cartItemsQty));
            var cartQtyValue = CartItemsQty.Text;
            Wait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(driver, _addToCartBtn));
            AddToCartBtn.Click();
            Wait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until((d) => !CartItemsQty.Text.Equals(cartQtyValue));
            return this;
        }
    }
}
