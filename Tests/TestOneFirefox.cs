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
            driver.Url = "https://www.google.com/";
            IWebElement searchField = driver.FindElement(By.Id("lst-ib"));
            searchField.SendKeys("hi there");
            searchField.SendKeys(Keys.Enter);
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
