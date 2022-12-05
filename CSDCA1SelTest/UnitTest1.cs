using NUnit.Framework;
using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    
    public class UnitTest1
    {

        [Test]
        public void TestMethod1()
        {
            String chromeDriverPath = Environment.GetEnvironmentVariable("ChromeWebDriver");

            chromeDriverPath ??= "C:\\Users\\Bearla\\Desktop\\CSDCA1";                 // for IDE

            using IWebDriver driver = new ChromeDriver(chromeDriverPath);
            // any exception below results in a test fail

            // navigate to URI for BPCalculator
            // web app running on IIS express
            driver.Navigate().GoToUrl("http://localhost:53135/");

            // get Systolic ID
            IWebElement SystolicElement = driver.FindElement(By.Id("SystId"));
            // enter 100 in element
            SystolicElement.SendKeys("100");

            // get Diastolic ID
            IWebElement DiastolicElement = driver.FindElement(By.Id("DiasId"));
            // enter 60 in element
            DiastolicElement.SendKeys("60");

            // submit the form
            driver.FindElement(By.Id("form1")).Submit();

            // explictly wait for result with "BPValue" item
            IWebElement ResultValue = new WebDriverWait(driver, TimeSpan.FromSeconds(20))
                .Until(c => c.FindElement(By.ClassName("form-control")));

            // item comes back like "Ideal Blood Pressure"
            string bpvalue = ResultValue.Text.ToString();

            StringAssert.EndsWith(bpvalue, "Ideal Blood Pressure");

            driver.Quit();

        }
    }
}
