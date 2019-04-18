using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using Pages;
using System;
using System.Collections.Generic;
using System.Threading;
using Pages.PageObjects.NavigationMenu;

namespace Tests.Firefox
{
    [TestFixture]
    public class RegistrationPageTests : BaseTest<FirefoxDriver>
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
        public void TestRegisterNewUser(string firstname, string lastname, string address1, string postcode, string city, string country, string state, string email, string phone, string password)
        {
            webDriver.Url = "http://localhost/litecart/";
            LoginSection loginSection = new LoginSection(webDriver);
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
            LoggedUserSection userSection = new LoggedUserSection(webDriver);
            userSection.LogOut();
            loginSection.LogInStoreUser(email, password);
            userSection.LogOut();
        }

        public string GetRandomEmail()
        {
            Random random = new Random();
            string address = string.Format("{0:0000}@test.com", random.Next(10000));
            return address;
        }
    }
}
