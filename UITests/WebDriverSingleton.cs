using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace UITests
{
    public class WebDriverSingleton
    {
        private static IWebDriver? driverInstance;

        private WebDriverSingleton() { }

        public static IWebDriver Instance
        {
            get
            {
                if (driverInstance == null)
                {
                    driverInstance = new EdgeDriver();
                    driverInstance.Manage().Window.Maximize();
                }
                return driverInstance;
            }
        }

        public static void QuitDriver()
        {
            if (driverInstance != null)
            {
                driverInstance.Quit();
                driverInstance.Dispose();
                driverInstance = null;
            }
        }
    }
}
