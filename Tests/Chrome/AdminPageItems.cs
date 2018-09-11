using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pages;
using System;
using System.Collections.Generic;

namespace Tests.Chrome
{
    [TestFixture]
    public class AdminPageItems : BaseTest<ChromeDriver>
    {
        LoginSection loginSection;
        [Test]
        public void AdminPageClickOnEachMenuItem()
        {
            driver.Url = "http://localhost/litecart/admin/";
            loginSection = new LoginSection(driver);

            var admPage = loginSection.LogInAdminPage("admin", "admin");

            List<string> menuItemsNames = admPage.GetMenuItemsNames(wait);
            List<bool> h1ExistsResults = new List<bool>();
            foreach (var item in menuItemsNames)
            {
                admPage.SelectMenuItem(item, wait);
                h1ExistsResults.Add(admPage.ContentHeaderPresence(wait));

                foreach (var subItem in admPage.GetSubMenuItemsNames(wait))
                {
                    admPage.SelectMenuItem(subItem, wait);
                    h1ExistsResults.Add(admPage.ContentHeaderPresence(wait));
                }
            }
            int testResult = 1;
            foreach (var item in h1ExistsResults)
            {
                testResult *= Convert.ToInt32(item);
            }
            Assert.IsTrue(testResult == 1);
        }

        [Test]
        public void tabletest()
        {
            driver.Url = "http://localhost/litecart/admin/";
            loginSection = new LoginSection(driver);
            var admPage = loginSection.LogInAdminPage("admin", "admin");
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";

            //TableHelper tableHelper = new TableHelper(driver.FindElement(By.CssSelector(".tableData")), wait);
            TableHelper tableHelper = new TableHelper(driver.FindElement(By.CssSelector(".dataTable")), wait);
            foreach (var item in tableHelper.GetColumnByIndex(3))
            {
                Console.WriteLine(item.Text);
            }
            foreach (var item in tableHelper.GetColumnByName("Name"))
            {
                Console.WriteLine(item.Text);
            }
            Console.WriteLine(tableHelper.GetCellByRowIndexColName(220, "Name"));
        }
    }
}
