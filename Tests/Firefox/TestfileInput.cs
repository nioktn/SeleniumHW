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
            driver.Url = "http://localhost/litecart/admin/";
            LoginSection loginSection = new LoginSection(driver);
            loginSection.LogInAdminPage("admin", "admin")
                .SelectMenuItem("Catalog");
            Catalog catalog = new Catalog(driver);

            string imagePath = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"..\..\src\images\linux.png");
            catalog.OpenProductAddingPage()
                .OpenGeneralTab()
                .UploadProductImage(imagePath)
                .EnterDateValidFromValue("03081998");
        }
    }
}
