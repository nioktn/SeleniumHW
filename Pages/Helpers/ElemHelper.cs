using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Pages
{
    public class ElemHelper
    {
        public static bool IsElementExists(IWebDriver driver, By locator)
        {
            try
            {
                driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }

        public static bool IsElementVisible(IWebDriver driver, By locator)
        {
            try
            {
                return driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }

        public static bool IsElementVisible(IWebElement parentElement, By locator)
        {
            try
            {
                return parentElement.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }

        public static void SelectFromDDL(IWebElement selectTag, string optionName)
        {
            SelectElement select = new SelectElement(selectTag);
            select.SelectByText(optionName);
        }

        public static void SelectFromDDLbyValue(IWebElement selectTag, string valueName)
        {
            SelectElement select = new SelectElement(selectTag);
            select.SelectByValue(valueName);
        }

        public static void SelectFromDDL(IWebElement selectTag, int index)
        {
            SelectElement select = new SelectElement(selectTag);
            select.SelectByIndex(index);
        }
    }
}
