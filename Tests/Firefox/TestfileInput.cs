using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using Pages;
using System;
using System.IO;
using Pages.PageObjects.NavigationMenu;

namespace Tests.Firefox
{
    [TestFixture]
    public class TestFileInputTests : BaseTest<FirefoxDriver>
    {
        [Test]
        public void TestTestInputFile()
        {
            webDriver.Url = "http://localhost/litecart/admin/";
            LoginSection loginSection = new LoginSection(webDriver);
            loginSection.LogInAdminPage("admin", "admin")
                .SelectMenuItem("Catalog");
            Catalog catalog = new Catalog(webDriver);

            string imagePath = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"..\..\src\images\linux.png");
            catalog.OpenProductAddingPage()
                .OpenGeneralTab()
                .UploadProductImage(imagePath)
                .EnterDateValidFromValue("03081998");
        }
    }
}
