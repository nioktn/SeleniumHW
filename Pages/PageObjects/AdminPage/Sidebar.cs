using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pages.Helpers;
using Pages.PageObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Pages
{
    public class Sidebar : PageObjectBase
    {
        private readonly By _sidebarSection = By.CssSelector("#sidebar");
        private readonly By _catalogBtn = By.CssSelector("[title = Catalog]");
        private readonly By _homeBtn = By.CssSelector("[title = Home]");
        private readonly By _webmailBtn = By.XPath("//*[@title = 'Webmail']");
        private readonly By _databaseManagerBtn = By.XPath("//*[@title = 'Database Manager']");
        private readonly By _logoutBtn = By.CssSelector("[title = Logout]");
        private const string _menuItems = "//*[@id='box-apps-menu']/li";
        private readonly By _subMenuItems = By.CssSelector(".docs li");

        public IWebElement CatalogBtn { get => webDriver.FindElement(_catalogBtn); }
        public IWebElement HomeBtn { get => webDriver.FindElement(_homeBtn); }
        public IWebElement WebmailBtn { get => webDriver.FindElement(_webmailBtn); }
        public IWebElement DatabaseManagerBtn { get => webDriver.FindElement(_databaseManagerBtn); }
        public IWebElement LogoutBtn { get => webDriver.FindElement(_logoutBtn); }
        public IList<IWebElement> MenuItems
        {
            get
            {
                WaitForElementExists(_menuItems);
                return webDriver.FindElements(By.XPath(_menuItems));
            }
        }
        public IList<IWebElement> SubMenuItems { get => webDriver.FindElements(_subMenuItems); }

        public Sidebar(IWebDriver driver) : base(driver)
        {
        }

        public IList<IWebElement> GetMenuItems()
        {

            WaitForElementExists(_menuItems);
            return MenuItems;
        }
        
        public void SelectMenuItem(string itemName)
        {
            WaitForElementExists(_menuItems);
            string locatorStr = string.Format("//*[.='{0}']/ancestor::a", itemName);
            webDriver.FindElement(By.XPath(locatorStr)).Click();
        }

        public IList<IWebElement> GetSubMenuItems()
        {
            return SubMenuItems;
        }
    }
}
