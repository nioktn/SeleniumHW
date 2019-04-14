using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Pages.PageObjects
{
    public class RegisterCustomerPage : PageObjectBase
    {
        public RegisterCustomerPage(IWebDriver webDriver) : base (webDriver) { }

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

        public IWebElement TaxId { get => webDriver.FindElement(_taxId); }
        public IWebElement Company { get => webDriver.FindElement(_company); }
        public IWebElement Firstname { get => webDriver.FindElement(_firstname); }
        public IWebElement Lastname { get => webDriver.FindElement(_lastname); }
        public IWebElement Address1 { get => webDriver.FindElement(_address1); }
        public IWebElement Address2 { get => webDriver.FindElement(_address2); }
        public IWebElement Postcode { get => webDriver.FindElement(_postcode); }
        public IWebElement City { get => webDriver.FindElement(_city); }
        public IWebElement Country { get => webDriver.FindElement(_country); }
        public IWebElement Email { get => webDriver.FindElement(_email); }
        public IWebElement Phone { get => webDriver.FindElement(_phone); }
        public IWebElement Subscription { get => webDriver.FindElement(_subscription); }
        public IWebElement Password { get => webDriver.FindElement(_password); }
        public IWebElement ConfirmPassword { get => webDriver.FindElement(_confirmPassword); }
        public IWebElement CreateAccButton { get => webDriver.FindElement(_createAccButton); }
        public IWebElement ZoneCode { get => webDriver.FindElement(_zoneCode); }


        public RegisterCustomerPage EnterFirstName(string firstname)
        {
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(webDriver, _firstname));
            Firstname.SendKeys(firstname);
            return this;
        }
        public RegisterCustomerPage EnterLastName(string lastname)
        {
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(webDriver, _lastname));
            Lastname.SendKeys(lastname);
            return this;
        }
        public RegisterCustomerPage EnterMainAddress(string address1)
        {
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(webDriver, _address1));
            Address1.SendKeys(address1);
            return this;
        }
        public RegisterCustomerPage EnterCity(string city)
        {
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(webDriver, _city));
            City.SendKeys(city);
            return this;
        }
        public RegisterCustomerPage EnterCountry(string countryName)
        {
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(webDriver, _country));
            ElemHelper.SelectFromDDL(Country, countryName);
            return this;
        }
        public RegisterCustomerPage EnterZoneCode(string zoneName)
        {
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ZoneCode.Enabled);
            ElemHelper.SelectFromDDLbyValue(ZoneCode, zoneName);
            return this;
        }
        public RegisterCustomerPage EnterPostCode(string postcode)
        {
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(webDriver, _postcode));
            Postcode.SendKeys(postcode);
            return this;
        }
        public RegisterCustomerPage EnterEmail(string email)
        {
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(webDriver, _email));
            Email.SendKeys(email);
            return this;
        }
        public RegisterCustomerPage EnterPhone(string phone)
        {
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(webDriver, _phone));
            Phone.SendKeys(phone);
            return this;
        }
        public RegisterCustomerPage EnterPassword(string password)
        {
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(webDriver, _password));
            Password.SendKeys(password);
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(webDriver, _confirmPassword));
            ConfirmPassword.SendKeys(password);
            return this;
        }
        public RegisterCustomerPage SubmitRegistration()
        {
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(webDriver, _createAccButton));
            CreateAccButton.Click();
            return this;
        }
    }
}
