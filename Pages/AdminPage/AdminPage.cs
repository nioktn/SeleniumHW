using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Pages
{
    public class AdminPage
    {
        private IWebDriver driver;

        public AdminPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IList<IWebElement> GetMenuItems(WebDriverWait wait)
        {
            Sidebar sidebar = new Sidebar(driver);
            return sidebar.GetMenuItems(wait);
        }

        public IList<IWebElement> GetSubMenuItems(WebDriverWait wait)
        {
            Sidebar sidebar = new Sidebar(driver);
            return sidebar.GetSubMenuItems(wait);
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
            Sidebar sidebar = new Sidebar(driver);
            sidebar.SelectMenuItem(itemName, wait);
            return this;
        }
    }
}
