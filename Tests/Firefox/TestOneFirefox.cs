using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Pages;
using Pages.PageObjects.NavigationMenu;

namespace Tests.Firefox

{
    [TestFixture]
    public class TestOneFirefoxTests : BaseTest<FirefoxDriver>
    {
        [Test]
        public void TestTestMethod1()
        {
            webDriver.Url = "http://localhost/litecart/en/";
            LoginSection ls = new LoginSection(webDriver);
            ls.LogInStoreUser("test@gmail.com", "testpassword1");
        }

        [Test]
        public void TestEnterAdminPage()
        {
            webDriver.Url = "http://localhost/litecart/admin/";
            LoginSection loginSection = new LoginSection(webDriver);
            loginSection.LogInAdminPage("admin", "admin");
        }
    }
}
