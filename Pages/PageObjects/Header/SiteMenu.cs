using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.PageObjects.Header
{
    public class SiteMenu : Header
    {

        protected readonly By _homeButton = By.CssSelector(".fa-home");
        public SiteMenu(IWebDriver webDriver) : base (webDriver)
        {
        }
        public IWebElement HomeButton { get => webDriver.FindElement(_homeButton); }


    }
}
