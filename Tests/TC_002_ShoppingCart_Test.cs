using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Pages;
using System;
using System.Threading;
using Pages.PageObjects;
using Pages.PageObjects.NavigationMenu;

namespace Tests
{
    [TestFixture]
    public class RegistrationPageTests : BaseTest<ChromeDriver>
    {
        static object[] newUserData = {
             new string[] {
                 "Firstname",
                 "Lastname",
                 "Address, 1",
                 "12345",
                 "Cityname",
                 "United States",
                 "HI",
                 string.Format("{0:0000}@test.com", new Random().Next(100000000)),
                 "+194094939403",
                 "pa$$w0rD" }
        };

        [Test, TestCaseSource("newUserData")]
        public void Test_RegisterNewUser(string firstname, string lastname, string address1, string postcode, string city, string country, string state, string email, string phone, string password)
        {
            Thread.Sleep(1000);
            driver.Url = "http://localhost/litecart/";
            LoginSection loginSection = new LoginSection(driver);
            loginSection.CreateNewUser()
                .EnterFirstName(firstname)
                .EnterLastName(lastname)
                .EnterMainAddress(address1)
                .EnterPostCode(postcode)
                .EnterCity(city)
                .EnterCountry(country)
                .EnterZoneCode(state)
                .EnterEmail(email)
                .EnterPhone(phone)
                .EnterPassword(password)
                .SubmitRegistration();

            Thread.Sleep(1000);
            LoggedUserSection userSection = new LoggedUserSection(driver);
            userSection.LogOut();
            loginSection.LogInStoreUser(email, password);
            userSection.LogOut();
            Thread.Sleep(1000);
        }

        public string GetRandomEmail()
        {
            Random random = new Random();
            string address = string.Format("{0:0000}@test.com", random.Next(10000));
            return address;
        }
    }
}
