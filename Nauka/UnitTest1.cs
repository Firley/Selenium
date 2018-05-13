using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Nauka
{

    [TestClass]
    public class UnitTest1
    {
        ChromeDriver driver;
        [TestInitialize]
        public void InicjalizujTesty()
        {
            driver = new ChromeDriver();
        }

        [TestMethod]
        public void TestMethod1()
        {
            driver.Url = "http://www.google.pl";
            IWebElement inputElement = driver.FindElementById("lst-ib");
            inputElement.SendKeys("Selenium WebDriver\n");
            ReadOnlyCollection<IWebElement> kolekcjaWynikow = driver.FindElements(By.CssSelector(".srg .g"));
            List<Pozycja> pozycje = new List<Pozycja>();
            foreach (var pozycjaElement in kolekcjaWynikow)
            {
                pozycje.Add(PobierzPozycje(pozycjaElement));
            }

            Random random = new Random();
            int wylosowanaPozycja = random.Next(kolekcjaWynikow.Count);
            IWebElement wylosowanaPozycjaElement = kolekcjaWynikow[wylosowanaPozycja];
            wchodzenieLink(wylosowanaPozycjaElement);

        }

        private Pozycja PobierzPozycje(IWebElement pozycjaElement)
        {
            IWebElement tytulPozycjiElement = pozycjaElement.FindElement(By.CssSelector("h3.r a"));

            Pozycja pozycja = new Pozycja();
            pozycja.Tytul = tytulPozycjiElement.Text;
            pozycja.Link = tytulPozycjiElement.GetAttribute("href");
            IWebElement opisElement = pozycjaElement.FindElement(By.CssSelector("span.st"));
            pozycja.Opis = opisElement.Text;
            return pozycja;
        }

        private void wchodzenieLink(IWebElement pozycjaElement)
        {
            IWebElement linkPozycjiElement = pozycjaElement.FindElement(By.CssSelector("h3.r a"));
            linkPozycjiElement.Click();
        }





        [TestCleanup]
        public void ZakonczTest()
        {
            driver.Quit();
        }
    }


}
