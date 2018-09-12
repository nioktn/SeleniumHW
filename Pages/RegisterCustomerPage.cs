﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Pages
{
    public class RegisterCustomerPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private readonly By _taxId = By.CssSelector("[name=tax_id]");
        private readonly By _company = By.CssSelector("[name=company]");
        private readonly By _firstname = By.CssSelector("[name=firstname]");
        private readonly By _lastname = By.CssSelector("[name=lastname]");
        private readonly By _address1 = By.CssSelector("[name=address1]");
        private readonly By _address2 = By.CssSelector("[name=address2]");
        private readonly By _postcode = By.CssSelector("[name=postcode]");
        private readonly By _city = By.CssSelector("[name=city]");
        private readonly By _country = By.CssSelector("select[name=country_code]");
        private readonly By _email = By.CssSelector("[name=email]");
        private readonly By _phone = By.CssSelector("[name=phone]");
        private readonly By _subscription = By.CssSelector("[name=newsletter]");
        private readonly By _password = By.CssSelector("[name=password]");
        private readonly By _confirmPassword = By.CssSelector("[name=confirmed_password]");
        private readonly By _createAccButton = By.CssSelector("[name=create_account]");
        private readonly By _zoneCode = By.CssSelector("select[name=zone_code]");

        public IWebElement TaxId { get => driver.FindElement(_taxId); }
        public IWebElement Company { get => driver.FindElement(_company); }
        public IWebElement Firstname { get => driver.FindElement(_firstname); }
        public IWebElement Lastname { get => driver.FindElement(_lastname); }
        public IWebElement Address1 { get => driver.FindElement(_address1); }
        public IWebElement Address2 { get => driver.FindElement(_address2); }
        public IWebElement Postcode { get => driver.FindElement(_postcode); }
        public IWebElement City { get => driver.FindElement(_city); }
        public IWebElement Country { get => driver.FindElement(_country); }
        public IWebElement Email { get => driver.FindElement(_email); }
        public IWebElement Phone { get => driver.FindElement(_phone); }
        public IWebElement Subscription { get => driver.FindElement(_subscription); }
        public IWebElement Password { get => driver.FindElement(_password); }
        public IWebElement ConfirmPassword { get => driver.FindElement(_confirmPassword); }
        public IWebElement CreateAccButton { get => driver.FindElement(_createAccButton); }
        public IWebElement ZoneCode { get => driver.FindElement(_zoneCode); }

        public RegisterCustomerPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public RegisterCustomerPage EnterFirstName(string firstname)
        {
            Firstname.SendKeys(firstname);
            return this;
        }
        public RegisterCustomerPage EnterLastName(string lastname)
        {
            Lastname.SendKeys(lastname);
            return this;
        }
        public RegisterCustomerPage EnterMainAddress(string address1)
        {
            Address1.SendKeys(address1);
            return this;
        }
        public RegisterCustomerPage EnterCity(string city)
        {
            City.SendKeys(city);
            return this;
        }
        public RegisterCustomerPage EnterCountry(string countryName)
        {
            ElemHelper.SelectFromDDL(Country, countryName);
            return this;
        }
        public RegisterCustomerPage EnterZoneCode(string zoneName)
        {
            wait.Until((d) => ZoneCode.Enabled);
            ElemHelper.SelectFromDDLbyValue(ZoneCode, zoneName);
            return this;
        }
        public RegisterCustomerPage EnterPostCode(string postcode)
        {
            Postcode.SendKeys(postcode);
            return this;
        }
        public RegisterCustomerPage EnterEmail(string email)
        {
            Email.SendKeys(email);
            return this;
        }
        public RegisterCustomerPage EnterPhone(string phone)
        {
            Phone.SendKeys(phone);
            return this;
        }
        public RegisterCustomerPage EnterPassword(string password)
        {
            Password.SendKeys(password);
            ConfirmPassword.SendKeys(password);
            return this;
        }
        public RegisterCustomerPage SubmitRegistration()
        {
            CreateAccButton.Click();
            return this;
        }
    }
}
