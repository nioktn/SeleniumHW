using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Pages
{
    public class AdminPage
    {
        private IWebDriver driver;

        public Sidebar sidebarInstance { get => new Sidebar(driver); }

        public AdminPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IList<IWebElement> GetMenuItems(WebDriverWait wait)
        {
            return sidebarInstance.GetMenuItems(wait);
        }

        public IList<IWebElement> GetSubMenuItems(WebDriverWait wait)
        {
            return sidebarInstance.GetSubMenuItems(wait);
        }

        public List<string> GetMenuItemsNames(WebDriverWait wait)
        {
            List<string> itemsNames = new List<string>();
            foreach (var item in GetMenuItems(wait))
            {
                itemsNames.Add(item.Text);
            }
            return itemsNames;
        }

        public List<string> GetSubMenuItemsNames(WebDriverWait wait)
        {
            List<string> subItemsNames = new List<string>();
            foreach (var item in GetSubMenuItems(wait))
            {
                subItemsNames.Add(item.Text);
            }
            return subItemsNames;
        }

        public bool ContentHeaderPresence(WebDriverWait wait)
        {
            Content content = new Content(driver);
            return content.HeaderIsPresent(wait);
        }

        public AdminPage SelectMenuItem(string itemName, WebDriverWait wait)
        {
            sidebarInstance.SelectMenuItem(itemName, wait);
            return this;
        }
    }
}
