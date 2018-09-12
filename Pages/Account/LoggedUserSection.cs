using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Pages
{
    public class LoggedUserSection
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private readonly By _loggedUserSection = By.CssSelector("#box-account");
        private readonly By _customerService = By.XPath("//div[@id='box-account']/.//a[contains(text(), 'Customer Service')]");
        private readonly By _orderHistory = By.XPath("//div[@id='box-account']/.//a[contains(text(), 'Order History')]");
        private readonly By _editAccount = By.XPath("//div[@id='box-account']/.//a[contains(text(), 'Edit Account')]");
        private readonly By _logout = By.XPath("//div[@id='box-account']/.//a[contains(text(), 'Logout')]");

        public IWebElement CustomerService { get => driver.FindElement(_customerService); }
        public IWebElement OrderHistory { get => driver.FindElement(_orderHistory); }
        public IWebElement EditAccout { get => driver.FindElement(_editAccount); }
        public IWebElement Logout { get => driver.FindElement(_logout); }

        public LoggedUserSection(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void LogOut()
        {
            Logout.Click();
        }

        public void LogOut(WebDriverWait wait)
        {
            wait.Until((d) => ElemHelper.IsElementVisible(driver, _logout));
            Logout.Click();
        }
    }
}