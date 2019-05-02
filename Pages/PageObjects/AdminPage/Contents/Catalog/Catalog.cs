using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace Pages
{
    public class Catalog : Content
    {
        private const string _catalogTableLocator = "//h1[contains(text(),'Catalog')]/..//table";
        private const string _addNewProduct = "//*[contains(text(),'Add New Product')]";
        private readonly By _addNewCategory = By.XPath("//*[contains(text(),'Add New Category')]");

        public IWebElement CatalogTable => WaitForElementExists(_catalogTableLocator);
        public IWebElement AddNewProduct { get => WaitForElementIsClickable(_addNewProduct); }
        public IWebElement AddNewCategory { get => webDriver.FindElement(_addNewCategory); }

        public Catalog(IWebDriver driver) : base(driver) { }

        public bool IsCatalogPageOpened()
        {
            return WaitForElementIsVisible(_addNewProduct).Displayed;
        }

        public AddEditProduct OpenProductAddingPage()
        {
            AddNewProduct.Click();
            return new AddEditProduct(webDriver);
        }

        public void ClickOnTableEntry(string entryName)
        {
            TableHelper th = new TableHelper(CatalogTable);
            var nameColumnRows = th.GetColumnByName("Name").ToList();
            var entr = nameColumnRows.First(entry => entry.Text.Contains(entryName))
                .FindElement(By.XPath($"/descendant::a[contains(., '{entryName}')]"));
            entr.Click();
        }

        public AddEditProduct OpenProductEditor(string productName)
        {
            TableHelper th = new TableHelper(CatalogTable);
            var nameColumnRows = th.GetColumnByName("Name").ToList();
            var entr = nameColumnRows.First(entry => entry.Text.Contains(productName))
                .FindElement(By.XPath($"/descendant::a[contains(., '{productName}')]"));
            entr.Click();
            return new AddEditProduct(webDriver);
        }
    }
}

