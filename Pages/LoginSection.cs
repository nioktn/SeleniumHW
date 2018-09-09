using OpenQA.Selenium;
using System;

namespace Pages
{
    public class LoginSection
    {
        private readonly IWebDriver driver;
        private readonly By emailField = By.XPath("//form[@name='login_form']/.//*[contains(@name, 'email')]");
        private readonly By usernameField = By.CssSelector("[name=username]");
        private readonly By passField = By.CssSelector("[name=password]");
        private readonly By rememberCheck = By.Name("remember_me");
        private readonly By loginButton = By.Name("login");

        public IWebElement EmailField { get => driver.FindElement(emailField); }
        public IWebElement UsernameField { get => driver.FindElement(usernameField); }
        public IWebElement PassField { get => driver.FindElement(passField); }
        public IWebElement RememberCheck { get => driver.FindElement(rememberCheck); }
        public IWebElement LoginButton { get => driver.FindElement(loginButton); }

        public LoginSection(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void LogInAdminPage(String username, String password)
        {
            EmailField.SendKeys(username);
            PassField.SendKeys(password);
            LoginButton.Click();
        }

        public void LogInStoreUser(String email, String password)
        {
            EmailField.SendKeys(email);
            PassField.SendKeys(password);
            LoginButton.Click();
        }
    }
}
