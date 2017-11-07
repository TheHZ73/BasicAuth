using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace BasicAuthNetcore
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void BeforeTest()
        {
            string directoryForChromeDriver = Directory.GetCurrentDirectory();
            driver = new ChromeDriver(directoryForChromeDriver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
        }

        [Test]
        public void TestBasicAuth()
        {
            string login = "aerobatic";
            string password = "aerobatic";

            var page = new PageHelper(driver);
            page.LoginUrlAerobatic(login, password);
            Assert.True(page.CheckLogin());
            page.PressLogout();
        }
    }
}