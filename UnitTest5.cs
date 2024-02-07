using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace FifthUnitTest
{
    [TestClass]
    public class FillingForms
    {

        private IWebDriver driver;
        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [TestMethod]
        public async Task FillingFormsTest()
        {

            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            await Task.Delay(1000);
            

            driver.FindElement(By.Id("firstName")).SendKeys("Robert");
            await Task.Delay(750);
            driver.FindElement(By.Id("lastName")).SendKeys("Knezevic");
            await Task.Delay(750);
            driver.FindElement(By.Id("userEmail")).SendKeys("robertknezevic77@gmail.com");
            await Task.Delay(750);

            driver.FindElement(By.CssSelector("label[for='gender-radio-1']")).Click();
            await Task.Delay(750);

            driver.FindElement(By.Id("userNumber")).SendKeys("0976984686");
            await Task.Delay(750);

            IWebElement dateOfBirthInput = driver.FindElement(By.Id("dateOfBirthInput"));
            dateOfBirthInput.Click();
            await Task.Delay(750);

            IWebElement yearOfBirth = driver.FindElement(By.CssSelector(".react-datepicker__year-select"));
            SelectElement select = new SelectElement(yearOfBirth);
            select.SelectByValue("2000");
            await Task.Delay(750);

            //*[@id="dateOfBirth"]/div[2]/div[2]/div/div/div[2]/div[1]/div[2]/div[1]/select
            IWebElement monthOfBirth = driver.FindElement(By.CssSelector(".react-datepicker__month-select"));
            SelectElement selectMonth = new SelectElement(monthOfBirth);
            selectMonth.SelectByValue("11");
            await Task.Delay(750);

            driver.FindElement(By.CssSelector(".react-datepicker__day[aria-label='Choose Sunday, December 31st, 2000']")).Click();

            //driver.FindElement(By.CssSelector(".react-datepicker__day.react-datepicker__day--031.react-datepicker__day--selected.react-datepicker__day--weekend")).Click();

            driver.FindElement(By.Id("subjectsInput")).SendKeys("Testing this page");
            await Task.Delay(750);

            driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-1']")).Click();
            await Task.Delay(750);

            driver.FindElement(By.Id("currentAddress")).SendKeys("Vijenac Ivana Cesmickog 17, Osijek, Osjecko-Baranjska zupanija");
            await Task.Delay(750);

           /* IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.body.style.zoom='70%'");
            await Task.Delay(1500);*/
            
            IWebElement button = driver.FindElement(By.XPath("//*[@id=\"submit\"]"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", button);


            // Zatvorite preglednik
            driver.Quit();

        }
    }
}
