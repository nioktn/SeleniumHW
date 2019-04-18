using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Pages
{
    public class Countries : Content
    {
        private readonly By _addNewCountryBtn = By.XPath("//*[contains(text(),'Add New Country')]");
        private readonly By _countriesTable = By.XPath("//h1[contains(text(),'Countries')]/..//table");

        public IWebElement CountriesTable { get => webDriver.FindElement(_countriesTable); }

        public Countries(IWebDriver driver) : base(driver) { }

        public List<string> GetCountriesNames()
        {
            TableHelper table = new TableHelper(CountriesTable);
            List<string> countriesNames = new List<string>();
            foreach (var item in table.GetColumnByName("Name"))
            {
                countriesNames.Add(item.Text);
            }
            return countriesNames;
        }

        public EditCountry OpenCountryById(int id)
        {
            TableHelper table = new TableHelper(CountriesTable);
            Wait.GetInstance(webDriver, TimeSpan.FromSeconds(10)).Until((d) => ElemHelper.IsElementVisible(webDriver, _countriesTable));
            table.GetCellByRowIndexColName(id, "Name").FindElement(By.XPath("./a")).Click();
            return new EditCountry(webDriver);
        }
    }
}

