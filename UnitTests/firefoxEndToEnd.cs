using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvraAutomatedTests;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace UnitTests
{
    [TestClass]
    public class firefoxEndToEnd
    {

        [TestMethod]
        public void firefoxEndToEndTest()
        {
            Boolean pass = false;
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Program program = new Program();
            program.endToEnd(driver);
            //check test passes
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
