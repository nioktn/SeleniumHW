using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Pages
{
    public class AddNewProduct : Content
    {
        private readonly By _tabGeneral = By.XPath("//*[contains(@href,'#tab-general')]");
        private readonly By _tabInformation = By.XPath("//*[contains(@href,'#tab-information')]");
        private readonly By _tabPrices = By.XPath("//*[contains(@href,'#tab-prices')]");

        public IWebElement TabGeneral { get => driver.FindElement(_tabGeneral); }
        public IWebElement TabInformation { get => driver.FindElement(_tabInformation); }
        public IWebElement TabPrices { get => driver.FindElement(_tabPrices); }

        public AddNewProduct(IWebDriver driver) : base(driver) { }

        public TabGeneral OpenGeneralTab()
        {
            TabGeneral.Click();
            return new TabGeneral(driver);
        }
    }
}