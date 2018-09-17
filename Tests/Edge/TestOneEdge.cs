using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Pages;

namespace Tests.Edge
{
    [TestFixture]
    public class TestOneEdgeTests : BaseTest<EdgeDriver>
    {
        [Test]
        public void TestTestMethod1()
        {
            driver.Url = "https://www.google.com/";
            IWebElement searchField = driver.FindElement(By.Id("lst-ib"));
            searchField.SendKeys("hi there");
            searchField.SendKeys(Keys.Enter);
        }

        [Test]
        public void TestEnterAdminPage()
        {
            driver.Url = "http://localhost/litecart/admin/";
            LoginSection loginSection = new LoginSection(driver);
            loginSection.LogInAdminPage("admin", "admin");
        }


        [OneTimeTearDown]
        public override void LastCleanUp()
        {
            driver.Quit();
        }
    }
}
