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
        string fileDir = "C:\\Users\\Mike.McCormick\\Documents\\Testing\\Evra\\FailedTests\\";
        [TestMethod]
        public void chromeLoginTest()
        {
            //set up test
            Boolean pass = false;
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Program program = new Program();
            program.loadLoginPage(driver);
            program.sumbitLoginDetails(driver, "qaskillschallenge@geophy.com", "qaskillschallenge@geophy.com");

            //check test passes
            if (program.isSearchPageLoaded(driver))
            {
                //test passes if search page loads successfully
                pass = true;
            }
            //take screenshot if search page failed to load
            if (pass == false)
            {
                //save screenshot with name of current failing test
                string filename = System.Reflection.MethodBase.GetCurrentMethod().Name;
                Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                image.SaveAsFile(fileDir + filename + ".png", ScreenshotImageFormat.Png);
            }
            driver.Close();
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void chromeLoginInvalidPassword()
        {
            //set up test
            Boolean pass = false;
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Program program = new Program();
            program.loadLoginPage(driver);
            program.sumbitLoginDetails(driver, "qaskillschallenge@geophy.com", "Qaskillschallenge@geophy.com");

            //check test passes
            if (!(program.isSearchPageLoaded(driver)))
            {
                //test passes if search page fails to load
                pass = true;
            }

            //take screenshot if search page loads successfully
            if (pass == false)
            {
                //save screenshot with name of current failing test
                string filename = System.Reflection.MethodBase.GetCurrentMethod().Name;
                Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                image.SaveAsFile(fileDir + filename + ".png", ScreenshotImageFormat.Png);
            }
            driver.Close();
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void chromeSubmitValuationTest()
        {
            //set up test
            Boolean pass = false;
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Program program = new Program();
            program.endToEnd(driver);

            //check test passes
            if (program.isResultsPageLoaded(driver))
            {
                //test passes if results page loadeds successfully
                pass = true;
            }

            //take screenshot if results page failed to load
            if (pass == false)
            {
                //save screenshot with name of current failing test
                string filename = System.Reflection.MethodBase.GetCurrentMethod().Name;
                Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                image.SaveAsFile(fileDir + filename + ".png", ScreenshotImageFormat.Png);
            }
            driver.Close();
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void chromeNumberOfUnitsInputTest()
        {
            //set up test
            Boolean pass = false;
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Program program = new Program();
            program.loadLoginPage(driver);
            program.sumbitLoginDetails(driver, "qaskillschallenge@geophy.com", "qaskillschallenge@geophy.com");
            if (program.ElementXpathExists(driver, "//*[@name='number_of_units']"))
            {
                IWebElement numberOfUnitsInput = driver.FindElement(By.XPath("//*[@name='number_of_units']"));
                numberOfUnitsInput.SendKeys(Keys.ArrowUp);
                string text = numberOfUnitsInput.GetAttribute("value");

                //check test passes
                if (!(text == "1"))
                {
                    pass = false;
                }
                else
                {
                    //test passes if text box=1
                    pass = true;
                }

                //take screenshot if text box value was not 1
                if (pass == false)
                {
                    //save screenshot with name of current failing test
                    string filename = System.Reflection.MethodBase.GetCurrentMethod().Name;
                    Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                    image.SaveAsFile(fileDir + filename + ".png", ScreenshotImageFormat.Png);
                }
                driver.Close();
                Assert.IsTrue(pass);
            }
        }

        public void chromeDisableValuationButton()
        {
            //set up test
            Boolean pass = false;
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Program program = new Program();
            program.loadLoginPage(driver);
            program.populateSearch(driver);
            if (program.ElementIdExists(driver, "noi"))
            {
                IWebElement noiInput = driver.FindElement(By.Id("noi"));
                for (int i = 0; i< 7; i++)
                {
                    noiInput.SendKeys(Keys.Backspace);
                    i += 1;
                }
            }

            //check test passes
            if (program.ElementIdExists(driver, "introjsRunValuationButton"))
            {
                IWebElement submitButton = driver.FindElement(By.Id("introjsRunValuationButton"));
                //check button is disabled here
                //pass=true;
            }

            //take screenshot if valuation button is enabled
            if (pass == false)
            {
                //save screenshot with name of current failing test
                string filename = System.Reflection.MethodBase.GetCurrentMethod().Name;
                Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                image.SaveAsFile(fileDir + filename + ".png", ScreenshotImageFormat.Png);
            }
            driver.Close();
            Assert.IsTrue(pass);
        }
    }
}