using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Pages;
using System;
using System.IO;

namespace Tests.Chrome
{
    [TestFixture]
    public class TestFileInput : BaseTest<ChromeDriver>
    {
        [Test]
        public void TestInputFile()
        {
            driver.Url = "http://localhost/litecart/admin/";
            LoginSection loginSection = new LoginSection(driver);
            loginSection.LogInAdminPage("admin", "admin")
                .SelectMenuItem("Catalog", wait);
            Catalog catalog = new Catalog(driver);

            string imagePath = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"..\..\src\images\linux.png");
            catalog.OpenProductAddingPage()
                .OpenGeneralTab()
                .UploadProductImage(imagePath)
                .EnterDateValidFromValue("03081998", wait);
        }
    }
}
