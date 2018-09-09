using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Tests
{
    [TestFixture]
    public class TestOneEdge : BaseTest<EdgeDriver>
    {
        [Test]
        public void TestMethod1()
        {
            driver.Url = "https://www.google.com/";
            IWebElement searchField = driver.FindElement(By.Id("lst-ib"));
            searchField.SendKeys("hi there");
            searchField.SendKeys(Keys.Enter);
        }

        [OneTimeTearDown]
        public override void LastCleanUp()
        {
            driver.Quit();
        }
    }
}
