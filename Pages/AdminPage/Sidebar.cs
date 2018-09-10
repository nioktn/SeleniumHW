using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Pages
{
    public class Sidebar
    {
        private readonly IWebDriver driver;
        private readonly By _sidebarSection = By.CssSelector("#sidebar");
        private readonly By _catalogBtn = By.CssSelector("[title = Catalog]");
        private readonly By _homeBtn = By.CssSelector("[title = Home]");
        private readonly By _webmailBtn = By.XPath("//*[@title = 'Webmail']");
        private readonly By _databaseManagerBtn = By.XPath("//*[@title = 'Database Manager']");
        private readonly By _logoutBtn = By.CssSelector("[title = Logout]");
        private readonly By _menuItems = By.XPath("//*[@id='box-apps-menu']/li");
        private readonly By _subMenuItems = By.CssSelector(".docs li");

        public IWebElement CatalogBtn { get => driver.FindElement(_catalogBtn); }
        public IWebElement HomeBtn { get => driver.FindElement(_homeBtn); }
        public IWebElement WebmailBtn { get => driver.FindElement(_webmailBtn); }
        public IWebElement DatabaseManagerBtn { get => driver.FindElement(_databaseManagerBtn); }
        public IWebElement LogoutBtn { get => driver.FindElement(_logoutBtn); }
        public IList<IWebElement> MenuItems { get => driver.FindElements(_menuItems); }
        public IList<IWebElement> SubMenuItems { get => driver.FindElements(_subMenuItems); }

        public Sidebar(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IList<IWebElement> GetMenuItems(WebDriverWait wait)
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(_menuItems));
            return MenuItems;
        }

        public void SelectMenuItem(string itemName, WebDriverWait wait)
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(_menuItems));
            string locatorStr = string.Format("//*[.='{0}']/ancestor::a", itemName);
            driver.FindElement(By.XPath(locatorStr)).Click();
        }

        public IList<IWebElement> GetSubMenuItems(WebDriverWait wait)
        {
            return SubMenuItems;
        }
    }
}
