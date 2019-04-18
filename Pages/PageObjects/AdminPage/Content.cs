using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pages.Helpers;
using Pages.PageObjects;
using Pages.PageObjects.AdminPage.Contents.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Pages
{
    public class Content : PageObjectBase
    {
        protected readonly By _contentSection = By.CssSelector("#content");
        protected readonly By _contentHeader = By.CssSelector("#content h1");
        protected readonly By _helpButton = By.XPath("//*[@title='Help']/ancestor::span");

        public IWebElement ContentHeader { get => webDriver.FindElement(_contentHeader); }
        public IWebElement HelpButton { get => webDriver.FindElement(_helpButton); }

        public Content(IWebDriver webDriver) : base(webDriver)
        {
        }

        public bool HeaderIsPresent()
        {
            return Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(d, _contentHeader));
        }

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

        public void SelectMenuItem(string itemName)
        {
            sidebarInstance.SelectMenuItem(itemName);
        }

        public EditCustomerPage OpenCustomerEditorPage(string name)
        {
            CustomersPage customersPage = new CustomersPage(webDriver);
            TableHelper th = new TableHelper(customersPage.CustomersTable);
            var wantedRow = th.AllRows.Select(row => new
            {
                Id = th.GetCellsOfRow(row).ElementAt(2).Text,
                Name = th.GetCellsOfRow(row).ElementAt(4).Text.Trim(),
                Edit = th.GetCellsOfRow(row).ElementAt(7).FindElement(By.XPath("//a[@title='Edit']"))
            }).OrderByDescending(row => row.Id).First(row => row.Name.Contains(name));
            wantedRow.Edit.Click();
            return new EditCustomerPage(webDriver);
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

        public void SelectMenuItem(AdminPageMenuItems menuItem)
        {
            sidebarInstance.SelectMenuItem(EnumHelpers.GetEnumOptionDescription(menuItem));
        }

        public void LogOut()
        {
            Sidebar sidebar = new Sidebar(webDriver);
            sidebar.LogoutBtn.Click();
        }
    }
}