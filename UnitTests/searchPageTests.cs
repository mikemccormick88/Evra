using System;
using EvraAutomatedTests;
using OpenQA.Selenium;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class searchPageTests
    {
        Program program;
        IWebDriver driver;

        [OneTimeSetUp]
        public void Init()
        {
            program = new Program();
            driver = program.getDriver("Chrome", 20);
            program.loadLoginPage(driver);
            program.sumbitLoginDetails(driver, "qaskillschallenge@geophy.com", "qaskillschallenge@geophy.com");
            program.populateSearch(driver);
        }

        [Test]
        public void searchPageLoaded()
        {
            Boolean pass = false;
            //check test passes
            if (driver.Url == "https://evra.geophy.com/search")
            {
                pass = true;
            }
            //take screenshot if search page failed to load
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            Assert.IsTrue(pass);
        }

        [Test]
        public void addressInputLoaded()
        {
            Boolean pass = false;
            //check test passes
            if (program.ElementExists(driver, "Id", "address_input"))
            {
                pass = true;
            }
            //take screenshot if address input failed to load
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            Assert.IsTrue(pass);
        }

        [Test]
        public void noiInputLoaded()
        {
            Boolean pass = false;
            //check test passes
            if (program.ElementExists(driver, "Id", "noi"))
            {
                pass = true;
            }
            //take screenshot if noi input failed to load
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            Assert.IsTrue(pass);
        }

        [Test]
        public void numberOfUnitsInputLoaded()
        {
            Boolean pass = false;
            //check test passes
            if (program.ElementExists(driver, "XPath", "//*[@name='number_of_units']"))
            {
                pass = true;
            }
            //take screenshot if number of units input failed to load
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            Assert.IsTrue(pass);
        }

        [Test]
        public void yearBuiltInputLoaded()
        {
            Boolean pass = false;
            //check test passes
            if (program.ElementExists(driver, "XPath", "//*[@name='year_built']"))
            {
                pass = true;
            }
            //take screenshot if year built input failed to load
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            Assert.IsTrue(pass);
        }

        [Test]
        public void occupancyInputLoaded()
        {
            Boolean pass = false;
            //check test passes
            if (program.ElementExists(driver, "XPath", "//*[@name='occupancy']"))
            {
                pass = true;
            }
            //take screenshot if occupancy input failed to load
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            Assert.IsTrue(pass);
        }

        [Test]
        public void numberOfUnitsInputTest()
        {
            Boolean pass = false;
            if (program.ElementExists(driver, "XPath", "//*[@name='number_of_units']"))
            {
                //use the up arrow key to increment 200 by 1 (number of units is set to 200 in test setup)
                IWebElement numberOfUnitsInput = driver.FindElement(By.XPath("//*[@name='number_of_units']"));
                numberOfUnitsInput.SendKeys(Keys.ArrowUp);
                string text = numberOfUnitsInput.GetAttribute("value");

                //check test passes
                if (text == "201")
                {
                    //test passes if text box=201
                    pass = true;
                }
                else
                {
                    pass = false;
                }
                //take screenshot if text box value was not 201
                if (pass == false)
                {
                    //save screenshot with name of failing test if test fails
                    program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
                }
                Assert.IsTrue(pass);
            }
        }

        [Test]
        public void disableSearchButtonWithoutYearInput()
        {
            Boolean pass = false;
            if (program.ElementExists(driver, "Name", "year_built"))
            {
                //delete text 2000 from the year built field
                if (program.ElementExists(driver, "Name", "year_built"))
                {
                    IWebElement yearbuilt = driver.FindElement(By.Name("year_built"));
                    yearbuilt.SendKeys(Keys.Backspace + Keys.Backspace + Keys.Backspace + Keys.Backspace);
                    if (program.ElementExists(driver, "Id", "introjsRunValuationButton"))
                    {
                        IWebElement button = driver.FindElement(By.Id("introjsRunValuationButton"));
                        //check test passes
                        if (button.GetAttribute("class") == "button w-full button--primary button--disabled")
                        {
                            //test passes if run valuation button is disabled
                            pass = true;
                        }
                    }
                }
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
    }
}
