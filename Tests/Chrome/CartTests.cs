using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Pages;
using Pages.PageObjects.Header;

namespace Tests.Chrome
{
    [TestFixture]
    public class CartTests : BaseTest<ChromeDriver>
    {
        [Test]
        public void TestCartAddDeleteProducts()
        {
            driver.Url = "http://localhost/litecart/";
            MainPage mainPage = new MainPage(driver);

            Header headerInstance = new Header(driver);
            headerInstance.cartWrapper.WrapperText = "lol";

            mainPage.SelectProductByName("Blue Duck")
                .AddProductToCart()
                .GoToMainPage()
                .SelectProductByName("Red Duck")
                .AddProductToCart()
                .GoToMainPage()
                .SelectProductByName("Purple Duck")
                .AddProductToCart()
                .OpenCartPage()
                .RemoveAllCartItems();
        }
    }
}
