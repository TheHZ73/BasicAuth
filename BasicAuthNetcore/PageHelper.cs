using OpenQA.Selenium;

namespace BasicAuthNetcore
{
    class PageHelper
    {
        private IWebDriver driver;

        private const string URL_BASIC_AUTH = @"auth-demo.aerobatic.io/protected-standard/";
        private const string AUTH_SUCCES = "Auth Success";

        private By checkElement = By.CssSelector("body > div.container > section > h1");
        private By buttonLogout = By.CssSelector("body > div.container > p > a");


        public PageHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void LoginUrlAerobatic(string login, string password)
        {
            driver.Navigate().GoToUrl("https://" + login + ":" + password + "@" + URL_BASIC_AUTH);
        }

        public bool CheckLogin()
        {
            return driver.FindElement(checkElement).Text.Contains(AUTH_SUCCES);
        }

        public void PressLogout()
        {
            driver.FindElement(buttonLogout).Click();
        }
    }
}
