using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Pages
{
    public class ProductCompactView
    {
        private readonly IWebDriver driver;
        private readonly IWebElement baseElement;
        private readonly By _name = By.CssSelector(".name");
        private readonly By _manufacturer = By.CssSelector(".manufacturer");
        private readonly By _regularPrice = By.CssSelector(".regular-price");
        private readonly By _campaignPrice = By.CssSelector(".campaign-price");
        private readonly By _price = By.CssSelector(".price");
        private readonly By _sticker = By.CssSelector(".sticker");

        public ProductCompactView(IWebDriver driver, IWebElement baseElement)
        {
            this.driver = driver;
            this.baseElement = baseElement;
        }

        public bool HasOneSticker(WebDriverWait wait)
        {
            wait.Until((d) => ElemHelper.IsElementVisible(driver, _name));
            return baseElement.FindElements(_sticker).Count == 1;
        }
    }
}
