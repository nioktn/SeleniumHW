using NUnit.Framework;
using OpenQA.Selenium.Edge;
using Pages;
using System;
using System.Collections.Generic;

namespace Tests.Edge
{
    [TestFixture]
    public class CartTests : BaseTest<EdgeDriver>
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
