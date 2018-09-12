using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Pages
{
    public class HeaderWrapper
    {
        private readonly IWebDriver driver;

        //TODO other stuff

        public HeaderWrapper(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
