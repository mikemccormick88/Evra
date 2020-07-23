using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvraAutomatedTests;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTests
{
    [TestClass]
    public class chromeTests
    {
        [TestMethod]
        public void chromeLoginTest()
        {
            Boolean pass = false;
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Program program = new Program();
            program.loadLoginPage(driver);
            program.sumbitLoginDetails(driver, "qaskillschallenge@geophy.com", "qaskillschallenge@geophy.com");
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
        public void chromeLoginInvalidPassword()
        {
            Boolean pass = false;
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Program program = new Program();
            program.loadLoginPage(driver);
            program.sumbitLoginDetails(driver, "qaskillschallenge@geophy.com", "Qaskillschallenge@geophy.com");
            //check search page has not loaded
            if (!(program.isSearchPageLoaded(driver)))
            {
                pass = true;
            }
            //take screenshot if search page loads
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
        public void chromeSubmitValuationTest()
        {
            Boolean pass = false;
            IWebDriver driver = new ChromeDriver();
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

        [TestMethod]
        public void chromeNumberOfUnitsInputTest()
        {
            Boolean pass = false;
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Program program = new Program();
            program.loadLoginPage(driver);
            program.sumbitLoginDetails(driver, "qaskillschallenge@geophy.com", "qaskillschallenge@geophy.com");
            if (program.ElementXpathExists(driver, "//*[@name='number_of_units']"))
            {
                IWebElement numberOfUnitsInput = driver.FindElement(By.XPath("//*[@name='number_of_units']"));
                numberOfUnitsInput.SendKeys(Keys.ArrowUp);
                string text = numberOfUnitsInput.GetAttribute("value");
                //check number of units text box updates to 1 as expected
                if (!(text == "1"))
                {
                    pass = false;
                }
                else
                {
                    pass = true;
                }
                //take screenshot if text box value was not 1
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
}
