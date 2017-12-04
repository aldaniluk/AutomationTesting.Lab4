using OpenQA.Selenium;
using System.Linq;
using System.Threading;

namespace Selenium.Pages
{
    public class AirportPage : Page
    {
        public static string URL { get; private set; } = "https://avia.tutu.ru/airport/";
        public static string SEARCH { get; private set; } = "";

        public AirportPage(IWebDriver driver) : base(driver)
        {
        }

        public AirportPage FindByCity(string city)
        {
            IWebElement input = driver.FindElement(By.ClassName("rm-ms_field"));
            input.SendKeys(city);

            IWebElement findButton = driver.FindElement(By.ClassName("decor_button_text"));
            findButton.Click();

            SEARCH = $"?search={city}";
            return this;
        }

        public AirportPage OpenMostPopularRussianAirport()
        {
            //find list
            IWebElement topList = driver
                .FindElements(By.ClassName("airport_top__list"))
                .First();

            //select first airport in the list
            IWebElement firstItem = topList
                .FindElements(By.ClassName("airport_top__item"))
                .First()
                .FindElement(By.TagName("a"));

            firstItem.Click();

            return this;
        }

        public RussianAirportsPage OpenAllRussianAirports()
        {
            //find link "Все 317 аэропортов России"
            IWebElement allRussianAirportLink = driver
                .FindElements(By.TagName("a"))
                .Where(el => el.Text == "Все 317 аэропортов России")
                .First();

            allRussianAirportLink.Click();

            return new RussianAirportsPage(driver);
        }
    }
}
