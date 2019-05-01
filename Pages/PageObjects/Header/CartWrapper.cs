using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.PageObjects.Header
{
    public class CartWrapper : Header
    {
        protected readonly By _cartSection = By.CssSelector("#cart");
        protected readonly By _cartItemsQty = By.CssSelector("#cart .quantity");
        protected readonly By _cartValue = By.CssSelector("#cart .formatted_value");
        protected readonly string _cartCheckout = "//div[@id='cart']/.//a[contains(text(), 'Checkout')]";

        public CartWrapper(IWebDriver webDriver) : base (webDriver)
        {

        }


        public IWebElement CartItemsQty { get => webDriver.FindElement(_cartItemsQty); }
        public IWebElement CartValue { get => webDriver.FindElement(_cartValue); }
        public IWebElement CartCheckout { get => WaitForElementIsClickable(_cartCheckout); }

        public bool IsCartQuantityChanged(string quantity)
        {
            return WaitForBooleanCondition(() => CartItemsQty.Text.Contains(quantity));
        }

        public bool IsCartPaymentDueChanged(string value)
        {
            return WaitForBooleanCondition(() => CartValue.Text.Contains(value));
        }

        public void ClickCheckoutLink() => WaitForElementIsClickable(_cartCheckout).Click();
    }
}
