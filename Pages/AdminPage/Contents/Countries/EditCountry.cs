using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Pages
{
    public class EditCountry : Content
    {
        private readonly By _geozonesTable = By.CssSelector("#table-zones");

        public IWebElement GeozonesTable { get => driver.FindElement(_geozonesTable); }

        public EditCountry(IWebDriver driver) : base(driver) { }

        public List<string> GetGeozonesNames(WebDriverWait wait)
        {
            wait.Until((d) => ElemHelper.IsElementVisible(driver, _geozonesTable));
            TableHelper table = new TableHelper(GeozonesTable, wait);
            List<string> countriesNames = new List<string>();
            foreach (var item in table.GetColumnByName("Name"))
            {
                countriesNames.Add(item.Text);
            }
            return countriesNames;
        }
    }
}
