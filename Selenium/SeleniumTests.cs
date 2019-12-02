using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace Selenium
{
    class SeleniumTests
    {
        IWebDriver driverF = new FirefoxDriver();
        IWebDriver driverC;
        string url = "https://www.google.com";
        
        [Test]
        public void TestGoogleSearchInFF()
        {
            GoToWebsite(driverF, url, 3000);
            IWebElement searchField = driverF.FindElement(By.Name("q"));
            searchField.SendKeys("C# selenium tests");
            Wait(2000);
            searchField.SendKeys(Keys.Enter);
            Wait(1000);
            driverF.Close();

        }

        [Test]
        public void TestGoogleSearchInChrome()
        {
            GoToWebsite(driverC, url, 3000);
            IWebElement searchField = driverC.FindElement(By.Name("q"));
            searchField.SendKeys("C# selenium tests");
            Wait(2000);
            searchField.SendKeys(Keys.Enter);
            Wait(2000);
        }

        private void GoToWebsite(IWebDriver driver, string url, int ms)
        {
            Wait(ms);
            driver.Navigate().GoToUrl("https://wwww.google.com/");
            Wait(ms);
        }

        static private void Wait(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }

        [SetUp]
        public void Init()
        {
            driverF = new FirefoxDriver();
            driverC = new ChromeDriver();
        }

        [TearDown]
        public void Destroy()
        {
            driverF.Close();
            driverC.Close();
        }
    }
}