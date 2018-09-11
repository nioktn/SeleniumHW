using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pages;
using System;
using System.Collections.Generic;

namespace Tests.Chrome
{
    [TestFixture]
    public class ProductPageCompactViewTest : BaseTest<ChromeDriver>
    {
        MainPage mainPage;
        IWebElement firstCampaignProduct;
        ProductCompactView compactView;
        ProductPage productPage;

        [Test]
        public void MainPageCompactViewAspectsCompare()
        {
            driver.Url = "http://localhost/litecart/";
            mainPage = new MainPage(driver);
            firstCampaignProduct = mainPage.GetCampaignsProducts(wait)[0];
            compactView = new ProductCompactView(driver, firstCampaignProduct);
            productPage = new ProductPage(driver);

            List<string> compactViewValues = new List<string>();
            compactViewValues.Add(compactView.Name.Text);
            compactViewValues.Add(compactView.RegularPrice.Text);
            compactViewValues.Add(compactView.CampaignPrice.Text);

            CompactViewRegularPriceGrayColor();
            CompactViewCampaignPriceRedBold();
            PageRegularPriceGrayLine();
            PageCampaignPriceRedBold();
            
            List<string> productPageValues = new List<string>();
            productPageValues.Add(productPage.Name.Text);
            productPageValues.Add(productPage.RegularPrice.Text);
            productPageValues.Add(productPage.CampaignPrice.Text);

            CollectionAssert.AreEqual(compactViewValues, productPageValues);
        }

        public void CompactViewRegularPriceGrayColor()
        {
            var compactRegularRgbValues = compactView.RegularPrice.GetCssValue("color").Substring(5, 13).Split(',');
            bool colorIsGray = Convert.ToInt32(compactRegularRgbValues[0]) == Convert.ToInt32(compactRegularRgbValues[1]) &
                Convert.ToInt32(compactRegularRgbValues[1]) == Convert.ToInt32(compactRegularRgbValues[2]); //gray color

            bool isLineThrow = "line-through".Equals(compactView.RegularPrice.GetCssValue("text-decoration-line")); //line-through

            Assert.IsTrue(isLineThrow & colorIsGray);
        }

        public void CompactViewCampaignPriceRedBold()
        {
            var compactCampaignRgbValues = compactView.CampaignPrice.GetCssValue("color").Substring(5, 13).Split(',');
            bool compactColorIsRed = Convert.ToInt32(compactCampaignRgbValues[1]) == 0 & Convert.ToInt32(compactCampaignRgbValues[2]) == 0; //red color

            bool isBold = "700".Equals(compactView.CampaignPrice.GetCssValue("font-weight")); //is bold

            var compactSizeRegularPrice = compactView.RegularPrice.GetCssValue("font-size");
            var compactSizeCampaignPrice = compactView.CampaignPrice.GetCssValue("font-size");
            bool isCampaignFontBigger = (Convert.ToInt32(compactSizeRegularPrice.Substring(0, 2)) < Convert.ToInt32(compactSizeCampaignPrice.Substring(0, 2))); // campaign font size > regular font size

            Assert.IsTrue(compactColorIsRed & isBold & isCampaignFontBigger);
        }

        public void PageRegularPriceGrayLine()
        {
            firstCampaignProduct.Click();
            var pageRegularRgbValues = productPage.RegularPrice.GetCssValue("color").Substring(5, 13).Split(',');
            bool pageColorIsGray = Convert.ToInt32(pageRegularRgbValues[0]) == Convert.ToInt32(pageRegularRgbValues[1]) &
                Convert.ToInt32(pageRegularRgbValues[1]) == Convert.ToInt32(pageRegularRgbValues[2]); //gray color

            bool isLineThrough = "line-through".Equals(productPage.RegularPrice.GetCssValue("text-decoration-line")); //line-through   

            Assert.IsTrue(pageColorIsGray & isLineThrough);
        }

        public void PageCampaignPriceRedBold()
        {
            var pageCampaignRgbValues = productPage.CampaignPrice.GetCssValue("color").Substring(5, 13).Split(',');
            bool pageColorIsRed = Convert.ToInt32(pageCampaignRgbValues[1]) == 0 & Convert.ToInt32(pageCampaignRgbValues[2]) == 0; //red color

            bool isBold = "700".Equals(productPage.CampaignPrice.GetCssValue("font-weight")); //is bold

            var pageSizeRegularPrice = productPage.RegularPrice.GetCssValue("font-size");
            var pageSizeCampaignPrice = productPage.CampaignPrice.GetCssValue("font-size");
            bool isCampaignFontBigger = Convert.ToInt32(pageSizeRegularPrice.Substring(0, 2)) < Convert.ToInt32(pageSizeCampaignPrice.Substring(0, 2)); // campaign fort pageSize > regular font pageSize 

            Assert.IsTrue(isBold & isCampaignFontBigger);
        }
    }
}
