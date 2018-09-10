using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
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
