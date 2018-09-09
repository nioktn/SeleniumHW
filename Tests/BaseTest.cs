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
    [TestFixture]
    public class BaseTest<T> where T : IWebDriver, new()
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public virtual void FirstInitialize()
        {
            if (typeof(T).Name.Equals("ChromeDriver"))
            {
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--start-maximize");
                driver = new T();
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
