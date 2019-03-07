using NUnit.Framework;
using OpenQA.Selenium.Edge;
using Pages;
using System;
using System.Collections.Generic;

namespace Tests.Edge

{
    [TestFixture]
    public class MainPageStickersTests : BaseTest<EdgeDriver>
    {
        [Test]
        public void TestAllProductsStickerPresence()
        {
            driver.Url = "http://localhost/litecart/";
            MainPage mainPage = new MainPage(driver);

            List<bool> stickersPresenceResults = new List<bool>();
            var productsList = mainPage.GetAllProducts();
            foreach (var item in productsList)
            {
                stickersPresenceResults.Add(new ProductCompactView(driver, item).HasOneSticker());
                Console.WriteLine(new ProductCompactView(driver, item).HasOneSticker());
            }

            int testResult = 1;
            foreach (var item in stickersPresenceResults)
            {
                testResult *= Convert.ToInt32(item);
            }
            Assert.IsTrue(testResult == 1);
        }
    }
}
