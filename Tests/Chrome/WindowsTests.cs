using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Chrome
{
    [TestFixture]
    public class WindowsTests : BaseTest<ChromeDriver>
    {
        LoginSection loginSection;
        [Test]
        public void TestExternalLinksOpen()
        {
            driver.Url = "http://localhost/litecart/admin/";
            loginSection = new LoginSection(driver);
            var admPage = loginSection.LogInAdminPage("admin", "admin");
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
            Countries countries = new Countries(driver);
            IList<IWebElement> externalLinks = countries.OpenCountryById(220)
                .GetAllExternalLinks();

            var oldWindows = driver.WindowHandles;
            foreach (var link in externalLinks)
            {
                link.Click();
                Wait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until((d) => driver.WindowHandles.Count > 1);
                var newWindow = driver.WindowHandles.Except(oldWindows).First();
                driver.SwitchTo().Window(newWindow);
                driver.Close();
                driver.SwitchTo().Window(oldWindows.First());
            }
        }
    }
}
