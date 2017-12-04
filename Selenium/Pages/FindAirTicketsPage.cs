using OpenQA.Selenium;

namespace Selenium.Pages
{
    public class FindAirTicketsPage : Page
    {
        public static string URL { get; private set; } =
            "https://avia.tutu.ru/offers/?class=Y&passengers=100&route[0]=330-30122017-75&route[1]=75-01012018-330&changes=all";

        public FindAirTicketsPage(IWebDriver driver) : base(driver)
        {
        } 

        
    }
}
