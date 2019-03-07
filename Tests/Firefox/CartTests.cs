using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using Pages;
using System;
using System.Collections.Generic;

namespace Tests.Firefox
{
    [TestFixture]
    public class CartTests : BaseTest<FirefoxDriver>
    {
        [Test]
        public void TestCartAddDeleteProducts()
        {
            driver.Url = "http://localhost/litecart/";
            MainPage mainPage = new MainPage(driver);

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
