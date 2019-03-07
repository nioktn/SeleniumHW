using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Pages
{
    public class LoginSection
    {
        private readonly IWebDriver driver;
        private readonly By _loginForm = By.CssSelector("[name=login_form]");
        private readonly By _emailField = By.XPath("//form[@name='login_form']/.//*[contains(@name, 'email')]");
        private readonly By _usernameField = By.CssSelector("[name=username]");
        private readonly By _passField = By.CssSelector("[name=password]");
        private readonly By _rememberCheck = By.Name("remember_me");
        private readonly By _loginButton = By.Name("login");
        private readonly By _lostPassButton = By.CssSelector("[name=lost_password]");
        private readonly By _registerButton = By.XPath("//*[contains(text(), 'New customers click here')]");

        public IWebElement EmailField { get => driver.FindElement(_emailField); }
        public IWebElement UsernameField { get => driver.FindElement(_usernameField); }
        public IWebElement PassField { get => driver.FindElement(_passField); }
        public IWebElement RememberCheck { get => driver.FindElement(_rememberCheck); }
        public IWebElement LoginButton { get => driver.FindElement(_loginButton); }
        public IWebElement LostPassButton { get => driver.FindElement(_lostPassButton); }
        public IWebElement RegisterButton { get => driver.FindElement(_registerButton); }

        public LoginSection(IWebDriver driver)
        {
            this.driver = driver;
        }

        public AdminPage LogInAdminPage(string username, string password)
        {
            UsernameField.SendKeys(username);
            PassField.SendKeys(password);
            LoginButton.Click();
            return new AdminPage(driver);
        }

        public void LogInStoreUser(string email, string password)
        {
            Wait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(driver, _emailField));
            Wait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(driver, _passField));
            EmailField.SendKeys(email);
            PassField.SendKeys(password);
            LoginButton.Click();
        }

        public RegisterCustomerPage CreateNewUser()
        {
            Wait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(driver, _registerButton));
            RegisterButton.Click();
            return new RegisterCustomerPage(driver);
        }
    }
}
