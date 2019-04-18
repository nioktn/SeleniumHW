using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Pages;
using System;
using System.IO;
using Pages.PageObjects.NavigationMenu;

namespace Tests.Chrome
{
    [TestFixture]
    public class TestFileInputTests : BaseTest<ChromeDriver>
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
