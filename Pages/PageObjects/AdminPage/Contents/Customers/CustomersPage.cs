using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.PageObjects.AdminPage.Contents.Customers
{
    public class CustomersPage : Content
    {
        private const string CustomersTableLocator = "//table[@class='dataTable']";

        public IWebElement CustomersTable => WaitForElementExists(CustomersTableLocator);

        public CustomersPage(IWebDriver webDriver) : base (webDriver)
        {
        }
    }
}
