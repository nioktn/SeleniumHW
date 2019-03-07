using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Pages;
using System.Collections.Generic;

namespace Tests.Chrome
{
    [TestFixture]
    public class AdminPageItemsTests : BaseTest<ChromeDriver>
    {
        LoginSection loginSection;
        [Test]
        public void TestAdminPageClickOnEachMenuItem()
        {
            driver.Url = "http://localhost/litecart/admin/";
            loginSection = new LoginSection(driver);

            var admPage = loginSection.LogInAdminPage("admin", "admin");

            List<string> menuItemsNames = admPage.GetMenuItemsNames();
            int numOfh1Headers = 0;
            foreach (var item in menuItemsNames)
            {
                admPage.SelectMenuItem(item);
                if (admPage.ContentHeaderPresence()) numOfh1Headers++;

                foreach (var subItem in admPage.GetSubMenuItemsNames())
                {
                    admPage.SelectMenuItem(subItem);
                    if (admPage.ContentHeaderPresence()) numOfh1Headers++;
                }
            }
            bool thereAre59h1Headers = numOfh1Headers == 59;
            Assert.IsTrue(thereAre59h1Headers);
        }
    }
}
