using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Pages;
using Pages.PageObjects.Header;
using Pages.PageObjects.NavigationMenu;
using System.Threading;

namespace Tests
{
    [TestFixture]
    public class RegistrationPageTests : BaseTest<ChromeDriver>
    {
        private Navigation navigationSection;
        private ProductPage productPage;
        private CartWrapper cartWrapper;
        private CartPage cartPage;

        [Test]
        public void Test_AddDeleteFromCart()
        {
            Thread.Sleep(1000);
            webDriver.Url = "http://localhost/litecart/";
            const string searchQuery = "Blue Duck";

            Thread.Sleep(1000);
            navigationSection = new Navigation(webDriver);
            navigationSection.ExequteSearchQuery(searchQuery);
            productPage = new ProductPage(webDriver);
            Assert.IsTrue(productPage.ProductName.Contains(searchQuery), "Searched product page wasn't opened");

            Thread.Sleep(1000);
            productPage.AddToCart();
            cartWrapper = new CartWrapper(webDriver);
            Assert.IsTrue(cartWrapper.IsCartQuantityChanged("1"), "Products quantity in cart wrapper isn't changed");
            Assert.IsTrue(cartWrapper.IsCartPaymentDueChanged("20"), "Payment due in cart wrapper isn't changed");

            Thread.Sleep(1000);
            cartWrapper.ClickCheckoutLink();
            cartPage = new CartPage(webDriver);
            StringAssert.Contains(cartPage.ProductName, searchQuery, "Added to cart product is not present on Cart Page");

            Thread.Sleep(1000);
            cartPage.RemoveCartItem(0);
            Assert.IsTrue(cartPage.IsCartEmpty(), "Product is not removed from the cart");
        }
    }
}
