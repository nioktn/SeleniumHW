using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    [TestFixture]
    public class TestOne
    {
        IWebDriver driver;
        ChromeOptions options;

        [OneTimeSetUp]
        public void Initialize()
        {
            options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            driver = new ChromeDriver(options);
        }

        [Test]
        public void TestMethod1()
        {
            driver.Url = "https://www.google.com/";
            IWebElement searchField = driver.FindElement(By.Id("lst-ib"));
            searchField.SendKeys("hi there");
            searchField.SendKeys(Keys.Enter);
        }

        [OneTimeTearDown]
        public void LastCleanUp()
        {
            driver.Quit();
        }
    }
}
