using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.ComponentModel;
using Pages.Helpers;

namespace Pages
{
    public class AddEditOrder : Content
    {
        private const string _addProductButtonLocator = "//a[contains(@class,'button') and contains(text(),'Add Product')]";
        private const string _addCustomItemLocator = "//a[contains(@class,'button') and contains(text(),'Add Custom Item')]";
        private const string _saveButtonLocator = "//button[@type='submit' and @name='save']";
        private const string _cancelButtonLocator = "//button[@type='button' and @name='cancel']";
        private const string _addCommentButtonLocator = "//a[contains(@class,'button') and contains(text(),'Add Comment')]";
        private const string _orderStatusSelectLoator = "//select[@name='order_status_id']";

        public IWebElement AddProductButton => WaitForElementIsClickable(_addProductButtonLocator);
        public IWebElement AddCustomItemButton => WaitForElementIsClickable(_addCustomItemLocator);
        public IWebElement SaveButton => WaitForElementIsClickable(_saveButtonLocator);
        public IWebElement CancelButton => WaitForElementIsClickable(_cancelButtonLocator);
        public IWebElement AddCommentButton => WaitForElementIsClickable(_addCommentButtonLocator);
        public IWebElement OrderStatusSelectLocator => WaitForElementExists(_orderStatusSelectLoator);

        public AddEditOrder(IWebDriver driver) : base(driver) { }

        public enum OrderStatus
        {
            [Description("Awaiting payment")]
            AwaitingPayment,
            [Description("Pending")]
            Pending,
            [Description("Processing")]
            Processing,
            [Description("Dispatched")]
            Dispatched,
            [Description("Cancelled")]
            Cancelled
        }

        public AddEditOrder SetOrderStatus(OrderStatus orderStatus)
        {
            SelectElement select = new SelectElement(OrderStatusSelectLocator);
            select.SelectByText(EnumHelpers.GetEnumOptionDescription(orderStatus));
            return this;
        }

        public void SaveOrder() => SaveButton.Click();
    }
}