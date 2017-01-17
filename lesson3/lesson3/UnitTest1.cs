using System;
using System.Drawing;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;

namespace csharp_example
{
    [TestFixture]
    public class MyFirstTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            // ChromeOptions options = new ChromeOptions();
            // options.BinaryLocation = @"C:\Users\Palnov\AppData\Local\Google\Chrome SxS\Application\chrome.exe";
            // options.AddArgument("start-maximized");
            // driver = new ChromeDriver(options);

            FirefoxOptions options = new FirefoxOptions();
            options.UseLegacyImplementation = false;
            FirefoxProfile profile = new FirefoxProfile("c:\\Users\\Palnov\\AppData\\Roaming\\Mozilla\\Firefox\\Profiles\\clwnpkkh.default");
            driver = new FirefoxDriver(profile);

        }

        [Test]
        public void FirstTest()
        {
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.FindElement(By.ClassName("gsfi")).SendKeys("webdriver");
            driver.FindElement(By.Name("btnG")).Click();
            wait.Until(ExpectedConditions.TitleIs("webdriver - Поиск в Google"));
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}