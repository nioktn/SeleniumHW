using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Pages;
using Pages.PageObjects.AdminPage.Contents.Customers;
using Pages.PageObjects.NavigationMenu;
using System;
using System.Linq;
using System.Threading;

namespace Tests
{
    [TestFixture]
    public class TC_001_RegisterCustomer_Test : BaseTest<ChromeDriver>
    {
        private Content adminContent;
        private LoginSection loginSection;

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
            webDriver.Url = "http://localhost/litecart/";
            loginSection = new LoginSection(webDriver);
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

            webDriver.Url = "http://localhost/litecart/admin";
            adminContent = loginSection.LogInAdminPage("admin", "admin");

            adminContent.SelectMenuItem(Content.AdminPageMenuItems.Customers);

            CustomersPage customersPage = new CustomersPage(webDriver);
            TableHelper th = new TableHelper(customersPage.CustomersTable);

            var nameColumnRows = th.GetColumnByName("Name").ToList();
            bool isNewCustomerPresentInTable = nameColumnRows.Any(entry => entry.Text.Contains(firstname) && entry.Text.Contains(lastname));

            Assert.IsTrue(isNewCustomerPresentInTable, "New customer is not preset in customers table");

            // Delete new customer after test is passed
            adminContent.OpenCustomerEditorPage(firstname)
                .DeleteCustomer();
        }

        public string GetRandomEmail()
        {
            Random random = new Random();
            string address = string.Format("{0:0000}@test.com", random.Next(10000));
            return address;
        }
    }
}
