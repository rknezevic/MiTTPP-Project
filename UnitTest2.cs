using System;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SecondUnitTest
{
    [TestClass]
    public class ZalandoPurchaseTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [TestMethod]
        public async Task TestZalandoPurchase()
        {

            driver.Navigate().GoToUrl("https://www.zalando.hr/muskarci-home/");

            await Task.Delay(3000);
            IWebElement searchBox = driver.FindElement(By.CssSelector("input[name='q']"));
            searchBox.SendKeys("nike patike");
            searchBox.SendKeys(Keys.Return);

            await Task.Delay(5000);
            IWebElement firstProduct = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div/div[6]/div/div/div[2]/div[2]/div[1]/div/article/a/figure/div/div/img[1]"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", firstProduct);

            await Task.Delay(3000);

            IWebElement openSelectMenu = driver.FindElement(By.XPath("//*[@id=\"picker-trigger\"]/span"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", openSelectMenu);

            await Task.Delay(3000);

            IWebElement chooseSize = driver.FindElement(By.XPath("//span[@class='sDq_FX _2kjxJ6 dgII7d HlZ_Tf' and text()='40']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", chooseSize);

            await Task.Delay(3000);
            IWebElement buyNowButton = driver.FindElement(By.CssSelector("[data-testid='pdp-add-to-cart'] button"));
            buyNowButton.Click();


            await Task.Delay(3000);

        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
