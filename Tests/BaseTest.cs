﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Tests.Logs;

namespace Tests
{
    public class BaseTest<T> where T : IWebDriver, new()
    {
        protected IWebDriver webDriver;

        [OneTimeSetUp]
        public virtual void FirstInitialize()
        {
            if (typeof(T).Name.Equals("ChromeDriver"))
            {
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--start-maximized");
                webDriver = new ChromeDriver(chromeOptions);
            }
            else
            {
                webDriver = new T();
                webDriver.Manage().Window.Maximize();
            }
        }

        [SetUp]
        public virtual void Initialize()
        {

        }

        [TearDown]
        public virtual void CleanUp()
        {
            Log4LiteCart.Log();
        }

        [OneTimeTearDown]
        public virtual void LastCleanUp()
        {
            webDriver.Quit();
        }
    }
}
