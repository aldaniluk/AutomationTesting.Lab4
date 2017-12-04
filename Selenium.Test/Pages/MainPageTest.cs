using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Driver;
using Selenium.Pages;

namespace Selenium.Test.Pages
{
    [TestFixture]
    public class MainPageTest
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

        [Test]
        public void OpenMainPage()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.Open();

            Assert.AreEqual(driver.Url, MainPage.URL);
        }

        [Test]
        public void OpenAirTicketsPage()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.Open().FindAirTickets();

            Assert.AreEqual(driver.Url, FindAirTicketsPage.URL);
        }

        [Test]
        public void LeaveOpinion()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.Open().LeaveOpinion("Thank you for your work!");
            IWebElement title = driver.FindElement(By.ClassName("success_title"));

            Assert.IsTrue(title.Displayed);
        }

        [Test]
        public void OrderingAirTicketsRules()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.Open().OrderingAirTicketsRules();

            Assert.AreEqual(driver.Url, AviaRulesPage.URL);
        }

        [Test]
        public void OpenAirports()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.Open().OpenAirports();

            Assert.AreEqual(driver.Url, AirportPage.URL);
        }
    }
}
