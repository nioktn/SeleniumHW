using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Pages;
using Pages.PageObjects.Header;
using Pages.PageObjects.NavigationMenu;
using System.Linq;
using System.Threading;

namespace Tests
{
    [TestFixture]
    public class TC_003_AddNewProduct_Test : BaseTest<ChromeDriver>
    {
        private const string NewProductName = "NewProduct_TestName_1";
        private LoginSection loginSection;
        private Sidebar adminSidebar;
        private Catalog catalogContent;
        private AddEditProduct newProductPage;

        [Test]
        public void Test_AddDeleteProduct()
        {
            Thread.Sleep(1000);
            webDriver.Url = "http://localhost/litecart/admin";
            loginSection = new LoginSection(webDriver);
            loginSection.LogInAdminPage("admin", "admin");

            Thread.Sleep(1000);
            adminSidebar = new Sidebar(webDriver);
            adminSidebar.SelectMenuItem("Catalog");
            catalogContent = new Catalog(webDriver);
            Assert.IsTrue(catalogContent.IsCatalogPageOpened(), "Catalog page is not opened");

            Thread.Sleep(1000);
            newProductPage = catalogContent.OpenProductAddingPage();
            var generalTab = newProductPage.OpenGeneralTab();
            Assert.IsTrue(generalTab.IsGeneralTabOpened(), "General tab is not opened");
            generalTab.FillNameInput(NewProductName);

            Thread.Sleep(1000);
            var pricesTab = newProductPage.OpenPricesTab();
            Assert.IsTrue(pricesTab.IsPricesTabOpened(), "Prices tab is not opened");
            pricesTab.FillPurchasePrice("100")
                .SelectPurchaseCurrency(TabPrices.CurrencyOptions.USD)
                .FillGrossPriceUsd("150")
                .FillGrossPriceEur("135");
            newProductPage.SaveNewProduct();
            Assert.IsTrue(catalogContent.IsCatalogPageOpened(), "Catalog page is not opened");

            Thread.Sleep(1000);
            TableHelper th = new TableHelper(catalogContent.CatalogTable);
            var nameColumnRows = th.GetColumnByName("Name").ToList();
            bool isNewProductPresentInTable = nameColumnRows.Any(entry => entry.Text.Contains(NewProductName));
            Assert.IsTrue(isNewProductPresentInTable, "New product is not present in catalog table");

            Thread.Sleep(1000);
            catalogContent.OpenProductEditor(NewProductName)
                .DeleteProduct();
            th = new TableHelper(catalogContent.CatalogTable);
            nameColumnRows = th.GetColumnByName("Name").ToList();
            isNewProductPresentInTable = nameColumnRows.Any(entry => entry.Text.Contains(NewProductName));
            Assert.IsFalse(isNewProductPresentInTable, "New product is not deleted");
        }
    }
}
