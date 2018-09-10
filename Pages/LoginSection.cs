using OpenQA.Selenium;

namespace Pages
{
    public class LoginSection
    {
        private readonly IWebDriver driver;
        private readonly By _emailField = By.XPath("//form[@name='login_form']/.//*[contains(@name, 'email')]");
        private readonly By _usernameField = By.CssSelector("[name=username]");
        private readonly By _passField = By.CssSelector("[name=password]");
        private readonly By _rememberCheck = By.Name("remember_me");
        private readonly By _loginButton = By.Name("login");

        public IWebElement EmailField { get => driver.FindElement(_emailField); }
        public IWebElement UsernameField { get => driver.FindElement(_usernameField); }
        public IWebElement PassField { get => driver.FindElement(_passField); }
        public IWebElement RememberCheck { get => driver.FindElement(_rememberCheck); }
        public IWebElement LoginButton { get => driver.FindElement(_loginButton); }

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
            EmailField.SendKeys(email);
            PassField.SendKeys(password);
            LoginButton.Click();
        }
    }
}
