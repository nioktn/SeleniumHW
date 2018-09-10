using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Pages;
using System;
using System.Collections.Generic;

namespace Tests.Chrome

{
    [TestFixture]
    public class MainPageStickers : BaseTest<ChromeDriver>
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
