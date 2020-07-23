using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvraAutomatedTests;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace UnitTests
{
    [TestClass]
    public class firefoxTests
    {
        [TestMethod]
        public void fireFoxLoginTest()
        {
            Boolean pass = false;
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Program program = new Program();
            program.loadLoginPage(driver);
            program.sumbitLoginDetails(driver, "qaskillschallenge@geophy.com", "qaskillschallenge@geophy.com"); ;
            //check search page has loaded successfully
            if (program.isSearchPageLoaded(driver))
            {
                pass = true;
            }
            //take screenshot if search page failed to load
            if (pass == false)
            {
                //save screenshot with name of current failing test
                string filename = System.Reflection.MethodBase.GetCurrentMethod().Name;
                Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                image.SaveAsFile("C:\\Users\\Mike.McCormick\\Desktop\\Testing\\" + filename + ".png", ScreenshotImageFormat.Png);
            }
            driver.Close();
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void fireFoxSubmitValuationTest()
        {
            Boolean pass = false;
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Program program = new Program();
            program.endToEnd(driver);
            //check results page has loaded successfully
            if (program.isResultsPageLoaded(driver))
            {
                pass = true;
            }
            //take screenshot if search page failed to load
            if (pass == false)
            {
                //save screenshot with name of current failing test
                string filename = System.Reflection.MethodBase.GetCurrentMethod().Name;
                Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                image.SaveAsFile("C:\\Users\\Mike.McCormick\\Desktop\\Testing\\" + filename + ".png", ScreenshotImageFormat.Png);
            }
            driver.Close();
            Assert.IsTrue(pass);
        }
    }
}
