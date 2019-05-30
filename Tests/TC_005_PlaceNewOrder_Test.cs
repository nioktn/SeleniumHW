using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Pages;
using Pages.PageObjects.NavigationMenu;
using System.Threading;

namespace Tests
{
    [TestFixture]
    public class TC_005_PlaceNewOrder_Test : BaseTest<ChromeDriver>
    {
        private const string ProductName = "Blue Duck";
        private LoginSection loginSection;
        private LoggedUserSection loggedUserSection;
        private Navigation navigationSeciton;
        private ProductPage productPage;
        private Sidebar adminSidebar;
        private Content adminContent;
        private AddEditProduct addEditProductPage;
        private TabGeneral generalTab;
        private Catalog catalogContent;

        [Test]
        public void Test_PlaceNewOrder()
        {
            Thread.Sleep(1000);
            //Navigate to main page
            webDriver.Url = "http://localhost/litecart/";
            loginSection = new LoginSection(webDriver);

            // LogIn as a registered user
            loginSection.LogInStoreUser("user@mail.com", "password");

            // Search for product
            navigationSeciton = new Navigation(webDriver);
            navigationSeciton.ExequteSearchQuery("Blue Duck");
            productPage = new ProductPage(webDriver);
            Assert.AreEqual("Blue Duck", productPage.ProductName, $"Product page with name \"{ProductName}\" isn't found");
            loggedUserSection = new LoggedUserSection(webDriver);
            loggedUserSection.Logout.Click();

            // Navigate to Admin page
            webDriver.Url = "http://localhost/litecart/admin";

            // LogIn as admin
            loginSection.LogInAdminPage("admin", "admin");
            adminSidebar = new Sidebar(webDriver);

            // Navigate to product editor
            adminSidebar.SelectMenuItem("Catalog");
            catalogContent = new Catalog(webDriver);
            catalogContent.ClickOnTableEntry("Rubber Ducks");
            addEditProductPage = catalogContent.OpenProductEditor(ProductName);
            generalTab = new TabGeneral(webDriver);
            Assert.AreEqual(generalTab.ProductNameValue(), ProductName, $"Editor page for product with name \"{ProductName}\" isn't opened");

            // Disable product
            generalTab.DisableProduct();
            generalTab.SaveNewProduct();

            // Navigate to main page
            webDriver.Url = "http://localhost/litecart/";
            loginSection = new LoginSection(webDriver);

            // LogIn as a registered user
            loginSection.LogInStoreUser("user@mail.com", "password");

            // Search for product
            navigationSeciton = new Navigation(webDriver);
            navigationSeciton.ExequteSearchQuery("Blue Duck");
            productPage = new ProductPage(webDriver);
            Assert.IsFalse(productPage.IsProductPageOpened());

            // Navigate to product editor
            adminSidebar.SelectMenuItem("Catalog");
            catalogContent = new Catalog(webDriver);
            catalogContent.SelectMenuItem("Rubber Ducks");
            addEditProductPage = catalogContent.OpenProductEditor(ProductName);
            generalTab = new TabGeneral(webDriver);
            Assert.AreEqual(generalTab.NameInput, ProductName, $"Editor page for product with name \"{ProductName}\" isn't opened");

            // Enable product after test is passed
            generalTab.EnableProduct();
            generalTab.SaveNewProduct();
        }
    }
}