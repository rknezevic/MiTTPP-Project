using System;
using System.Diagnostics;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FourthUnitTest
{

    [TestClass]
    public class FilterSearch
    {

        private IWebDriver driver;
        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [TestMethod]
        public async Task FilterSearchTest()
        {

            driver.Navigate().GoToUrl("https://www.zalando.hr/muskarci-home/");

            await Task.Delay(2000);

            IWebElement shoes = driver.FindElement(By.CssSelector("a._ZDS_REF_SCOPE_.CDD5jc.l9TUOd.CKDt_l.LyRfpJ.JT3_zV._9ia6Xz.uMACAo._5Yd-hZ"));
            shoes.Click();

            await Task.Delay(2000);

            IWebElement brandElement = driver.FindElement(By.XPath("//*[@id='collection_view_catalog-filters']/div[2]/div[2]/div/button/span"));
            brandElement.Click();

            await Task.Delay(2000);

            IWebElement adidasElement = driver.FindElement(By.XPath("//span[contains(@class, 'sDq_FX') and text()='adidas (Sve)']"));
            adidasElement.Click();

            await Task.Delay(2000);

            IWebElement saveElement = driver.FindElement(By.XPath("//span[@class='heWLCX ZkIJC- r9BRio qXofat sDq_FX _2kjxJ6 dgII7d' and text()='Spremi']"));
            saveElement.Click();

        }
    }
}
 
