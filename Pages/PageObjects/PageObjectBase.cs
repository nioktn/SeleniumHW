using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Pages.PageObjects
{
    public class PageObjectBase
    {
        private const int defaultTimeout = 30;
        protected IWebDriver webDriver;

        public PageObjectBase(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement WaitForElementIsClickable(string xpathLocator, int timeout = defaultTimeout) =>
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout)).Until(ElementToBeClickable(By.XPath(xpathLocator)));
        public IWebElement WaitForElementIsVisible(string xpathLocator, int timeout = defaultTimeout) =>
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout)).Until(ElementIsVisible(By.XPath(xpathLocator)));
        public IWebElement WaitForElementExists(string xpathLocator, int timeout = defaultTimeout) =>
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout)).Until(ElementExists(By.XPath(xpathLocator)));

        public bool WaitForBooleanCondition(Func<bool> conditionFunc, int timeout = defaultTimeout)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout));
            try
            {
                return wait.Until(d => conditionFunc.Invoke());
            }
            catch
            {
                return false;
            }
        }
    }
}
