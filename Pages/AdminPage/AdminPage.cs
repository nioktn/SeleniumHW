using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Pages
{
    public class AdminPage
    {
        //private WebDriverWait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until _Wait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until;
        private readonly IWebDriver driver;

        public Sidebar sidebarInstance { get => new Sidebar(driver); }
        //public WebDriverWait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until Wait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until
        //{
        //    get {
        //        if (_Wait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until != null) return _Wait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until;
        //        else
        //        {
        //            _Wait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until = new WebDriverWait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until(driver, TimeSpan.FromSeconds(10));
        //            return _Wait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until;
        //        }
        //    }
        //}

    public AdminPage(IWebDriver driver)
    {
        this.driver = driver;
    }

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
        Content content = new Content(driver);
        return content.HeaderIsPresent();
    }

    public AdminPage SelectMenuItem(string itemName)
    {
        sidebarInstance.SelectMenuItem(itemName);
        return this;
    }

    public void LogOut()
    {
        Sidebar sidebar = new Sidebar(driver);
        sidebar.LogoutBtn.Click();
    }
}
}
