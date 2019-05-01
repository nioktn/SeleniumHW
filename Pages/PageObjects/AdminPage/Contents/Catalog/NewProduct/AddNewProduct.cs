using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Pages
{
    public class AddEditProduct : Content
    {
        private const string _tabGeneralLocator = "//*[contains(@href,'#tab-general')]";
        private const string _tabInformationLocator = "//*[contains(@href,'#tab-information')]";
        private const string _saveButtonLocator = "//button[@type='submit' and @name='save']";
        private const string _cancelButtonLocator = "//button[@type='button' and @name='cancel']";
        private const string _deleteButtonLocator = "//button[@type='submit' and @name='delete']";
        private readonly By _tabPrices = By.XPath("//*[contains(@href,'#tab-prices')]");

        public IWebElement TabGeneral { get => WaitForElementIsClickable(_tabGeneralLocator); }
        public IWebElement TabInformation { get => WaitForElementIsClickable(_tabInformationLocator); }
        public IWebElement TabPrices { get => webDriver.FindElement(_tabPrices); }

        public AddEditProduct(IWebDriver driver) : base(driver) { }

        public TabGeneral OpenGeneralTab()
        {
            TabGeneral.Click();
            return new TabGeneral(webDriver);
        }

        public TabPrices OpenPricesTab()
        {
            TabPrices.Click();
            return new TabPrices(webDriver);
        }

        public void SaveNewProduct()
        {
            WaitForElementIsClickable(_saveButtonLocator).Click();
        }

        public void CancelAddingNewProduct()
        {
            WaitForElementIsClickable(_cancelButtonLocator).Click();
        }

        public void DeleteProduct()
        {
            WaitForElementIsClickable(_deleteButtonLocator).Click();
            IAlert alert = webDriver.SwitchTo().Alert();
            alert.Accept();
        }
    }
}