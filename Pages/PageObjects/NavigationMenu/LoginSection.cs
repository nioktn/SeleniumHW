using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.PageObjects.NavigationMenu
{
    public class LoginSection : Navigation
    {
        public LoginSection(IWebDriver webDriver) : base(webDriver) { }
        
        private readonly By _loginForm = By.CssSelector("[name=login_form]");
        private readonly By _emailField = By.XPath("//form[@name='login_form']/.//*[contains(@name, 'email')]");
        private readonly By _usernameField = By.CssSelector("[name=username]");
        private readonly By _passField = By.CssSelector("[name=password]");
        private readonly By _rememberCheck = By.Name("remember_me");
        private readonly By _loginButton = By.Name("login");
        private readonly By _lostPassButton = By.CssSelector("[name=lost_password]");
        private readonly By _registerButton = By.XPath("//*[contains(text(), 'New customers click here')]");

        public IWebElement EmailField => webDriver.FindElement(_emailField); 
        public IWebElement UsernameField => webDriver.FindElement(_usernameField); 
        public IWebElement PassField => webDriver.FindElement(_passField); 
        public IWebElement RememberCheck => webDriver.FindElement(_rememberCheck); 
        public IWebElement LoginButton => webDriver.FindElement(_loginButton); 
        public IWebElement LostPassButton => webDriver.FindElement(_lostPassButton); 
        public IWebElement RegisterButton => webDriver.FindElement(_registerButton); 

        public AdminPage LogInAdminPage(string username, string password)
        {
            UsernameField.SendKeys(username);
            PassField.SendKeys(password);
            LoginButton.Click();
            return new AdminPage(webDriver);
        }

        public void LogInStoreUser(string email, string password)
        {
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(webDriver, _emailField));
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(webDriver, _passField));
            EmailField.SendKeys(email);
            PassField.SendKeys(password);
            LoginButton.Click();
        }

        public RegisterCustomerPage CreateNewUser()
        {
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(webDriver, _registerButton));
            RegisterButton.Click();
            return new RegisterCustomerPage(webDriver);
        }
    }
}