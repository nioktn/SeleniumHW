using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Pages
{
    public class MainPage
    {
        private readonly IWebDriver driver;
        private readonly By _boxMostPopular = By.CssSelector("#box-most-popular");
        private readonly By _boxCampaigns = By.CssSelector("#box-campaigns");
        private readonly By _boxLatestProducts = By.CssSelector("#box-latest-products");
        private readonly By _allProducts = By.XPath("//*[contains(@class, 'product column shadow hover-light')]");

        public IList<IWebElement> AllProducts { get => driver.FindElements(_allProducts); }

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IList<IWebElement> GetAllProducts(WebDriverWait wait)
        {
            wait.Until((d) => ElemHelper.IsElementVisible(driver, _allProducts));
            return AllProducts;
        }
    }
}
