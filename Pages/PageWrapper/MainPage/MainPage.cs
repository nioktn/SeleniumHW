using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Pages
{
    public class MainPage : HeaderWrapper
    {       
        private readonly By _boxMostPopular = By.CssSelector("#box-most-popular");
        private readonly By _boxCampaigns = By.CssSelector("#box-campaigns");
        private readonly By _boxLatestProducts = By.CssSelector("#box-latest-products");
        private readonly By _allProducts = By.XPath("//*[contains(@class, 'product column shadow hover-light')]");
        private readonly By _innerProducts = By.CssSelector(".product.column.shadow.hover-light");

        public IList<IWebElement> AllProducts { get => driver.FindElements(_allProducts); }
        public IList<IWebElement> CampaignsProducts { get => driver.FindElement(_boxCampaigns).FindElements(_innerProducts); }
        public IList<IWebElement> MostPopularProducts { get => driver.FindElement(_boxMostPopular).FindElements(_innerProducts); }
        public IList<IWebElement> LatestProducts { get => driver.FindElement(_boxLatestProducts).FindElements(_innerProducts); }

        public MainPage(IWebDriver driver) : base(driver) { }

        public IList<IWebElement> GetAllProducts()
        {
            Wait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(driver, _allProducts));
            return AllProducts;
        }

        public IWebElement GetProductByName(string name)
        {
            foreach (var item in GetAllProducts())
            {
                if (new ProductCompactView(driver, item).Name.Text.Contains(name))
                    return item; 
            }
            return null;
        }

        public ProductPage SelectProduct(IWebElement product)
        {
            product.Click();
            return new ProductPage(driver);
        }

        public ProductPage SelectProductByName(string name)
        {
            GetProductByName(name).Click();
            return new ProductPage(driver);
        }

        public IList<IWebElement> GetCampaignsProducts()
        {
            Wait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(driver, _boxCampaigns));
            return CampaignsProducts;
        }
    }
}
