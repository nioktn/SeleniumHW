using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Pages;

namespace Tests
{
    [TestFixture]
    public class TestOneFirefox : BaseTest<FirefoxDriver>
    {
        [Test]
        public void TestMethod1()
        {
            driver.Url = "http://localhost/litecart/en/";
            LoginSection ls = new LoginSection(driver);
            ls.LogInStoreUser("test@gmail.com", "testpassword1");
        }

        [Test]
        public void EnterAdminPage()
        {
            driver.Url = "http://localhost/litecart/admin/";
            LoginSection loginSection = new LoginSection(driver);
            loginSection.LogInAdminPage("admin", "admin");
        }
    }
}
