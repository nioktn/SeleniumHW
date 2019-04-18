﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Pages
{
    public class TabGeneral : AddNewProduct
    {
        private readonly By _uploadImageField = By.XPath("//input[contains(@name, 'new_images[]')]");
        private readonly By _dateValidFrom = By.CssSelector("[name=date_valid_from]");

        public IWebElement UploadImageField { get => webDriver.FindElement(_uploadImageField); }
        public IWebElement DateValidFrom { get => webDriver.FindElement(_dateValidFrom); }

        public TabGeneral(IWebDriver driver) : base(driver) { }

        public TabGeneral UploadProductImage(string path)
        {
            UploadImageField.SendKeys(path);
            return this;
        }

        public TabGeneral EnterDateValidFromValue(string value)
        {
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(webDriver, _dateValidFrom));
            DateValidFrom.SendKeys(value);
            return this;
        }
    }
}

