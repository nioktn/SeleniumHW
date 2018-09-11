using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Pages
{
    public class TableHelper
    {
        private readonly WebDriverWait wait;
        private readonly By _allRows = By.XPath("./tbody/tr");
        private readonly By _headers = By.XPath("./tbody/tr[1]/th");
        private readonly By _cellsOfRow = By.XPath("./td");

        public IWebElement tableElement;
        public IList<IWebElement> AllRows { get => tableElement.FindElements(_allRows); }
        public IList<IWebElement> Headers { get => tableElement.FindElements(_headers); }

        public TableHelper(IWebDriver driver, By tableLocator, WebDriverWait wait)
        {
            this.tableElement = driver.FindElement(tableLocator);
            this.wait = wait;
        }

        public TableHelper(IWebElement tableElement, WebDriverWait wait)
        {
            this.tableElement = tableElement;
            this.wait = wait;
        }

        public IList<IWebElement> GetCellsOfRow(IWebElement rowElement)
        {
            return rowElement.FindElements(_cellsOfRow);
        }

        public IList<IWebElement> GetColumnByIndex(int index)
        {
            //IList<IWebElement> result = new List<IWebElement>();
            //foreach (var row in AllRows)
            //{
            //    result.Add(GetCellsOfRow(row)[index]);
            //}
            //return result;
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

            //IList<IWebElement> result = new List<IWebElement>();
            //int 
            //foreach (var row in AllRows)
            //{
            //    result.Add(GetC)
            //}
        }

        public IWebElement GetCellByRowIndexColName(int rowIndex, string colName)
        {
            return GetColumnByName(colName)[rowIndex-1];
        }
    }
}
