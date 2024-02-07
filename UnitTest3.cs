using System;
using System.Diagnostics;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ThirdUnitTest
{
    [TestClass]
    public class Performance
    {

        private IWebDriver driver;
        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [TestMethod]
        public async Task PerformanceTest()
        {
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                driver.Navigate().GoToUrl("https://www.zalando.hr/muskarci-home/");

                await Task.Delay(1000);


                IWebElement shoes = driver.FindElement(By.CssSelector("a._ZDS_REF_SCOPE_.CDD5jc.l9TUOd.CKDt_l.LyRfpJ.JT3_zV._9ia6Xz.uMACAo._5Yd-hZ"));
                shoes.Click();


                stopwatch.Stop();

                Console.WriteLine($"Vrijeme učitavanja stranice: {stopwatch.ElapsedMilliseconds} ms");

                Assert.IsTrue(stopwatch.ElapsedMilliseconds < 7000, "Stranica se učitala u manje od 3 sekunde.");

            }
        }
    }
}