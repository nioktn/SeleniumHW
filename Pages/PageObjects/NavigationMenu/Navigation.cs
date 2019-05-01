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
        protected const string NavigationMenuSectionPath = "//aside[@id='navigation']";
        protected const string SearchBoxPath = "//div[@class='input-wrapper']/input[@type='search']";

        public IWebElement searchBoxElement => WaitForElementIsClickable(SearchBoxPath);

        public Navigation(IWebDriver webDriver) : base (webDriver)
        {
        }

        public void ExequteSearchQuery(string searchQuery)
        {
            searchBoxElement.SendKeys(searchQuery);
            searchBoxElement.SendKeys(Keys.Enter);
        }
    }
}
