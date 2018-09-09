using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pages;

namespace Tests
{
    [TestFixture]
    public class TestOneChrome : BaseTest<ChromeDriver>
    {        
        [Test]
        public void TestMethod1()
        {
            driver.Url = "http://localhost/litecart/en/";
            LoginSection ls = new LoginSection(driver);
            ls.LogInStoreUser("test@gmail.com", "testpassword1");
        }

        //[Test]
        //public void TestMethod1()
        //{
        //    driver.Url = "https://www.google.com/";
        //    IWebElement searchField = driver.FindElement(By.Id("lst-ib"));
        //    searchField.SendKeys("hi there");
        //    searchField.SendKeys(Keys.Enter);
        //}

    }
}
