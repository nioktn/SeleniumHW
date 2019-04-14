using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Pages.Helpers;
using Pages.PageObjects;

namespace Pages.PageObjects
{
    public class AdminPage : PageObjectBase
    {

        public AdminPage(IWebDriver webDriver) : base(webDriver) { }

        public Sidebar sidebarInstance => new Sidebar(webDriver);

        public IList<IWebElement> GetMenuItems()
        {
            return sidebarInstance.GetMenuItems();
        }

        public IList<IWebElement> GetSubMenuItems()
        {
            return sidebarInstance.GetSubMenuItems();
        }

        public List<string> GetMenuItemsNames()
        {
            List<string> itemsNames = new List<string>();
            foreach (var item in GetMenuItems())
            {
                itemsNames.Add(item.Text);
            }
            return itemsNames;
        }

        public List<string> GetSubMenuItemsNames()
        {
            List<string> subItemsNames = new List<string>();
            foreach (var item in GetSubMenuItems())
            {
                subItemsNames.Add(item.Text);
            }
            return subItemsNames;
        }

        public bool ContentHeaderPresence()
        {
            Content content = new Content(webDriver);
            return content.HeaderIsPresent();
        }
        public enum AdminPageMenuItems
        {
            [Description("Catalog")]
            Catalog,
            [Description("Customers")]
            Customers,
            [Description("Orders")]
            Orders,
            [Description("Users")]
            Users
        }

        public AdminPage SelectMenuItem(string itemName)
        {
            sidebarInstance.SelectMenuItem(itemName);
            return this;
        }

        public AdminPage SelectMenuItem(AdminPageMenuItems menuItem)
        {
            sidebarInstance.SelectMenuItem(EnumHelpers.GetEnumOptionDescription(menuItem));
            return this;
        }


        public void LogOut()
        {
            Sidebar sidebar = new Sidebar(webDriver);
            sidebar.LogoutBtn.Click();
        }
    }
}
