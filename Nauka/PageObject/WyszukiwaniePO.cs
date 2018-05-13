using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nauka.PageObject
{
    class WyszukiwaniePO
    {
        public WyszukiwaniePO(IWebDriver driver)
        {
            this.driver = driver;

        }
        private IWebDriver driver;
        public IWebElement PoleWyszukiwania
        {
            get
            {
                return driver.FindElement(By.CssSelector("#lst-ib"));
            }
        }
    }
}
