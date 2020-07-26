using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvraAutomatedTests;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UnitTests
{
    [TestClass]
    public class chromeEndToEnd
    {
        string fileDir = "C:\\Testing\\Evra\\";

        [TestMethod]
        public void chromeEndToEndTest()
        {
            //set up test
            Boolean pass = false;
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Program program = new Program();
            program.endToEnd(driver);
            

            if (program.ElementExists(driver, "Id", "property-section"))
            {
                //test passes if results page loads successfully
                pass = true;
            }

            //take screenshot if results page failed to load
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            driver.Close();
            Assert.IsTrue(pass);
        }
    }
}