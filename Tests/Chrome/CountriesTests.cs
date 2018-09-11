using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Pages;
using System;
using System.Collections.Generic;

namespace Tests.Chrome
{
    [TestFixture]
    public class CountriesTests : BaseTest<ChromeDriver>
    {
        LoginSection loginSection;
        [Test]
        public void CountriesAlphabeticOrderTest()
        {
            driver.Url = "http://localhost/litecart/admin/";
            loginSection = new LoginSection(driver);
            var admPage = loginSection.LogInAdminPage("admin", "admin");
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";

            Countries countries = new Countries(driver);
            List<string> actualResult = countries.GetCountriesNames(wait);
            List<string> expectedResult = actualResult;
            expectedResult.Sort();
            foreach (var item in expectedResult)
            {
                Console.WriteLine(item);
            }

            foreach (var item in actualResult)
            {
                Console.WriteLine(item);
            }
            CollectionAssert.AreEqual(expectedResult, actualResult);
            admPage.LogOut();
        }

        static object[] countriesIds = {
            new Int32[] { 223 },
            new Int32[] { 38 } };

        [Test, TestCaseSource("countriesIds")]
        public void USA_Canada_GeozonesAlphabeticOrderTest(int countryId)
        {
            driver.Url = "http://localhost/litecart/admin/";
            loginSection = new LoginSection(driver);
            var admPage = loginSection.LogInAdminPage("admin", "admin");
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";

            Countries countries = new Countries(driver);
            List<string> actualResult = countries.OpenCountryById(countryId, wait)
                .GetGeozonesNames(wait);
            List<string> expectedResult = actualResult;
            expectedResult.Sort();
            CollectionAssert.AreEqual(expectedResult, actualResult);
            admPage.LogOut();
        }
    }
}
