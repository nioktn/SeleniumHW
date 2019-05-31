using OpenQA.Selenium;

namespace Pages.PageObjects.Header
{
    public class SiteMenu : Header
    {
        protected readonly By _homeButton = By.CssSelector(".fa-home");
        public SiteMenu(IWebDriver webDriver) : base (webDriver) { }
        public IWebElement HomeButton => webDriver.FindElement(_homeButton);

        public void NavigateHome() => HomeButton.Click();
    }
}