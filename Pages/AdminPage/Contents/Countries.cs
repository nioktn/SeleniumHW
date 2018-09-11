using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Pages
{
    public class Countries : Content
    {
        private readonly By addNewCountryBtn = By.XPath("//*[contains(text(),'Add New Country')]");
        private readonly By _countriesTable = By.CssSelector(".dataTable");

        public IWebElement CountriesTable { get => driver.FindElement(_countriesTable); }

        public Countries(IWebDriver driver) : base(driver) { }

        public List<string> GetCountriesNames(WebDriverWait wait)
        {
            TableHelper table = new TableHelper(CountriesTable, wait);
            List<string> countriesNames = new List<string>();
            foreach (var item in table.GetColumnByName("Name"))
            {
                countriesNames.Add(item.Text);
            }
            return countriesNames;
        }

        public void OpenCountryById(int id, WebDriverWait wait)
        {
            TableHelper table = new TableHelper(CountriesTable, wait);
            table.GetCellByRowIndexColName(id, "Name").FindElement(By.XPath("./a")).Click();
        }
    }
}
