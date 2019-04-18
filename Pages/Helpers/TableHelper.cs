using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Pages
{
    public class TableHelper
    {
        private readonly By _allRows = By.XPath("/descendant::tr[@class='row'] ");
        private readonly By _headers = By.XPath("./tbody/tr[1]/th");
        private readonly By _cellsOfRow = By.XPath("./td");

        public IWebElement tableElement;
        public IList<IWebElement> AllRows { get => tableElement.FindElements(_allRows); }
        public IList<IWebElement> Headers { get => tableElement.FindElements(_headers); }

        public TableHelper(IWebDriver driver, By tableLocator)
        {
            this.tableElement = driver.FindElement(tableLocator);
        }

        public TableHelper(IWebElement tableElement)
        {
            this.tableElement = tableElement;
        }
        
        public IList<IWebElement> GetCellsOfRow(IWebElement rowElement)
        {
            return rowElement.FindElements(_cellsOfRow);
        }

        public IList<IWebElement> GetColumnByIndex(int index)
        {
            string columnLocator = string.Format("./tbody/tr/td[{0}]", index);
            return tableElement.FindElements(By.XPath(columnLocator));
        }

        public IList<IWebElement> GetColumnByName(string name)
        {
            int index = 0;
            foreach (var item in Headers)
            {
                if (item.Text.Contains(name)) break;
                else index++;
            }
            return GetColumnByIndex(index + 1);
        }

        public IWebElement GetCellByRowIndexColName(int rowIndex, string colName)
        {
            return GetColumnByName(colName)[rowIndex-1];
        }
    }
}
