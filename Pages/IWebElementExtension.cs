using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages
{
    public static class IWebElementExtension
    {
        public static void TripleClick(this IWebElement webElement)
        {
            webElement.Click();
            webElement.Click();
            webElement.Click();
        }
    }
}
