using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Pages;
using System;
using System.Threading;

namespace Tests.Chrome
{
    [TestFixture]
    public class RemoteTests : BaseTest<ChromeDriver>
    {
        IWebDriver remoteDriver;
        public override void FirstInitialize()
        {
            remoteDriver = new RemoteWebDriver(new Uri("http://10.130.73.130:4444/wd/hub"), new ChromeOptions());
        }

        LoginSection loginSection;
        [Test]
        public void remote()
        {
            //var chromeOptions = new ChromeOptions();
            remoteDriver.Url = "http://localhost/litecart/admin/";
            Thread.Sleep(30000);
            //loginSection = new LoginSection(driver);

            //var admPage = loginSection.LogInAdminPage("admin", "admin");

            //List<string> menuItemsNames = admPage.GetMenuItemsNames();
            //List<bool> h1ExistsResults = new List<bool>();
            //foreach (var item in menuItemsNames)
            //{
            //    admPage.SelectMenuItem(item);
            //    h1ExistsResults.Add(admPage.ContentHeaderPresence());

            //    foreach (var subItem in admPage.GetSubMenuItemsNames())
            //    {
            //        admPage.SelectMenuItem(subItem);
            //        h1ExistsResults.Add(admPage.ContentHeaderPresence());
            //    }
            //}
            //int testResult = 1;
            //foreach (var item in h1ExistsResults)
            //{
            //    testResult *= Convert.ToInt32(item);
            //}
            //Assert.IsTrue(testResult == 1);
        }
    }
}
