using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Pages
{
    public class Content
    {
        protected readonly IWebDriver driver;
        protected readonly By _contentSection = By.CssSelector("#content");
        protected readonly By _contentHeader = By.CssSelector("#content h1");
        protected readonly By _helpButton = By.XPath("//*[@title='Help']/ancestor::span");

        public IWebElement ContentHeader { get => driver.FindElement(_contentHeader); }
        public IWebElement HelpButton { get => driver.FindElement(_helpButton); }

        public Content(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool HeaderIsPresent()
        {
            return Wait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(d, _contentHeader)); 
        }
    }
}
