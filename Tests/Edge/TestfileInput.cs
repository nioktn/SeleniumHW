﻿using NUnit.Framework;
using OpenQA.Selenium.Edge;
using Pages;
using System;
using System.IO;
using Pages.PageObjects.NavigationMenu;

namespace Tests.Edge
{
    [TestFixture]
    public class TestFileInputTests : BaseTest<EdgeDriver>
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
