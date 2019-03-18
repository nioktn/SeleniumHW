using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.PageObjects.Header
{
    public class CartWrapper : Header
    {
        public string WrapperText = "sample text";
        public CartWrapper(IWebDriver webDriver) : base (webDriver)
        {

        }
    }
}
