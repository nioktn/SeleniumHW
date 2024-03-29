﻿using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Pages;
using Pages.PageObjects.NavigationMenu;

namespace Tests.Chrome
{
    [TestFixture]
    public class TestOneChromeTests : BaseTest<ChromeDriver>
    {        
        [Test]
        public void TestTestMethod1()
        {
            webDriver.Url = "http://localhost/litecart/en/";
            LoginSection ls = new LoginSection(webDriver);
            ls.LogInStoreUser("test@gmail.com", "testpassword1");
        }


        [Test]
        public void TestEnterAdminPage()
        {
            webDriver.Url = "http://localhost/litecart/admin/";
            LoginSection loginSection = new LoginSection(webDriver);
            loginSection.LogInAdminPage("admin", "admin");
        }
    }
}
