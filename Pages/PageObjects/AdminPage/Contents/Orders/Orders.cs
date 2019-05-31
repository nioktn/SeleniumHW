using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using Pages.PageObjects.AdminPage.Contents.Customers;

namespace Pages
{
    public class Orders : Content
    {
        private const string _catalogTableLocator = "//h1[contains(text(),'Orders')]/..//table";
        private const string _createNewOrderLocator = "//a[@class='button' and contains(text(),'Create New Order')]";
        private const string _addNewCategory = "//*[contains(text(),'Add New Category')]";

        public IWebElement CatalogTable => WaitForElementExists(_catalogTableLocator);
        public IWebElement CreateNewOrder => WaitForElementIsClickable(_createNewOrderLocator);

        public Orders(IWebDriver driver) : base(driver) { }

        public bool IsOrdersPageOpened()
        {
            return WaitForElementIsVisible(_createNewOrderLocator).Displayed;
        }
        
        public AddEditOrder OpenLastOrderEntry()
        {
            TableHelper th = new TableHelper(CatalogTable);
            var wantedRow = th.AllRows.First().FindElement(By.XPath("//a[@title='Edit']"));
            wantedRow.Click();
            return new AddEditOrder(webDriver);
        }
    }
}