using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Pages;
using System;
using System.Collections.Generic;
using Pages.PageObjects.NavigationMenu;

namespace Tests.Chrome
{
    [TestFixture]
    public class CountriesTests : BaseTest<ChromeDriver>
    {
        LoginSection loginSection;
        [Test]
        public void TestCountriesAlphabeticOrder()
        {
            webDriver.Url = "http://localhost/litecart/admin/";
            loginSection = new LoginSection(webDriver);
            var content = loginSection.LogInAdminPage("admin", "admin");
            webDriver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";

            Countries countries = new Countries(webDriver);
            List<string> actualResult = countries.GetCountriesNames();
            List<string> expectedResult = actualResult;
            expectedResult.Sort();
            CollectionAssert.AreEqual(expectedResult, actualResult);
            //admPage.LogOut();
        }

        static object[] countriesIds = {
            new Int32[] { 223 },
            new Int32[] { 38 } };

        [Test, TestCaseSource("countriesIds")]
        public void TestUSA_Canada_GeozonesAlphabeticOrderTest(int countryId)
        {
            webDriver.Url = "http://localhost/litecart/admin/";
            loginSection = new LoginSection(webDriver);
            var admPage = loginSection.LogInAdminPage("admin", "admin");
            webDriver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";

            Countries countries = new Countries(webDriver);
            List<string> actualResult = countries.OpenCountryById(countryId)
                .GetGeozonesNames();
            List<string> expectedResult = actualResult;
            expectedResult.Sort();
            CollectionAssert.AreEqual(expectedResult, actualResult);
            admPage.LogOut();
        }
    }
}
