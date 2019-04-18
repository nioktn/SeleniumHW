using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Pages;
using Pages.PageObjects.NavigationMenu;

namespace Tests.Edge
{
    [TestFixture]
    public class TestOneEdgeTests : BaseTest<EdgeDriver>
    {
        [Test]
        public void TestTestMethod1()
        {
            webDriver.Url = "https://www.google.com/";
            IWebElement searchField = webDriver.FindElement(By.Id("lst-ib"));
            searchField.SendKeys("hi there");
            searchField.SendKeys(Keys.Enter);
        }

        [Test]
        public void TestEnterAdminPage()
        {
            webDriver.Url = "http://localhost/litecart/admin/";
            LoginSection loginSection = new LoginSection(webDriver);
            loginSection.LogInAdminPage("admin", "admin");
        }


        [OneTimeTearDown]
        public override void LastCleanUp()
        {
            webDriver.Quit();
        }
    }
}
