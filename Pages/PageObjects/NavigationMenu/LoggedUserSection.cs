using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Pages.PageObjects.NavigationMenu
{
    public class LoggedUserSection : Navigation
    {
        public LoggedUserSection(IWebDriver webDriver) : base (webDriver) { }

        private readonly By _loggedUserSection = By.CssSelector("#box-account");
        private readonly By _customerService = By.XPath("//div[@id='box-account']/.//a[contains(text(), 'Customer Service')]");
        private readonly By _orderHistory = By.XPath("//div[@id='box-account']/.//a[contains(text(), 'Order History')]");
        private readonly By _editAccount = By.XPath("//div[@id='box-account']/.//a[contains(text(), 'Edit Account')]");
        private readonly By _logout = By.XPath("//div[@id='box-account']/.//a[contains(text(), 'Logout')]");

        public IWebElement CustomerService { get => webDriver.FindElement(_customerService); }
        public IWebElement OrderHistory { get => webDriver.FindElement(_orderHistory); }
        public IWebElement EditAccout { get => webDriver.FindElement(_editAccount); }
        public IWebElement Logout { get => webDriver.FindElement(_logout); }


        public void LogOut()
        {
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(webDriver, _logout));
            Logout.Click();
        }
    }
}