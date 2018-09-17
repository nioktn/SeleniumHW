using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Tests
{
    public class BaseTest<T> where T : IWebDriver, new()
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public virtual void FirstInitialize()
        {
            if (typeof(T).Name.Equals("ChromeDriver"))
            {
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--start-maximized");
                driver = new ChromeDriver(chromeOptions);
            }
            else
            {
                driver = new T();
                driver.Manage().Window.Maximize();
            }
        }

        [SetUp]
        public virtual void Initialize()
        {

        }

        [TearDown]
        public virtual void CleanUp()
        {

        }

        [OneTimeTearDown]
        public virtual void LastCleanUp()
        {
            driver.Quit();
        }
    }
}
