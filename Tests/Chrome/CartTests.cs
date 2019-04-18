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
            webDriver.Url = "http://localhost/litecart/";
            MainPage mainPage = new MainPage(webDriver);

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
