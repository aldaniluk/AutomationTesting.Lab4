using OpenQA.Selenium;

namespace Selenium.Pages
{
    public class MostPopularRussianAirportPage : Page
    {
        //airport Домодедово
        public static string URL { get; private set; } = "https://avia.tutu.ru/airport/27db84/";

        public MostPopularRussianAirportPage(IWebDriver driver) : base(driver)
        {
        }
    }
}
