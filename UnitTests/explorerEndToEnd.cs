using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvraAutomatedTests;
using OpenQA.Selenium;

namespace UnitTests
{
    [TestClass]
    public class explorerEndToEnd
    {
        [TestMethod]
        [Timeout (30000)]
        public void IeEndToEndTest()
        {
            Boolean pass = false;
            Program program = new Program();
            IWebDriver driver = program.getDriver("IE", 20);
            program.endToEnd(driver);
            //check test passes
            if (program.ElementExists(driver, "Id", "property-section"))
            {
                //test passes if search page loads successfully
                pass = true;
            }
            //take screenshot if search page failed to load
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
