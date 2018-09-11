using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Pages
{
    public class ProductPage
    {
        private readonly IWebDriver driver;
        private readonly By _name = By.CssSelector(".title[itemprop=name]");
        private readonly By _model = By.CssSelector(".sku[itemprop=sku]");
        private readonly By _manufacturer = By.CssSelector(".manufacturer");
        private readonly By _regularPrice = By.CssSelector(".regular-price");
        private readonly By _campaignPrice = By.CssSelector(".campaign-price");
        private readonly By _price = By.CssSelector(".price");
        private readonly By _stockStatus = By.CssSelector(".stock-available > .value");
        private readonly By _addToCartBtn = By.CssSelector("add_cart_product");

        public IWebElement Name { get => driver.FindElement(_name); }
        public IWebElement Model { get => driver.FindElement(_model); }
        public IWebElement Manufacturer { get => driver.FindElement(_manufacturer); }
        public IWebElement RegularPrice { get => driver.FindElement(_regularPrice); }
        public IWebElement CampaignPrice { get => driver.FindElement(_campaignPrice); }
        public IWebElement Price { get => driver.FindElement(_price); }
        public IWebElement StockStatus { get => driver.FindElement(_stockStatus); }
        public IWebElement AddToCartBtn { get => driver.FindElement(_addToCartBtn); }

        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
        }

    }
}
