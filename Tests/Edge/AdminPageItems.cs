using NUnit.Framework;
using OpenQA.Selenium.Edge;
using Pages;
using System;
using System.Collections.Generic;
using Pages.PageObjects.NavigationMenu;

namespace Tests.Edge
{
    [TestFixture]
    public class AdminPageItemsTests : BaseTest<EdgeDriver>
    {
        LoginSection loginSection;
        [Test]
        public void TestAdminPageClickOnEachMenuItem()
        {
            driver.Url = "http://localhost/litecart/admin/";
            loginSection = new LoginSection(driver);

            var admPage = loginSection.LogInAdminPage("admin", "admin");

            List<string> menuItemsNames = admPage.GetMenuItemsNames();
            List<bool> h1ExistsResults = new List<bool>();
            foreach (var item in menuItemsNames)
            {
                admPage.SelectMenuItem(item);
                h1ExistsResults.Add(admPage.ContentHeaderPresence());

                foreach (var subItem in admPage.GetSubMenuItemsNames())
                {
                    admPage.SelectMenuItem(subItem);
                    h1ExistsResults.Add(admPage.ContentHeaderPresence());
                }
            }
            int testResult = 1;
            foreach (var item in h1ExistsResults)
            {
                testResult *= Convert.ToInt32(item);
            }
            Assert.IsTrue(testResult == 1);
        }
    }
}
