using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace Pages.PageObjects.MainPageContent
{
    public class HomePageContent : PageContent
    {
        public HomePageContent(IWebDriver webDriver) : base(webDriver) { }

        private readonly By _boxMostPopular = By.XPath("//div[@id='box-most-popular']");
        private readonly By _boxCampaigns = By.XPath("//div[@id='box-campaigns']");
        private readonly By _boxLatestProducts = By.XPath("//div[@id='box-latest-products']");
        private readonly By _allProducts = By.XPath("//*[contains(@class, 'product column shadow hover-light')]");
        private readonly By _innerProducts = By.CssSelector(".product.column.shadow.hover-light");

        public IList<IWebElement> AllProducts => webDriver.FindElements(_allProducts);
        public IList<IWebElement> CampaignsProducts => webDriver.FindElement(_boxCampaigns).FindElements(_innerProducts);
        public IList<IWebElement> MostPopularProducts => webDriver.FindElement(_boxMostPopular).FindElements(_innerProducts);
        public IList<IWebElement> LatestProducts => webDriver.FindElement(_boxLatestProducts).FindElements(_innerProducts);
        
        public IList<IWebElement> GetAllProducts()
        {
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(webDriver, _allProducts));
            return AllProducts;
        }

        public IWebElement GetProductByName(string name)
        {
            foreach (var item in GetAllProducts())
            {
                if (new ProductCompactView(webDriver, item).Name.Text.Contains(name))
                    return item;
            }
            return null;
        }

        public ProductPage SelectProduct(IWebElement product)
        {
            product.Click();
            return new ProductPage(webDriver);
        }

        public ProductPage SelectProductByName(string name)
        {
            GetProductByName(name).Click();
            return new ProductPage(webDriver);
        }

        public IList<IWebElement> GetCampaignsProducts()
        {
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(webDriver, _boxCampaigns));
            return CampaignsProducts;
        }
    }
}
