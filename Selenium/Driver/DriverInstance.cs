using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Selenium.Driver
{
    public static class DriverInstance
    {
        private static IWebDriver driver;

        public static IWebDriver Get()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
            }

            return driver;
        }

        public static void SetWaitTime(int seconds)
        {
            if (driver != null)
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
            }
        }

        public static void Close()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}
