using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvraAutomatedTests;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

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
            InternetExplorerOptions ieoptions = new InternetExplorerOptions();
            //causes exception when zoom settings are inconsistent
            ieoptions.IgnoreZoomLevel = true;
            //stop login page being redirected to search page in explorer
            ieoptions.EnsureCleanSession = true;
            IWebDriver driver = new InternetExplorerDriver(ieoptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Program program = new Program();
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
