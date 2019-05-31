using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using Pages.PageObjects;

namespace Pages
{
    public class CartPage : PageObjectBase
    {
        private readonly By _orderSummaryTable = By.XPath("//h2[contains(text(), 'Order Summary')]/..//table[contains(@class, 'dataTable')]");
        //private readonly By _removeCartItemButton = By.CssSelector("[name=remove_cart_item]");
        //private readonly By _updateCartItem = By.CssSelector("[name=update_cart_item]");
        private readonly By _shortcutCartItems = By.CssSelector("ul.shortcuts > li.shortcut");
        private readonly By _cartItems = By.CssSelector("ul.items > li.item");
        private const string _productNamePath = "//a[@href]/strong";
        private const string _emptyCartMessagePath = "//p/em[text()='There are no items in your cart.']";
        private const string _confirmOrderButtonLocator = "//button[@type='submit' and @name='confirm_order']";
        private const string _cartPageTitle = "//h1[@class='title']";

        //public IWebElement RemoveCartItemButton { get => driver.FindElement(_removeCartItemButton); }
        //public IWebElement UpdateCartItem { get => driver.FindElement(_updateCartItem); }
        public IList<IWebElement> ShortcutCartItems { get => webDriver.FindElements(_shortcutCartItems); }
        public IList<IWebElement> CartItems { get => webDriver.FindElements(_cartItems); }
        public IWebElement OrderSummaryTable { get => webDriver.FindElement(_orderSummaryTable); }
        public string ProductName => WaitForElementExists(_productNamePath).Text.Trim();
        public IWebElement ConfirmOrderButton => WaitForElementIsClickable(_confirmOrderButtonLocator);
        public IWebElement CartPageTitle => WaitForElementIsVisible(_cartPageTitle);

        public CartPage(IWebDriver driver) : base(driver) { }

        public CartPage RemoveCartItem(int index)
        {
            if (index != 0) ShortcutCartItems[index].Click();
            string currentItem = string.Format("//ul[contains(@class, 'items')]/./li[contains(@class, 'item')][{0}]", index + 1);
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(webDriver, By.XPath(currentItem)));
            string removeButton = currentItem + "/.//*[contains(text(), 'Remove')]";
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(webDriver, By.XPath(removeButton)));
            webDriver.FindElement(By.XPath(removeButton)).Click();
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(OrderSummaryTable));
            if (index != 0) Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_orderSummaryTable));
            return this;
        }

        public void ConfirmOrder() => ConfirmOrderButton.Click();

        public bool IsCartEmpty()
        {
            WaitForElementExists(_emptyCartMessagePath);
            return true;
        }

        public bool IsOrderSuccessful()
        {
            return CartPageTitle.Text.Contains("Your order is successfully completed!");
        }

        public CartPage RemoveAllCartItems()
        {
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(_shortcutCartItems));
            var shortcutItems = ShortcutCartItems;
            var cartItems = CartItems;
            for (int i = shortcutItems.Count - 1; i >= 0; i--)
            {
                RemoveCartItem(i);
            }
            return this;
        }
    }
}
