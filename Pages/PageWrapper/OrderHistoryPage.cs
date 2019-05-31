using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.SqlServer.Server;
using Pages.PageObjects;

namespace Pages
{
    public class OrderHistoryPage : PageObjectBase
    {
        private readonly By _orderSummaryTable = By.XPath("//h2[contains(text(), 'Order Summary')]/..//table[contains(@class, 'dataTable')]");
        private readonly By _shortcutCartItems = By.CssSelector("ul.shortcuts > li.shortcut");
        private readonly By _cartItems = By.CssSelector("ul.items > li.item");
        private const string _orderHistoryTable = "//h1[contains(text(),'Order History')]/..//table";
        private const string _confirmOrderButtonLocator = "//button[@type='submit' and @name='confirm_order']";
        private const string _cartPageTitle = "//h1[@class='title']";

        public OrderHistoryPage(IWebDriver webDriver) : base(webDriver) { }

        public IList<IWebElement> ShortcutCartItems => webDriver.FindElements(_shortcutCartItems);
        public IWebElement OrderHistoryTable => WaitForElementExists(_orderHistoryTable);
        public IWebElement LastOrderEntry => new TableHelper(OrderHistoryTable).AllRows.First();

        public string GetLastOrderStatus()
        {
            return LastOrderEntry.FindElement(By.XPath("/descendant::td[2]")).Text.Trim();
        }
    }
}