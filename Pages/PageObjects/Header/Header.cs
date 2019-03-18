using OpenQA.Selenium;

namespace Pages.PageObjects.Header
{
    public abstract class Header : PageObjectBase
    {
        protected const string LogotypeLocator = "//div[@id='logotype-wrapper']";
        protected const string HeaderSection = "//div[@id='header-wrapper']";

        protected IWebElement logotypeElement => WaitForElementIsClickable(LogotypeLocator);

        public Header(IWebDriver webDriver) : base(webDriver)
        {
        }




        //public MainPage GoToMainPage()
        //{
        //    Wait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(driver, _homeButton));
        //    HomeButton.Click();
        //    return new MainPage(driver);
        //}

        //public CartPage OpenCartPage()
        //{
        //    Wait.GetInstance(driver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(driver, _cartCheckout));
        //    CartCheckout.Click();
        //    return new CartPage(driver);
        //}
    }
}
