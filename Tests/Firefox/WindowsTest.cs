using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Pages.PageObjects.NavigationMenu;

namespace Tests.Firefox
{
    [TestFixture]
    public class WindowsTests : BaseTest<FirefoxDriver>
    {
        LoginSection loginSection;
        [Test]
        public void TestTestExternalLinksOpen()
        {
            webDriver.Url = "http://localhost/litecart/admin/";
            loginSection = new LoginSection(webDriver);
            var admPage = loginSection.LogInAdminPage("admin", "admin");
            webDriver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
            Countries countries = new Countries(webDriver);
            IList<IWebElement> externalLinks = countries.OpenCountryById(220)
                .GetAllExternalLinks();

            var oldWindows = webDriver.WindowHandles;
            foreach (var link in externalLinks)
            {
                link.Click();
                Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => webDriver.WindowHandles.Count > 1);
                var newWindow = webDriver.WindowHandles.Except(oldWindows).First();
                webDriver.SwitchTo().Window(newWindow);
                webDriver.Close();
                webDriver.SwitchTo().Window(oldWindows.First());
            }
        }
    }
}
