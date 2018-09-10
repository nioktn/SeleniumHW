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
        protected WebDriverWait wait;

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
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
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
