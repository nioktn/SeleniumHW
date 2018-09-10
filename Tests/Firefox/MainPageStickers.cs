using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using Pages;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Tests.Firefox

{
    [TestFixture]
    public class MainPageStickers : BaseTest<FirefoxDriver>
    {
        [Test]
        public void AllProductsStickerPresence()
        {
            driver.Url = "http://localhost/litecart/";
            MainPage mainPage = new MainPage(driver);

            List<bool> stickersPresenceResults = new List<bool>();
            var productsList = mainPage.GetAllProducts(wait);
            foreach (var item in productsList)
            {
                stickersPresenceResults.Add(new ProductCompactView(driver, item).HasOneSticker(wait));
                Console.WriteLine(new ProductCompactView(driver, item).HasOneSticker(wait));
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
