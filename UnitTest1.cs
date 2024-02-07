using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;



namespace FirstUnitTest
{
    [TestClass]
    public class ChessLoginTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [TestMethod]
        public async Task TestLoginAsync()

        {
            

            driver.Navigate().GoToUrl("https://www.chess.com/login_and_go");

            IWebElement usernameInput = driver.FindElement(By.Id("username"));

            usernameInput.SendKeys("robertknezevic77");

            await Task.Delay(2000);


            IWebElement passwordInput = driver.FindElement(By.Id("password"));
            passwordInput.SendKeys("Volimsah123");

            await Task.Delay(2000);


            IWebElement loginButton = driver.FindElement(By.Id("login"));
            loginButton.Click();

            await Task.Delay(3000);

            Assert.IsTrue(driver.Url.Contains("home"), "Prijavljivanje nije uspjelo.");

            await Task.Delay(0);

        }

    }
}