using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.PageObjects.NavigationMenu
{
    public class Navigation : PageObjectBase
    {
        protected const string searchBoxPath = "//div[@class='input-wrapper']/input[@type='search']";

        protected IWebElement searchBoxElement => WaitForElementIsClickable(searchBoxPath);

        public Navigation(IWebDriver webDriver) : base (webDriver)
        {
        }
    }
}
