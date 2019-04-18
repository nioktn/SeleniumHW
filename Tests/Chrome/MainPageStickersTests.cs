using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Pages;
using System;
using System.Collections.Generic;

namespace Tests.Chrome
{
    [TestFixture]
    public class MainPageStickersTests : BaseTest<ChromeDriver>
    {
        [Test]
        public void TestAllProductsStickerPresence()
        {
            webDriver.Url = "http://localhost/litecart/";
            MainPage mainPage = new MainPage(webDriver);

            List<bool> stickersPresenceResults = new List<bool>();
            var productsList = mainPage.GetAllProducts();
            foreach (var item in productsList)
            {
                stickersPresenceResults.Add(new ProductCompactView(webDriver, item).HasOneSticker());
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
