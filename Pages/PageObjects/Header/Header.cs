using OpenQA.Selenium;

namespace Pages.PageObjects.Header
{
    public abstract class Header : PageObjectBase
    {
        protected const string LogotypeLocator = "//div[@id='logotype-wrapper']";
        protected const string HeaderSection = "//div[@id='header-wrapper']";

        protected IWebElement logotypeElement => WaitForElementIsClickable(LogotypeLocator);

        public Header(IWebDriver webDriver) : base(webDriver)
        {
        }
    }
}
