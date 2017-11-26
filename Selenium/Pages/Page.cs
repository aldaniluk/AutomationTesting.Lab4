using OpenQA.Selenium;

namespace Selenium.Pages
{
    public abstract class Page
    {
        protected IWebDriver driver;

        public Page(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
