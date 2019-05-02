using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Pages
{
    public class TabGeneral : AddEditProduct
    {
        private readonly By _uploadImageField = By.XPath("//input[contains(@name, 'new_images[]')]");
        private readonly By _dateValidFrom = By.CssSelector("[name=date_valid_from]");
        private const string _nameInputLocator = "//input[@name='name[en]' and @type='text']";

        public IWebElement UploadImageField { get => webDriver.FindElement(_uploadImageField); }
        public IWebElement DateValidFrom { get => webDriver.FindElement(_dateValidFrom); }
        public IWebElement NameInput => WaitForElementExists(_nameInputLocator);

        public string ProductNameValue() => NameInput.GetAttribute("value").Trim();
        
        public TabGeneral(IWebDriver driver) : base(driver) { }

        public TabGeneral UploadProductImage(string path)
        {
            UploadImageField.SendKeys(path);
            return this;
        }

        public bool IsGeneralTabOpened()
        {
            return WaitForElementIsVisible(_nameInputLocator).Displayed;
        }

        public TabGeneral FillNameInput(string name)
        {
            NameInput.SendKeys(name);
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

