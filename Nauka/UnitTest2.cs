using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Nauka.PageObject;
using System.Linq;

namespace Nauka
{

    [TestClass]
    public class UnitTest2
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
            WyszukiwaniePO stronaWyszukiwania = new WyszukiwaniePO(driver);
            stronaWyszukiwania.PoleWyszukiwania.SendKeys("Selenium WebDriver\n");

            WynikiWyszukiwaniaPO stronaWynikow = new WynikiWyszukiwaniaPO(driver);
            IList<PozycjaWynikuPO> kolekcjaWynikow = stronaWynikow.ListaWynikow;

            List<Pozycja> pozycje = new List<Pozycja>();
            foreach (var pozycjaElement in kolekcjaWynikow)
            {
                pozycje.Add(PobierzPozycje(pozycjaElement));
            }


            var lista = pozycje.Where(p => p.Tytul.Contains("tutorial")).Take(3).ToList();

            Random random = new Random();
            int wylosowanaPozycja = random.Next(kolekcjaWynikow.Count);
            PozycjaWynikuPO wylosowanaPozycjaElement = kolekcjaWynikow[wylosowanaPozycja];
            wchodzenieLink(wylosowanaPozycjaElement);
            

        }

        private Pozycja PobierzPozycje(PozycjaWynikuPO pozycjaWyniku)
        {
            Pozycja pozycja = new Pozycja();

            pozycja.Tytul = pozycjaWyniku.Tytul.Text;
            pozycja.Link = pozycjaWyniku.Tytul.GetAttribute("href");
            pozycja.Opis = pozycjaWyniku.Opis.Text;

            return pozycja;
        }

        private void wchodzenieLink(PozycjaWynikuPO pozycjaWyniku)
        {
            pozycjaWyniku.Tytul.Click();
        }

        [TestCleanup]
        public void ZakonczTest()
        {
            driver.Quit();
        }
    }


}
