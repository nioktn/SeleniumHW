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

        public static WebDriverWait GetInstance(IWebDriver driver, int time = 10)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(time));
        }
    }
}
