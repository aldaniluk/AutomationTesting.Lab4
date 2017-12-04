using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Driver;
using Selenium.Pages;
using System;
using System.Threading;
using System.Web;

namespace Selenium.Test.Pages
{
    [TestFixture]
    public class AirportPageTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Init()
        {
            driver = DriverInstance.Get();
            DriverInstance.SetWaitTime(30);
        }

        [TearDown]
        public void Close()
        {
            DriverInstance.Close();
        }

        [TestCase("Минск")]
        [TestCase("Барселона")]
        [TestCase("Сальто")]
        public void FindByCity(string city)
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.Open().OpenAirports().FindByCity(city);
            
            //encode because of russian letters
            Assert.IsTrue(string.Compare(driver.Url, 
                $"{AirportPage.URL}?search={HttpUtility.UrlEncode(city)}",
                StringComparison.InvariantCultureIgnoreCase) == 0);
        }

        [Test]
        public void OpenMostPopularRussianAirport()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.Open().OpenAirports().OpenMostPopularRussianAirport();

            Assert.AreEqual(driver.Url, MostPopularRussianAirportPage.URL);
        }

        [Test]
        public void OpenAllRussianAirports()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.Open().OpenAirports().OpenAllRussianAirports();

            Assert.AreEqual(driver.Url, RussianAirportsPage.URL);
        }
    }
}
