using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Pages
{
    public class Content
    {
        private readonly IWebDriver driver;
        private readonly By _contentSection = By.CssSelector("#content");
        private readonly By _contentHeader = By.CssSelector("#content h1");

        public IWebElement ContentHeader { get => driver.FindElement(_contentHeader); }

        public Content(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool HeaderIsPresent(WebDriverWait wait)
        {
           return wait.Until((d) => ElemHelper.IsElementVisible(d, _contentHeader));
        }
    }
}
