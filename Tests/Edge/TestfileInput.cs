using NUnit.Framework;
using OpenQA.Selenium.Edge;
using Pages;
using System;
using System.IO;

namespace Tests.Edge
{
    [TestFixture]
    public class TestFileInputTests : BaseTest<EdgeDriver>
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
