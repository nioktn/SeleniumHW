using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Pages
{
    public class EditCountry : Content
    {
        private readonly By _geozonesTable = By.CssSelector("#table-zones");
        private readonly By _externalLinks = By.XPath("//*[contains(@class, 'external-link')]");

        public IWebElement GeozonesTable { get => webDriver.FindElement(_geozonesTable); }
        public IList<IWebElement> ExternalLinks { get => webDriver.FindElements(_externalLinks); }

        public EditCountry(IWebDriver driver) : base(driver) { }

        public List<string> GetGeozonesNames()
        {
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(webDriver, _geozonesTable));
            TableHelper table = new TableHelper(GeozonesTable);
            List<string> countriesNames = new List<string>();
            foreach (var item in table.GetColumnByName("Name"))
            {
                countriesNames.Add(item.Text);
            }
            return countriesNames;
        }

        public IList<IWebElement> GetAllExternalLinks()
        {
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(_externalLinks));
            return ExternalLinks;
        }
    }
}
