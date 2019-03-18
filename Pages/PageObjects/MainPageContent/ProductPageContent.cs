using System;
using OpenQA.Selenium;

namespace Pages.PageObjects.MainPageContent
{
    public class ProductPageContent : MainPageContent.PageContent
    {
        public ProductPageContent(IWebDriver webDriver) : base(webDriver) { }

        private readonly By _name = By.CssSelector(".title[itemprop=name]");
        private readonly By _model = By.CssSelector(".sku[itemprop=sku]");
        private readonly By _manufacturer = By.CssSelector(".manufacturer");
        private readonly By _regularPrice = By.CssSelector(".regular-price");
        private readonly By _campaignPrice = By.CssSelector(".campaign-price");
        private readonly By _price = By.CssSelector(".price");
        private readonly By _stockStatus = By.CssSelector(".stock-available > .value");
        private readonly By _addToCartBtn = By.CssSelector("[name=add_cart_product]");

        public IWebElement Name => webDriver.FindElement(_name);
        public IWebElement Model => webDriver.FindElement(_model);
        public IWebElement Manufacturer => webDriver.FindElement(_manufacturer);
        public IWebElement RegularPrice => webDriver.FindElement(_regularPrice);
        public IWebElement CampaignPrice => webDriver.FindElement(_campaignPrice);
        public IWebElement Price => webDriver.FindElement(_price);
        public IWebElement StockStatus => webDriver.FindElement(_stockStatus);
        public IWebElement AddToCartBtn => webDriver.FindElement(_addToCartBtn);


        //public ProductPage AddProductToCart()
        //{
        //    Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(webDriver, _cartItemsQty));
        //    var cartQtyValue = CartItemsQty.Text;
        //    Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(webDriver, _addToCartBtn));
        //    AddToCartBtn.Click();
        //    Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => !CartItemsQty.Text.Equals(cartQtyValue));
        //    return this;
        //}
    }
}

