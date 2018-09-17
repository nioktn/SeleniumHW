using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Pages
{
    public static class Wait
    {
        public static WebDriverWait GetInstance(IWebDriver driver, TimeSpan time)
        {
            return new WebDriverWait(driver, time);
        }
    }
}
