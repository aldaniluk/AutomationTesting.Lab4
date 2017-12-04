using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Linq;
using System.Threading;

namespace Selenium.Pages
{
    public class MainPage : Page
    {
        public static string URL { get; private set; } = "https://avia.tutu.ru/";

        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public MainPage Open()
        {
            driver.Navigate().GoToUrl(URL);
            return this;
        }

        public FindAirTicketsPage FindAirTickets()
        {
            IWebElement fromDate = driver.FindElement(By.ClassName("j-date_from"));
            fromDate.SendKeys("30.12.2017");

            IWebElement toDate = driver.FindElement(By.ClassName("j-date_back"));
            toDate.SendKeys("01.01.2018");

            IWebElement cityFrom = driver.FindElement(By.ClassName("j-city_from"));
            cityFrom.SendKeys("Минск");

            IWebElement cityTo = driver.FindElement(By.ClassName("j-city_to"));
            cityTo.SendKeys("Санкт-Петербург");


            IWebElement findTickects = driver.FindElement(By.ClassName("j-submit_button"));
            Thread.Sleep(1_000); //wait for 1 second
            findTickects.Click();

            return new FindAirTicketsPage(driver);
        }

        public MainPage LeaveOpinion(string message)
        {
            IWebElement leaveOpinion = driver.FindElement(By.ClassName("j-add_review_text"));
            leaveOpinion.Click();

            IWebElement comment = driver.FindElement(By.ClassName("j-comment"));
            comment.SendKeys(message);

            //find button "Отправить"
            IWebElement button = driver
                .FindElements(By.ClassName("j-button"))
                .Where(el => el.FindElement(By.ClassName("name")).Text == "Отправить")
                .First();

            button.Click();

            return this;
        }

        public AviaRulesPage OrderingAirTicketsRules()
        {
            //find link "Правила заказа авиабилетов"
            IWebElement rules = driver
                .FindElements(By.TagName("a"))
                .Where(el => el.Text == "Правила заказа авиабилетов")
                .First();

            rules.Click();

            return new AviaRulesPage(driver);
        }

        public AirportPage OpenAirports()
        {
            //find link "Аэропорты"
            IWebElement rules = driver
                .FindElements(By.TagName("a"))
                .Where(el => el.Text == "Аэропорты")
                .First();

            rules.Click();

            return new AirportPage(driver);
        }
    }
}
