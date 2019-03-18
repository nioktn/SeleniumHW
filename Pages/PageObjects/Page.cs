using OpenQA.Selenium;

namespace Pages.PageObjects
{
    public class Page : PageObjectBase
    {

        public Page(IWebDriver webDriver, Header header, Footer footer) : base(webDriver)
        {
            headerSection = header;
            footerSeciton = footer;
        }
    }
}
