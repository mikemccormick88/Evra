using System;
using EvraAutomatedTests;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class searchPageTests
    {
        string fileDir = "C:\\Testing\\Evra\\";
        Program program;
        IWebDriver driver;

        [OneTimeSetUp]
        public void Init()
        {
            driver = setUpDriver();
            program = new Program();
            program.loadLoginPage(driver);
            program.sumbitLoginDetails(driver, "qaskillschallenge@geophy.com", "qaskillschallenge@geophy.com");
            program.populateSearch(driver);
        }

        [Test]
        public void isSearchPageLoaded()
        {
            Boolean pass = false;
            //check test passes
            if (driver.Url == "https://evra.geophy.com/search")
            {
                pass = true;
            }
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            Assert.IsTrue(pass);
        }

        [Test]
        public void isAddressInputLoaded()
        {
            Boolean pass = false;
            //check test passes
            if (program.ElementIdExists(driver, "address_input"))
            {
                pass = true;
            }
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            Assert.IsTrue(pass);
        }

        [Test]
        public void isNoiInputLoaded()
        {
            Boolean pass = false;
            //check test passes
            if (program.ElementIdExists(driver, "noi"))
            {
                pass = true;
            }
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            Assert.IsTrue(pass);
        }

        [Test]
        public void isNumberOfUnitsInputLoaded()
        {
            Boolean pass = false;
            //check test passes
            if (program.ElementXpathExists(driver, "//*[@name='number_of_units']"))
            {
                pass = true;
            }
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            Assert.IsTrue(pass);
        }

        [Test]
        public void isYearBuiltLoaded()
        {
            Boolean pass = false;
            //check test passes
            if (program.ElementXpathExists(driver, "//*[@name='year_built']"))
            {
                pass = true;
            }
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            Assert.IsTrue(pass);
        }

        [Test]
        public void isOccupancyInputLoaded()
        {
            Boolean pass = false;
            //check test passes
            if (program.ElementXpathExists(driver, "//*[@name='occupancy']"))
            {
                pass = true;
            }
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            Assert.IsTrue(pass);
        }

        [Test]
        public void NumberOfUnitsInputTest()
        {
            Boolean pass = false;
            if (program.ElementXpathExists(driver, "//*[@name='number_of_units']"))
            {
                IWebElement numberOfUnitsInput = driver.FindElement(By.XPath("//*[@name='number_of_units']"));
                numberOfUnitsInput.SendKeys(Keys.ArrowUp);
                string text = numberOfUnitsInput.GetAttribute("value");

                //check test passes
                if (text == "201")
                {
                    //test passes if text box=1
                    pass = true;
                }
                else
                {
                    pass = false;
                }

                //take screenshot if text box value was not 1
                if (pass == false)
                {
                    //save screenshot with name of failing test if test fails
                    program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
                }
                Assert.IsTrue(pass);
            }
        }

        [Test]
        public void DisableSearchButtonWithoutYearInput()
        {
            Boolean pass = false;
            //set up test
            IWebElement yearbuilt = driver.FindElement(By.Name("year_built"));
            yearbuilt.SendKeys(Keys.Backspace);
            yearbuilt.SendKeys(Keys.Backspace);
            yearbuilt.SendKeys(Keys.Backspace);
            yearbuilt.SendKeys(Keys.Backspace);
            IWebElement button = driver.FindElement(By.Id("introjsRunValuationButton"));

            //check test passes
            if (button.GetAttribute("class") == "button w-full button--primary button--disabled")
            {
                //test passes if search button is disabled
                pass = true;
            }

            //take screenshot if search button is enabled
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            Assert.IsTrue(pass);
        }

        [OneTimeTearDown]
        public void Close()
        {
            driver.Close();
        }

        public IWebDriver setUpDriver()
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return chromeDriver;
            //IWebDriver firefoxDriver = new FirefoxDriver();
            //InternetExplorerOptions ieoptions = new InternetExplorerOptions();
            //ieoptions.IgnoreZoomLevel = true;
            //ieoptions.EnsureCleanSession = true;
            //IWebDriver ieDriver = new InternetExplorerDriver(ieoptions);
            //ieDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //return ieDriver;
        }
    }
}
