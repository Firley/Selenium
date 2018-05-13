using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nauka.PageObject
{
    class PozycjaWynikuPO
    {
        public PozycjaWynikuPO(IWebElement element)
        {
            this.element = element;
        }
        IWebElement element;
        public IWebElement Tytul
        {
            get { return element.FindElement(By.CssSelector("h3.r a")); }
        }
        public IWebElement Opis
        {
            get { return element.FindElement(By.CssSelector("span.st")); }
        }
    }
}
