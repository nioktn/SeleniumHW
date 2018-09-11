using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Pages
{
    public class Countries : Content
    {
        private readonly By _addNewCountryBtn = By.XPath("//*[contains(text(),'Add New Country')]");
        private readonly By _countriesTable = By.XPath("//h1[contains(text(),'Countries')]/..//table");

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

        public EditCountry OpenCountryById(int id, WebDriverWait wait)
        {
            TableHelper table = new TableHelper(CountriesTable, wait);
            wait.Until((d) => ElemHelper.IsElementVisible(driver, _countriesTable));
            table.GetCellByRowIndexColName(id, "Name").FindElement(By.XPath("./a")).Click();
            return new EditCountry(driver);
        }
    }
}

