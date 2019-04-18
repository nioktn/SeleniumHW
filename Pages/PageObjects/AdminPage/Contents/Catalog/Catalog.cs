using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Pages
{
    public class Catalog : Content
    {
        private readonly By _catalogTable = By.XPath("//h1[contains(text(),'Catalog')]/..//table");
        private readonly By _addNewProduct = By.XPath("//*[contains(text(),'Add New Product')]");
        private readonly By _addNewCategory = By.XPath("//*[contains(text(),'Add New Category')]");

        public IWebElement CatalogTable { get => webDriver.FindElement(_catalogTable); }
        public IWebElement AddNewProduct { get => webDriver.FindElement(_addNewProduct); }
        public IWebElement AddNewCategory { get => webDriver.FindElement(_addNewCategory); }

        public Catalog(IWebDriver driver) : base(driver) { }

        public AddNewProduct OpenProductAddingPage()
        {
            AddNewProduct.Click();
            return new AddNewProduct(webDriver);
        }
    }
}

