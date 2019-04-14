using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Pages;
using Pages.PageObjects.NavigationMenu;

namespace Tests.Chrome
{
    [TestFixture]
    public class TestOneChromeTests : BaseTest<ChromeDriver>
    {        
        [Test]
        public void TestTestMethod1()
        {
            driver.Url = "http://localhost/litecart/en/";
            LoginSection ls = new LoginSection(driver);
            ls.LogInStoreUser("test@gmail.com", "testpassword1");
        }


        [Test]
        public void TestEnterAdminPage()
        {
            driver.Url = "http://localhost/litecart/admin/";
            LoginSection loginSection = new LoginSection(driver);
            loginSection.LogInAdminPage("admin", "admin");
        }
    }
}
