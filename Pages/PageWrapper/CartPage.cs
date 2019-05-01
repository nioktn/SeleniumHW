using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Pages
{
    public class CartPage : HeaderWrapper
    {
        private readonly By _orderSummaryTable = By.XPath("//h2[contains(text(), 'Order Summary')]/..//table[contains(@class, 'dataTable')]");
        //private readonly By _removeCartItemButton = By.CssSelector("[name=remove_cart_item]");
        //private readonly By _updateCartItem = By.CssSelector("[name=update_cart_item]");
        private readonly By _shortcutCartItems = By.CssSelector("ul.shortcuts > li.shortcut");
        private readonly By _cartItems = By.CssSelector("ul.items > li.item");
        private const string _productNamePath = "//a[@href]/strong";
        private const string _emptyCartMessagePath = "//p/em[text()='There are no items in your cart.']";

        //public IWebElement RemoveCartItemButton { get => driver.FindElement(_removeCartItemButton); }
        //public IWebElement UpdateCartItem { get => driver.FindElement(_updateCartItem); }
        public IList<IWebElement> ShortcutCartItems { get => driver.FindElements(_shortcutCartItems); }
        public IList<IWebElement> CartItems { get => driver.FindElements(_cartItems); }
        public IWebElement OrderSummaryTable { get => driver.FindElement(_orderSummaryTable); }
        public string ProductName => WaitForElementExists(_productNamePath).Text.Trim();

        public CartPage(IWebDriver driver) : base(driver) { }

        public CartPage RemoveCartItem(int index)
        {
            if (index != 0) ShortcutCartItems[index].Click();
            string currentItem = string.Format("//ul[contains(@class, 'items')]/./li[contains(@class, 'item')][{0}]", index + 1);
            Wait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(driver, By.XPath(currentItem)));
            string removeButton = currentItem + "/.//*[contains(text(), 'Remove')]";
            Wait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(driver, By.XPath(removeButton)));
            driver.FindElement(By.XPath(removeButton)).Click();
            Wait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(OrderSummaryTable));
            if (index != 0) Wait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(_orderSummaryTable));
            return this;
        }


        public bool IsCartEmpty()
        {
            WaitForElementExists(_emptyCartMessagePath);
            return true;
        }

        public CartPage RemoveAllCartItems()
        {
            Wait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(_shortcutCartItems));
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
