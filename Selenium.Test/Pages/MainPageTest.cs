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
        private static string EXPECTED_MAIN_URL = "https://avia.tutu.ru/";
        private static string EXPECTED_AIR_TICKETS_URL =
            "https://avia.tutu.ru/offers/?class=Y&passengers=100&route[0]=330-30122017-75&route[1]=75-01012018-330&changes=all";


        [SetUp]
        public void Init()
        {
            driver = DriverInstance.Get();
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

            Assert.AreEqual(driver.Url, EXPECTED_MAIN_URL);
        }

        [Test]
        public void OpenAirTicketsPage()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.Open().FindAirTickets();
            DriverInstance.SetWaitTime(30);

            Assert.AreEqual(driver.Url, EXPECTED_AIR_TICKETS_URL);
        }

        [Test]
        public void LeaveOpinion()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.Open().LeaveOpinion("Thank you for your work!");
            IWebElement title = driver.FindElement(By.ClassName("success_title"));

            Assert.IsTrue(title.Displayed);
        }
    }
}
