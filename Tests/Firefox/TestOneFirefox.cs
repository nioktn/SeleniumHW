using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Pages;

namespace Tests.Firefox

{
    [TestFixture]
    public class TestOneFirefoxTests : BaseTest<FirefoxDriver>
    {
        [Test]
        public void TestTestMethod1()
        {
            driver.Url = "http://localhost/litecart/en/";
            LoginSection ls = new LoginSection(driver);
            ls.LogInStoreUser("test@gmail.com", "testpassword1");
        }

        [Test]
        public void TestEnterAdminPage()
        {
            driver.Url = "http://localhost/litecart/admin/";
            LoginSection loginSection = new LoginSection(driver);
            loginSection.LogInAdminPage("admin", "admin");
        }
    }
}
