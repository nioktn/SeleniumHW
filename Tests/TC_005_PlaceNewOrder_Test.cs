using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Pages;
using Pages.PageObjects.NavigationMenu;
using System.Threading;
using Pages.Helpers;
using Pages.PageObjects.Header;

namespace Tests
{
    [TestFixture]
    public class TC_005_PlaceNewOrder_Test : BaseTest<ChromeDriver>
    {
        private const string ProductName = "Blue Duck";
        private LoginSection loginSection;
        private ProductPage productPage;
        private CartWrapper cartWrapper;
        private CartPage cartPage;
        private SiteMenu siteMenu;
        private Navigation navigationSection;
        private LoggedUserSection loggedUserSection;
        private Sidebar adminSidebar;
        private Orders ordersPage;
        
        [Test]
        public void Test_PlaceNewOrder()
        {
            Thread.Sleep(1000);

            // Navigate to main page
            webDriver.Url = "http://localhost/litecart/";
            loginSection = new LoginSection(webDriver);

            // LogIn as a registered user
            loginSection.LogInStoreUser("user@mail.com", "password");

            // Search for product
            navigationSection = new Navigation(webDriver);
            navigationSection.ExequteSearchQuery("Blue Duck");
            productPage = new ProductPage(webDriver);
            Assert.AreEqual("Blue Duck", productPage.ProductName, $"Product page with name \"{ProductName}\" isn't found");

            // Add product to Cart
            productPage.AddProductToCart();

            // Navigate to Cart Page
            cartWrapper = new CartWrapper(webDriver);
            cartWrapper.ClickCheckoutLink();
            
            // Confirm Order
            cartPage = new CartPage(webDriver);
            cartPage.ConfirmOrder();
            Assert.IsTrue(cartPage.IsOrderSuccessful(), "Order confirmation was not successful");

            // Navigate to Home from site menu
            siteMenu = new SiteMenu(webDriver);
            siteMenu.NavigateHome();

            // LogOut from current user account
            loggedUserSection = new LoggedUserSection(webDriver);
            loggedUserSection.Logout.Click();

            // Navigate to Admin page
            webDriver.Url = "http://localhost/litecart/admin";

            // LogIn as admin
            loginSection.LogInAdminPage("admin", "admin");
            adminSidebar = new Sidebar(webDriver);

            // Navigate to orders page
            adminSidebar.SelectMenuItem("Orders");
            ordersPage = new Orders(webDriver);
            Assert.IsTrue(ordersPage.IsOrdersPageOpened());

            // Navigate to product editor
            ordersPage.OpenLastOrderEntry()
                .SetOrderStatus(AddEditOrder.OrderStatus.AwaitingPayment)
                .SaveOrder();

            // Navigate to main page
            webDriver.Url = "http://localhost/litecart/";
            loginSection = new LoginSection(webDriver);

            // LogIn as a registered user
            loginSection.LogInStoreUser("user@mail.com", "password");

            // Navigate to order history and check last order entry status
            loggedUserSection = new LoggedUserSection(webDriver);
            var lastOrderStatus = loggedUserSection.OpenOrderHistoryPage()
                .GetLastOrderStatus();
            var expectedStatusValue = EnumHelpers.GetEnumOptionDescription(AddEditOrder.OrderStatus.AwaitingPayment);
            StringAssert.AreEqualIgnoringCase(expectedStatusValue, lastOrderStatus);

        }
    }
}