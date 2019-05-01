using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pages.Helpers;
using System.Collections.Generic;

namespace Pages
{
    public class TabPrices : AddEditProduct
    {
        private const string PurchasePriceLocator = "//input[@name='purchase_price' and @type='number']";
        private const string PurchaseCurrencyLocator = "//select[@name='purchase_price_currency_code']";
        private const string GrossPriceUsd = "//input[@name='gross_prices[USD]']";
        private const string GrossPriceEur = "//input[@name='gross_prices[EUR]']";

        public TabPrices(IWebDriver driver) : base(driver) { }

        public TabPrices FillPurchasePrice(string value)
        {
            var elem = WaitForElementIsVisible(PurchasePriceLocator);
            elem.Clear();
            elem.SendKeys(value);
            return this;
        }

        public enum CurrencyOptions { USD, EUR }

        public TabPrices SelectPurchaseCurrency(CurrencyOptions option)
        {
            SelectElement purchaseCurrencySelect = new SelectElement(WaitForElementIsVisible(PurchaseCurrencyLocator));
            purchaseCurrencySelect.SelectByValue(option.ToString());
            return this;
        }

        public TabPrices FillGrossPriceUsd(string value)
        {
            var elem = WaitForElementIsVisible(GrossPriceUsd);
            elem.Clear();
            elem.SendKeys(value);
            return this;
        }

        public bool IsPricesTabOpened()
        {
            return WaitForElementIsVisible(PurchasePriceLocator).Displayed;
        }


        public TabPrices FillGrossPriceEur(string value)
        {
            var elem = WaitForElementIsVisible(GrossPriceEur);
            elem.Clear();
            elem.SendKeys(value);
            return this;
        }
    }
}