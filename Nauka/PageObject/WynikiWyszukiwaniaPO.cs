
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nauka.PageObject
{
    class WynikiWyszukiwaniaPO
    {
        public WynikiWyszukiwaniaPO(IWebDriver driver)
        {
            this.driver = driver;

        }
        IWebDriver driver;

        [Obsolete]
        public IList<IWebElement> ListaWynikowWE
        {
            get
            {
                ReadOnlyCollection<IWebElement> kolekcjaWynikow = driver.FindElements(By.CssSelector(".srg .g"));
                return kolekcjaWynikow;
            }
        }

        public IList<PozycjaWynikuPO> ListaWynikow
        {
            get
            {
                List<PozycjaWynikuPO> listaPozycjiWynikow = new List<PozycjaWynikuPO>();
                ReadOnlyCollection<IWebElement> kolekcjaWynikow = driver.FindElements(By.CssSelector(".srg .g"));
                foreach (var pozycja in kolekcjaWynikow)
                {
                    listaPozycjiWynikow.Add(new PozycjaWynikuPO(pozycja));
                }
                return listaPozycjiWynikow;
            }
        }

        public IList<PozycjaWynikuPO> ListaWynikowLinq
        {
            get
            {
                ReadOnlyCollection<IWebElement> kolekcjaWynikow = driver.FindElements(By.CssSelector(".srg .g"));
                return kolekcjaWynikow.Select((pozycja) => { return new PozycjaWynikuPO(pozycja); }).ToList();
            }
        }


    }
}
